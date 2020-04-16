using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructs;
using Keyframe = DataStructs.Keyframe;


namespace AnimationStuff
{
    public class CustomAnimationComponent : MonoBehaviour
    {

        [Header("Animation Playing Settings")] 
        
        [SerializeField] private int keyframesPerSecond = 30;

        [SerializeField] [Range(.1f, 2f)] private float speedMultiplier = 1f;

        [SerializeField] private LinkedList<DataStructs.Keyframe> animationSequence;

        [SerializeField] private bool loop = false;
        
        [Header("Animation Visualising Settings")]

        [SerializeField] private Color trailEffectColor = Color.green;

        private IEnumerator PlayableRoutine => loop ? PlayLoopedKeyframeSequence() : PlayKeyframeSequence() ;

        private Queue<DataStructs.Keyframe> m_QueuedKeyframes;
            


        private float m_DeltaTime; 


        private void Awake()
        {
            m_DeltaTime = 1f / (keyframesPerSecond * speedMultiplier);
            m_QueuedKeyframes = new Queue<DataStructs.Keyframe>(animationSequence);
        }

        private void AssignKeyframeData(Keyframe keyframe)
        {
            var obj = gameObject;
            obj.transform.position = keyframe.Position;
            obj.transform.rotation = keyframe.Rotation;
        }


        private IEnumerator PlayKeyframeSequence()
        {
            var node = animationSequence.First as LinkedListNode<DataStructs.Keyframe>;

            var nodeValue = node.Value;

            while (node.Next != null)
            {
                AssignKeyframeData(nodeValue);
                if (node.Next != null)
                {
                    nodeValue = node.Next.Value;
                    node = node.Next;
                }
                
                yield return new WaitForSeconds(m_DeltaTime);
            }
            Debug.Log("Sequence ended");
        }

        private IEnumerator PlayLoopedKeyframeSequence()
        {
            while (true)
            {
                var kFrame = m_QueuedKeyframes.Dequeue();
                AssignKeyframeData(kFrame);
                m_QueuedKeyframes.Enqueue(kFrame);
                yield return new WaitForSeconds(m_DeltaTime);
            }
        }


        public void PlayAnimation()
        {
            StartCoroutine(PlayableRoutine);
        }

        public void StopAnimation()
        {
            StopCoroutine(PlayableRoutine);
        }

    }
}


