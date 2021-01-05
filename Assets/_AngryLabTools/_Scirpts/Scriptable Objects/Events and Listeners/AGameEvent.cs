using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AGameEvent<T> : ScriptableObject
{
    [SerializeField] private List<RegisteredListenerInfo<T>> registeredListeners = new List<RegisteredListenerInfo<T>>();
    private List<IGameEventListener<T>> eventListener = new List<IGameEventListener<T>>();

    internal virtual void Raise(T item)
    {
        for (int i = (eventListener.Count - 1); i >= 0; i--)
        {
            eventListener[i].OnEventRaised(item);
        }
    }

    internal virtual void RegisterListener(IGameEventListener<T> listener)
    {
        if (!eventListener.Contains(listener))
        {
            eventListener.Add(listener);
            registeredListeners.Add(new RegisteredListenerInfo<T>() { name = listener.ToString() });
        }
    }

    internal virtual void UnregisterListener(IGameEventListener<T> listener)
    {
        if (eventListener.Contains(listener))
        {
            eventListener.Remove(listener);
            registeredListeners.Remove(registeredListeners.FirstOrDefault(x=> x.name == listener.ToString()));
        }
    }

    internal virtual void UnregisterAllListener()
    {
        eventListener.Clear();
        registeredListeners.Clear();
    }
}

[System.Serializable]
internal class RegisteredListenerInfo<T>
{
    public string name;
}