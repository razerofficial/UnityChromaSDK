using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChromaSDKAnimation1D))]
public class ChromaSDKAnimation1DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ChromaSDKAnimation1D myTarget = (ChromaSDKAnimation1D)target;
    }
}
