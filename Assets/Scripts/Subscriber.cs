using UnityEngine;

public class Subscriber : MonoBehaviour
{
    private IEventBus eventBus;

    private void OnEnable()
    {
        eventBus = EventBus.Instance;
        // Check if the instance is not null before subscribing
        if (eventBus != null)
        {
            // Subscribe to the event
            eventBus.Subscribe<int>("OnSpacePressed", OnSpacePressed);
        }
        else
        {
            Debug.LogError("EventBus instance is not found!");
        }
    }

    private void OnDisable()
    {
        // Check if the instance is not null before unsubscribing
        if (eventBus != null)
        {
            // Unsubscribe from the event
            eventBus.Unsubscribe<int>("OnSpacePressed", OnSpacePressed);
        }
    }

    // Action to perform when the event is triggered
    private void OnSpacePressed(int value)
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        Debug.Log($"Space bar pressed with value: {value}");
    }
}
