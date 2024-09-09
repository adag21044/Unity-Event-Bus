using UnityEngine;

public class EventFactory 
{
    public static Publisher CreatePublisher(GameObject parent)
    {
        var publisherObject = new GameObject("Publisher");
        publisherObject.transform.SetParent(parent.transform);
        return publisherObject.AddComponent<Publisher>();
    }

    public static Subscriber CreateSubscriber(GameObject parent)
    {
        var subscriberObject = new GameObject("Subscriber");
        subscriberObject.transform.SetParent(parent.transform);
        return subscriberObject.AddComponent<Subscriber>();
    }
}