using ChromaSDK;
using ChromaSDK.Api;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

// Unity 3.X doesn't like namespaces
[ExecuteInEditMode]
public class ChromaSDKAnimation1D : ChromaSDKBaseAnimation
{
    [SerializeField]
    public ChromaDevice1DEnum Device = ChromaDevice1DEnum.ChromaLink;

    [SerializeField]
    private ColorArray[] _mFrames = null;

    [SerializeField]
    public AnimationCurve Curve = new AnimationCurve();

    public List<EffectArray1dInput> Frames
    {
        // returns a copy
        get
        {
            int maxLeds = ChromaUtils.GetMaxLeds(Device);
            if (null == _mFrames ||
                _mFrames.Length == 0 ||
                null == _mFrames[0] ||
                null == _mFrames[0].Colors ||
                _mFrames[0].Colors.Length != maxLeds)
            {
                ClearFrames();
            }

            List<EffectArray1dInput> frames = new List<EffectArray1dInput>();
            for (int index = 0; index < _mFrames.Length; ++index)
            {
                var sourceFrame = _mFrames[index];
                var sourceElements = sourceFrame.Colors;
                var elements = new EffectArray1dInput();
                for (int i = 0; i < sourceElements.Length; ++i)
                {
                    var color = sourceElements[i];
                    elements.Add(color);
                }
                frames.Add(elements);
            }
            return frames;
        }
        set
        {
            List<EffectArray1dInput> sourceFrames = value;
            _mFrames = new ColorArray[sourceFrames.Count];
            for (int index = 0; index < sourceFrames.Count; ++index)
            {
                var sourceElements = sourceFrames[index];
                var frame = new ColorArray();
                var elements = new int[sourceElements.Count];
                for (int i = 0; i < sourceElements.Count; ++i)
                {
                    int color = (int)sourceElements[i];
                    elements[i] = color;
                }
                frame.Colors = elements;
                _mFrames[index] = frame;
            }
        }
    }

    public delegate void ChomaOnComplete1D(ChromaSDKAnimation1D animation);

    // Callback when animation completes
    private ChomaOnComplete1D _mOnComplete = null;

    // Effects needs to be loaded before the animation can be played
    private bool _mIsLoaded = false;

    private bool _mIsPlaying = false;
    private DateTime _mTime = DateTime.MinValue; //reset
    private int _mCurrentFrame = 0;
    private List<EffectResponseId> _mEffects = new List<EffectResponseId>();

    /// <summary>
    /// Set frames to the default state
    /// </summary>
    public void ClearFrames()
    {
        int maxLeds = ChromaUtils.GetMaxLeds(Device);
        _mFrames = new ColorArray[1];
        var frame = new ColorArray();
        var elements = new int[maxLeds];
        for (int i = 0; i < maxLeds; ++i)
        {
            elements[i] = 0;
        }
        frame.Colors = elements;
        _mFrames[0] = frame;
    }

    /// <summary>
    /// Play the animation
    /// </summary>
    public void Play()
    {
        Debug.Log("Play");

        if (!_mIsLoaded)
        {
            Debug.LogError("Play Animation has not been loaded!");
            return;
        }

        // clear on play to avoid unsetting on a loop
        _mOnComplete = null;

        _mTime = DateTime.Now; //Time when animation started
        _mIsPlaying = true;
        _mCurrentFrame = 0;

        if (_mCurrentFrame < _mEffects.Count)
        {
            //Debug.Log("SetEffect.");
            EffectResponseId effect = _mEffects[_mCurrentFrame];
            if (null != effect)
            {
                EffectIdentifierResponse result = ChromaUtils.SetEffect(effect.Id);
                if (null == result ||
                    result.Result != 0)
                {
                    Debug.LogError("Failed to set effect!");
                }
            }
            else
            {
                Debug.LogError("Failed to set effect!");
            }
        }
    }

    /// <summary>
    /// Play the animation and fire the OnComplete event
    /// </summary>
    /// <param name="onComplete"></param>
    public void PlayWithOnComplete(ChomaOnComplete1D onComplete)
    {
        //Debug.Log("PlayWithOnComplete");

        if (!_mIsLoaded)
        {
            Debug.LogError("Animation has not been loaded!");
            return;
        }

        _mOnComplete = onComplete;

        _mTime = DateTime.Now; //Time when animation started
        _mIsPlaying = true;
        _mCurrentFrame = 0;

        if (_mCurrentFrame < _mEffects.Count)
        {
            //Debug.Log("SetEffect.");
            EffectResponseId effect = _mEffects[_mCurrentFrame];
            if (null != effect)
            {
                EffectIdentifierResponse result = ChromaUtils.SetEffect(effect.Id);
                if (null == result ||
                    result.Result != 0)
                {
                    Debug.LogError("Failed to set effect!");
                }
            }
            else
            {
                Debug.LogError("Failed to set effect!");
            }
        }
    }

    /// <summary>
    /// Stop the animation
    /// </summary>
    public void Stop()
    {
        Debug.Log("Stop");
        _mIsPlaying = false;
        _mTime = DateTime.MinValue; //reset
        _mCurrentFrame = 0;
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
    public void Load()
    {
        //Debug.Log("Load:");

        if (_mIsLoaded)
        {
            Debug.LogError("Animation has already been loaded!");
            return;
        }

        if (ChromaConnectionManager.Instance.Connected)
        {
            for (int i = 0; i < Frames.Count; ++i)
            {
                EffectArray1dInput frame = Frames[i];
                EffectResponseId effect = ChromaUtils.CreateEffectCustom1D(Device, frame);
                if (null == effect ||
                    effect.Result != 0)
                {
                    Debug.LogError("Failed to create effect!");
                }
                _mEffects.Add(effect);
            }

            _mIsLoaded = true;
        }
    }

    /// <summary>
    /// Check if the animation has loaded
    /// </summary>
    /// <returns></returns>
    public bool IsLoaded()
    {
        //Debug.Log(string.Format("IsLoaded={0}", _mIsLoaded));
        return _mIsLoaded;
    }

    /// <summary>
    /// Reset to the default state
    /// </summary>
    public void Reset()
    {
        _mOnComplete = null;
        _mIsLoaded = false;
        _mIsPlaying = false;
        _mTime = DateTime.MinValue;
        _mCurrentFrame = 0;
        _mEffects.Clear();
    }

    /// <summary>
    /// Unload the effects
    /// </summary>
    public void Unload()
    {
        //Debug.Log("Unload:");

        if (!_mIsLoaded)
        {
            Debug.LogError("Animation has already been unloaded!");
            return;
        }

        for (int i = 0; i < _mEffects.Count; ++i)
        {
            EffectResponseId effect = _mEffects[i];
            if (null != effect)
            {
                //Debug.Log("RemoveEffect.");
                EffectIdentifierResponse result = ChromaUtils.RemoveEffect(effect.Id);
                if (null == result ||
                    result.Result != 0)
                {
                    Debug.LogError("Failed to delete effect!");
                }
            }
            else
            {
                Debug.LogError("Failed to delete effect!");
            }
        }
        _mEffects.Clear();
        _mIsLoaded = false;
    }

    private float GetTime(int index)
    {
        if (index >= 0 &&
            index < Curve.keys.Length)
        {
            return Curve.keys[index].time;
        }
        return 0.033f;
    }

    public override void Update()
    {
        base.Update();

        if (_mTime == DateTime.MinValue)
        {
            return;
        }

        float time = (float)(DateTime.Now - _mTime).TotalSeconds;
        float nextTime = GetTime(_mCurrentFrame);
        if (nextTime < time)
        {
            ++_mCurrentFrame;
            if (_mCurrentFrame < _mEffects.Count)
            {
                if (ChromaConnectionManager.Instance.Connected)
                {
                    //Debug.Log("SetEffect.");
                    EffectResponseId effect = _mEffects[_mCurrentFrame];
                    if (null != effect)
                    {
                        EffectIdentifierResponse result = ChromaUtils.SetEffect(effect.Id);
                        if (null == result ||
                            result.Result != 0)
                        {
                            Debug.LogError("Failed to set effect!");
                        }
                    }
                    else
                    {
                        Debug.LogError("Failed to set effect!");
                    }
                }
            }
            else
            {
                //UE_LOG(LogTemp, Log, TEXT("UChromaSDKPluginAnimation1DObject::Tick Animation Complete."));
                _mIsPlaying = false;
                _mTime = DateTime.MinValue; //reset
                _mCurrentFrame = 0;

                // execute the complete event if set
                if (null != _mOnComplete)
                {
                    _mOnComplete.Invoke(this);
                }
            }
        }
    }

    public void RefreshCurve()
    {
        //copy times
        List<float> times = new List<float>();
        for (int i = 0; i < Curve.keys.Length; ++i)
        {
            Keyframe key = Curve.keys[i];
            float time = key.time;
            if (time <= 0.0f)
            {
                time = 0.033f;
            }
            times.Add(time);
        }

        // make sure curve data doesn't have any extra items
        while (times.Count > Frames.Count)
        {
            int lastIndex = times.Count - 1;
            times.RemoveAt(lastIndex);
        }

        // make sure curve data has the same number of items as frames
        while (times.Count < Frames.Count)
        {
            if (times.Count == 0)
            {
                times.Add(1.0f);
            }
            else
            {
                int lastIndex = times.Count - 1;
                float time = times[lastIndex] + 1.0f;
                times.Add(time);
            }
        }

        // reset array
        while (Curve.keys.Length > 0)
        {
            Curve.RemoveKey(0);
        }
        for (int i = 0; i < times.Count; ++i)
        {
            float time = times[i];
            Curve.AddKey(time, 0.0f);
        }
    }
}
