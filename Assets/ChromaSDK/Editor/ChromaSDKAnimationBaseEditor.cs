// Access to Types and Utils
using ChromaSDK;
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
using UnityEditor;
using UnityEngine;

/// <summary>
/// The purpose of this class is to manage the api connection
/// </summary>
public class ChromaSDKAnimationBaseEditor : Editor
{
    /// <summary>
    /// Instance of the RazerAPI
    /// </summary>
    protected RazerApi _mApiRazerInstance;

    /// <summary>
    /// Instance of the API
    /// </summary>
    protected ChromaApi _mApiChromaInstance;

    /// <summary>
    /// Detect app shutdown
    /// </summary>
    private bool _mWaitForExit = true;

    /// <summary>
    /// Actions to run on the main thread
    /// </summary>
    private List<Action> _mMainActions = new List<Action>();

    #region Handle Coroutines in edit-mode

    /// <summary>
    /// Keep track of initialization
    /// </summary>
    private bool _mHasEditorUpdates = false;

    /// <summary>
    /// Use for co-routine simulation
    /// </summary>
    private List<IEnumerator> _mPendingRoutines = new List<IEnumerator>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="routineName"></param>
    /// <param name="routine"></param>
    protected void SafeStartCoroutine(string routineName, IEnumerator routine)
    {
        Debug.Log(string.Format("SafeStartCoroutine: {0}", routineName));
        _mPendingRoutines.Add(routine);
    }

    /// <summary>
    /// Start editor updates
    /// </summary>
    public void StartEditorUpdates()
    {
        if (!_mHasEditorUpdates)
        {
            Debug.Log("StartEditorUpdates:");
            _mHasEditorUpdates = true;
            _mPendingRoutines.Clear();
            EditorApplication.update += EditorUpdate;
            SafeStartCoroutine("Initialize", Initialize());
        }
    }

    //Stop editor updates
    public void StopEditorUpdates()
    {
        if (_mHasEditorUpdates)
        {
            Debug.Log("StopEditorUpdates:");
            _mHasEditorUpdates = false;
            _mPendingRoutines.Clear();
            EditorApplication.update -= EditorUpdate;
        }
    }

    public void EditorUpdate()
    {
        //Debug.LogFormat("EditorUpdate: {0}", _mPendingRoutines.Count);

        //Debug.LogFormat("OnGUI: IsCompiling: {0}", EditorApplication.isCompiling);
        if (EditorApplication.isCompiling)
        {
            StopEditorUpdates();
        }

        int i = 0;
        while (i < _mPendingRoutines.Count)
        {
            //Debug.LogFormat("EditorUpdate: {0}", _mPendingRoutines.Count);
            IEnumerator routine = _mPendingRoutines[i];
            try
            {
                if (null != routine &&
                    routine.MoveNext())
                {
                    //more work
                    ++i;
                    continue;
                }
            }
            catch (Exception)
            {
                // something bad happened,
                // stop coroutine
            }
            //done
            _mPendingRoutines.RemoveAt(i);
            continue;
        }
    }

    #endregion

    /// <summary>
    /// Run on the main thread
    /// </summary>
    /// <param name="action"></param>
    private void RunOnMainThread(Action action)
    {
        _mMainActions.Add(action);
    }

    private ChromaSDKBaseAnimation GetAnimation()
    {
        return (ChromaSDKBaseAnimation)target;
    }

    /// <summary>
    /// OnEnable is invoked on play, or while playing after compile
    /// </summary>
    void OnEnable()
    {
        Debug.Log("OnEnable:");
        _mWaitForExit = true;

        StartEditorUpdates();
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

        StopEditorUpdates();
    }

    public override void OnInspectorGUI()
    {
        if (_mMainActions.Count > 0)
        {
            Action action = _mMainActions[0];
            _mMainActions.RemoveAt(0);
            action.Invoke();
        }

        if (null == _mApiChromaInstance)
        {

        }
    }

    void SetHeartbeatText(string text)
    {
        Debug.Log(text);
    }

    /// <summary>
    /// Use heartbeat to keep the REST API listening after initialization,
    /// be sure to call from a thread and not the main thread
    /// </summary>
    void DoHeartbeat()
    {
        if (null == _mApiChromaInstance)
        {
            Debug.LogError("DoHeartbeat: ApiChromaInstance is null!");
        }
        else
        {
            Uri uri = new Uri(_mApiChromaInstance.ApiClient.BasePath);

            Debug.Log(string.Format("Monitoring Heartbeat {0}...", uri.Port));

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

            Debug.Log(string.Format("Heartbeat {0} exited", uri.Port));

        }
    }

    /// <summary>
    /// Initialize Chroma by hitting the REST server and set the API port
    /// </summary>
    /// <returns></returns>
    void PostChromaSdk()
    {
        Debug.Log("PostChromaSdk:");
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

            // Coroutines can only start from the main thread
            RunOnMainThread(() =>
            {
                // retry
                SafeStartCoroutine("Initialize", Initialize());
            });
        }
    }

    /// <summary>
    /// Initialize after a delay
    /// </summary>
    /// <returns></returns>
    IEnumerator Initialize()
    {
        Debug.Log("Initialize:");

        // wait to initialize in case recompile just shutdown
        RunOnMainThread(() =>
        {
            SetHeartbeatText("Waiting to initialize ChromaSDK...");
        });

        // delay, WaitForSeconds doesn't work in edit mode
        DateTime wait = DateTime.Now + TimeSpan.FromSeconds(2);
        while (DateTime.Now < wait)
        {
            yield return null;
        }

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
}
