using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using observer_pattern.ObserverPattern.Core;
using observer_pattern.ObserverPattern.ObserverSystem;

namespace observer_pattern.ObserverPattern.Objects;

public class Player : ISubject
{
    public List<IObserver> Observers { get; set; }
    
    public Texture2D Texture;
    public Vector2 Position;
    public Rectangle Bounds;

    public float Health;
    
    public Player(Vector2 position)
    {
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([Color.YellowGreen]);
        Position = position;
        UpdateBounds();

        Health = 100f;
        Observers = new();
    }

    public void AddObserver(IObserver observer) => Observers.Add(observer);

    public void RemoveObserver(IObserver observer) => Observers.Remove(observer);
    
    public void Notify(EventEnum sendingEvent)
    {
        foreach (IObserver observer in Observers)
            observer.OnNotify(sendingEvent);
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
        Notify(EventEnum.PlayerDecreaseHealth);
        Console.WriteLine($"Health: {Health}");
    }
}