using ChromaSDK.ChromaPackage.Model;
using RazerSDK.RazerPackage.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using ChromaApi = ChromaSDK.Api.DefaultApi;
using ChromaCustomApi = CustomChromaSDK.Api.DefaultApi;
using RazerApi = RazerSDK.Api.DefaultApi;
using CustomEffectType = CustomChromaSDK.CustomChromaPackage.Model.EffectType;
using CustomKeyboardInput = CustomChromaSDK.CustomChromaPackage.Model.KeyboardInput;
using Random = System.Random;

public class TestSwaggerClient : MonoBehaviour
{
    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllBlue;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllGreen;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllRed;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllOrange;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllWhite;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonCustom;

    /// <summary>
    /// Meta reference to a ui button
    /// </summary>
    public Button _mButtonAllClear;

    /// <summary>
    /// Instance of the RazerAPI
    /// </summary>
    private RazerApi _mApiRazerInstance;

    /// <summary>
    /// Instance of the API
    /// </summary>
    private ChromaApi _mApiInstance;

    /// <summary>
    /// Instance of the custom API
    /// </summary>
    private ChromaCustomApi _mApiCustomInstance;

    /// <summary>
    /// Thread safe random object
    /// </summary>
    Random _mRandom = new System.Random(123);

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
    void InitChroma()
    {
        try
        {
            // use the Razer API to get the session
            _mApiRazerInstance = new RazerApi();

            var input = new ChromaSdkInput();
            input.Title = "Test";
            input.Description = "This is a REST interface test application";
            input.Author = new ChromaSdkInputAuthor();
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
            ChromaSdkResponse result = _mApiRazerInstance.Chromasdk(input);
            Debug.Log(result);

            // setup the api instances with the session uri
            _mApiInstance = new ChromaApi(result.Uri);
            _mApiCustomInstance = new ChromaCustomApi(result.Uri);
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling RazerApi.Chromasdk: {0}", e);
        }
    }

    /// <summary>
    /// Avoid blocking the UI thread
    /// </summary>
    /// <param name="action"></param>
    void RunOnThread(Action action)
    {
        Thread thread = new Thread(new ThreadStart(() => {
            action.Invoke();
        }));
        thread.Start();
    }

    /// <summary>
    /// Get Effect: CHROMA_NONE
    /// </summary>
    /// <returns></returns>
    EffectInput GetChromaNoneEffect()
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_NONE;
        return input;
    }

    /// <summary>
    /// Delegate method for setting effects
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    delegate EffectResponse SetEffectMethod(EffectInput data);

    /// <summary>
    /// Set effect on all devices
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    List<EffectResponse> SetEffectOnAll(EffectInput input)
    {
        List<EffectResponse> results = new List<EffectResponse>();
        try
        {
            List<SetEffectMethod> methods = new List<SetEffectMethod>();
            methods.Add(_mApiInstance.PutChromaLink);
            methods.Add(_mApiInstance.PutHeadset);
            methods.Add(_mApiInstance.PutKeyboard);
            methods.Add(_mApiInstance.PutKeypad);
            methods.Add(_mApiInstance.PutMouse);
            methods.Add(_mApiInstance.PutMousepad);
            foreach (SetEffectMethod method in methods)
            {
                EffectResponse result = method.Invoke(input);
                Debug.Log(result);
                results.Add(result);
            }
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when setting affect on all devices: {0}", e);
        }
        return results;

    }

    EffectInput GetStaticColor(int color)
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_STATIC;
        input.Param = new EffectInputParam(color);
        return input;
    }

    /// <summary>
    /// Use the API to set the CHROMA_STATIC effect
    /// </summary>
    /// <param name="color"></param>
    void SetStaticColor(int color)
    {
        try
        {
            var input = GetStaticColor(color);
            EffectResponse result = _mApiInstance.PutKeyboard(input);
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling ChromaApi.PutKeyboard: {0}", e);
        }
    }

    /// <summary>
    /// Use the API to set the CHROMA_CUSTOM effect
    /// </summary>
    void SetKeyboardCustomEffect()
    {
        var rows = new List<List<int?>>();
        for (int i = 0; i < 6; ++i)
        {
            var row = new List<int?>();
            for (int j = 0; j < 22; ++j)
            {
                row.Add(_mRandom.Next(16777215));
            }
            rows.Add(row);
        }
        try
        {
            var input = new CustomKeyboardInput(CustomEffectType.CHROMA_CUSTOM, rows);
            _mApiCustomInstance.PutKeyboard(input);
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling ChromaCustomApi.PutKeyboard: {0}", e);
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

        // use heartbeat to keep the REST API alive
        StartCoroutine(HeartBeat());

        // subscribe to ui click events
        _mButtonAllBlue.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetStaticColor(16711680);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllGreen.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetStaticColor(65280);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllRed.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetStaticColor(255);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllOrange.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetStaticColor(65535);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllWhite.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetStaticColor(16777215);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonCustom.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetKeyboardCustomEffect();
            });
        });

        // subscribe to ui click events
        _mButtonAllClear.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                var input = GetChromaNoneEffect();
                SetEffectOnAll(input);
            });
        });

    }

    /// <summary>
    /// Clear the active effect on quit
    /// </summary>
    private void OnApplicationQuit()
    {
        // avoid blocking the UI thread
        RunOnThread(() =>
        {
            var input = GetChromaNoneEffect();
            SetEffectOnAll(input);
        });
    }
}
