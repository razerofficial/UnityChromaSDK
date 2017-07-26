using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaSDKAnimation2D))]
public class ChromaSDKAnimation2DEditor : ChromaSDKAnimationBaseEditor
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private ChromaDevice2DEnum _mDevice = ChromaDevice2DEnum.Keyboard;

    private EffectArray2dInput _mColors = null;

    private Keyboard.RZKEY _mKey = Keyboard.RZKEY.RZKEY_ESC;

    private Mouse.RZLED2 _mLed = Mouse.RZLED2.RZLED2_LOGO;

    private ChromaSDKAnimation2D _mLastTarget = null;

    private static bool _sToggleLabels = true;

    [MenuItem("GameObject/ChromaSDK/Create 2D Animation", priority=2)]
    private static void CreateAsset()
    {
        GameObject gameObject = new GameObject("ChromaEffect");
        gameObject.AddComponent<ChromaSDKAnimation2D>();
        Selection.activeGameObject = gameObject;
    }

    private ChromaSDKAnimation2D GetAnimation()
    {
        return (ChromaSDKAnimation2D)target;
    }

    public override void OnInspectorGUI()
    {
        if (!EditorApplication.isCompiling)
        {
            base.OnInspectorGUI();

            // backup original color
            Color oldBackgroundColor = GUI.backgroundColor;

            ChromaSDKAnimation2D animation = GetAnimation();

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

            // Device
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.Label("Device:");
            _mDevice = (ChromaDevice2DEnum)EditorGUILayout.EnumPopup(_mDevice, GUILayout.Width(150));
            if (GUILayout.Button("Set", GUILayout.Width(100)))
            {
                OnClickSetDevice();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            bool connected = ChromaConnectionManager.Instance.Connected;

            GUI.enabled = connected;

            GUILayout.BeginHorizontal();

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

            if (GUILayout.Button("Preview") ||
                Event.current.shift)
            {
                OnClickPreviewButton();
            }

            GUI.enabled = true;

            GUILayout.EndHorizontal();

            // Import

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Import Image"))
            {
                OnClickImportImageButton();
            }
            if (GUILayout.Button("Import Animation"))
            {
                OnClickImportAnimationButton();
            }
            if (GUILayout.Button("Reverse Animation"))
            {
                OnClickReverseAnimationButton();
            }
            GUILayout.FlexibleSpace();
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

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Contrast"))
            {
                OnClickContrastButton();
            }
            if (GUILayout.Button("Saturate"))
            {
                OnClickSaturateButton();
            }
            if (GUILayout.Button("Desaturate"))
            {
                OnClickDesaturateButton();
            }
            if (GUILayout.Button("Darken"))
            {
                OnClickDarkenButton();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Shift Down"))
            {
                OnClickShiftButton(1, 0);
            }
            if (GUILayout.Button("Shift Left"))
            {
                OnClickShiftButton(0, -1);
            }
            if (GUILayout.Button("Shift Right"))
            {
                OnClickShiftButton(0, 1);
            }
            if (GUILayout.Button("Shift Up"))
            {
                OnClickShiftButton(-1, 0);
            }
            GUILayout.EndHorizontal();

            // grid info

            int maxRow = ChromaUtils.GetMaxRow(animation.Device);
            int maxColumn = ChromaUtils.GetMaxColumn(animation.Device);

            GUILayout.Label(string.Format("{0} x {1}", maxRow, maxColumn));

            if (_mDevice == ChromaDevice2DEnum.Keyboard)
            {
                _sToggleLabels = EditorGUILayout.Toggle("Labels:", _sToggleLabels);
            }

            // Preview

            // the grid panel
            GUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            // the left-part

            GUILayout.BeginVertical();
            if (GUILayout.Button(" ", GUILayout.Height(20)))
            {
                OnClickFillButton();
            }
            for (int i = 0; i < maxRow; ++i)
            {
                if (GUILayout.Button(" ", GUILayout.Height(20)))
                {
                    OnClickFillRow(i);
                }
            }
            GUILayout.EndVertical();

            // the right-part

            GUILayout.BeginVertical();

            int boxWidth = Screen.width / (maxColumn + 1) - 5;

            // the top-buttons
            GUILayout.BeginHorizontal();
            for (int j = 0; j < maxColumn; ++j)
            {
                if (GUILayout.Button(" ", GUILayout.Width(boxWidth)))
                {
                    OnClickFillColumn(j);
                }
            }
            GUILayout.EndHorizontal();

            // the main-grid

            string tooltip = null;
            Rect tooltipRect = new Rect(0,0,0,0);
            Texture2D oldTexture = GUI.skin.button.normal.background;
            SetupBlankTexture();
            if (_mCurrentFrame < frames.Count)
            {
                EffectArray2dInput frame = frames[_mCurrentFrame];
                for (int i = 0; i < maxRow && i < frame.Count; ++i)
                {
                    List<int> row = frame[i];
                    GUILayout.BeginHorizontal();

                    for (int j = 0; j < maxColumn && j < row.Count; ++j)
                    {
                        int color = row[j];
                        GUI.backgroundColor = ChromaUtils.ToRGB(color);
                        // use a box instead of button so it looks better
                        GUILayout.Box("", GUILayout.Width(boxWidth));
                        Rect rect = GUILayoutUtility.GetLastRect();
                        // check for hovering box
                        if (Event.current.alt &&
                            rect.Contains(Event.current.mousePosition))
                        {
                            _mColor = ChromaUtils.ToRGB(color);
                        }
                        if (_mDevice == ChromaDevice2DEnum.Keyboard &&
                            !_sToggleLabels &&
                            rect.Contains(Event.current.mousePosition))
                        {
                            tooltip = ChromaUtils.GetKeyString(i, j);
                            tooltipRect = rect;
                        }
                        // use the box location to use a button to catch the click event
                        GUI.skin.button.normal.background = _sTextureClear;
                        if (GUI.Button(rect, ""))
                        {
                            OnClickColor(i, j);
                        }
                        GUI.skin.button.normal.background = oldTexture;

                        if (_mDevice == ChromaDevice2DEnum.Keyboard &&
                            _sToggleLabels)
                        {
                            string keyString = ChromaUtils.GetKeyString(i, j);
                            GUI.Label(rect, keyString);
                        }
                    }

                    GUILayout.EndHorizontal();
                }
            }
            GUI.SetNextControlName("");

            if (!string.IsNullOrEmpty(tooltip))
            {
                var labelStyle = GUI.skin.GetStyle("Label");
                Vector2 size = labelStyle.CalcSize(new GUIContent(tooltip));
                tooltipRect.y -= 20;
                tooltipRect.width = size.x + 10;
                tooltipRect.height = size.y + 10;
                GUI.skin.box.normal.background = _sTextureClear;
                GUI.Box(tooltipRect, " ");
                labelStyle.alignment = TextAnchor.MiddleCenter;
                GUI.Label(tooltipRect, tooltip);
            }

            // end of right-part

            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();

            // end of grid panel
            GUILayout.EndHorizontal();

            // restore original color
            GUI.backgroundColor = oldBackgroundColor;

            // show separator
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // Key
            if (animation.Device == ChromaDevice2DEnum.Keyboard)
            {
                GUILayout.BeginHorizontal();
                _mKey = (Keyboard.RZKEY)EditorGUILayout.EnumPopup("Select a key", _mKey);
                if (GUILayout.Button("Set key", GUILayout.Width(100)))
                {
                    OnClickColor(
                        ChromaUtils.GetHighByte((int)_mKey),
                        ChromaUtils.GetLowByte((int)_mKey));
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Set RZLED_LOGO"))
                {
                    OnClickColor(
                        ChromaUtils.GetHighByte((int)Keyboard.RZLED.RZLED_LOGO),
                        ChromaUtils.GetLowByte((int)Keyboard.RZLED.RZLED_LOGO));
                }
                GUILayout.EndHorizontal();
            }

            // Led
            if (animation.Device == ChromaDevice2DEnum.Mouse)
            {
                GUILayout.BeginHorizontal();
                _mLed = (Mouse.RZLED2)EditorGUILayout.EnumPopup("Select an LED", _mLed);

                if (GUILayout.Button("Set LED", GUILayout.Width(100)))
                {
                    OnClickColor(
                        ChromaUtils.GetHighByte((int)_mLed),
                        ChromaUtils.GetLowByte((int)_mLed));
                }
                GUILayout.EndHorizontal();
            }

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

            GUILayout.BeginHorizontal();
            _mColor = EditorGUILayout.ColorField(_mColor, GUILayout.Width(40));
            _mColor = EditorGUILayout.ColorField("Brush color", _mColor);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUI.SetNextControlName(CONTROL_OVERRIDE);
            GUILayout.Label("Override Time (ALL frames)");
            _mOverrideFrameTime = EditorGUILayout.FloatField(_mOverrideFrameTime, GUILayout.Width(100));
            GUI.SetNextControlName(string.Empty);
            if (GUILayout.Button("Override", GUILayout.Width(100)))
            {
                OnClickOverrideButton();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

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

            if (GUILayout.Button("Insert"))
            {
                OnClickInsertButton();
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
                    else if (e.keyCode == KeyCode.Space)
                    {
                        OnClickPlayButton();
                        Repaint();
                    }
                }
            }
        }

        Repaint();
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
        ChromaSDKAnimation2D animation = GetAnimation();
        if (animation.IsLoaded())
        {
            animation.Unload();
        }
    }

    private void LoadImage(string path)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
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

            ChromaDevice2DEnum device = animation.Device;
            var colors = ChromaUtils.CreateColors2D(device);

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

                    for (int y = 0; y < colors.Count && y < height; y++)
                    {
                        var row = colors[y];
                        for (int x = 0; x < row.Count && x < width; x++)
                        {
                            int color = ImageManager.PluginGetPixel(frameIndex, x, y);
                            row[x] = color;
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

    private void OnClickReverseAnimationButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();
        frames.Reverse();
        animation.Frames = frames;
        animation.RefreshCurve();
    }

    private void OnClickOverrideButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
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
        ChromaSDKAnimation2D animation = GetAnimation();
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
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            frames[_mCurrentFrame] = ChromaUtils.CreateColors2D(device);
        }
        animation.Frames = frames;
    }

    private void OnClickFillButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var rows = ChromaUtils.CreateColors2D(device);
            for (int i = 0; i < maxRow; ++i)
            {
                var row = rows[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    row[j] = ChromaUtils.ToBGR(_mColor);
                }
            }
            frames[_mCurrentFrame] = rows;
        }
        animation.Frames = frames;
    }

    private void OnClickFillRow(int row)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var rows = frames[_mCurrentFrame];
            if (row < rows.Count)
            {
                var colors = rows[row];
                for (int j = 0; j < maxColumn; ++j)
                {
                    colors[j] = ChromaUtils.ToBGR(_mColor);
                }
            }
            frames[_mCurrentFrame] = rows;
        }
        animation.Frames = frames;
    }

    private void OnClickFillColumn(int column)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var rows = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                var row = rows[i];
                if (column < row.Count)
                {
                    row[column] = ChromaUtils.ToBGR(_mColor);
                }
            }
            frames[_mCurrentFrame] = rows;
        }
        animation.Frames = frames;
    }

    private void OnClickCopyButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var frame = frames[_mCurrentFrame];
            _mColors = ChromaUtils.CreateColors2D(device);
            if (frame.Count == maxRow &&
                null != frame[0] &&
                frame[0].Count == maxColumn)
            {
                for (int i = 0; i < maxRow; ++i)
                {
                    for (int j = 0; j < maxColumn; ++j)
                    {
                        _mColors[i][j] = frame[i][j];
                    }
                }
            }
        }
    }

    private void OnClickPasteButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            if (null != _mColors &&
                _mColors.Count == maxRow &&
                null != _mColors[0] &&
                _mColors[0].Count == maxColumn)
            {
                var frame = ChromaUtils.CreateColors2D(device);
                for (int i = 0; i < maxRow; ++i)
                {
                    for (int j = 0; j < maxColumn; ++j)
                    {
                        frame[i][j] = _mColors[i][j];
                    }
                }
                frames[_mCurrentFrame] = frame;
            }
        }
        animation.Frames = frames;
    }

    private void OnClickRandomButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            frames[_mCurrentFrame] = ChromaUtils.CreateRandomColors2D(device);
        }
        animation.Frames = frames;
    }

    private void OnClickPreviewButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            EffectArray2dInput colors = frames[_mCurrentFrame];
            EffectResponseId effect = ChromaUtils.CreateEffectCustom2D(device, colors);
            if (null != effect &&
                effect.Result == 0)
            {
                ChromaUtils.SetEffect(effect.Id);
                ChromaUtils.RemoveEffect(effect.Id);
            }
        }
    }

    private void OnClickPlayButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (!animation.IsLoaded())
        {
            animation.Load();
        }

        animation.Play();
    }

    private void OnClickStopButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (animation.IsPlaying())
        {
            animation.Stop();
        }
    }

    private void OnClickLoadButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();

        animation.Load();
    }

    private void OnClickUnloadButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        Unload();
    }

    private void OnClickContrastButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var frame = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    Color color = ChromaUtils.ToRGB(row[j]);
                    float avg = (color.r + color.g + color.b) / 3f;
                    if (avg < 0.5f)
                    {
                        color.r *= 0.75f;
                        color.g *= 0.75f;
                        color.b *= 0.75f;
                    }
                    else if (avg > 0.5f)
                    {
                        color.r = Mathf.Min(1f, color.r * 1.25f);
                        color.g = Mathf.Min(1f, color.g * 1.25f);
                        color.b = Mathf.Min(1f, color.b * 1.25f);
                    }
                    row[j] = ChromaUtils.ToBGR(color);
                }
            }
        }
        animation.Frames = frames;
    }

    private void OnClickSaturateButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var frame = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    Color color = ChromaUtils.ToRGB(row[j]);
                    float max = Mathf.Max(Mathf.Max(color.r, color.g), color.b);
                    color = Color.Lerp(Color.black, _mColor, max);
                    row[j] = ChromaUtils.ToBGR(color);
                }
            }
        }
        animation.Frames = frames;
    }

    private void OnClickDesaturateButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var frame = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    Color color = ChromaUtils.ToRGB(row[j]);
                    color.r = color.g = color.b = color.grayscale;
                    row[j] = ChromaUtils.ToBGR(color);
                }
            }
        }
        animation.Frames = frames;
    }

    private void OnClickDarkenButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            var frame = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    Color color = ChromaUtils.ToRGB(row[j]);
                    color.r *= 0.75f;
                    color.g *= 0.75f;
                    color.b *= 0.75f;
                    row[j] = ChromaUtils.ToBGR(color);
                }
            }
        }
        animation.Frames = frames;
    }

    private void OnClickShiftButton(int y, int x)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            int offsetX = maxColumn - x;
            int offsetY = maxRow - y;
            var oldFrame = frames[_mCurrentFrame];
            var newFrame = ChromaUtils.CreateColors2D(device);
            for (int i = 0; i < maxRow; ++i)
            {
                var oldRow = oldFrame[(i + offsetY) % maxRow];
                var newRow = newFrame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    int color = oldRow[(j + offsetX) % maxColumn];
                    newRow[j] = color;
                }
            }
            frames[_mCurrentFrame] = newFrame;
        }
        animation.Frames = frames;
    }

    private void OnClickPreviousButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
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
    
    private void OnClickColor(int row, int column)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < frames.Count)
        {
            int color = ChromaUtils.ToBGR(_mColor);
            frames[_mCurrentFrame][row][column] = color;
            Repaint();
        }
        animation.Frames = frames;
    }

    private void OnClickNextButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
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
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        EffectArray2dInput oldFrame;
        if (frames.Count > 0)
        {
            oldFrame = frames[_mCurrentFrame];
        }
        else
        {
            oldFrame = ChromaUtils.CreateColors2D(animation.Device);
        }
        EffectArray2dInput frame = ChromaUtils.CreateColors2D(animation.Device);
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
        // copy colors
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    row[j] = oldFrame[i][j];
                }
            }
        }
        animation.Frames = frames;
        animation.RefreshCurve();
    }

    private void OnClickInsertButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        Unload();

        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
        }
        EffectArray2dInput oldFrame;
        if (frames.Count > 0)
        {
            oldFrame = frames[_mCurrentFrame];
        }
        else
        {
            oldFrame = ChromaUtils.CreateColors2D(animation.Device);
        }
        EffectArray2dInput frame = ChromaUtils.CreateColors2D(animation.Device);
        if (frames.Count == 0)
        {
            frames.Add(frame);
            _mCurrentFrame = frames.Count - 1;
        }
        else
        {
            frames.Insert(_mCurrentFrame, frame);
        }
        // copy colors
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            for (int i = 0; i < maxRow; ++i)
            {
                var row = frame[i];
                for (int j = 0; j < maxColumn; ++j)
                {
                    row[j] = oldFrame[i][j];
                }
            }
        }
        animation.Frames = frames;
        animation.RefreshCurve();
    }

    private void OnClickDeleteButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
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
            frames[0] = ChromaUtils.CreateColors2D(animation.Device);

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
