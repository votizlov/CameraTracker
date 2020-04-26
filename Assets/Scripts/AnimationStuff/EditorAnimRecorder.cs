#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using AnimationStuff;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

//Я ЗА ЭТОТ КОД НЕ ОТВЕЧАЮ
public class EditorAnimRecorder : MonoBehaviour
{
    public AnimationClip clip;
    public CameraAnimationExporter exporter;
    public bool toExportFbx;
    public GameObject objToExport;

    private GameObjectRecorder m_Recorder;

    void Start()
    {
        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
        if(toExportFbx)
            exporter.exportObject(objToExport);
    }

    void LateUpdate()
    {
        if (clip == null)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }

    void OnDisable()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            //m_Recorder.SaveToClip(clip);
        }
    }
}
#endif