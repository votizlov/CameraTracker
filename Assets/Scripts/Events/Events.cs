using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Events
{
    [Serializable]
    internal class Events
    {
        [SerializeField] private string _tag;
        [SerializeField] private TypeInitialization _typeAction = TypeInitialization.Custom;
        [SerializeField] private TypeRunEvents _typeRun = TypeRunEvents.AllDuringAction;
        [SerializeField] private List<Event> _events = new List<Event>();
        private bool _isSorted;

        public bool IsEqualType(TypeInitialization type) => type == _typeAction;
        public bool IsEqualTag(string tag) => tag == _tag;
        public float GetDuration() => _typeRun == TypeRunEvents.AllDuringAction ? _events.Last().delayInitialization : _events.Sum(evt => evt.delayInitialization);

        public void Run(MonoBehaviour owner)
        {
            Sort();
            var calculateDelay = _typeRun == TypeRunEvents.AllDuringAction
                ? new Func<float, float, float>((delay, lastDelay) => delay - lastDelay)
                : (delay, lastDelay) => delay;
            
            owner.StartCoroutine(Run(calculateDelay));
        }

        private IEnumerator Run(Func<float, float, float> calculateDelay)
        {
            var lastDelay = 0f;
            foreach (var @event in _events)
            {
                var delay = calculateDelay(@event.delayInitialization, lastDelay);
                if (delay > 0.00001) yield return new WaitForSeconds(delay);
                
                @event.Invoke();
                lastDelay = @event.delayInitialization;
            }
        }

        private void Sort()
        {
            if (_typeRun != TypeRunEvents.AllDuringAction || _isSorted) return;

            _events.Sort((x, y) => x.delayInitialization.CompareTo(y.delayInitialization));
            _isSorted = true;
        }
    }
}
