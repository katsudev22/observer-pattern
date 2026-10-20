namespace observer_pattern.ObserverPattern.ObserverSystem.Events;

public class OnDecreasedHealthEvent : IEvent
{
    public float NewHealth;

    public OnDecreasedHealthEvent(float newHealth) => NewHealth = newHealth;
}