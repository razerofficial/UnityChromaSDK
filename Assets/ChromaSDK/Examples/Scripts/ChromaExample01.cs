// Access to Chroma data structures
using ChromaSDK.ChromaPackage.Model;
// Access to the Chroma API
using ChromaSDK.Api;
// Access to the Session data structures
using RazerSDK.ChromaPackage.Model;
// Access to the Session API
using RazerSDK.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using Random = System.Random;

public class ChromaExample01 : MonoBehaviour
{
    /// <summary>
    /// Meta references to ui controls
    /// </summary>
    private string _mTextHeartbeat;

    /// <summary>
    /// Instance of the RazerAPI
    /// </summary>
    private RazerApi _mApiRazerInstance;

    /// <summary>
    /// Instance of the API
    /// </summary>
    private ChromaApi _mApiChromaInstance;

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
            input.Title = "UnityPlugin";
            input.Description = "This is a REST interface Unity client";
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
            //Debug.Log(result);

            // setup the api instance with the session uri
            _mApiChromaInstance = new ChromaApi(result.Uri);

            Debug.Log("Init complete.");

            // use heartbeat to keep the REST API alive
            DoHeartbeat();
        }
        catch (Exception e)
        {
            Debug.LogError(string.Format("Exception when calling RazerApi.PostChromaSdk: {0}", e));
            _mApiRazerInstance = null;

            // retry
            StartCoroutine(Initialize());
        }
    }

    /// <summary>
    /// Set the heartbeat text
    /// </summary>
    /// <param name="text"></param>
    void SetHeartbeatText(string text)
    {
        _mTextHeartbeat = text;
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
            SetHeartbeatText("Waiting to initialize ChromaSDK...");
        });

        // delay
        yield return new WaitForSeconds(2);

        ChromaUtils.RunOnThread(() =>
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
            if (null == _mApiChromaInstance)
            {
                return;
            }

            // destroy the Chroma session
            DeleteChromaSdkResponse result = _mApiChromaInstance.DeleteChromaSdk();
            //Debug.Log(result);
        }
        catch (Exception e)
        {
            Debug.LogError(string.Format("Exception when calling RazerApi.DeleteChromaSdk: {0}", e));
        }
        finally
        {
            // clear the references
            _mApiRazerInstance = null;
            _mApiChromaInstance = null;
        }
    }

    /// <summary>
    /// Clear effect on all devices using PUT
    /// </summary>
    /// <returns></returns>
    List<EffectResponse> SetEffectNoneOnAll()
    {
        if (null == _mApiChromaInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();
        var methods = new List<MethodEffectNone>();
        methods.Add(_mApiChromaInstance.PutChromaLinkNone);
        methods.Add(_mApiChromaInstance.PutHeadsetNone);
        methods.Add(_mApiChromaInstance.PutKeyboardNone);
        methods.Add(_mApiChromaInstance.PutKeypadNone);
        methods.Add(_mApiChromaInstance.PutMouseNone);
        methods.Add(_mApiChromaInstance.PutMousepadNone);
        foreach (MethodEffectNone method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke();
                //Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogError(string.Format("Failed to set none effect: {0}", method.Method));
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
        if (null == _mApiChromaInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();
        var methods = new List<MethodEffectStatic>();
        methods.Add(_mApiChromaInstance.PutChromaLinkStatic);
        methods.Add(_mApiChromaInstance.PutHeadsetStatic);
        methods.Add(_mApiChromaInstance.PutKeyboardStatic);
        methods.Add(_mApiChromaInstance.PutKeypadStatic);
        methods.Add(_mApiChromaInstance.PutMouseStatic);
        methods.Add(_mApiChromaInstance.PutMousepadStatic);
        foreach (MethodEffectStatic method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke(color);
                //Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogError(string.Format("Failed to set static effect: {0}", method.Method));
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
        if (null == _mApiChromaInstance)
        {
            Debug.LogError("Need to register Chroma Server. The api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();
        var methods = new List<MethodPutEffect>();
        methods.Add(_mApiChromaInstance.PutChromaLink);
        methods.Add(_mApiChromaInstance.PutHeadset);
        methods.Add(_mApiChromaInstance.PutKeyboard);
        methods.Add(_mApiChromaInstance.PutKeypad);
        methods.Add(_mApiChromaInstance.PutMouse);
        methods.Add(_mApiChromaInstance.PutMousepad);
        foreach (MethodPutEffect method in methods)
        {
            try
            {
                EffectResponse result = method.Invoke(input);
                //Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogError(string.Format("Failed to invoke: {0}", method.Method));
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
        if (null == _mApiChromaInstance)
        {
            Debug.LogError("Need to register Chroma Server. The custom api instance is not set!");
            return null;
        }

        var results = new List<EffectResponse>();

#region 2D
        var items2d = new List<PutAnimationData2D>();
        items2d.Add(new PutAnimationData2D(_mApiChromaInstance.PutKeyboardCustom, GetEffectChromaCustom(22, 6)));
        items2d.Add(new PutAnimationData2D(_mApiChromaInstance.PutKeypadCustom, GetEffectChromaCustom(5, 4)));
        items2d.Add(new PutAnimationData2D(_mApiChromaInstance.PutMouseCustom, GetEffectChromaCustom(7, 9)));
        foreach (PutAnimationData2D item in items2d)
        {
            try
            {
                EffectResponse result = item.Method.Invoke(item.Data);
                //Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogError(string.Format("Failed to invoke: {0}", item.Method));
            }
        }
#endregion
#region 1D
        var items1d = new List<PutAnimationData1D>();
        items1d.Add(new PutAnimationData1D(_mApiChromaInstance.PutChromaLinkCustom, GetEffectChromaCustom(5)));
        items1d.Add(new PutAnimationData1D(_mApiChromaInstance.PutHeadsetCustom, GetEffectChromaCustom(5)));
        items1d.Add(new PutAnimationData1D(_mApiChromaInstance.PutMousepadCustom, GetEffectChromaCustom(15)));
        foreach (PutAnimationData1D item in items1d)
        {
            try
            {
                EffectResponse result = item.Method.Invoke(item.Data);
                //Debug.Log(result);
                results.Add(result);
            }
            catch (Exception)
            {
                Debug.LogError(string.Format("Failed to invoke: {0}", item.Method));
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

        if (null == _mApiChromaInstance)
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
            items2d.Add(new PostAnimationData2D(_mApiChromaInstance.PostKeyboardCustom, GetEffectChromaCustom(22, 6)));
            items2d.Add(new PostAnimationData2D(_mApiChromaInstance.PostKeypadCustom, GetEffectChromaCustom(5, 4)));
            items2d.Add(new PostAnimationData2D(_mApiChromaInstance.PostMouseCustom, GetEffectChromaCustom(7, 9)));
            foreach (PostAnimationData2D item in items2d)
            {
                try
                {
                    EffectResponseId result = item.Method.Invoke(item.Data);
                    //Debug.Log(result);
                    effects.Add(result.Id);
                }
                catch (Exception)
                {
                    Debug.LogError(string.Format("Failed to invoke: {0}", item.Method));
                }
            }
#endregion
#region 1D
            var items1d = new List<PostAnimationData1D>();
            items1d.Add(new PostAnimationData1D(_mApiChromaInstance.PostChromaLinkCustom, GetEffectChromaCustom(5)));
            items1d.Add(new PostAnimationData1D(_mApiChromaInstance.PostHeadsetCustom, GetEffectChromaCustom(5)));
            items1d.Add(new PostAnimationData1D(_mApiChromaInstance.PostMousepadCustom, GetEffectChromaCustom(15)));
            foreach (PostAnimationData1D item in items1d)
            {
                try
                {
                    EffectResponseId result = item.Method.Invoke(item.Data);
                    //Debug.Log(result);
                    effects.Add(result.Id);
                }
                catch (Exception)
                {
                    Debug.LogError(string.Format("Failed to invoke: {0}", item.Method));
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
            null != _mApiChromaInstance)
        {
            List<string> effects = frames[index];

            try
            {
                var input = new EffectIdentifierInput(null, effects);
                EffectIdentifierResponse result = _mApiChromaInstance.PutEffect(input);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format("Failed to put effects: {0}", e));
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
                    EffectIdentifierResponse result = _mApiChromaInstance.RemoveEffect(input);
                    //Debug.Log(result);
                }
                catch (Exception e)
                {
                    Debug.LogError(string.Format("Failed to delete effect by id: {0}", e));
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
                EffectIdentifierResponse result = _mApiChromaInstance.RemoveEffect(input);
                //Debug.Log(result);
            }
            catch (Exception e)
            {
                Debug.LogError(string.Format("Failed to delete effects: {0}", e));
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
        if (null != _mApiChromaInstance)
        {
            Uri uri = new Uri(_mApiChromaInstance.ApiClient.BasePath);
            
            RunOnMainThread(() =>
            {
                SetHeartbeatText(string.Format("Monitoring Heartbeat {0}...", uri.Port));
            });

            while (_mWaitForExit &&
                null != _mApiChromaInstance)
            {
                try
                {
                    // The Chroma API uses a heartbeat every 1 second
                    _mApiChromaInstance.Heartbeat();
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
                SetHeartbeatText(string.Format("Heartbeat {0} exited", uri.Port));
            });
            
        }
    }

    // Display the UI in Unity GUI to be compatible with 3.X
    void OnGUI()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("Unity Plugin - Chroma REST API");
        GUILayout.FlexibleSpace();
        GUILayout.Label(_mTextHeartbeat);

        GUILayout.EndHorizontal();

        GUILayout.Label("Set a static color on all devices");

        GUILayout.BeginHorizontal();

        Color oldColor = GUI.backgroundColor;

        const int height = 50;

        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("Blue", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(Color.blue));
            });
        }

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Green", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(Color.green));
            });
        }

        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Red", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(Color.red));
            });
        }

        GUI.backgroundColor = new Color(1f, 0.5f, 0f);
        if (GUILayout.Button("Orange", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(new Color(1f, 0.5f, 0f)));
            });
        }

        GUI.backgroundColor = new Color(0f, 1f, 1f);
        if (GUILayout.Button("Aqua", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(new Color(0, 1f, 1f)));
            });
        }

        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("White", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectStaticOnAll(ChromaUtils.ToBGR(Color.white));
            });
        }

        GUI.backgroundColor = oldColor;

        if (GUILayout.Button("Random", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetKeyboardCustomEffect();
            });
        }

        if (GUILayout.Button("Clear", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                SetEffectNoneOnAll();
            });
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Set a different color to a specific device");

        GUILayout.BeginHorizontal();

        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("Keyboard", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.blue));
                _mApiChromaInstance.PutKeyboard(input);
            });
        }

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Headset", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.green));
                _mApiChromaInstance.PutHeadset(input);
            });
        }

        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Mouse", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.red));
                _mApiChromaInstance.PutMouse(input);
            });
        }

        GUI.backgroundColor = new Color(1f, 0.5f, 0f);
        if (GUILayout.Button("Mousepad", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(new Color(1f, 0.5f, 0f)));
                _mApiChromaInstance.PutMousepad(input);
            });
        }

        GUI.backgroundColor = new Color(0f, 1f, 1f);
        if (GUILayout.Button("Keypad", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(new Color(0f, 1f, 1f)));
                _mApiChromaInstance.PutKeypad(input);
            });
        }

        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("ChromaLink", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.white));
                _mApiChromaInstance.PutChromaLink(input);
            });
        }

        GUI.backgroundColor = oldColor;

        GUILayout.EndHorizontal();

        GUILayout.Label("Play animation...");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Start", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                DoAnimation();
            });
        }

        if (GUILayout.Button("End", GUILayout.Height(height)))
        {
            _mPlayAnimation = false;
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Register Chroma Server", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                PostChromaSdk();
            });
        }

        if (GUILayout.Button("Unregister Chroma Server", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                DeleteChromaSdk();
            });
        }

        GUILayout.EndHorizontal();
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
    }

    /// <summary>
    /// Stop heartbeat on disable, on disable is called on stop, or if compiling
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("OnDisable:");
        _mWaitForExit = false;

        // avoid blocking the UI thread
        ChromaUtils.RunOnThread(() =>
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
        ChromaUtils.RunOnThread(() =>
        {
            DeleteChromaSdk();
        });
    }
}
