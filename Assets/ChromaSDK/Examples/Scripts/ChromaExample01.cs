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
using RazerApi = RazerSDK.Api.DefaultApi;
using RazerDeleteApi = RazerSDKDelete.Api.DefaultApi;
using Random = System.Random;

public class ChromaExample01 : MonoBehaviour
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
    public Button _mButtonAllRandom;
    public Button _mButtonAllBlue;
    public Button _mButtonAllGreen;
    public Button _mButtonAllRed;
    public Button _mButtonAllOrange;
    public Button _mButtonAllAqua;
    public Button _mButtonAllWhite;
    public Button _mButtonAllClear;
    public Button _mButtonKeyboard;
    public Button _mButtonHeadset;
    public Button _mButtonMouse;
    public Button _mButtonMousepad;
    public Button _mButtonKeypad;
    public Button _mButtonChromaLink;
    public Button _mButtonStart;
    public Button _mButtonEnd;
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
    /// Thread safe random object
    /// </summary>
    private static Random _sRandom = new System.Random(123);

    /// <summary>
    /// Delegate method for clearing effects
    /// </summary>
    /// <returns></returns>
    delegate EffectResponse MethodEffectNone();

    /// <summary>
    /// Delegate method for setting static color effects
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    delegate EffectResponse MethodEffectStatic(int? color);

    /// <summary>
    /// Delegate method for setting effects
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    delegate EffectResponse MethodPutEffect(EffectInput data);

    /// <summary>
    /// Delegate method for setting custom effects for one-dimensional arrays
    /// </summary>
    /// <param name="colors"></param>
    /// <returns></returns>
    delegate EffectResponse MethodPutCustomArray1d(EffectArray1dInput data);

    /// <summary>
    /// Delegate method for setting custom effects for two-dimensional arrays
    /// </summary>
    /// <param name="colors"></param>
    /// <returns></returns>
    delegate EffectResponse MethodPutCustomArray2d(EffectArray2dInput data);

    /// <summary>
    /// Delegate method for setting custom effects for one-dimensional arrays
    /// </summary>
    /// <param name="colors"></param>
    /// <returns></returns>
    delegate EffectResponseId MethodPostCustomArray1d(EffectArray1dInput data);

    /// <summary>
    /// Delegate method for setting custom effects for two-dimensional arrays
    /// </summary>
    /// <param name="colors"></param>
    /// <returns></returns>
    delegate EffectResponseId MethodPostCustomArray2d(EffectArray2dInput data);

    /// <summary>
    /// Detect app shutdown
    /// </summary>
    private bool _mWaitForExit = true;

    /// <summary>
    /// Keep animation playing
    /// </summary>
    private bool _mPlayAnimation = false;

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
    private static EffectArray1dInput GetEffectChromaCustom(int maxElements)
    {
        var elements = new EffectArray1dInput();
        for (int i = 0; i < maxElements; ++i)
        {
            elements.Add(_sRandom.Next(16777215));
        }
        return elements;
    }

    /// <summary>
    /// Get Effect: CHROMA_CUSTOM 2D Array
    /// </summary>
    /// <param name="maxColumns"></param>
    /// <param name="maxRows"></param>
    /// <returns></returns>
    private static EffectArray2dInput GetEffectChromaCustom(int maxColumns, int maxRows)
    {
        var rows = new EffectArray2dInput();
        for (int i = 0; i < maxRows; ++i)
        {
            var row = new List<int>();
            for (int j = 0; j < maxColumns; ++j)
            {
                row.Add(_sRandom.Next(16777215));
            }
            rows.Add(row);
        }
        return rows;
    }

    #endregion

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
    void PostChromaSdk()
    {
        if (!_mWaitForExit)
        {
            return;
        }

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

            Debug.Log("Initializing...");
            PostChromaSdkResponse result = _mApiRazerInstance.PostChromaSdk(input);
            Debug.Log(result);

            // setup the api instances with the session uri
            _mApiRazerDeleteInstance = new RazerDeleteApi(result.Uri);
            _mApiInstance = new ChromaApi(result.Uri);

            Debug.Log("Init complete.");

            // use heartbeat to keep the REST API alive
            DoHeartbeat();
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("Exception when calling RazerApi.PostChromaSdk: {0}", e);
            _mApiRazerInstance = null;

            // retry
            StartCoroutine(Initialize());
        }
    }

    /// <summary>
    /// Initialize after a delay
    /// </summary>
    /// <returns></returns>
    IEnumerator Initialize()
    {
        // wait to initialize in case recompile just shutdown
        RunOnMainThread(() =>
        {
            _mTextHeartbeat.text = "Waiting to initialize ChromaSDK...";
        });

        // delay
        yield return new WaitForSeconds(2);

        RunOnThread(() =>
        {
            // start initialization
            PostChromaSdk();
        });
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

            DeleteChromaSdkResponse result = instance.DeleteChromaSdk();
            Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("Exception when calling RazerApi.DeleteChromaSdk: {0}", e);
        }
    }

    /// <summary>
    /// Clear effect on all devices using PUT
    /// </summary>
    /// <returns></returns>
    List<EffectResponse> SetEffectNoneOnAll()
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();
        var methods = new List<MethodEffectNone>();
        methods.Add(_mApiInstance.PutChromaLinkNone);
        methods.Add(_mApiInstance.PutHeadsetNone);
        methods.Add(_mApiInstance.PutKeyboardNone);
        methods.Add(_mApiInstance.PutKeypadNone);
        methods.Add(_mApiInstance.PutMouseNone);
        methods.Add(_mApiInstance.PutMousepadNone);
        foreach (MethodEffectNone method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke();
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to set none effect: {0}", method.Method);
            }

        }
        return results;
    }

    /// <summary>
    /// Set static effect on all devices using PUT
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    List<EffectResponse> SetEffectStaticOnAll(int color)
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();
        var methods = new List<MethodEffectStatic>();
        methods.Add(_mApiInstance.PutChromaLinkStatic);
        methods.Add(_mApiInstance.PutHeadsetStatic);
        methods.Add(_mApiInstance.PutKeyboardStatic);
        methods.Add(_mApiInstance.PutKeypadStatic);
        methods.Add(_mApiInstance.PutMouseStatic);
        methods.Add(_mApiInstance.PutMousepadStatic);
        foreach (MethodEffectStatic method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke(color);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to set static effect: {0}", method.Method);
            }

        }
        return results;
    }

    /// <summary>
    /// Set effect on all devices using PUT
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
        var methods = new List<MethodPutEffect>();
        methods.Add(_mApiInstance.PutChromaLink);
        methods.Add(_mApiInstance.PutHeadset);
        methods.Add(_mApiInstance.PutKeyboard);
        methods.Add(_mApiInstance.PutKeypad);
        methods.Add(_mApiInstance.PutMouse);
        methods.Add(_mApiInstance.PutMousepad);
        foreach (MethodPutEffect method in methods)
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
    /// Container for custom method and data with one-dimension using PUT
    /// </summary>
    class PutAnimationData1D
    {
        public MethodPutCustomArray1d Method { get; set; }
        public EffectArray1dInput Data { get; set; }
        public PutAnimationData1D(MethodPutCustomArray1d method, EffectArray1dInput data)
        {
            Method = method;
            Data = data;
        }
    }

    /// <summary>
    /// Container for custom method and data with two-dimensions using PUT
    /// </summary>
    class PutAnimationData2D
    {
        public MethodPutCustomArray2d Method { get; set; }
        public EffectArray2dInput Data { get; set; }
        public PutAnimationData2D(MethodPutCustomArray2d method, EffectArray2dInput data)
        {
            Method = method;
            Data = data;
        }
    }

    /// <summary>
    /// Use the API to set the CHROMA_CUSTOM effect
    /// </summary>
    List<EffectResponse> SetKeyboardCustomEffect()
    {
        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The custom api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();

        #region 2D
        var items2d = new List<PutAnimationData2D>();
        items2d.Add(new PutAnimationData2D(_mApiInstance.PutKeyboardCustom, GetEffectChromaCustom(22, 6)));
        items2d.Add(new PutAnimationData2D(_mApiInstance.PutKeypadCustom, GetEffectChromaCustom(5, 4)));
        items2d.Add(new PutAnimationData2D(_mApiInstance.PutMouseCustom, GetEffectChromaCustom(7, 9)));
        foreach (PutAnimationData2D item in items2d)
        {
            try
            {
                EffectResponse result = item.Method.Invoke(item.Data);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to invoke: {0}", item.Method);
            }
        }
        #endregion
        #region 1D
        var items1d = new List<PutAnimationData1D>();
        items1d.Add(new PutAnimationData1D(_mApiInstance.PutChromaLinkCustom, GetEffectChromaCustom(5)));
        items1d.Add(new PutAnimationData1D(_mApiInstance.PutHeadsetCustom, GetEffectChromaCustom(5)));
        items1d.Add(new PutAnimationData1D(_mApiInstance.PutMousepadCustom, GetEffectChromaCustom(15)));
        foreach (PutAnimationData1D item in items1d)
        {
            try
            {
                EffectResponse result = item.Method.Invoke(item.Data);
                Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogErrorFormat("Failed to invoke: {0}", item.Method);
            }
        }
        #endregion
        return results;
    }

    /// <summary>
    /// Container for custom method and data with one-dimension using POST
    /// </summary>
    class PostAnimationData1D
    {
        public MethodPostCustomArray1d Method { get; set; }
        public EffectArray1dInput Data { get; set; }
        public PostAnimationData1D(MethodPostCustomArray1d method, EffectArray1dInput data)
        {
            Method = method;
            Data = data;
        }
    }

    /// <summary>
    /// Container for custom method and data with two-dimensions using POST
    /// </summary>
    class PostAnimationData2D
    {
        public MethodPostCustomArray2d Method { get; set; }
        public EffectArray2dInput Data { get; set; }
        public PostAnimationData2D(MethodPostCustomArray2d method, EffectArray2dInput data)
        {
            Method = method;
            Data = data;
        }
    }

    /// <summary>
    /// Create and play an animation
    /// </summary>
    void DoAnimation()
    {
        if (_mPlayAnimation)
        {
            return;
        }

        if (null == _mApiInstance)
        {
            Debug.LogError("Need to register Chroma Server. The custom api instance is not set!");
            return;
        }

        _mPlayAnimation = true;

        // build custom effects

        //create 10 frames
        List<List<string>> frames = new List<List<string>>();

        const int FRAME_COUNT = 10;
        for (int i = 0; i < FRAME_COUNT; ++i)
        {
            // list of effect ids
            List<string> effects = new List<string>();

            #region 2D
            var items2d = new List<PostAnimationData2D>();
            items2d.Add(new PostAnimationData2D(_mApiInstance.PostKeyboardCustom, GetEffectChromaCustom(22, 6)));
            items2d.Add(new PostAnimationData2D(_mApiInstance.PostKeypadCustom, GetEffectChromaCustom(5, 4)));
            items2d.Add(new PostAnimationData2D(_mApiInstance.PostMouseCustom, GetEffectChromaCustom(7, 9)));
            foreach (PostAnimationData2D item in items2d)
            {
                try
                {
                    EffectResponseId result = item.Method.Invoke(item.Data);
                    Debug.Log(result);
                    effects.Add(result.Id);
                }
                catch (Exception)
                {
                    Debug.LogErrorFormat("Failed to invoke: {0}", item.Method);
                }
            }
            #endregion
            #region 1D
            var items1d = new List<PostAnimationData1D>();
            items1d.Add(new PostAnimationData1D(_mApiInstance.PostChromaLinkCustom, GetEffectChromaCustom(5)));
            items1d.Add(new PostAnimationData1D(_mApiInstance.PostHeadsetCustom, GetEffectChromaCustom(5)));
            items1d.Add(new PostAnimationData1D(_mApiInstance.PostMousepadCustom, GetEffectChromaCustom(15)));
            foreach (PostAnimationData1D item in items1d)
            {
                try
                {
                    EffectResponseId result = item.Method.Invoke(item.Data);
                    Debug.Log(result);
                    effects.Add(result.Id);
                }
                catch (Exception)
                {
                    Debug.LogErrorFormat("Failed to invoke: {0}", item.Method);
                }
            }
            #endregion

            // add the frame
            frames.Add(effects);
        }

        Debug.Log("Animation looping...");

        int index = 0;
        while (_mWaitForExit &&
            _mPlayAnimation &&
            frames.Count > 0 &&
            null != _mApiInstance)
        {
            List<string> effects = frames[index];

            try
            {
                var input = new EffectIdentifierInput(null, effects);
                EffectIdentifierResponse result = _mApiInstance.PutEffect(input);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Failed to put effects: {0}", e);
            }

            index = (index + 1) % frames.Count;

            // loop animation frames
            Thread.Sleep(100);
        }

        Debug.Log("Animation complete.");

        // clean up effects single item, first frame
        if (_mWaitForExit &&
            frames.Count > 0)
        {
            List<string> effects = frames[0];
            frames.RemoveAt(0);
            foreach (string id in effects)
            {
                try
                {
                    var input = new EffectIdentifierInput(id, null);
                    EffectIdentifierResponse result = _mApiInstance.RemoveEffect(input);
                    Debug.Log(result);
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("Failed to delete effect by id: {0}", e);
                }
            }
        }
        
        // clean up effects by array
        while (_mWaitForExit &&
            frames.Count > 0)
        {
            List<string> effects = frames[0];
            frames.RemoveAt(0);
            try
            {
                var input = new EffectIdentifierInput(null, effects);
                EffectIdentifierResponse result = _mApiInstance.RemoveEffect(input);
                Debug.Log(result);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Failed to delete effects: {0}", e);
            }
        }

        Debug.Log("Animation cleaned.");
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
    void Start()
    {
        Debug.Log("Start:");
    }

    /// <summary>
    /// OnEnable is invoked on play, or while playing after compile
    /// </summary>
    void OnEnable()
    {
        Debug.Log("OnEnable:");
        _mWaitForExit = true;

        // initialize
        StartCoroutine(Initialize());

        // subscribe to ui click events
        _mButtonAllBlue.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_BLUE);
            });
        });

        // subscribe to ui click events
        _mButtonAllGreen.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_GREEN);
            });
        });

        // subscribe to ui click events
        _mButtonAllRed.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_RED);
            });
        });

        // subscribe to ui click events
        _mButtonAllOrange.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_ORANGE);
            });
        });

        // subscribe to ui click events
        _mButtonAllAqua.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_AQUA);
            });
        });

        // subscribe to ui click events
        _mButtonAllWhite.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectStaticOnAll(COLOR_WHITE);
            });
        });

        // subscribe to ui click events
        _mButtonAllRandom.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetKeyboardCustomEffect();
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
        _mButtonStart.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                DoAnimation();
            });
        });

        // subscribe to ui click events
        _mButtonEnd.onClick.AddListener(() =>
        {
            _mPlayAnimation = false;
        });

        // subscribe to ui click events
        _mButtonAllClear.onClick.AddListener(() =>
        {
            // avoid blocking the UI thread
            RunOnThread(() =>
            {
                SetEffectNoneOnAll();
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
    /// Stop heartbeat on disable, on disable is called on stop, or if compiling
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
    /// Stop heartbeat on exit and clear effect, on quit happens on stop
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
