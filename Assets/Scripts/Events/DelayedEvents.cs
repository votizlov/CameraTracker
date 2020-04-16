using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events
{
    public class DelayedEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private List<Events> _events;

        private void Start()
        {
            Run(TypeInitialization.OnStart);
        }

        private void OnDestroy()
        {
            Run(TypeInitialization.OnDestroy);
        }

        private void OnEnable()
        {
            Run(TypeInitialization.OnEnable);
        }

        private void OnDisable()
        {
            Run(TypeInitialization.OnDisable);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Run(TypeInitialization.OnPointerDown);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Run(TypeInitialization.OnPointerUp);
        }

        public void OnMouseDown()
        {
            Run(TypeInitialization.OnMouseDown);
        }

        public void Invoke()
        {
            var eventsSelectedByType = _events
                .Where(evt => evt.IsEqualType(TypeInitialization.Custom) && evt.IsEqualTag("")).ToArray();
            if (!eventsSelectedByType.Any()) return;

            foreach (var evt in eventsSelectedByType) evt.Run(this);
        }

        public void Invoke(string customTag)
        {
            var eventsSelectedByType = _events
                .Where(evt => evt.IsEqualType(TypeInitialization.Custom) && evt.IsEqualTag(customTag)).ToArray();
            if (!eventsSelectedByType.Any()) return;

            foreach (var evt in eventsSelectedByType) evt.Run(this);
        }

        private void Run(TypeInitialization type)
        {
            var eventsSelectedByType = _events.Where(evt => evt.IsEqualType(type)).ToArray();
            if (!eventsSelectedByType.Any()) return;

            var obj = type == TypeInitialization.OnDestroy || type == TypeInitialization.OnDisable
                ? GetTempObject(type)
                : this;
            foreach (var evt in eventsSelectedByType) evt.Run(obj);
        }

        private MonoBehaviour GetTempObject(TypeInitialization type)
        {
            var obj = new GameObject(name + "_delay_destroyed");
            var component = obj.AddComponent<DelayDestroyedObject>();
            var duration = _events.Where(evt => evt.IsEqualType(type)).Max(evt => evt.GetDuration()) + 1;
            component.Destroy(duration);
            return component;
        }
    }
}

