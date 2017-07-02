using System;
using UnityEngine;

// Unity 3.X doesn't like namespaces
public class ChromaSDKBaseAnimation : MonoBehaviour
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

    public virtual void Update()
    {

    }
}
