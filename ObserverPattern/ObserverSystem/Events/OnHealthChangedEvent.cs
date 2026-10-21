namespace observer_pattern.ObserverPattern.ObserverSystem.Events;

public class OnHealthChangedEvent : IEvent
{
    public float NewHealth;

    public OnHealthChangedEvent(float newHealth) => NewHealth = newHealth;
}