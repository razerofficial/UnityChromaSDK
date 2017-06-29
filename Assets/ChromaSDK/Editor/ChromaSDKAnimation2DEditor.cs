using ChromaSDK;
using ChromaSDK.Api;
using ChromaSDK.ChromaPackage.Model;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaSDKAnimation2D))]
public class ChromaSDKAnimation2DEditor : ChromaSDKAnimationBaseEditor
{
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

        if (GUILayout.Button("Import image"))
        {

        }

        if (GUILayout.Button("Import animation"))
        {

        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Override"))
        {
            OnClickOverrideButton();
        }

        _mOverrideFrameTime = EditorGUILayout.FloatField("Override Frame Time", _mOverrideFrameTime);

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
                    if (GUILayout.Button(" ", GUILayout.Width(12)))
                    {
                        OnClickColor(i, j);
                    }
                }

                GUILayout.EndHorizontal();
            }
        }

        // restore original color
        GUI.backgroundColor = oldBackgroundColor;

        // Key
        GUILayout.BeginHorizontal();
        _mKey = (Keyboard.RZKEY)EditorGUILayout.EnumPopup("Select a key", _mKey);
        if (GUILayout.Button("Set key", GUILayout.Width(100)))
        {

        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Set logo"))
        {

        }
        GUILayout.EndHorizontal();

        // Led
        GUILayout.BeginHorizontal();
        _mLed = (Mouse.RZLED2)EditorGUILayout.EnumPopup("Select an LED", _mLed);
        if (GUILayout.Button("Set LED", GUILayout.Width(100)))
        {

        }
        GUILayout.EndHorizontal();

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

        EditorGUILayout.LabelField("Duration:", string.Format("{0} second(s)",
            duration));


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

        Event e = Event.current;
        if (e.type == EventType.keyUp)
        {
            if (e.keyCode == KeyCode.LeftArrow)
            {
                OnClickPreviousButton();
                Repaint();
            }
            else if (e.keyCode == KeyCode.RightArrow)
            {
                OnClickNextButton();
                Repaint();
            }
        }

        base.OnInspectorGUI();
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
