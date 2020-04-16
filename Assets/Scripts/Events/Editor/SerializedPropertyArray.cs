using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace sdk_feed.Common.Extensions
{
    public static class SerializedPropertyArray
    {
        public static void DrawArray(this SerializedProperty property, GUIContent content = null)
        {
            content = content ?? new GUIContent(property.name);
            EditorGUILayout.PropertyField(property, content);
            if (!property.isExpanded) return;

            for (var i = 0; i < property.arraySize; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i));
                if (GUILayout.Button("+", GUILayout.Width(18))) InsertArrayElementAtIndex(property, i);
                if (GUILayout.Button("▲", GUILayout.Width(18))) MoveArrayElement(property, i, i - 1);
                if (GUILayout.Button("▼", GUILayout.Width(18))) MoveArrayElement(property, i, i + 1);
                if (GUILayout.Button ("x", GUILayout.Width(18))) DeleteArrayElementAtIndex(property, i);
                EditorGUILayout.EndHorizontal();
            }
        }
        
        private static void InsertArrayElementAtIndex(SerializedProperty property, int index)
        {
            if (index < 0 || index > property.arraySize) return;
            property.InsertArrayElementAtIndex(index);
        }
        
        private static void DeleteArrayElementAtIndex(SerializedProperty property, int index)
        {
            if (CheckIndexOutOfRange(property, index)) return;
            
            property.DeleteArrayElementAtIndex(index);
        }
        public static void MoveArrayElement(SerializedProperty property, int srcIndex, int dstIndex)
        {
            if (CheckIndexOutOfRange(property, srcIndex) || CheckIndexOutOfRange(property, dstIndex)) return;
            property.MoveArrayElement(srcIndex, dstIndex);
        }
        
        public static void InsertArrayElementAtIndex(this SerializedProperty property, int index, List<bool> isShowElement)
        {
            if (index < 0 || index > property.arraySize) return;
            
            property.InsertArrayElementAtIndex(index);
            isShowElement.Insert(index, true);
        }
        
        public static void DeleteArrayElementAtIndex(this SerializedProperty property, int index, List<bool> isShowElement)
        {
            if (CheckIndexOutOfRange(property, index)) return;
            
            property.DeleteArrayElementAtIndex(index);
            isShowElement.RemoveAt(index);
        }
        
        public static void MoveArrayElement(this SerializedProperty property, int srcIndex, int dstIndex, List<bool> isShowElement)
        {
            if (CheckIndexOutOfRange(property, srcIndex) || CheckIndexOutOfRange(property, dstIndex)) return;
            
            property.MoveArrayElement(srcIndex, dstIndex);
            var curValue = isShowElement[srcIndex];
            isShowElement[srcIndex] = isShowElement[dstIndex];
            isShowElement[dstIndex] = curValue;
        }

        private static bool CheckIndexOutOfRange(SerializedProperty property, int index) => index < 0 || index >= property.arraySize;
    }
}