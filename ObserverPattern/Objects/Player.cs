using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using observer_pattern.ObserverPattern.Core;
using observer_pattern.ObserverPattern.Managers;
using observer_pattern.ObserverPattern.ObserverSystem;
using observer_pattern.ObserverPattern.ObserverSystem.Events;

namespace observer_pattern.ObserverPattern.Objects;

public class Player : Subject
{
    public Texture2D Texture;
    public Vector2 Position;
    public Rectangle Bounds;
    public float Health;
    public Vector2 Direction;
    public float Speed;
    
    public Player(Vector2 position)
    {
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([Color.YellowGreen]);
        Position = position;
        UpdateBounds();
        Health = 100f;
        Speed = 400f;
    }
    
    public void Update()
    {
        UpdateBounds();
        DecreaseHealth();
    }

    public void Draw() =>
        Globals.SpriteBatch.Draw(Texture, Position, Bounds, Color.White, 0f, new(25, 25), 1f, SpriteEffects.None, 0f);
    
    private void UpdateBounds()
    {
        int width = 50;
        int height = 50;

        Bounds = new Rectangle(
            (int)Position.X - width / 2,
            (int)Position.Y - height / 2,
            width,
            height
        );
    }

    private void DecreaseHealth()
    {
        if (Health <= 0) return;
        Health -= 0.1f;
        OnHealthChangedEvent onHealthChangedEvent = new(Health);
        Notify(onHealthChangedEvent);
    }
}