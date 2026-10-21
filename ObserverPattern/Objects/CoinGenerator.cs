using System;
using System.Collections.Generic;
using observer_pattern.ObserverPattern.Core;
using observer_pattern.ObserverPattern.ObserverSystem;
using observer_pattern.ObserverPattern.ObserverSystem.Events;

namespace observer_pattern.ObserverPattern.Objects;

public class CoinGenerator : IObserver
{
    public List<Coin> Coins { get; private set; }
    public float SpawnRate;
    public float SpawnCooldown;

    private Random _random;
    
    public CoinGenerator()
    {
        Coins = new();
        SpawnRate = 0f;
        SpawnCooldown = 3f;
        _random = new Random();
    }

    public void Update()
    {
        SpawnCoin();
        foreach (Coin coin in Coins) coin.Update();
    }

    public void Draw()
    {
        foreach (Coin coin in Coins) coin.Draw();
    }

    private void SpawnCoin()
    {
        SpawnRate += Globals.Time;

        if (SpawnRate >= SpawnCooldown && Coins.Count <= 3)
        {
            int positionX = _random.Next(50, Globals.GameWindow.X - 50);
            int positionY = _random.Next(50, Globals.GameWindow.Y - 50);   
            Coins.Add(new(new(positionX, positionY)));
            SpawnRate = 0f;
        }
    }

    public void OnNotify(IEvent receivedEvent)
    {
        if (receivedEvent is OnCoinCollected onCoinCollected)
            Coins.RemoveAt(onCoinCollected.CoinId);
    }
}