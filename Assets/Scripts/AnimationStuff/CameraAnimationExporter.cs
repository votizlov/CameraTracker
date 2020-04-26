#if UNITY_EDITOR

using System;
using System.IO;
using UnityEditor;
using UnityEditor.Formats.Fbx.Exporter;
using UnityEngine;

namespace AnimationStuff
{
    public class CameraAnimationExporter : MonoBehaviour
    {
        public GameObject cameraToExport;
        public String animName;
        public AnimationClip clip;

        public void AnimToFbx()
        {
            //todo solve legacy problem and attach animation to controller
            cameraToExport.GetComponent<Animation>().clip =
                AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/" + animName + ".anim");
            ExportGameObjects();
        }

        public void AnimToFbx(String animName)
        {
            this.animName = animName;
            AnimToFbx();
        }

        private void ExportGameObjects()
        {
            Debug.Log("Exporting anim to fbx");
            string filePath = "Assets/" + animName + ".fbx";//Path.Combine(Application.dataPath, "Camera.fbx");
            ModelExporter.ExportObject(filePath, cameraToExport);

            
            // ModelExporter.ExportObject can be used instead of 
            // ModelExporter.ExportObjects to export a single game object
        }

        public void exportObject(GameObject obj)
        {
            cameraToExport = obj;
            ExportGameObjects();
        }

    }
}
#endif