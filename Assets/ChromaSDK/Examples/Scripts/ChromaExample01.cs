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
using UnityEngine;

using Random = System.Random;

public class ChromaExample01 : MonoBehaviour
{
    /// <summary>
    /// 1D animation assets
    /// </summary>
    public ChromaSDKAnimation1D[] _mAnimations1D = null;

    /// <summary>
    /// 2D animation assets
    /// </summary>
    public ChromaSDKAnimation2D[] _mAnimations2D = null;

    /// <summary>
    /// Connection manager maintains REST connection
    /// </summary>
    private ChromaConnectionManager _mConnectionManager = null;

    /// <summary>
    /// Show status label
    /// </summary>
    private string _mTextStatus;

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
    /// Display result with label prefix
    /// </summary>
    /// <param name="label"></param>
    /// <param name="result"></param>
    private static void DisplayResult(string label, EffectResponse result)
    {
        if (null == result)
        {
            Debug.LogError(string.Format("{0} Result was null!", label));
        }
        else
        {
            Debug.Log(string.Format("{0} {1}", label, result));
        }
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

#endregion

    /// <summary>
    /// Clear effect on all devices using PUT
    /// </summary>
    void SetEffectNoneOnAll()
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        DisplayResult("PutChromaLinkNone:", chromaApi.PutChromaLinkNone());
        DisplayResult("PutHeadsetNone:", chromaApi.PutHeadsetNone());
        DisplayResult("PutKeyboardNone:", chromaApi.PutKeyboardNone());
        DisplayResult("PutKeypadNone:", chromaApi.PutKeypadNone());
        DisplayResult("PutMouseNone:", chromaApi.PutMouseNone());
        DisplayResult("PutMousepadNone:", chromaApi.PutMousepadNone());
    }

    /// <summary>
    /// Set static effect on all devices using PUT
    /// </summary>
    /// <param name="color"></param>
    void SetEffectStaticOnAll(int color)
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        DisplayResult("PutChromaLinkStatic:", chromaApi.PutChromaLinkStatic(color));
        DisplayResult("PutHeadsetStatic:", chromaApi.PutHeadsetStatic(color));
        DisplayResult("PutKeyboardStatic:", chromaApi.PutKeyboardStatic(color));
        DisplayResult("PutKeypadStatic:", chromaApi.PutKeypadStatic(color));
        DisplayResult("PutMouseStatic:", chromaApi.PutMouseStatic(color));
        DisplayResult("PutMousepadStatic:", chromaApi.PutMousepadStatic(color));
    }

    /// <summary>
    /// Set effect on all devices using PUT
    /// </summary>
    /// <param name="input"></param>
    void SetEffectOnAll(EffectInput input)
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        DisplayResult("PutChromaLink:", chromaApi.PutChromaLink(input));
        DisplayResult("PutHeadset:", chromaApi.PutHeadset(input));
        DisplayResult("PutKeyboard:", chromaApi.PutKeyboard(input));
        DisplayResult("PutKeypad:", chromaApi.PutKeypad(input));
        DisplayResult("PutMouse:", chromaApi.PutMouse(input));
        DisplayResult("PutMousepad:", chromaApi.PutMousepad(input));
    }

    /// <summary>
    /// Use the API to set the CHROMA_CUSTOM effect
    /// </summary>
    void SetKeyboardCustomEffect()
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        DisplayResult("PutChromaLinkCustom:", chromaApi.PutChromaLinkCustom(ChromaUtils.CreateRandomColors1D(ChromaDevice1DEnum.ChromaLink)));
        DisplayResult("PutHeadsetCustom:", chromaApi.PutHeadsetCustom(ChromaUtils.CreateRandomColors1D(ChromaDevice1DEnum.Headset)));
        DisplayResult("PutKeyboardCustom:", chromaApi.PutKeyboardCustom(ChromaUtils.CreateRandomColors2D(ChromaDevice2DEnum.Keyboard)));
        DisplayResult("PutKeypadCustom:", chromaApi.PutKeypadCustom(ChromaUtils.CreateRandomColors2D(ChromaDevice2DEnum.Keypad)));
        DisplayResult("PutMouseCustom:", chromaApi.PutMouseCustom(ChromaUtils.CreateRandomColors2D(ChromaDevice2DEnum.Mouse)));
        DisplayResult("PutMousepadCustom:", chromaApi.PutMousepadCustom(ChromaUtils.CreateRandomColors1D(ChromaDevice1DEnum.Mousepad)));
    }

    /// <summary>
    /// Loop 1D animation using complete callback
    /// </summary>
    /// <param name="animation"></param>
    void LoopAnimation1D(ChromaSDKAnimation1D animation)
    {
        if (_mPlayAnimation)
        {
            animation.PlayWithOnComplete(LoopAnimation1D);
        }
    }

    /// <summary>
    /// Loop 2D animation using complete callback
    /// </summary>
    /// <param name="animation"></param>
    void LoopAnimation2D(ChromaSDKAnimation2D animation)
    {
        if (_mPlayAnimation)
        {
            animation.PlayWithOnComplete(LoopAnimation2D);
        }
    }

    /// <summary>
    /// Create and play an animation
    /// </summary>
    void DoAnimations()
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        _mPlayAnimation = true;

        // load 1D animations

        foreach (ChromaSDKAnimation1D animation in _mAnimations1D)
        {
            // unload in case animation was playing in editor
            if (animation.IsLoaded())
            {
                animation.Unload();
            }
            // load the animation
            animation.Load();
        }

        // load 2D animations

        foreach (ChromaSDKAnimation2D animation in _mAnimations2D)
        {
            // unload in case animation was playing in editor
            if (animation.IsLoaded())
            {
                animation.Unload();
            }
            // load the animation
            animation.Load();
        }        

        Debug.Log("Play animations looping...");

        foreach (ChromaSDKAnimation1D animation in _mAnimations1D)
        {
            LoopAnimation1D(animation);
        }

        foreach (ChromaSDKAnimation2D animation in _mAnimations2D)
        {
            LoopAnimation2D(animation);
        }
    }

    void StopAnimations()
    {
        if (!_mConnectionManager.Connected)
        {
            Debug.LogError("Chroma client is not yet connected!");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        // unload 1D animations
        foreach (ChromaSDKAnimation1D animation in _mAnimations1D)
        {
            if (animation.IsLoaded())
            {
                animation.Unload();
            }
        }

        // unload 2D animations
        foreach (ChromaSDKAnimation2D animation in _mAnimations2D)
        {
            if (animation.IsLoaded())
            {
                animation.Unload();
            }
        }
    }

    /// <summary>
    /// Get the connection manager on start
    /// </summary>
    private void Start()
    {
        _mConnectionManager = ChromaConnectionManager.Instance;
    }

    // Display the UI in Unity GUI to be compatible with 3.X
    void OnGUI()
    {
        if (null == _mConnectionManager)
        {
            GUILayout.Label("Waiting for start...");
            return;
        }

        ChromaApi chromaApi = _mConnectionManager.ApiChromaInstance;

        _mTextStatus = _mConnectionManager.Connected ? "Connected" : "Not Connected";

        GUILayout.BeginHorizontal();

        GUILayout.Label("Unity Plugin - Chroma REST API");
        GUILayout.FlexibleSpace();
        GUILayout.Label(_mTextStatus);

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

        GUILayout.Label("Set a built-in effect on all devices");

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Breathing 1", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_BREATHING);
                input.Param = new EffectInputParam();
                input.Param.Color1 = ChromaUtils.ToBGR(Color.red);
                input.Param.Color2 = ChromaUtils.ToBGR(Color.green);
                input.Param.Type = 1;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Breathing 2", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_BREATHING);
                input.Param = new EffectInputParam();
                input.Param.Color1 = ChromaUtils.ToBGR(Color.green);
                input.Param.Color2 = ChromaUtils.ToBGR(Color.yellow);
                input.Param.Type = 2;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Reactive 1", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_REACTIVE);
                input.Param = new EffectInputParam();
                input.Param.Color = ChromaUtils.ToBGR(Color.red);
                input.Param.Duration = 1;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Reactive 2", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_REACTIVE);
                input.Param = new EffectInputParam();
                input.Param.Color = ChromaUtils.ToBGR(Color.green);
                input.Param.Duration = 2;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Reactive 3", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_REACTIVE);
                input.Param = new EffectInputParam();
                input.Param.Color = ChromaUtils.ToBGR(Color.blue);
                input.Param.Duration = 3;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Spectrum Cycling", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_SPECTRUMCYCLING);
                input.Param = new EffectInputParam();
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Wave 1", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_WAVE);
                input.Param = new EffectInputParam();
                input.Param.Direction = 1;
                SetEffectOnAll(input);
            });
        }

        if (GUILayout.Button("Wave 2", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                var input = new EffectInput(EffectType.CHROMA_WAVE);
                input.Param = new EffectInputParam();
                input.Param.Direction = 2;
                SetEffectOnAll(input);
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
                DisplayResult("PutKeyboard:", chromaApi.PutKeyboard(input));
            });
        }

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Headset", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.green));
                DisplayResult("PutHeadset:", chromaApi.PutHeadset(input));
            });
        }

        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Mouse", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.red));
                DisplayResult("PutMouse:", chromaApi.PutMouse(input));
            });
        }

        GUI.backgroundColor = new Color(1f, 0.5f, 0f);
        if (GUILayout.Button("Mousepad", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(new Color(1f, 0.5f, 0f)));
                DisplayResult("PutMousepad:", chromaApi.PutMousepad(input));
            });
        }

        GUI.backgroundColor = new Color(0f, 1f, 1f);
        if (GUILayout.Button("Keypad", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(new Color(0f, 1f, 1f)));
                DisplayResult("PutKeypad:", chromaApi.PutKeypad(input));
            });
        }

        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("ChromaLink", GUILayout.Height(height)))
        {
            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                EffectInput input = GetEffectChromaStatic(ChromaUtils.ToBGR(Color.white));
                DisplayResult("PutChromaLink:", chromaApi.PutChromaLink(input));
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
                DoAnimations();
            });
        }

        if (GUILayout.Button("End", GUILayout.Height(height)))
        {
            _mPlayAnimation = false;

            // avoid blocking the UI thread
            ChromaUtils.RunOnThread(() =>
            {
                StopAnimations();
            });
        }

        GUILayout.EndHorizontal();
    }
}
