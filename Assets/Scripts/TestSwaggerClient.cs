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
    /// Instance of the API
    /// </summary>
    private ChromaApi _mApiInstance;

    /// <summary>
    /// Instance of the custom API
    /// </summary>
    private ChromaCustomApi _mApiCustomInstance;

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
    void InitChroma()
    {
        try
        {
            // use the default basepath to get the session
            _mApiInstance = new ChromaApi();

            var input = new BaseInput();
            input.Title = "Test";
            input.Description = "This is a REST interface test application";
            input.Author = new BaseInputAuthor();
            input.Author.Name = "Chroma Developer";
            input.Author.Contact = "www.razerzone.com";
            input.DeviceSupported = new List<string> 
            {
                "keyboard",
                "mouse",
                "headset",
                "mousepad",
                "keypad",
                "chromalink",
            };
            input.Category = "application";
            SessionResponse result = _mApiInstance.CallBase(input);
            Debug.Log(result);

            // this code should is needed because result url was blank
            result.Url = string.Format("http://localhost:{0}", result.Sessionid);

            // should have just needed to do this
            _mApiInstance = new ChromaApi(result.Url);
            _mApiCustomInstance = new ChromaCustomApi(result.Url);
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling DefaultApi.CallBase: {0}", e);
        }
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
            Debug.LogFormat("Exception when calling DefaultApi.PutKeyboardInput: {0}", e);
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
            Debug.LogFormat("Exception when calling DefaultApi.PutKeyboardInput: {0}", e);
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
    void Start()
    {
        InitChroma();

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
