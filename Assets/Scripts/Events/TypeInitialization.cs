namespace Events
{
    public enum TypeInitialization
    {
        Custom, // Вызывается через метод Invoke
        
        OnPointerDown,
        OnPointerUp,
        
        OnStart,
        OnDestroy,
        
        OnEnable,
        OnDisable,
        
        OnMouseDown,
        OnMouseUp,
        
        OnAwake
    }
}