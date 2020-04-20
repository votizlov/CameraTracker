#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using AnimationStuff;
using UnityEditor;
using UnityEngine;

//todo я бля хз как кватернион вращения правильно записать в курву
public class KeyframesToAnim : MonoBehaviour
{
    private KeyframesContainer container;
    public String clipName;
    public bool exportToFbx = true;
    public CameraAnimationExporter FBXexporter;
    private AnimationClip clip;
    private AnimationCurve curveX;
    private AnimationCurve curveY;
    private AnimationCurve curveZ;
    private AnimationCurve curveRot;
    private float currTime = 0;

    private void Start()
    {
        container = KeyframesContainer.GetInstance;
    }

    public void CreateAnim()
    {
        Debug.Log(container);
        if (container.keyframes.Count == 0)
        {
            Debug.Log("No keyframes recorded");
            return;
        }

        clip = new AnimationClip();
        curveX = AnimationCurve.EaseInOut(0, 0, 0, 0);
        curveY = AnimationCurve.EaseInOut(0, 0, 0, 0);
        curveZ = AnimationCurve.EaseInOut(0, 0, 0, 0);
        Debug.Log("Exporting to .anim");
        exportKeyframes();
    }

    private void exportKeyframes()
    {
        foreach (var keyframe in container.keyframes)
        {
            curveX.AddKey(currTime, keyframe.position.x);
            curveY.AddKey(currTime, keyframe.position.y);
            curveZ.AddKey(currTime, keyframe.position.z);
            currTime++;
        }

        OnExportSucsess();
    }

    private void OnExportSucsess()
    {
        clip.SetCurve("", typeof(Transform), "position.x", curveX);
        clip.SetCurve("", typeof(Transform), "position.y", curveY);
        clip.SetCurve("", typeof(Transform), "position.z", curveZ);
        AssetDatabase.CreateAsset(clip, "Assets/" + clipName + ".anim");
        Debug.Log("Created asset .anim");
        FBXexporter.AnimToFbx(clipName);
    }
}
#endif