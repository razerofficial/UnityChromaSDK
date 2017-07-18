using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

// Unity 3.X doesn't like namespaces
public class ChromaSDKBaseAnimation : MonoBehaviour, IUpdate
{
    /// <summary>
    /// Only used to serialize to disk
    /// </summary>
    [Serializable]
    public class ColorArray
    {
        [SerializeField]
        public int[] Colors;
    }

    /// <summary>
    /// Get the list of effect ids
    /// </summary>
    /// <returns></returns>
    public virtual List<EffectResponseId> GetEffects()
    {
        return null;
    }

    /// <summary>
    /// Update event to invoke in edit-mode
    /// </summary>
    public virtual void Update()
    {
        if (ChromaConnectionManager.Instance.Connected)
        {
        }
    }
}
