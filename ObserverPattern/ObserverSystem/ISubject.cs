using System.Collections.Generic;

namespace observer_pattern.ObserverPattern.ObserverSystem;

public interface ISubject
{
    public List<IObserver> Observers { get; protected set; }
    
    public void AddObserver(IObserver observer);
    public void RemoveObserver(IObserver observer);
    public void Notify(EventEnum sendingEvent);
}