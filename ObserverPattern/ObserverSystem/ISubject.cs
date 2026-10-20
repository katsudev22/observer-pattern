using System.Collections.Generic;

namespace observer_pattern.ObserverPattern.ObserverSystem;

public abstract class Subject
{
    public List<IObserver> Observers { get; private set; } = new();

    public void AddObserver(IObserver observer) => Observers.Add(observer);

    public void RemoveObserver(IObserver observer) => Observers.Remove(observer);

    public void Notify(IEvent sendingEvent)
    {
        foreach (IObserver observer in Observers)
            observer.OnNotify(sendingEvent);
    }
}