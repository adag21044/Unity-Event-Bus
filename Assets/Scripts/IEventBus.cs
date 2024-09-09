using System;
public interface IEventBus 
{
    void Subscribe<T>(string eventName, Action<T> listener);    
    void Unsubscribe<T>(string eventName, Action<T> listener);
    void Publish<T>(string eventName, T parameter);
}