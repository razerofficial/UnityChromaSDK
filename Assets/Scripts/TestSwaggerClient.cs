﻿using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestSwaggerClient : MonoBehaviour
{

    public TextAsset _mJsonData;

    public Button _mButtonRed;

    public Button _mButtonGreen;

    public Button _mButtonBlue;

    public Button _mButtonClear;

    private int _mPort = 80;

    private DefaultApi _mApiInstance;

    class SessionData
    {
        public int sessionid;
        public string uri;
    }

    int ParsePort(string jsonData)
    {
        //Debug.Log(jsonData);

        SessionData session = JsonUtility.FromJson<SessionData>(jsonData);
        System.Uri uri = new System.Uri(session.uri);
        //Debug.Log(uri.Port);

        return uri.Port;
    }

    IEnumerator InitChroma()
    {
        string postUrl = string.Format("http://localhost:{0}/razer/chromasdk", _mPort);

        var postHeader = new Dictionary<string, string>();

        string jsonData = _mJsonData.text;
        //Debug.Log("jsonString: " + jsonData);

        postHeader.Add("Content-Type", "application/json");
        postHeader.Add("Content-Length", jsonData.Length.ToString());

        var request = new WWW(postUrl, UTF8Encoding.UTF8.GetBytes(jsonData), postHeader);

        yield return request;

        _mPort = ParsePort(request.text);

        request.Dispose();
    }

    void ClearEffect()
    {
        try
        {
            var input = new KeyboardInput();
            input.Effect = "CHROMA_NONE";
            InlineResponseDefault result = _mApiInstance.PutKeyboard(input);
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.Log("Exception when calling DefaultApi.PutKeyboardInput: " + e.Message);
        }
    }

    void SetStaticColor(int color)
    {
        try
        {
            var input = new KeyboardInput();
            input.Effect = "CHROMA_STATIC";
            input.Param = new KeyboardParam();
            input.Param.Color = color;
            InlineResponseDefault result = _mApiInstance.PutKeyboard(input);
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.Log("Exception when calling DefaultApi.PutKeyboardInput: " + e.Message);
        }
    }

    IEnumerator HeartBeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _mApiInstance.Heartbeat();
        }
    }

    // Use this for initialization
    IEnumerator Start()
    {
        yield return InitChroma();

        Debug.LogFormat("Ready for Port: {0}!", _mPort);

        string url = string.Format("http://localhost:{0}/chromasdk", _mPort);
        _mApiInstance = new DefaultApi(url);
        Debug.Log(_mApiInstance.ApiClient.BasePath);

        StartCoroutine(HeartBeat());

        _mButtonRed.onClick.AddListener(() =>
        {
            SetStaticColor(255);
        });

        _mButtonGreen.onClick.AddListener(() =>
        {
            SetStaticColor(65280);
        });

        _mButtonBlue.onClick.AddListener(() =>
        {
            SetStaticColor(16711680);
        });

        _mButtonClear.onClick.AddListener(() =>
        {
            ClearEffect();
        });

    }

    private void OnApplicationQuit()
    {
        ClearEffect();
    }
}
