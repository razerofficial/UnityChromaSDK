using ChromaSDK;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaConnectionManager))]
public class ChromaConnectionEditor : ChromaSDKAnimationBaseEditor
{
    public override void OnInspectorGUI()
    {
        if (!EditorApplication.isCompiling)
        {
            //show parent
            base.OnInspectorGUI();

            bool connecting = ChromaConnectionManager.Instance.Connecting;
            bool connected = ChromaConnectionManager.Instance.Connected;

            EditorGUILayout.LabelField("Status:",
                connected ? "Connected" : connecting ? "Connecting..." : "Not Connected");

            GUI.enabled = !connected && !connecting;
            if (GUILayout.Button("Connect"))
            {
                ChromaConnectionManager.Instance.Connect();
                Repaint();
            }

            GUI.enabled = connected && !connecting;
            if (GUILayout.Button("Disconnect"))
            {
                ChromaConnectionManager.Instance.Disconnect();
                Repaint();
            }

            GUI.enabled = true;
        }
    }
}
