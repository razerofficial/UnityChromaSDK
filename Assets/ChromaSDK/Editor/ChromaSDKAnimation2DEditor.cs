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

    private Color _mColor = Color.red;

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

        if (animation.Frames.Count == 0)
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

        }

        _mOverrideFrameTime = EditorGUILayout.FloatField("Override Frame Time", _mOverrideFrameTime);

        // Device
        animation.Device = (ChromaDevice2DEnum)EditorGUILayout.EnumPopup("Device", animation.Device);

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
        if (_mCurrentFrame < animation.Frames.Count)
        {
            EffectArray2dInput frame = animation.Frames[_mCurrentFrame];
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
            _mCurrentFrame,
            null == animation.Frames ? 0 : animation.Frames.Count));

        EditorGUILayout.LabelField("Duration:", string.Format("{0} second(s)",
            1.0f));


        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Previous"))
        {

        }

        if (GUILayout.Button("Next"))
        {

        }

        if (GUILayout.Button("Add"))
        {
            OnClickAddButton();
        }

        if (GUILayout.Button("Delete"))
        {

        }

        GUILayout.EndHorizontal();


        // Custom Curve
        animation.Curve = EditorGUILayout.CurveField("Edit Curve:", animation.Curve);
    }

    private void OnClickClearButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            List<EffectArray2dInput> frames = animation.Frames;
            frames[_mCurrentFrame] = ChromaUtils.CreateColors2D(device);
        }
    }

    private void OnClickFillButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            List<EffectArray2dInput> frames = animation.Frames;
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
    }

    private void OnClickCopyButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
        }
    }

    private void OnClickPasteButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
        }
    }

    private void OnClickRandomButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            List<EffectArray2dInput> frames = animation.Frames;
            frames[_mCurrentFrame] = ChromaUtils.CreateRandomColors2D(device);
        }
    }

    private void OnClickPreviewButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (_mCurrentFrame >= 0 &&
            _mCurrentFrame < animation.Frames.Count)
        {
            ChromaDevice2DEnum device = animation.Device;
            List<EffectArray2dInput> frames = animation.Frames;
            EffectArray2dInput colors = frames[_mCurrentFrame];
            EffectResponseId effect = ChromaUtils.CreateEffectCustom2D(_mApiChromaInstance, device, colors);
            if (effect.Result == 0)
            {
                ChromaUtils.SetEffect(_mApiChromaInstance, effect.Id);
                ChromaUtils.RemoveEffect(_mApiChromaInstance, effect.Id);
            }
        }
    }

    private void OnClickPlayButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (!animation.IsLoaded())
        {
            animation.Load(_mApiChromaInstance);
        }
        animation.Play(_mApiChromaInstance);
    }

    private void OnClickStopButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (animation.IsPlaying())
        {
            animation.Stop();
        }
    }

    private void OnClickLoadButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (!animation.IsLoaded())
        {
            animation.Load(_mApiChromaInstance);
        }
    }

    private void OnClickUnloadButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        if (animation.IsLoaded())
        {
            animation.Unload(_mApiChromaInstance);
        }
    }

    private void OnClickAddButton()
    {
        ChromaSDKAnimation2D animation = GetAnimation();
        EffectArray2dInput frame = ChromaUtils.CreateColors2D(animation.Device);
        animation.Frames.Add(frame);
    }
}