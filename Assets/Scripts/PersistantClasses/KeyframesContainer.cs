using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using Keyframe = DataStructs.Keyframe;

public class KeyframesContainer : MonoBehaviour
{
    [FormerlySerializedAs("Keyframes")] public List<DataStructs.Keyframe> keyframes;

    private static KeyframesContainer s_Instance;

    public static KeyframesContainer GetInstance => s_Instance;

    private void Awake()
    {
        keyframes = new List<Keyframe>();
        s_Instance = this;
        
        DontDestroyOnLoad(transform.gameObject);
    }
}
