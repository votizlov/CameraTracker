using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static sdk_feed.Common.Extensions.SerializedPropertyArray;

namespace Events.Editor
{
    public static class EventsEditor
    {
        static List<bool> _isShowEventList = new List<bool>();
        private static SerializedProperty _events;

        public static void Draw(SerializedProperty events)
        {
            if (events == null) return;
            
            _events = events.FindPropertyRelative("_events");
            
            var type = (TypeInitialization) events.FindPropertyRelative("_typeAction").enumValueIndex;
            if (type == TypeInitialization.Custom) EditorGUILayout.PropertyField(events.FindPropertyRelative("_tag"));
            EditorGUILayout.PropertyField(events.FindPropertyRelative("_typeAction"));
            EditorGUILayout.PropertyField(events.FindPropertyRelative("_typeRun"));
            EditorGUILayout.Space();

            DrawEventsList();
        }

        private static void DrawEventsList()
        {
            if (_events.arraySize == 0)
            {
                if (GUILayout.Button("Add event")) _events.InsertArrayElementAtIndex(0, _isShowEventList);
                return;
            }
            AppendShowEventList();
            
            EditorGUILayout.LabelField("Events");
		    EditorGUI.indentLevel += 1;
            for (var i = 0; i < _events.arraySize; i++)
            {
                var evt = _events.GetArrayElementAtIndex(i);
                DrawEvent(evt, i);
            }
            EditorGUI.indentLevel -= 1;
        }

        private static void AppendShowEventList()
        {
            if (_isShowEventList.Count >= _events.arraySize) return;
            for (var i = _isShowEventList.Count; i < _events.arraySize; ++i) _isShowEventList.Add(true);
        }

        private static void DrawEvent(SerializedProperty evt, int index)
        {
            DrawEventHeader(evt, index);
            if (index >= _isShowEventList.Count || !_isShowEventList[index]) return;
            
            EditorGUILayout.PropertyField(evt.FindPropertyRelative("_delayInitialization"), true);
            EditorGUILayout.PropertyField(evt.FindPropertyRelative("_event"), true);
        }

        private static void DrawEventHeader(SerializedProperty evt, int index)
        {
            EditorGUILayout.BeginHorizontal();
            var header = "Delay Initialization: " + evt.FindPropertyRelative("_delayInitialization").floatValue;
            _isShowEventList[index] = EditorGUILayout.Foldout(_isShowEventList[index], header);

            if (GUILayout.Button("+", GUILayout.Width(18))) _events.InsertArrayElementAtIndex(index, _isShowEventList);
            if (GUILayout.Button("▲", GUILayout.Width(18))) _events.MoveArrayElement(index, index - 1, _isShowEventList);
            if (GUILayout.Button("▼", GUILayout.Width(18))) _events.MoveArrayElement(index, index + 1, _isShowEventList);
            if (GUILayout.Button("x", GUILayout.Width(18))) _events.DeleteArrayElementAtIndex(index, _isShowEventList);
            EditorGUILayout.EndHorizontal();
        }
    }
}