using ChromaSDK;
using ChromaSDK.Api;
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

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // backup original color
        Color oldBackgroundColor = GUI.backgroundColor;

        ChromaSDKAnimation2D animation = (ChromaSDKAnimation2D)target;

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

        }

        if (GUILayout.Button("Fill"))
        {

        }

        if (GUILayout.Button("Random"))
        {

        }

        if (GUILayout.Button("Copy"))
        {

        }

        if (GUILayout.Button("Paste"))
        {

        }

        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Preview"))
        {

        }

        if (GUILayout.Button("Play"))
        {
            animation.Play(_mApiChromaInstance);
        }

        if (GUILayout.Button("Stop"))
        {
            animation.Stop();
        }

        if (GUILayout.Button("Load"))
        {
            animation.Load(_mApiChromaInstance);
        }

        if (GUILayout.Button("Unload"))
        {
            animation.Unload(_mApiChromaInstance);
        }

        GUILayout.EndHorizontal();

        int maxRow = ChromaUtils.GetMaxRow(animation.Device);
        int maxColumn = ChromaUtils.GetMaxColumn(animation.Device);

        GUILayout.Label(string.Format("{0} x {1}", maxRow, maxColumn));

        // Preview

        GUI.backgroundColor = Color.red;

        for (int i = 0; i < maxRow; ++i)
        {
            GUILayout.BeginHorizontal();

            for (int j = 0; j < maxColumn; ++j)
            {
                if (GUILayout.Button(" ", GUILayout.Width(12)))
                {

                }
            }

            GUILayout.EndHorizontal();
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

        }

        if (GUILayout.Button("Delete"))
        {

        }

        GUILayout.EndHorizontal();


        // Custom Curve
        animation.Curve = EditorGUILayout.CurveField("Edit Curve:", animation.Curve);
    }
}
