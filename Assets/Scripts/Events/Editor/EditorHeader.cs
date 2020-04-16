using UnityEditor;
using UnityEngine;

namespace Events.Editor
{
     public static class  EditorHeader
    {
        public static void Header(this UnityEditor.Editor property)
        {
            var script = MonoScript.FromMonoBehaviour((MonoBehaviour)property.target);
            EditorGUI.BeginDisabledGroup(true);
			script = EditorGUILayout.ObjectField("Script:", script, typeof(MonoScript), false) as MonoScript;
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();
        }
        
    }
}