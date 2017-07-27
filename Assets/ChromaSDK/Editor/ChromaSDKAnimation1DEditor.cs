using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaSDKAnimation1D))]
public class ChromaSDKAnimation1DEditor : ChromaSDKAnimationBaseEditor
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private ChromaDevice1DEnum _mDevice = ChromaDevice1DEnum.ChromaLink;

    private EffectArray1dInput _mColors = null;

    private ChromaSDKAnimation1D _mLastTarget = null;

    [MenuItem("GameObject/ChromaSDK/Create 1D Animation", priority=1)]
    private static void CreateAsset()
    {
        GameObject gameObject = new GameObject("ChromaEffect");
        gameObject.AddComponent<ChromaSDKAnimation1D>();
        Selection.activeGameObject = gameObject;
    }

    private ChromaSDKAnimation1D GetAnimation()
    {
        return (ChromaSDKAnimation1D)target;
    }

    protected override int GetFrameCount()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        return animation.Frames.Count;
    }

    public override void OnInspectorGUI()
    {
        if (!EditorApplication.isCompiling)
        {
            base.OnInspectorGUI();

            // backup original color
            Color oldBackgroundColor = GUI.backgroundColor;

            ChromaSDKAnimation1D animation = GetAnimation();

            if (_mLastTarget != animation)
            {
                _mLastTarget = animation;
                _mDevice = animation.Device;
            }

            var frames = animation.Frames; //copy

            if (frames.Count == 0)
            {
                OnClickAddButton();
            }

            // Import

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Import Image"))
            {
                OnClickImportImageButton();
            }
            if (GUILayout.Button("Import Animation"))
            {
                OnClickImportAnimationButton();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUI.SetNextControlName(CONTROL_OVERRIDE);
            _mOverrideFrameTime = EditorGUILayout.FloatField("Override Time", _mOverrideFrameTime);
            GUI.SetNextControlName(string.Empty);
            if (GUILayout.Button("Override", GUILayout.Width(100)))
            {
                OnClickOverrideButton();
            }
            GUILayout.EndHorizontal();

            // Device
            GUILayout.BeginHorizontal();
            _mDevice = (ChromaDevice1DEnum)EditorGUILayout.EnumPopup("Device", _mDevice);
            if (GUILayout.Button("Set", GUILayout.Width(100)))
            {
                OnClickSetDevice();
            }
            GUILayout.EndHorizontal();

            // Apply
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Clear"))
            {
                OnClickClearButton();
            }

            if (GUILayout.Button("Fill"))
            {
                OnClickFillButton();
            }

            if (GUILayout.Button("Random"))
            {
                OnClickRandomButton();
            }

            if (GUILayout.Button("Copy"))
            {
                OnClickCopyButton();
            }

            if (GUILayout.Button("Paste"))
            {
                OnClickPasteButton();
            }

            GUILayout.EndHorizontal();

            bool connected = ChromaConnectionManager.Instance.Connected;

            GUI.enabled = connected;

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Preview"))
            {
                OnClickPreviewButton();
            }

            if (GUILayout.Button("Play"))
            {
                OnClickPlayButton();
            }

            if (GUILayout.Button("Stop"))
            {
                OnClickStopButton();
            }

            GUI.enabled = connected && !animation.IsLoaded();
            if (GUILayout.Button("Load"))
            {
                OnClickLoadButton();
            }

            GUI.enabled = connected && animation.IsLoaded();
            if (GUILayout.Button("Unload"))
            {
                OnClickUnloadButton();
            }

            GUI.enabled = true;

            GUILayout.EndHorizontal();

            int maxLeds = ChromaUtils.GetMaxLeds(animation.Device);

            GUILayout.Label(string.Format("1 x {0}", maxLeds));

            // Preview
            Texture2D oldTexture = GUI.skin.button.normal.background;
            SetupBlankTexture();
            if (_mCurrentFrame < frames.Count)
            {
                GUILayout.BeginHorizontal();
                EffectArray1dInput frame = frames[_mCurrentFrame];
                for (int i = 0; i < frame.Count; ++i)
                {
                    int color = (int)frame[i];

                    GUI.backgroundColor = ChromaUtils.ToRGB(color);
                    // use a box instead of button so it looks better
                    GUILayout.Box("", GUILayout.Width(12));
                    Rect rect = GUILayoutUtility.GetLastRect();
                    // use the box location to use a button to catch the click event
                    GUI.skin.button.normal.background = _sTextureClear;
                    if (GUI.Button(rect, ""))
                    {
                        OnClickColor(i);
                    }
                    GUI.skin.button.normal.background = oldTexture;
                }
                GUILayout.EndHorizontal();
            }
            GUI.SetNextControlName("");

            // restore original color
            GUI.backgroundColor = oldBackgroundColor;

            // show separator
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // preset colors

            GUILayout.BeginHorizontal();
            const float k = 0.5f;
            Color[] palette =
            {
            Color.red, Color.red * k,
            ORANGE, ORANGE * k,
            Color.yellow, Color.yellow * k,
            Color.green, Color.green * k,
            Color.blue, Color.blue * k,
            Color.cyan, Color.cyan * k,
            PURPLE, PURPLE * k,
            Color.white, Color.gray, Color.black,
        };
            foreach (Color color in palette)
            {
                Color newColor = color;
                newColor.a = 1f;
                GUI.backgroundColor = newColor;
                // use a box instead of button so it looks better
                GUILayout.Box("", GUILayout.Width(12));
                Rect rect = GUILayoutUtility.GetLastRect();
                // use the box location to use a button to catch the click event
                GUI.skin.button.normal.background = _sTextureClear;
                if (GUI.Button(rect, ""))
                {
                    _mColor = newColor;
                }
                GUI.skin.button.normal.background = oldTexture;
            }
            GUILayout.EndHorizontal();

            // restore original color
            GUI.backgroundColor = oldBackgroundColor;

            // Set the color

            _mColor = EditorGUILayout.ColorField("Brush color", _mColor);

            EditorGUILayout.LabelField("Frame:", string.Format("{0} of {1}",
                _mCurrentFrame + 1,
                null == frames ? 0 : frames.Count));

            float duration = 0.0f;
            if (_mCurrentFrame < frames.Count &&
                _mCurrentFrame < animation.Curve.keys.Length)
            {
                if (_mCurrentFrame == 0)
                {
                    duration = animation.Curve.keys[_mCurrentFrame].time;
                }
                else
                {
                    duration =
                        animation.Curve.keys[_mCurrentFrame].time -
                        animation.Curve.keys[_mCurrentFrame - 1].time;
                }
            }

            GUI.SetNextControlName(CONTROL_DURATION);
            GUILayout.BeginHorizontal();
            float newDuration = EditorGUILayout.FloatField("Duration:", duration);
            if (duration != newDuration &&
                newDuration > 0f)
            {
                if (_mCurrentFrame < frames.Count &&
                    _mCurrentFrame < animation.Curve.keys.Length)
                {
                    float time;
                    if (_mCurrentFrame == 0)
                    {
                        time = newDuration;
                    }
                    else
                    {
                        time = animation.Curve.keys[_mCurrentFrame - 1].time + newDuration;
                    }
                    animation.Curve.RemoveKey(_mCurrentFrame);
                    animation.Curve.AddKey(time, 0f);
                }
            }
            GUILayout.Label("seconds(s)");
            GUILayout.EndHorizontal();
            GUI.SetNextControlName(string.Empty);


            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Previous"))
            {
                OnClickPreviousButton();
            }

            if (GUILayout.Button("Next"))
            {
                OnClickNextButton();
            }

            if (GUILayout.Button("Add"))
            {
                OnClickAddButton();
            }

            if (GUILayout.Button("Delete"))
            {
                OnClickDeleteButton();
            }

            GUILayout.EndHorizontal();


            // Custom Curve
            animation.Curve = EditorGUILayout.CurveField("Edit Curve:", animation.Curve);

            //Debug.Log(GUI.GetNameOfFocusedControl());
            if (string.IsNullOrEmpty(GUI.GetNameOfFocusedControl()))
            {
                Event e = Event.current;
                if (e.type == EventType.keyUp)
                {
                    if (e.keyCode == KeyCode.Delete)
                    {
                        OnClickClearButton();
                        Repaint();
                    }
                    else if (e.keyCode == KeyCode.C &&
                        e.modifiers == EventModifiers.Control)
                    {
                        OnClickCopyButton();
                    }
                    else if (e.keyCode == KeyCode.V &&
                        e.modifiers == EventModifiers.Control)
                    {
                        OnClickPasteButton();
                        Repaint();
                    }
                    else if (e.keyCode == KeyCode.P)
                    {
                        OnClickPlayButton();
                    }
                    else if (e.keyCode == KeyCode.LeftArrow)
                    {
                        OnClickPreviousButton();
                        Repaint();
                    }
                    else if (e.keyCode == KeyCode.RightArrow)
                    {
                        OnClickNextButton();
                        Repaint();
                    }
                    else if (e.keyCode == KeyCode.Plus ||
                        e.keyCode == KeyCode.KeypadPlus)
                    {
                        OnClickAddButton();
                        Repaint();
                    }
                    else if (e.keyCode == KeyCode.Minus ||
                        e.keyCode == KeyCode.KeypadMinus)
                    {
                        OnClickDeleteButton();
                        Repaint();
                    }
                }
            }
        }
    }

    private string GetImageFolder()
    {
        if (EditorPrefs.HasKey(KEY_FOLDER_IMAGES))
        {
            return EditorPrefs.GetString(KEY_FOLDER_IMAGES);
        }
        return "Assets/ChromaSDK/Examples/Textures";
    }

    private string GetAnimationFolder()
    {
        if (EditorPrefs.HasKey(KEY_FOLDER_ANIMATIONS))
        {
            return EditorPrefs.GetString(KEY_FOLDER_ANIMATIONS);
        }
        return "Assets/ChromaSDK/Examples/Textures";
    }

    private string GetImageExtensions()
    {
        return "Image File;*.bmp;*.jpg;*.png";
    }

    private string GetAnimationExtensions()
    {
        return "GIF Animation;*.gif";
    }

    private void Unload()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        if (animation.IsLoaded())
        {
            animation.Unload();
        }
    }

    private void LoadImage(string path)
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();

        if (!string.IsNullOrEmpty(path))
        {
            ImageManager.LoadImage(path);

            DateTime wait = DateTime.Now + TimeSpan.FromSeconds(1);
            while (DateTime.Now < wait)
            {
                Thread.Sleep(0);
            }

            int frameCount = ImageManager.PluginGetFrameCount();
            if (frameCount == 0)
            {
                Debug.LogError("Failed to read frames from image! Please try again!");
            }

            ChromaDevice1DEnum device = animation.Device;
            var colors = ChromaUtils.CreateColors1D(device);

            for (int frameIndex = 0; frameIndex < frameCount; ++frameIndex)
            {
                if (frameIndex > 0)
                {
                    OnClickAddButton();
                }
                var frames = animation.Frames; //copy
                if (_mCurrentFrame >= 0 &&
                    _mCurrentFrame < animation.Frames.Count)
                {
                    //Debug.Log(string.Format("Frame count: {0}", frameCount));

                    int height = ImageManager.PluginGetHeight();
                    int width = ImageManager.PluginGetWidth();

                    if (height > 0)
                    {
                        for (int x = 0; x < colors.Count && x < width; x++)
                        {
                            int color = ImageManager.PluginGetPixel(frameIndex, x, 0);
                            colors[x] = color;
                        }
                    }

                    frames[_mCurrentFrame] = colors;
                }
                animation.Frames = frames;
            }
        }
    }

    private void OnClickImportImageButton()
    {
        string path = EditorUtility.OpenFilePanel("Open Image", GetImageFolder(), GetImageExtensions());
        if (!string.IsNullOrEmpty(path))
        {
            EditorPrefs.SetString(KEY_FOLDER_IMAGES, Path.GetDirectoryName(path));
        }
        LoadImage(path);
    }

    private void OnClickImportAnimationButton()
    {
        string path = EditorUtility.OpenFilePanel("Open Animation", GetAnimationFolder(), GetAnimationExtensions());
        if (!string.IsNullOrEmpty(path))
        {
            EditorPrefs.SetString(KEY_FOLDER_ANIMATIONS, Path.GetDirectoryName(path));
        }
        LoadImage(path);
    }

    private void OnClickOverrideButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        float frameTime = _mOverrideFrameTime;
        float time = 0.0f;
        //clear old keys
        while (animation.Curve.keys.Length > 0)
        {
            animation.Curve.RemoveKey(0);
        }
        //add keys on new interval
        for (int i = 0; i < frames.Count; ++i)
        {
            time += frameTime;
            animation.Curve.AddKey(time, 0f);
        }
        animation.RefreshCurve();
    }

    private void OnClickSetDevice()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();

        if (animation.Device != _mDevice)
        {
            animation.Device = _mDevice;
            animation.ClearFrames();
            animation.RefreshCurve();
        }
    }

    private void OnClickClearButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice1DEnum device = animation.Device;
            frames[_mCurrentFrame] = ChromaUtils.CreateColors1D(device);
        }
        animation.Frames = frames;
    }

    private void OnClickFillButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice1DEnum device = animation.Device;
            int maxLeds = ChromaUtils.GetMaxLeds(device);
            var elements = ChromaUtils.CreateColors1D(device);
            for (int i = 0; i < maxLeds; ++i)
            {
                elements[i] = ChromaUtils.ToBGR(_mColor);
            }
            frames[_mCurrentFrame] = elements;
        }
        animation.Frames = frames;
    }

    private void OnClickCopyButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice1DEnum device = animation.Device;
            int maxLeds = ChromaUtils.GetMaxLeds(device);
            var frame = frames[_mCurrentFrame];
            _mColors = ChromaUtils.CreateColors1D(device);
            if (frame.Count == maxLeds)
            {
                for (int i = 0; i < maxLeds; ++i)
                {
                    _mColors[i] = frame[i];
                }
            }
        }
    }

    private void OnClickPasteButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice1DEnum device = animation.Device;
            int maxLeds = ChromaUtils.GetMaxLeds(device);
            if (_mColors.Count == maxLeds)
            {
                var frame = ChromaUtils.CreateColors1D(device);
                for (int i = 0; i < maxLeds; ++i)
                {
                    frame[i] = _mColors[i];
                }
                frames[_mCurrentFrame] = frame;
            }
        }
        animation.Frames = frames;
    }

    private void OnClickRandomButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice1DEnum device = animation.Device;
            frames[_mCurrentFrame] = ChromaUtils.CreateRandomColors1D(device);
        }
        animation.Frames = frames;
    }

    protected override void OnClickPreviewButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (ChromaConnectionManager.Instance.Connected)
        {
            if (_mCurrentFrame >= 0 &&
                _mCurrentFrame < frames.Count)
            {
                ChromaDevice1DEnum device = animation.Device;
                EffectArray1dInput colors = frames[_mCurrentFrame];
                EffectResponseId effect = ChromaUtils.CreateEffectCustom1D(device, colors);
                if (null != effect &&
                    effect.Result == 0)
                {
                    ChromaUtils.SetEffect(effect.Id);
                    ChromaUtils.RemoveEffect(effect.Id);
                }
            }
        }
    }

    private void OnClickPlayButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (!animation.IsLoaded())
        {
            animation.Load();
        }

        animation.Play();
    }

    private void OnClickStopButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (animation.IsPlaying())
        {
            animation.Stop();
        }
    }

    private void OnClickLoadButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();

        animation.Load();
    }

    private void OnClickUnloadButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();
    }

    private void OnClickPreviousButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        if (_mCurrentFrame > 0)
        {
            --_mCurrentFrame;
        }
        animation.RefreshCurve();
    }

    private void OnClickColor(int element)
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < frames.Count)
        {
            int color = ChromaUtils.ToBGR(_mColor);
            frames[_mCurrentFrame][element] = color;
            Repaint();
        }
        animation.Frames = frames;
    }

    private void OnClickNextButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        if ((_mCurrentFrame + 1) < frames.Count)
        {
            ++_mCurrentFrame;
        }
        animation.RefreshCurve();
    }

    private void OnClickAddButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        EffectArray1dInput frame = ChromaUtils.CreateColors1D(animation.Device);
        if (_mCurrentFrame == frames.Count ||
            (_mCurrentFrame + 1) == frames.Count)
        {
            frames.Add(frame);
            _mCurrentFrame = frames.Count - 1;
        }
        else
        {
            ++_mCurrentFrame;
            frames.Insert(_mCurrentFrame, frame);

        }
        animation.Frames = frames;
        animation.RefreshCurve();
    }

    private void OnClickDeleteButton()
    {
        ChromaSDKAnimation1D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        if (frames.Count == 1)
        {
            // reset frame
            frames[0] = ChromaUtils.CreateColors1D(animation.Device);

            // reset curve
            while (animation.Curve.keys.Length > 0)
            {
                animation.Curve.RemoveKey(0);
            }
        }
        else if (frames.Count > 0)
        {
            frames.RemoveAt(_mCurrentFrame);
            if (_mCurrentFrame == frames.Count)
            {
                _mCurrentFrame = frames.Count - 1;
            }
        }
        animation.Frames = frames;
        animation.RefreshCurve();
    }
#endif
}
