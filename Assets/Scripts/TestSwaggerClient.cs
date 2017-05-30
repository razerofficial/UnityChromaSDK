using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using ChromaApi = ChromaSDK.Api.DefaultApi;
using ChromaCustomApi = CustomChromaSDK.Api.DefaultApi;
using CustomEffectType = CustomChromaSDK.CustomChromaPackage.Model.EffectType;
using CustomKeyboardInput = CustomChromaSDK.CustomChromaPackage.Model.KeyboardInput;

public class TestSwaggerClient : MonoBehaviour
{
    /// <summary>
    /// Meta reference to the app json information
    /// </summary>
    public TextAsset _mJsonData;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonRed;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonGreen;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonBlue;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonCustom;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonClear;

    /// <summary>
    /// Default REST port
    /// </summary>
    private int _mPort = 80;

    /// <summary>
    /// Instance of the API
    /// </summary>
    private ChromaApi _mApiInstance;

    /// <summary>
    /// Instance of the custom API
    /// </summary>
    private ChromaCustomApi _mApiCustomInstance;

    /// <summary>
    /// Structure of session data
    /// </summary>
    class SessionData
    {
        public int sessionid;
        public string uri;
    }

    /// <summary>
    /// Parse the port from the session response
    /// </summary>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    int ParsePort(string jsonData)
    {
        //Debug.Log(jsonData);

        SessionData session = JsonUtility.FromJson<SessionData>(jsonData);
        System.Uri uri = new System.Uri(session.uri);
        //Debug.Log(uri.Port);

        return uri.Port;
    }

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Use API to set the CHROMA_NONE effect
    /// </summary>
    void ClearEffect()
    {
        try
        {
            var input = new KeyboardInput();
            input.Effect = EffectType.CHROMA_NONE;
            KeyboardResponse result = _mApiInstance.PutKeyboard(input);
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.Log("Exception when calling DefaultApi.PutKeyboardInput: " + e.Message);
        }
    }

    /// <summary>
    /// Use the API to set the CHROMA_STATIC effect
    /// </summary>
    /// <param name="color"></param>
    void SetStaticColor(int color)
    {
        try
        {
            var input = new KeyboardInput();
            input.Effect = EffectType.CHROMA_STATIC;
            input.Param = new KeyboardInputParam(color);
            KeyboardResponse result = _mApiInstance.PutKeyboard(input);
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.Log("Exception when calling DefaultApi.PutKeyboardInput: " + e.Message);
        }
    }

    /// <summary>
    /// Use heartbeat to keep the REST API listening after initialization
    /// </summary>
    /// <returns></returns>
    IEnumerator HeartBeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            // only one heartbeat is needed
            // since the custom api hits the same port
            _mApiInstance.Heartbeat();
        }
    }

    // Use this for initialization
    IEnumerator Start()
    {
        yield return InitChroma();

        Debug.LogFormat("Ready for Port: {0}!", _mPort);

        string url = string.Format("http://localhost:{0}/chromasdk", _mPort);
        _mApiInstance = new ChromaApi(url);
        _mApiCustomInstance = new ChromaCustomApi(url);
        Debug.Log(_mApiInstance.ApiClient.BasePath);

        // use heartbeat to keep the REST API alive
        StartCoroutine(HeartBeat());

        // subscribe to ui click events
        _mButtonRed.onClick.AddListener(() =>
        {
            SetStaticColor(255);
        });

        // subscribe to ui click events
        _mButtonGreen.onClick.AddListener(() =>
        {
            SetStaticColor(65280);
        });

        // subscribe to ui click events
        _mButtonBlue.onClick.AddListener(() =>
        {
            SetStaticColor(16711680);
        });

        // subscribe to ui click events
        _mButtonCustom.onClick.AddListener(() =>
        {
            var rows = new List<List<int?>>();
            for (int i = 0; i < 6; ++i)
            {
                var row = new List<int?>();
                for (int j = 0; j < 22; ++j)
                {
                    row.Add(UnityEngine.Random.Range(0, 16777215));
                }
                rows.Add(row);
            }
            var input = new CustomKeyboardInput(CustomEffectType.CHROMA_CUSTOM, rows);
            _mApiCustomInstance.PutKeyboard(input);
        });

        // subscribe to ui click events
        _mButtonClear.onClick.AddListener(() =>
        {
            ClearEffect();
        });

    }

    /// <summary>
    /// Clear the active effect on quit
    /// </summary>
    private void OnApplicationQuit()
    {
        ClearEffect();
    }
}
