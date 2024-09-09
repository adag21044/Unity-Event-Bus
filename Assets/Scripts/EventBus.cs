using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
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
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    //Subscribe to an event
    public void Subscribe(string eventName, Action listener)
    {
        if(eventDictionary.TryGetValue(eventName, out Action existingEvent))
        {
            existingEvent += listener;
            eventDictionary[eventName] = existingEvent;
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    //Unsubscribe from an event
    public void Unsubscribe(string eventName, Action listener)
    {
        if(eventDictionary.TryGetValue(eventName, out Action existingEvent))
        {
            existingEvent -= listener;
            
            if(existingEvent == null)
            {
                eventDictionary.Remove(eventName);
            }
            else
            {
                eventDictionary[eventName] = existingEvent;
            }
        }
    }

    //Trigger an event
    public void Publish(string eventName)
    {
        if(eventDictionary.TryGetValue(eventName, out Action existingEvent))
        {
            existingEvent?.Invoke();
        }
    }
}
