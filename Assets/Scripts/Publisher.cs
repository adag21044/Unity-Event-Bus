using UnityEngine;

public class Publisher : MonoBehaviour
{
    private void Update()
    {
        // Trigger the event when tje space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed");

            // Publish with an integer parameter
            EventBus.Instance.Publish("OnSpacePressed", Random.Range(1, 100));
        }
    }
}