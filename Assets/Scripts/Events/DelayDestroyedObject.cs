using UnityEngine;

namespace Events
{
    /// <inheritdoc />
    /// <summary>Класс служит для уничтожения временного объекта и запуска корутин на нем</summary>
    internal class DelayDestroyedObject : MonoBehaviour
    {
        internal void Destroy(float delay) => StartCoroutine(InvokeAction.Timer(delay, delegate { Destroy(gameObject); }));
    }
}