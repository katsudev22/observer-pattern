using System.Collections.Generic;
using observer_pattern.ObserverPattern.Core;

namespace observer_pattern.ObserverPattern.Objects;

public class CoinGenerator
{
    public List<Coin> Coins { get; private set; }
    public float SpawnRate;
    public float SpawnCooldown;
    
    public CoinGenerator()
    {
        Coins = new();
        SpawnRate = 0f;
        SpawnCooldown = 3f;
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
        
        int positionX = Globals.GameWindow.X - 100;
        int positionY = Globals.GameWindow.Y - 100;
        
        if (SpawnRate >= SpawnCooldown && Coins.Count <= 3)
            Coins.Add(new(new(positionX, positionY)));

        SpawnRate = 0f;
    }
}