using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using observer_pattern.ObserverPattern.Core;

namespace observer_pattern.ObserverPattern.Objects;

public class Coin
{
    public Texture2D Texture;
    public Vector2 Position;
    public Rectangle Bounds;

    public Coin(Vector2 position)
    {
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([Color.Yellow]);
        Position = position;
        Bounds = new((int)Position.X, (int)Position.Y, 50, 50);
    }

    public void Update()
    {
        
    }

    public void Draw() =>
        Globals.SpriteBatch.Draw(Texture, Position, Bounds, Color.White, 0f, new(25, 25), 1f, SpriteEffects.None, 0f);
}