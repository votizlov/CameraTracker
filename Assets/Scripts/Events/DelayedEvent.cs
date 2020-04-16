using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Events
{
    internal class DelayedEvent : AbstractEvent
    {
        [SerializeField] private UnityEvent _event;
        
        protected override void RunEvent ()
        {
            _event?.Invoke();
        }
    }
}