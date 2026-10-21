namespace observer_pattern.ObserverPattern.ObserverSystem.Events;

public class OnCoinCollected : IEvent
{
    public int CoinId;

    public OnCoinCollected(int coinId) => CoinId = coinId;
}