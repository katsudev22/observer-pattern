using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using observer_pattern.ObserverPattern.Core;
using observer_pattern.ObserverPattern.Objects;

namespace observer_pattern.ObserverPattern.ObserverSystem;

public class UiManager : IObserver
{
    public Player Player;

    public Texture2D HealthTexture;
    public Vector2 Position;
    public Rectangle Bounds;

    public int Width;
    public int Height;
    
    public UiManager(Player player)
    {
        Player = player;

        Width = 1000;
        Height = 40;
        
        HealthTexture = new(Globals.GraphicsDevice, 1, 1);
        HealthTexture.SetData([Color.IndianRed]);
        Position = new(25, 25);
        Bounds = new((int)Position.X, (int)Position.Y, Width, Height);
    }
    
    public void OnNotify(EventEnum receivedEvent)
    {
        switch (receivedEvent)
        {
            case EventEnum.PlayerDecreaseHealth:
                UpdateHealthBar();
                break;
        }
    }

    public void Draw()
    {
        Bounds = new((int)Position.X, (int)Position.Y, Width, Height);
        Globals.SpriteBatch.Draw(HealthTexture, Bounds, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
    }
        
    private void UpdateHealthBar() => Width = (int)(Player.Health * 8f);
}