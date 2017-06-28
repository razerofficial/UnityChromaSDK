using ChromaSDK;
using ChromaSDK.Api;
using ChromaSDK.ChromaPackage.Model;
using System.Collections.Generic;
using UnityEngine;

// Unity 3.X doesn't like namespaces
public class ChromaSDKAnimation2D : MonoBehaviour
{
    public ChromaDevice2DEnum Device = ChromaDevice2DEnum.Keyboard;
    public float Duration = 1f;
    public List<EffectArray2dInput> Frames;

    public delegate void ChomaOnComplete2D(ChromaSDKAnimation2D animation);

    // Callback when animation completes
    private ChomaOnComplete2D _mOnComplete;

    // Effects needs to be loaded before the animation can be played
    private bool _mIsLoaded;

    private bool _mIsPlaying;
    private float _mTime;
    private int _mCurrentFrame;
    private List<EffectResponseId> _mEffects;

    /// <summary>
    /// Play the animation
    /// </summary>
    public void Play(ChromaApi api)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod());

        if (!_mIsLoaded)
        {
            Debug.LogError("Play Animation has not been loaded!");
            return;
        }

        // clear on play to avoid unsetting on a loop
        _mOnComplete = null;

        _mTime = 0.0f;
        _mIsPlaying = true;
        _mCurrentFrame = 0;

        if (_mCurrentFrame < _mEffects.Count)
        {
            Debug.Log("SetEffect.");
            EffectResponseId effect = _mEffects[_mCurrentFrame];
            EffectIdentifierResponse result = ChromaUtils.SetEffect(api, effect.Id);
            if (null == result ||
                result.Result != 0)
            {
                Debug.LogError("Play: Failed to set effect!");
            }
        }
    }

    /// <summary>
    /// Play the animation and fire the OnComplete event
    /// </summary>
    /// <param name="onComplete"></param>
    public void PlayWithOnComplete(ChromaApi api, ChomaOnComplete2D onComplete)
    {

    }

    /// <summary>
    /// Stop the animation
    /// </summary>
    public void Stop()
    {

    }

    /// <summary>
    /// Is the animation currently playing?
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        return _mIsPlaying;
    }

    /// <summary>
    /// Load the effects before playing
    /// </summary>
    public void Load(ChromaApi api)
    {

    }

    /// <summary>
    /// Check if the animation has loaded
    /// </summary>
    /// <returns></returns>
    public bool IsLoaded()
    {
        return _mIsLoaded;
    }

    /// <summary>
    /// Unload the effects
    /// </summary>
    public void Unload(ChromaApi api)
    {

    }

    private float GetTime(int index)
    {
        return 0f;
    }

    private void Update()
    {
    }
}
