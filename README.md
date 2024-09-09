# Unity Event Bus

This project demonstrates an implementation of the Event Bus pattern in Unity, adhering to SOLID principles and game programming patterns. The Event Bus allows different game objects to communicate with each other without direct references, promoting loose coupling and enhancing code maintainability.

## Project Structure

- **EventBus.cs**: Implements a singleton Event Bus to manage event subscriptions, unsubscriptions, and event publishing.
- **EventFactory.cs**: Provides factory methods to create Publisher and Subscriber game objects.
- **Publisher.cs**: Publishes events when certain conditions are met (e.g., pressing the space bar).
- **Subscriber.cs**: Subscribes to events and responds when those events are triggered.
- **IEventBus.cs**: Interface for the Event Bus, defining methods for subscribing, unsubscribing, and publishing events.

## Design Patterns Used

1. **Singleton Pattern**: Used in `EventBus` to ensure only one instance of the Event Bus exists in the scene.
2. **Observer Pattern**: Implements event subscription and notification, allowing publishers and subscribers to interact without tight coupling.
3. **Factory Pattern**: `EventFactory` creates instances of publishers and subscribers, adhering to the Single Responsibility Principle (SRP).

## Implementation Details

### EventBus.cs

- Manages a dictionary of events, allowing multiple listeners to subscribe to a single event.
- Provides methods to subscribe to, unsubscribe from, and publish events.
- Implements the Singleton pattern to ensure a single EventBus instance.

### Publisher.cs

- Publishes an event (`OnSpacePressed`) when the space bar is pressed.
- Uses the Event Bus to publish events, promoting loose coupling with subscribers.

### Subscriber.cs

- Subscribes to the `OnSpacePressed` event and changes its color upon receiving the event.
- Ensures clean subscription and unsubscription in `OnEnable` and `OnDisable` methods to avoid memory leaks.
