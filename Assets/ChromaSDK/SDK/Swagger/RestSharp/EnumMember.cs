#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5

using System;

public class EnumMember : Attribute
{
    public string Value { get; set; }
}

#endif
