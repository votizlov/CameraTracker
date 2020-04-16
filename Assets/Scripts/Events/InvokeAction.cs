using System;
using System.Collections;
using UnityEngine;

namespace Events
{
    public static class InvokeAction
    {
        public static IEnumerator FixedUpdate(Action action)
        {
            yield return new WaitForFixedUpdate();
            action?.Invoke();
        }
        
        
        public static IEnumerator Timer(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
                
        
        public static IEnumerator WaitUntil(Func<bool> predicate, Action action)
        {
            yield return new WaitUntil(predicate);
            action?.Invoke();
        }
                
        
        public static IEnumerator EndOfFrame(Action action)
        {
            yield return new WaitForEndOfFrame();
            action?.Invoke();
        }
    }
}