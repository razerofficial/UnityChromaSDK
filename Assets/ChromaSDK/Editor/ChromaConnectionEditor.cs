using ChromaSDK;
using RazerSDK.ChromaPackage.Model;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaConnectionManager))]
public class ChromaConnectionEditor : ChromaSDKAnimationBaseEditor
{
    readonly string[] DEVICES =
    {
        "chromalink",
        "headset",
        "keyboard",
        "keypad",
        "mouse",
        "mousepad",
    };

    public override void OnInspectorGUI()
    {
        if (!EditorApplication.isCompiling)
        {
            //show parent
            base.OnInspectorGUI();

            ChromaConnectionManager connectionManager = ChromaConnectionManager.Instance;

            if (null == connectionManager._mInfo)
            {
                connectionManager.SetupDefaultInfo();
            }

            ChromaSdkInput info = connectionManager._mInfo;

            info.Author.Contact = EditorGUILayout.TextField("Author.Contact:", info.Author.Contact);
            info.Author.Name = EditorGUILayout.TextField("Author.Name:", info.Author.Name);
            info.Category = EditorGUILayout.TextField("Category:", info.Category);
            info.Description = EditorGUILayout.TextField("Description:", info.Description);
            foreach (string device in DEVICES)
            {
                string label = string.Format("Support {0}:", device);
                bool isChecked = EditorGUILayout.Toggle(label, info.DeviceSupported.Contains(device));
                if (isChecked)
                {
                    if (!info.DeviceSupported.Contains(device))
                    {
                        info.DeviceSupported.Add(device);
                    }
                }
                else
                {
                    if (info.DeviceSupported.Contains(device))
                    {
                        info.DeviceSupported.Remove(device);
                    }
                }
            }
            info.Title = EditorGUILayout.TextField("Title:", info.Title);

            bool connecting = connectionManager.Connecting;
            bool connected = connectionManager.Connected;

            EditorGUILayout.LabelField("Status:",
                connected ? "Connected" : connecting ? "Connecting..." : "Not Connected");

            GUI.enabled = !connected && !connecting;
            if (GUILayout.Button("Connect"))
            {
                connectionManager.Connect();
                Repaint();
            }

            GUI.enabled = connected && !connecting;
            if (GUILayout.Button("Disconnect"))
            {
                connectionManager.Disconnect();
                Repaint();
            }

            GUI.enabled = true;
        }
    }
}
