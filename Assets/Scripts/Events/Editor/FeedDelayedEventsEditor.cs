using UnityEditor;
using System.Collections.Generic;
using Events.Editor;
using sdk_feed.Common.Extensions;
using UnityEngine;

namespace Events
{
    [CustomEditor(typeof(DelayedEvents), true)]
    [CanEditMultipleObjects]
    public class FeedDelayedEventsEditor : UnityEditor.Editor
    {
        //events
        private SerializedProperty _events;
        private static readonly List<bool> _isShowEvents = new List<bool>();
        private bool _isDeleteEvent;


        private void OnEnable()
        {
            _events = serializedObject.FindProperty("_events");
            FillShowEventsList();
        }


        public override void OnInspectorGUI()
        {
            this.Header();
			serializedObject.Update();
            DrawEvents();
            DrawButtons();
        }

        private void DrawEvents()
        {
            for (var i = 0; i < _events.arraySize; i++) DrawEvent(i, _events.GetArrayElementAtIndex(i));
            if (serializedObject.hasModifiedProperties) serializedObject.ApplyModifiedProperties();
        }

        private void DrawEvent(in int index, in SerializedProperty evt)
        {
            DrawHeaderEvent(index, evt);
            if (index < _isShowEvents.Count && _isShowEvents[index]) EventsEditor.Draw(evt);
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        private void DrawHeaderEvent(in int index, in SerializedProperty evt)
        {
            EditorGUILayout.BeginHorizontal();
            _isShowEvents[index] = EditorGUILayout.BeginFoldoutHeaderGroup(_isShowEvents[index], GetHeaderEventName(evt));
            
            if (GUILayout.Button("+", GUILayout.Width(18))) _events.InsertArrayElementAtIndex(index, _isShowEvents);
            if (GUILayout.Button("▲", GUILayout.Width(18))) _events.MoveArrayElement(index, index - 1, _isShowEvents);
            if (GUILayout.Button("▼", GUILayout.Width(18))) _events.MoveArrayElement(index, index + 1, _isShowEvents);
            if (GUILayout.Button("x", GUILayout.Width(18))) _events.DeleteArrayElementAtIndex(index, _isShowEvents);
            
            EditorGUILayout.EndHorizontal();
        }

        private static GUIContent GetHeaderEventName(in SerializedProperty evt)
        {
            var type = evt.FindPropertyRelative("_typeAction");
            var delay = evt.FindPropertyRelative("_typeRun");
            var isTypeAsCustom = type.enumNames[type.enumValueIndex] == TypeInitialization.Custom.ToString();
            var evtTag = evt.FindPropertyRelative("_tag").stringValue;
            var tag = isTypeAsCustom && !string.IsNullOrEmpty(evtTag) ? evtTag + " :: " : "";
            return new GUIContent(tag + type.enumNames[type.enumValueIndex] + " :: " + delay.enumNames[delay.enumValueIndex]);
        }

        private void DrawButtons()
        {
            if (_events.arraySize > 0) return;
            if (!GUILayout.Button("Add Events Sequence")) return;
            
            _events.InsertArrayElementAtIndex(_events.arraySize, _isShowEvents);
            serializedObject.ApplyModifiedProperties();
        }
        
        private void FillShowEventsList()
        {
            if (_isShowEvents.Count >= _events.arraySize) return;
            while (_isShowEvents.Count < _events.arraySize)  _isShowEvents.Add(true);
        }
    }
}