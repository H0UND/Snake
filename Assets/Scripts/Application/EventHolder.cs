namespace Snake.Application
{
    using System;
    using System.Collections.Generic;

    internal class EventHolder<T> where T : class
    {
        private static readonly List<Action<T>> Listeners = new List<Action<T>>();
        private static T currentInfoState;

        internal static void AddListener(Action<T> listener)
        {
            Listeners.Add(listener);
            if (currentInfoState != null)
            {
                listener?.Invoke(currentInfoState);
            }
        }

        internal static void RaiseRegistrationInfo(T state)
        {
            currentInfoState = state;
            foreach (var listener in Listeners)
            {
                listener?.Invoke(state);
            }
        }

        internal static void RemoveListener(Action<T> listener)
        {
            if (Listeners.Contains(listener))
            {
                Listeners.Remove(listener);
            }
        }
    }
}