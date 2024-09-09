using UnityEngine;

public class Subscriber : MonoBehaviour
{
    private void OnEnable()
    {
        // Check if the instance is not null before subscribing
        if (EventBus.Instance != null)
        {
            // Subscribe to the event
            EventBus.Instance.Subscribe<int>("OnSpacePressed", OnSpacePressed);
        }
        else
        {
            Debug.LogError("EventBus instance is not found!");
        }
    }

    private void OnDisable()
    {
        // Check if the instance is not null before unsubscribing
        if (EventBus.Instance != null)
        {
            // Unsubscribe from the event
            EventBus.Instance.Unsubscribe<int>("OnSpacePressed", OnSpacePressed);
        }
    }

    // Action to perform when the event is triggered
    private void OnSpacePressed(int value)
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        Debug.Log($"Space bar pressed with value: {value}");
    }
}
