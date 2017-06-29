using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using System.Collections.Generic;
using UnityEngine;

// Unity 3.X doesn't like namespaces
[ExecuteInEditMode]
public class ChromaSDKAnimation1D : ChromaSDKBaseAnimation
{
    public AnimationCurve Curve = new AnimationCurve();

    public ChromaDevice1DEnum Device = ChromaDevice1DEnum.ChromaLink;

    public List<EffectArray1dInput> Frames = new List<EffectArray1dInput>();
}
