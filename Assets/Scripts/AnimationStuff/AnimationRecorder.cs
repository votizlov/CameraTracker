using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace AnimationStuff
{
    public class AnimationRecorder : MonoBehaviour
    {
        private bool isRecording;
        public float recordInterval;
        public event Action onRecordEnd;
        public Animation animation;
        public Animator animator;

        private GameObjectRecorder recorder;

        private AnimationClip clip;
    
        void Start()
        {
            clip = new AnimationClip();
            recorder = new GameObjectRecorder(gameObject);
            recorder.BindComponentsOfType<Transform>(gameObject,false);
        }

        public void toggleRecording()
        {
            if (isRecording){ isRecording = false; return;}

            isRecording = true;
            Debug.Log("Recording start");
            StartCoroutine(Record());
        }

        private IEnumerator Record()
        {
            while (isRecording)
            {
                recorder.TakeSnapshot(Time.deltaTime);
                yield return new WaitForSeconds(recordInterval);
            }
            Debug.Log("RecordingEnd");
            recorder.SaveToClip(clip);
            //animation.clip = clip;
            //onRecordEnd.Invoke();
            //animation.Play(PlayMode.StopSameLayer);
            recorder.ResetRecording();
        }
    }
}
