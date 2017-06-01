using ChromaSDK.ChromaPackage.Model;
using RazerSDK.RazerPackage.Model;
using RazerSDKDelete.RazerDeletePackage.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using ChromaApi = ChromaSDK.Api.DefaultApi;
using ChromaCustomApi = CustomChromaSDK.Api.DefaultApi;
using RazerApi = RazerSDK.Api.DefaultApi;
using RazerDeleteApi = RazerSDKDelete.Api.DefaultApi;
using CustomEffectType = CustomChromaSDK.CustomChromaPackage.Model.EffectType;
using CustomEffectInput = CustomChromaSDK.CustomChromaPackage.Model.EffectInput;
using CustomEffectInput1D = CustomChromaSDK.CustomChromaPackage.Model.EffectInput1D;
using CustomEffectResponse = CustomChromaSDK.CustomChromaPackage.Model.EffectResponse;
using Random = System.Random;

public class TestSwaggerClient : MonoBehaviour
{
    /// <summary>
    /// Colors
    /// </summary>
    const int COLOR_AQUA = 16776960;
    const int COLOR_BLUE = 16711680;
    const int COLOR_GREEN = 65280;
    const int COLOR_RED = 255;
    const int COLOR_ORANGE = 32767;
    const int COLOR_WHITE = 16777215;

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
    public Text _mTextHeartbeat;

    /// <summary>
    /// Instance of the RazerAPI
    /// </summary>
    private RazerApi _mApiRazerInstance;

    /// <summary>
    /// Instance of the RazerAPI for delete
    /// </summary>
    private RazerDeleteApi _mApiRazerDeleteInstance;

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
    private static Random _sRandom = new System.Random(123);

    /// <summary>
    /// Delegate method for setting effects
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    delegate EffectResponse SetEffectMethod(EffectInput data);

    /// <summary>
    /// Delegates method for setting custom effects
    /// </summary>
    delegate CustomEffectResponse SetCustomEffectMethod(CustomEffectInput data);
    delegate CustomEffectResponse SetCustomEffectMethod1D(CustomEffectInput1D data);

    /// <summary>
    /// Detect app shutdown
    /// </summary>
    private bool _mWaitForExit = true;

    /// <summary>
    /// Actions to run on the main thread
    /// </summary>
    private List<Action> _mMainActions = new List<Action>();

    /// <summary>
    /// UI interaction needs to execute on the main thread
    /// </summary>
    private void FixedUpdate()
    {
        if (_mMainActions.Count > 0)
        {
            Action action = _mMainActions[0];
            _mMainActions.RemoveAt(0);
            action.Invoke();
        }
    }

    /// <summary>
    /// Run on the main thread
    /// </summary>
    /// <param name="action"></param>
    void RunOnMainThread(Action action)
    {
        _mMainActions.Add(action);
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
                Debug.LogError("Failed to invoke action!");
            }
        }));
        thread.Start();
    }

    #region Helpers

    /// <summary>
    /// Get Effect: CHROMA_NONE
    /// </summary>
    /// <returns></returns>
    private static EffectInput GetEffectChromaNone()
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_NONE;
        return input;
    }

    /// <summary>
    /// Get Effect: CHROMA_STATIC
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private static EffectInput GetEffectChromaStatic(int color)
    {
        var input = new EffectInput();
        input.Effect = EffectType.CHROMA_STATIC;
        input.Param = new EffectInputParam(color);
        return input;
    }

    /// <summary>
    /// Get Effect: CHROMA_CUSTOM 1D Array
    /// </summary>
    /// <param name="maxElements"></param>
    /// <returns></returns>
    private static CustomEffectInput1D GetCustomEffectChroma(int maxElements)
    {
        var elements = new List<int?>();
        for (int i = 0; i < maxElements; ++i)
        {
            elements.Add(_sRandom.Next(16777215));
        }
        var input = new CustomEffectInput1D(CustomEffectType.CHROMA_CUSTOM, elements);
        return input;
    }

    /// <summary>
    /// Get Effect: CHROMA_CUSTOM 2D Array
    /// </summary>
    /// <param name="maxColumns"></param>
    /// <param name="maxRows"></param>
    /// <returns></returns>
    private static CustomEffectInput GetCustomEffectChroma(int maxColumns, int maxRows)
    {
        var rows = new List<List<int?>>();
        for (int i = 0; i < maxRows; ++i)
        {
            var row = new List<int?>();
            for (int j = 0; j < maxColumns; ++j)
            {
                row.Add(_sRandom.Next(16777215));
            }
            rows.Add(row);
        }
        var input = new CustomEffectInput(CustomEffectType.CHROMA_CUSTOM, rows);
        return input;
    }

    #endregion

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
            _mApiRazerDeleteInstance = new RazerDeleteApi(result.Uri);
            _mApiInstance = new ChromaApi(result.Uri);
            _mApiCustomInstance = new ChromaCustomApi(result.Uri);

            // use heartbeat to keep the REST API alive
            DoHeartbeat();
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("Exception when calling RazerApi.PostChromaSdk: {0}", e);
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
            if (null == _mApiRazerDeleteInstance)
            {
                return;
            }

            // save a reference to the delete instance
            RazerDeleteApi instance = _mApiRazerDeleteInstance;

            // clear the references
            _mApiRazerInstance = null;
            _mApiRazerDeleteInstance = null;
            _mApiInstance = null;
            _mApiCustomInstance = null;

            DeleteChromaSdkResponse result = instance.DeleteChromaSdk();
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("Exception when calling RazerApi.DeleteChromaSdk: {0}", e);
        }
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

        var results = new List<EffectResponse>();
        var methods = new List<SetEffectMethod>();
        methods.Add(_mApiInstance.PutChromaLink);
        methods.Add(_mApiInstance.PutHeadset);
        methods.Add(_mApiInstance.PutKeyboard);
        methods.Add(_mApiInstance.PutKeypad);
        methods.Add(_mApiInstance.PutMouse);
        methods.Add(_mApiInstance.PutMousepad);
        foreach (SetEffectMethod method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke(input);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to invoke: {0}", method.Method);
            }

        }
        return results;
    }

    /// <summary>
    /// Implicitly create a KeyValuePair item without all the explicit types
    /// </summary>
    /// <param name="method"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private static KeyValuePair<SetCustomEffectMethod1D, CustomEffectInput1D> CreateItem(SetCustomEffectMethod1D method, int elements)
    {
        return CreateItem(method, elements, CustomEffectType.CHROMA_CUSTOM);
    }
    private static KeyValuePair<SetCustomEffectMethod1D, CustomEffectInput1D> CreateItem(SetCustomEffectMethod1D method, int elements, CustomEffectType effectType)
    {
        var input = GetCustomEffectChroma(elements);
        input.Effect = effectType;
        return new KeyValuePair<SetCustomEffectMethod1D, CustomEffectInput1D>(method, input);
    }
    private static KeyValuePair<SetCustomEffectMethod, CustomEffectInput> CreateItem(SetCustomEffectMethod method, int columns, int rows)
    {
        return CreateItem(method, columns, rows, CustomEffectType.CHROMA_CUSTOM);
    }
    private static KeyValuePair<SetCustomEffectMethod, CustomEffectInput> CreateItem(SetCustomEffectMethod method, int columns, int rows, CustomEffectType effectType)
    {
        var input = GetCustomEffectChroma(columns, rows);
        input.Effect = effectType;
        return new KeyValuePair<SetCustomEffectMethod, CustomEffectInput>(method, input);
    }

    /// <summary>
    /// Use the API to set the CHROMA_CUSTOM effect
    /// </summary>
    List<CustomEffectResponse> SetKeyboardCustomEffect()
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The custom api instance is not set!");
            return null;
        }

        var results = new List<CustomEffectResponse>();

        #region 2D
        var items = new List<KeyValuePair<SetCustomEffectMethod, CustomEffectInput>>();
        items.Add(CreateItem(_mApiCustomInstance.PutKeyboard, 22, 6));
        items.Add(CreateItem(_mApiCustomInstance.PutKeypad, 5, 4));
        items.Add(CreateItem(_mApiCustomInstance.PutMouse, 7, 9, CustomEffectType.CHROMA_CUSTOM2));
        foreach (KeyValuePair<SetCustomEffectMethod, CustomEffectInput> item in items)
        {
            try
            {
                CustomEffectResponse result = item.Key.Invoke(item.Value);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to invoke: {0}", item.Key.Method);
            }
        }
        #endregion
        #region 1D
        var items1D = new List<KeyValuePair<SetCustomEffectMethod1D, CustomEffectInput1D>>();
        items1D.Add(CreateItem(_mApiCustomInstance.PutChromaLink, 5));
        items1D.Add(CreateItem(_mApiCustomInstance.PutHeadset, 5));
        items1D.Add(CreateItem(_mApiCustomInstance.PutMousepad, 15));
        foreach (KeyValuePair<SetCustomEffectMethod1D, CustomEffectInput1D> item in items1D)
        {
            try
            {
                CustomEffectResponse result = item.Key.Invoke(item.Value);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to invoke: {0}", item.Key.Method);
            }
        }
        #endregion
        return results;
    }

    /// <summary>
    /// Use heartbeat to keep the REST API listening after initialization,
    /// be sure to call from a thread and not the main thread
    /// </summary>
    void DoHeartbeat()
    {
        if (null != _mApiInstance)
        {
            Uri uri = new Uri(_mApiInstance.ApiClient.BasePath);
            
            RunOnMainThread(() =>
            {
                _mTextHeartbeat.text = string.Format("Monitoring Heartbeat {0}...", uri.Port);
            });

            while (_mWaitForExit &&
                null != _mApiInstance)
            {
                try
                {
                    // only one heartbeat is needed
                    // since the custom api hits the same port
                    _mApiInstance.Heartbeat();
                }
                catch (Exception)
                {
                    Debug.LogError("Failed to check heartbeat!");
                }

                // Wait for a sec
                Thread.Sleep(1000);
            }

            RunOnMainThread(() =>
            {
                _mTextHeartbeat.text = string.Format("Heartbeat {0} exited", uri.Port);
            });
            
        }
    }

    // Use this for initialization
    void OnEnable()
    {
        Debug.Log("OnEnable:");
        _mWaitForExit = true;

        RunOnThread(() =>
        {
            // start initialization
            PostChromaSdk();
        });

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
                EffectInput input = GetEffectChromaStatic(COLOR_AQUA);
                _mApiInstance.PutKeypad(input);
            });
        });

        // subscribe to ui click events
        _mButtonChromaLink.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(COLOR_WHITE);
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

        // avoid blocking the UI thread
        RunOnThread(() =>
        {
            DeleteChromaSdk();
        });
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
            DeleteChromaSdk();
        });
    }
}
