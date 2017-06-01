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
    /// Meta references to ui controls
    /// </summary>
    public Button _mButtonAllBlue;
    public Button _mButtonAllGreen;
    public Button _mButtonAllRed;
    public Button _mButtonAllOrange;
    public Button _mButtonAllWhite;
    public Button _mButtonKeyboard;
    public Button _mButtonHeadset;
    public Button _mButtonMouse;
    public Button _mButtonMousepad;
    public Button _mButtonKeypad;
    public Button _mButtonChromaLink;
    public Button _mButtonCustom;
    public Button _mButtonAllClear;
    public Button _mButtonRegister;
    public Button _mButtonUnregister;

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
    /// Delegate method for setting effects
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    delegate EffectResponse SetEffectMethod(EffectInput data);

    /// <summary>
    /// Colors
    /// </summary>
    const int COLOR_BLUE = 16711680;
    const int COLOR_GREEN = 65280;
    const int COLOR_RED = 255;
    const int COLOR_ORANGE = 32767;
    const int COLOR_WHITE = 16777215;

    /// <summary>
    /// Keep track of initialization
    /// </summary>
    private bool _mInitialized = false;

    /// <summary>
    /// Detect app shutdown
    /// </summary>
    private bool _mWaitForExit = true;

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
    void PostChromaSdk()
    {
        try
        {
            if (null != _mApiRazerInstance)
            {
                return;
            }

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
            PostChromaSdkResponse result = _mApiRazerInstance.PostChromaSdk(input);
            Debug.Log(result);

            // setup the api instances with the session uri
            _mApiInstance = new ChromaApi(result.Uri);
            _mApiCustomInstance = new ChromaCustomApi(result.Uri);

            // initialization complete
            _mInitialized = true;
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling RazerApi.PostChromaSdk: {0}", e);
        }
    }

    /// <summary>
    /// Uninitialize Chroma
    /// </summary>
    /// <returns></returns>
    void DeleteChromaSdk()
    {
        try
        {
            if (null == _mApiRazerInstance)
            {
                return;
            }

            DeleteChromaSdkResponse result = _mApiRazerInstance.DeleteChromaSdk();
            Debug.Log(result);

            // clear the references
            _mApiRazerInstance = null;
            _mApiInstance = null;
            _mApiCustomInstance = null;

            // no longer initialized
            _mInitialized = false;
        }
        catch (Exception e)
        {
            Debug.LogFormat("Exception when calling RazerApi.DeleteChromaSdk: {0}", e);
        }
    }

    /// <summary>
    /// Avoid blocking the UI thread
    /// </summary>
    /// <param name="action"></param>
    void RunOnThread(Action action)
    {
        Thread thread = new Thread(new ThreadStart(() => {
            try
            {
                action.Invoke();
            }
            catch (Exception)
            {
                Debug.Log("Failed to invoke action!");
            }
        }));
        thread.Start();
    }

    /// <summary>
    /// Get Effect: CHROMA_NONE
    /// </summary>
    /// <returns></returns>
    EffectInput GetEffectChromaNone()
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_NONE;
        return input;
    }

    /// <summary>
    /// Set effect on all devices
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    List<EffectResponse> SetEffectOnAll(EffectInput input)
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

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

    EffectInput GetEffectChromaStatic(int color)
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_STATIC;
        input.Param = new EffectInputParam(color);
        return input;
    }

    /// <summary>
    /// Use the API to set the CHROMA_CUSTOM effect
    /// </summary>
    void SetKeyboardCustomEffect()
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The custom api instance is not set!");
            return;
        }

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
    void DoHeartBeat()
    {
        Thread thread = new Thread(() =>
        {
            while (_mWaitForExit)
            {
                try
                {
                    if (null != _mApiRazerInstance)
                    {
                        // only one heartbeat is needed
                        // since the custom api hits the same port
                        _mApiInstance.Heartbeat();
                    }
                }
                catch (Exception)
                {
                    Debug.LogError("Failed to check heartbeat!");
                }

                // Wait for a sec
                Thread.Sleep(1000);
            }
        });
        thread.Start();
    }

    // Use this for initialization
    IEnumerator Start()
    {
        RunOnThread(() =>
        {
            // start initialization
            PostChromaSdk();
        });

        // wait for initialization
        while (!_mInitialized)
        {
            yield return null;
        }

        // use heartbeat to keep the REST API alive
        DoHeartBeat();

        // subscribe to ui click events
        _mButtonAllBlue.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_BLUE);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllGreen.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_GREEN);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllRed.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_RED);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllOrange.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_ORANGE);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonAllWhite.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_WHITE);
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonKeyboard.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_BLUE);
                _mApiInstance.PutKeyboard(input);
            });
        });

        // subscribe to ui click events
        _mButtonHeadset.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_GREEN);
                _mApiInstance.PutHeadset(input);
            });
        });

        // subscribe to ui click events
        _mButtonMouse.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_RED);
                _mApiInstance.PutMouse(input);
            });
        });

        // subscribe to ui click events
        _mButtonMousepad.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_ORANGE);
                _mApiInstance.PutMousepad(input);
            });
        });

        // subscribe to ui click events
        _mButtonKeypad.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_BLUE);
                _mApiInstance.PutKeypad(input);
            });
        });

        // subscribe to ui click events
        _mButtonChromaLink.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_BLUE);
                _mApiInstance.PutChromaLink(input);
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
                var input = GetEffectChromaNone();
                SetEffectOnAll(input);
            });
        });

        // subscribe to ui click events
        _mButtonRegister.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                PostChromaSdk();
            });
        });

        // subscribe to ui click events
        _mButtonUnregister.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                DeleteChromaSdk();
            });
        });

    }

    /// <summary>
    /// Stop heartbeat on disable
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("OnDisable:");
        _mWaitForExit = false;
    }

    /// <summary>
    /// Stop heartbeat on exit and clear effect
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit:");
        _mWaitForExit = false;

        // avoid blocking the UI thread
        RunOnThread(() =>
        {
            var input = GetEffectChromaNone();
            SetEffectOnAll(input);
        });
    }
}
