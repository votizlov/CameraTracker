using System;
using System.Collections;
using System.Collections.Generic;
using DataStructs;
using UnityEngine;


namespace AnimationStuff
{
    public class CasualAnimationWriter : MonoBehaviour
    {

        private float _deltaTime = 0f;

        private IEnumerator _routine;
        
        public void StartWriting(float frameRate)
        {
            _deltaTime = 1 / frameRate;
            StartCoroutine(_routine);
        }

        private void Awake()
        {
            _routine = Writing();
        }

        public void StopWriting()
        {
            StopCoroutine(_routine);
        }

        private IEnumerator Writing()
        {
            while (true)
            {
                var t = transform;
                KeyframesContainer.GetInstance.keyframes.Add(new DataStructs.Keyframe(t.position, t.rotation, 0));
                yield return new WaitForSeconds(_deltaTime);
            }
        }
        
    }
}


