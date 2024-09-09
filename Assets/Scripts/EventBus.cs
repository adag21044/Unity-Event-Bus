using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour, IEventBus
{
    //Singleton implementation
    private static EventBus instance;
    public static EventBus Instance => instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Dictionary to hold events and their listeners
    private Dictionary<string, Delegate> eventDictionary = new Dictionary<string, Delegate>();

    //Subscribe to an event
    public void Subscribe<T>(string eventName, Action<T> listener)
    {
        if(eventDictionary.TryGetValue(eventName, out Delegate existingEvent))
        {
            eventDictionary[eventName] = Delegate.Combine(existingEvent, listener);
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    //Unsubscribe from an event
    public void Unsubscribe<T>(string eventName, Action<T> listener)
    {
        if(eventDictionary.TryGetValue(eventName, out Delegate existingEvent))
        {
            var currentDel = Delegate.Remove(existingEvent, listener);

            if(currentDel == null)
            {
                eventDictionary.Remove(eventName);
            }
            else
            {
                eventDictionary[eventName] = currentDel;
            }
        }
    }

    //Publish an event
    public void Publish<T>(string eventName, T parameter)
    {
        if(eventDictionary.TryGetValue(eventName, out Delegate existingEvent))
        {
            if(existingEvent is Action<T> action)
            {
                action(parameter);
            }
        }
    }
}
