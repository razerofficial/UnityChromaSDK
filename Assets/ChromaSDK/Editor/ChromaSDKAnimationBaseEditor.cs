// Access to Types and Utils
using ChromaSDK;
// Access to Chroma data structures
using ChromaSDK.ChromaPackage.Model;
// Access to the Chroma API
using ChromaSDK.Api;
// Access to the Session data structures
using RazerSDK.ChromaPackage.Model;
// Access to the Session API
using RazerSDK.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

/// <summary>
/// The purpose of this class is to manage the api connection
/// </summary>
public class ChromaSDKAnimationBaseEditor : Editor
{
    protected const string KEY_FOLDER_ANIMATIONS = "folder/animations";
    protected const string KEY_FOLDER_IMAGES = "folder/images";
    protected const string CONTROL_DURATION = "control-duration";
    protected const string CONTROL_OVERRIDE = "control-override";
    protected readonly Color ORANGE = new Color(1f, 0.5f, 0f, 1f);
    protected readonly Color PURPLE = new Color(1f, 0f, 1f, 1f);

    protected static Texture2D _sTextureClear = null;

    protected float _mOverrideFrameTime = 0.1f;

    protected Color _mColor = Color.red;

    protected int _mCurrentFrame = 0;

    private static List<IUpdate> _sTargets = new List<IUpdate>();

    protected void SetupBlankTexture()
    {
        if (null == _sTextureClear)
        {
            _sTextureClear = new Texture2D(1, 1, TextureFormat.RGB24, false);
            _sTextureClear.SetPixel(0, 0, Color.white);
            _sTextureClear.Apply();
        }
    }

    #region Move to a connection manager class

    #region Handle Coroutines in edit-mode

    /// <summary>
    /// Keep track of initialization
    /// </summary>
    private static bool _sHasEditorUpdates = false;

    /// <summary>
    /// Start editor updates
    /// </summary>
    public static void StartEditorUpdates()
    {
        if (!_sHasEditorUpdates)
        {
            Debug.Log("StartEditorUpdates:");
            _sHasEditorUpdates = true;
            EditorApplication.update += EditorUpdate;
            ChromaConnectionManager.Instance.Connect();
        }
    }

    //Stop editor updates
    public static void StopEditorUpdates()
    {
        if (_sHasEditorUpdates)
        {
            Debug.Log("StopEditorUpdates:");
            _sHasEditorUpdates = false;
            EditorApplication.update -= EditorUpdate;
        }
    }

    public override void OnInspectorGUI()
    {
        // Add the target to a list of targets that will be updated
        IUpdate targetUpdater = (IUpdate)target;
        int i = 0;
        bool found = false;
        while (i < _sTargets.Count)
        {
            IUpdate updater = _sTargets[i];
            if (null != updater)
            {
                if (updater == targetUpdater)
                {
                    found = true;
                    break;
                }
                ++i;
            }
            else
            {
                _sTargets.RemoveAt(i);
            }
        }
        if (!found)
        {
            _sTargets.Add(targetUpdater);
        }
    }

    public static void EditorUpdate()
    {
        // stop editor updates if compiling and disconnect
        if (EditorApplication.isCompiling)
        {
            StopEditorUpdates();
            ChromaConnectionManager.Instance.Disconnect();
        }
        else
        {
            // Connection Manager updates aren't needed in PlayMode,
            // if the ConnectionManager is in the Scene
            if (!Application.isPlaying)
            {
                // keep updates happening in edit mode
                ChromaConnectionManager.Instance.Update();
            }
            
            // Update the targets being inspected
            int i = 0;
            while (i < _sTargets.Count)
            {
                IUpdate updater = _sTargets[i];
                if (null != updater)
                {
                    updater.Update();
                    ++i;
                }
                else
                {
                    _sTargets.RemoveAt(i);
                }
            }
        }
    }

    #endregion

    /// <summary>
    /// OnEnable is invoked on play, or while playing after compile
    /// </summary>
    private void OnEnable()
    {
        //Debug.Log("ChromaSDKAnimationBaseEditor: OnEnable");
        StartEditorUpdates();
    }

    #endregion
}
