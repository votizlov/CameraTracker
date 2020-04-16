namespace Events
{
    /// <inheritdoc />
    /// <summary>
    ///     <para>Тип запуска списка событий</para>
    ///     <list type="TypeRunEvents">
    ///         <item>
    ///             <description><c>TypeRunEvents.AllDuringAction</c> запускает все события сразу</description>
    ///         </item>
    ///         <item>
    ///             <description><c>TypeRunEvents.Sequence</c> запускает события последовательно через время задержки, уникальное для каждого события</description>
    ///         </item>
    ///     </list>
    /// </summary>
    internal enum TypeRunEvents
    {
        AllDuringAction,
        Sequence
    }
}