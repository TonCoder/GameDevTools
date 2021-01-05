using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AGameEventListener<T,E,UER> : MonoBehaviour, IGameEventListener<T> where E: AGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E _gameEvent;
    [SerializeField] private UER unityEventResponse;

    public E UGameEvent { get { return _gameEvent; } }

    private void OnEnable()
    {
        UGameEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        UGameEvent?.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        unityEventResponse?.Invoke(item);
    }
}
