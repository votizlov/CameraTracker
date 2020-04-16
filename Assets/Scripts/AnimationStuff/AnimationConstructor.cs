using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnimationStuff
{
    public class AnimationConstructor : MonoBehaviour
    {
        public AnimationClip GetAnimationClipFromKeyFrames(List<DataStructs.Keyframe> keyframes)
        {
            var animClip = new AnimationClip();

            var previousCurve = AnimationCurve.Constant(0, 0, 0);
            
            animClip.SetCurve("", typeof(Transform), "localPosition.x", 
                previousCurve);
            
            
            
            
            //todo : CalculateFrameTime, SetAll3Curves.
            
            for (int i = 1; i < keyframes.Count; i++)
            {
                var curvX = AnimationCurve.Linear(previousCurve.keys[0].time, keyframes[i - 1].Position.x, i,
                    keyframes[i].Position.x);
                
                animClip.SetCurve("", typeof(Transform), "localPosition.x", curvX);

                previousCurve = curvX;
            }
            
            
            

            return animClip;
        }
    }
}


