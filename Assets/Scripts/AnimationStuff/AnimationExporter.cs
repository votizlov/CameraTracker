using System.IO;
using UnityEditor.Formats.Fbx.Exporter;
using UnityEngine;

namespace AnimationStuff
{
    public class AnimationExporter : MonoBehaviour
    {
        public AnimationRecorder recorder;

        private void Awake()
        {
            recorder.onRecordEnd += ExportGameObjects;
        }

        private void OnDisable()
        {
            recorder.onRecordEnd -= ExportGameObjects;
        }

        public void ExportGameObjects()
        {
            Debug.Log("Exporting anim to fbx");
            string filePath = Path.Combine(Application.dataPath, "Camera.fbx");
            ModelExporter.ExportObject(filePath, gameObject);

            // ModelExporter.ExportObject can be used instead of 
            // ModelExporter.ExportObjects to export a single game object
        }

    }
}
