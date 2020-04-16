using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events
{
    public abstract class AbstractEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TypeInitialization _typeInitialization = TypeInitialization.Custom;
        [SerializeField] private float _delayInitialization = 2.0f;

        private void Awake()
        {
            if (_typeInitialization == TypeInitialization.OnAwake) Run();
        }

        private void Start()
        {
            if (_typeInitialization == TypeInitialization.OnStart) Run();
        }
        
        
        private void OnDestroy()
        {
            if (_typeInitialization == TypeInitialization.OnDestroy) Run();
        }
        
        
        private void OnEnable()
        {
            if (_typeInitialization == TypeInitialization.OnEnable) Run();
        }
        
        
        private void OnDisable()
        {
            if (_typeInitialization == TypeInitialization.OnDisable) Run();
        }

        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_typeInitialization == TypeInitialization.OnPointerDown) Run();
        }

        
        public void Invoke()
        {
            if (_typeInitialization == TypeInitialization.Custom) Run();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            if (_typeInitialization == TypeInitialization.OnPointerUp) Run();
        }


        private void OnMouseDown()
        {
            if (_typeInitialization == TypeInitialization.OnMouseDown) Run();
        }

        private void OnMouseUp()
        {
            if (_typeInitialization == TypeInitialization.OnMouseUp) Run();
        }

        private void Run()
        {
            if (Math.Abs(_delayInitialization) < 0.0001)
            {
                RunEvent();
            }
            else
            {
                StartCoroutine(InvokeAction.Timer(_delayInitialization, RunEvent));
            }
        }
        protected abstract void RunEvent();
    }
}