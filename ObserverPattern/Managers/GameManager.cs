using observer_pattern.ObserverPattern.Core;
using observer_pattern.ObserverPattern.Objects;
using observer_pattern.ObserverPattern.ObserverSystem;

namespace observer_pattern.ObserverPattern.Managers;

public class GameManager
{
    public Player Player;
    public UiManager UiManager;
    public CoinGenerator CoinGenerator;
    
    public GameManager()
    {
        Player = new(new(Globals.GameWindow.X / 2, Globals.GameWindow.Y / 2));
        UiManager = new();
        CoinGenerator = new();
        
        RegisterObservers();
    }

    public void Update()
    {
        Player.Update();
        CoinGenerator.Update();
        VerifyCollisions();
    }

    public void Draw()
    {
        Player.Draw();
        UiManager.Draw();
        CoinGenerator.Draw();
    }

    private void RegisterObservers()
    {
        Player.AddObserver(UiManager);
        Player.AddObserver(CoinGenerator);
    }

    private void VerifyCollisions()
    {
        for (int i = 0; i < CoinGenerator.Coins.Count; i++)
        {
            Coin coin = CoinGenerator.Coins[i];
            if (coin.Bounds.Intersects(Player.Bounds))
                Player.OnCoinCollision(i);
        }
    }
}