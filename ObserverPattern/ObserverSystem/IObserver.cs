namespace observer_pattern.ObserverPattern.ObserverSystem;

public interface IObserver
{
    public void OnNotify(IEvent receivedEvent);
}