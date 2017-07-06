using ChromaSDK;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaConnectionManager))]
public class ChromaConnectionEditor : ChromaSDKAnimationBaseEditor
{
    public override void OnInspectorGUI()
    {
        //show parent
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Status:",
            ChromaConnectionManager.Instance.Connected ? "Connected" : "Not Connected");

        if (GUILayout.Button("Connect"))
        {
            ChromaConnectionManager.Instance.Connect();
            Repaint();
        }

        if (GUILayout.Button("Disconnect"))
        {
            ChromaConnectionManager.Instance.Disconnect();
            Repaint();
        }
    }
}
