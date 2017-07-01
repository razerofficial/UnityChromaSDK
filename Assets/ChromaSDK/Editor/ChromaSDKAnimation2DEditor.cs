using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaSDKAnimation2D))]
public class ChromaSDKAnimation2DEditor : ChromaSDKAnimationBaseEditor
{
    const string KEY_FOLDER_ANIMATIONS = "folder/animations";
    const string KEY_FOLDER_IMAGES = "folder/images";
    const string CONTROL_DURATION = "control-duration";
    const string CONTROL_OVERRIDE = "control-override";
    readonly Color ORANGE = new Color(1f, 0.5f, 0f, 1f);
    readonly Color PURPLE = new Color(1f, 0f, 1f, 1f);

    private static Texture2D _sTextureClear = null;

    private float _mOverrideFrameTime = 0.1f;

    private ChromaDevice2DEnum _mDevice = ChromaDevice2DEnum.Keyboard;

    private Color _mColor = Color.red;

    private EffectArray2dInput _mColors = null;

    private Keyboard.RZKEY _mKey = Keyboard.RZKEY.RZKEY_ESC;

    private Mouse.RZLED2 _mLed = Mouse.RZLED2.RZLED2_LOGO;

    private int _mCurrentFrame = 0;

    private ChromaSDKAnimation2D GetAnimation()
    {
        return (ChromaSDKAnimation2D)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // backup original color
        Color oldBackgroundColor = GUI.backgroundColor;

        ChromaSDKAnimation2D animation = GetAnimation();
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
        _mDevice = (ChromaDevice2DEnum)EditorGUILayout.EnumPopup("Device", _mDevice);
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

        if (GUILayout.Button("Load"))
        {
            OnClickLoadButton();
        }

        if (GUILayout.Button("Unload"))
        {
            OnClickUnloadButton();
        }

        GUILayout.EndHorizontal();

        int maxRow = ChromaUtils.GetMaxRow(animation.Device);
        int maxColumn = ChromaUtils.GetMaxColumn(animation.Device);

        GUILayout.Label(string.Format("{0} x {1}", maxRow, maxColumn));

        // Preview
        Texture2D oldTexture = GUI.skin.button.normal.background;
        if (null == _sTextureClear)
        {
            _sTextureClear = new Texture2D(1, 1, TextureFormat.RGB24, false);
            _sTextureClear.SetPixel(0, 0, Color.white);
            _sTextureClear.Apply();
        }
        if (_mCurrentFrame < frames.Count)
        {
            EffectArray2dInput frame = frames[_mCurrentFrame];
            for (int i = 0; i < maxRow; ++i)
            {
                List<int> row = frame[i];
                GUILayout.BeginHorizontal();

                for (int j = 0; j < maxColumn; ++j)
                {
                    int color = row[j];
                    GUI.backgroundColor = ChromaUtils.ToRGB(color);
                    // use a box instead of button so it looks better
                    GUILayout.Box("", GUILayout.Width(12));
                    Rect rect = GUILayoutUtility.GetLastRect();
                    // use the box location to use a button to catch the click event
                    GUI.skin.button.normal.background = _sTextureClear;
                    if (GUI.Button(rect, ""))
                    {
                        OnClickColor(i, j);
                    }
                    GUI.skin.button.normal.background = oldTexture;
                }

                GUILayout.EndHorizontal();
            }
        }
        GUI.SetNextControlName("");

        // restore original color
        GUI.backgroundColor = oldBackgroundColor;

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

        base.OnInspectorGUI();
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

    private void LoadImage(string path)
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        if (!string.IsNullOrEmpty(path))
        {
            ImageManager.LoadImage(path);

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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRows = ChromaUtils.GetMaxRow(device);
            int maxColumns = ChromaUtils.GetMaxColumn(device);
            var rows = ChromaUtils.CreateColors2D(device);
            for (int i = 0; i < maxRows; ++i)
            {
                var row = rows[i];
                for (int j = 0; j < maxColumns; ++j)
                {
                    row[j] = ChromaUtils.ToBGR(_mColor);
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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            int maxRow = ChromaUtils.GetMaxRow(device);
            int maxColumn = ChromaUtils.GetMaxColumn(device);
            if (_mColors.Count == maxRow &&
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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            EffectArray2dInput colors = frames[_mCurrentFrame];
            EffectResponseId effect = ChromaUtils.CreateEffectCustom2D(_mApiChromaInstance, device, colors);
            if (null != effect &&
                effect.Result == 0)
            {
                ChromaUtils.SetEffect(_mApiChromaInstance, effect.Id);
                ChromaUtils.RemoveEffect(_mApiChromaInstance, effect.Id);
            }
        }
    }

    private void OnClickPlayButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (!animation.IsLoaded())
        {
            animation.Load(_mApiChromaInstance);
        }

        animation.Play(_mApiChromaInstance);
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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        animation.Load(_mApiChromaInstance);
    }

    private void OnClickUnloadButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }
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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

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
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

        if (_mCurrentFrame < 0 ||
            _mCurrentFrame >= frames.Count)
        {
            _mCurrentFrame = 0;
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
        animation.Frames = frames;
        animation.RefreshCurve();
    }

    private void OnClickDeleteButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EditorUtility.SetDirty(animation);
        var frames = animation.Frames; //copy
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }

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
}
