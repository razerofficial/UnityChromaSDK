using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

// Unity 3.X doesn't like namespaces
[ExecuteInEditMode]
[Serializable]
public class ChromaSDKAnimation2D : ChromaSDKBaseAnimation
{
    /// <summary>
    /// Only used to serialize to disk
    /// </summary>
    [Serializable]
    public class ColorFrame2D
    {
        [SerializeField]
        public ColorArray[] Colors;
    }

    [SerializeField]
    public ChromaDevice2DEnum Device = ChromaDevice2DEnum.Keyboard;

    [SerializeField]
    private ColorFrame2D[] _mFrames = null;

    [SerializeField]
    public AnimationCurve Curve = new AnimationCurve();

    public List<EffectArray2dInput> Frames
    {
        // returns a copy
        get
        {
            int maxRow = ChromaUtils.GetMaxRow(Device);
            int maxColumn = ChromaUtils.GetMaxColumn(Device);
            if (null == _mFrames ||
                _mFrames.Length == 0 ||
                null == _mFrames[0] ||
                null == _mFrames[0].Colors ||
                _mFrames[0].Colors.Length != maxRow ||
                null == _mFrames[0].Colors[0].Colors ||
                _mFrames[0].Colors[0].Colors.Length != maxColumn)
            {
                ClearFrames();
            }

            List<EffectArray2dInput> frames = new List<EffectArray2dInput>();
            for (int index = 0; index < _mFrames.Length; ++index)
            {
                var sourceFrame = _mFrames[index];
                var sourceRows = sourceFrame.Colors;
                var rows = new EffectArray2dInput();
                for (int i = 0; i < sourceRows.Length; ++i)
                {
                    var sourceRow = sourceRows[i].Colors;
                    var row = new List<int>();
                    for (int j = 0; j < sourceRow.Length; ++j)
                    {
                        int color = sourceRow[j];
                        row.Add(color);
                    }
                    rows.Add(row);
                }
                frames.Add(rows);
            }
            return frames;
        }
        set
        {
            List<EffectArray2dInput> sourceFrames = value;
            _mFrames = new ColorFrame2D[sourceFrames.Count];
            for (int index = 0; index < sourceFrames.Count; ++index)
            {
                var sourceRows = sourceFrames[index];
                var frame = new ColorFrame2D();
                var rows = new ColorArray[sourceRows.Count];
                for (int i = 0; i < sourceRows.Count; ++i)
                {
                    var sourceRow = sourceRows[i];
                    rows[i] = new ColorArray();
                    var row = new int[sourceRow.Count];
                    for (int j = 0; j < sourceRow.Count; ++j)
                    {
                        int color = sourceRow[j];
                        row[j] = color;
                    }
                    rows[i].Colors = row;
                }
                frame.Colors = rows;
                _mFrames[index] = frame;
            }
        }
    }

    public delegate void ChomaOnComplete2D(ChromaSDKAnimation2D animation);

    // Callback when animation completes
    private ChomaOnComplete2D _mOnComplete = null;

    // Effects needs to be loaded before the animation can be played
    private bool _mIsLoaded = false;

    private bool _mIsPlaying = false;
    private DateTime _mTime = DateTime.MinValue; //reset
    private int _mCurrentFrame = 0;
    private List<EffectResponseId> _mEffects = new List<EffectResponseId>();

    /// <summary>
    /// Pause the effects if the app loses focus
    /// </summary>
    private bool _mIsPaused = false;

    /// <summary>
    /// Get the list of effect ids
    /// </summary>
    /// <returns></returns>
    public override List<EffectResponseId> GetEffects()
    {
        return _mEffects;
    }

    /// <summary>
    /// Set frames to the default state
    /// </summary>
    public void ClearFrames()
    {
        int maxRow = ChromaUtils.GetMaxRow(Device);
        int maxColumn = ChromaUtils.GetMaxColumn(Device);
        _mFrames = new ColorFrame2D[1];
        var frame = new ColorFrame2D();
        var rows = new ColorArray[maxRow];
        for (int i = 0; i < maxRow; ++i)
        {
            rows[i] = new ColorArray();
            var row = new int[maxColumn];
            for (int j = 0; j < maxColumn; ++j)
            {
                row[j] = 0;
            }
            rows[i].Colors = row;
        }
        frame.Colors = rows;
        _mFrames[0] = frame;
    }

    /// <summary>
    /// Play the animation
    /// </summary>
    public void Play()
    {
        //Debug.Log("Play");

        if (!_mIsLoaded)
        {
            Load();
            //Debug.LogError("Play Animation has not been loaded!");
            return;
        }

        // clear on play to avoid unsetting on a loop
        _mOnComplete = null;

        _mTime = DateTime.Now; //Time when animation started
        _mIsPlaying = true;
        _mCurrentFrame = 0;

        if (_mCurrentFrame < _mEffects.Count)
        {
            if (!_mIsPaused &&
                ChromaConnectionManager.Instance.Connected)
            {
                //Debug.Log("SetEffect.");
                EffectResponseId effect = _mEffects[_mCurrentFrame];
                if (null != effect)
                {
                    ChromaUtils.SetEffect(effect.Id);
                }
                /*
                //Silently fail
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
                */
            }
        }
    }

    /// <summary>
    /// Play the animation and fire the OnComplete event
    /// </summary>
    /// <param name="onComplete"></param>
    public void PlayWithOnComplete(ChomaOnComplete2D onComplete)
    {
        //Debug.Log("PlayWithOnComplete");

        if (!_mIsLoaded)
        {
            // auto load if not loaded
            Load();
            //Debug.LogError("Animation has not been loaded!");
            return;
        }

        _mOnComplete = onComplete;

        _mTime = DateTime.Now; //Time when animation started
        _mIsPlaying = true;
        _mCurrentFrame = 0;

        if (_mCurrentFrame < _mEffects.Count)
        {
            if (!_mIsPaused &&
                ChromaConnectionManager.Instance.Connected)
            {
                //Debug.Log("SetEffect.");
                EffectResponseId effect = _mEffects[_mCurrentFrame];
                if (null != effect)
                {
                    ChromaUtils.SetEffect(effect.Id);
                }
                /*
                //Silently fail
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
                */
            }
        }
    }

    /// <summary>
    /// Stop the animation
    /// </summary>
    public void Stop()
    {
        //Debug.Log("Stop");
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
    /// Load the effects before playing
    /// </summary>
    public void Load()
    {
        //Debug.Log("Load:");

        if (_mIsLoaded)
        {
            //Debug.LogError("Animation has already been loaded!");
            return;
        }

        if (ChromaConnectionManager.Instance.Connected)
        {
            //Debug.Log(string.Format("Create {0} Frames.", Frames.Count));
            for (int i = 0; i < Frames.Count; ++i)
            {
                EffectArray2dInput frame = Frames[i];
                //Debug.Log("Create Effect.");
                EffectResponseId effect = ChromaUtils.CreateEffectCustom2D(Device, frame);
                /*
                // app can check the effect list for null or non-zero result
                if (null == effect ||
                    effect.Result != 0)
                {
                    Debug.LogError("Failed to create effect!");
                }
                */
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
    /// Unload the effects
    /// </summary>
    public void Unload()
    {
        //Debug.Log("Unload:");

        if (!_mIsLoaded)
        {
            //Debug.LogError("Animation has already been unloaded!");
            return;
        }

        for (int i = 0; i < _mEffects.Count; ++i)
        {
            EffectResponseId effect = _mEffects[i];
            if (null != effect)
            {
                ChromaUtils.RemoveEffect(effect.Id);
            }
            /*
            //Silently fail
            if (null != effect)
            {
                //Debug.Log("RemoveEffect.");
                EffectIdentifierResponse result = ChromaUtils.RemoveEffect(effect.Id);
                if (result.Result != 0)
                {
                    Debug.LogError("Failed to delete effect!");
                }
            }
            else
            {
                Debug.LogError("Failed to delete effect!");
            }
            */
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

    private void OnApplicationPause(bool pause)
    {
        //Debug.Log(string.Format("OnApplicationPause: {0}", pause));
        if (Application.isPlaying)
        {
            _mIsPaused = pause;
        }
        else
        {
            _mIsPaused = false;
        }
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
                if (!_mIsPaused &&
                    ChromaConnectionManager.Instance.Connected)
                {
                    //Debug.Log("SetEffect.");
                    EffectResponseId effect = _mEffects[_mCurrentFrame];
                    if (null != effect)
                    {
                        ChromaUtils.SetEffect(effect.Id);
                    }
                    /*
                    //Silently fail
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
                    */
                }
            }
            else
            {
                //UE_LOG(LogTemp, Log, TEXT("UChromaSDKPluginAnimation2DObject::Tick Animation Complete."));
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

    public override void RefreshCurve()
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
