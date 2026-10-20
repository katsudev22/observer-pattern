using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace observer_pattern.ObserverPattern.Core;

public static class Globals
{
    public static float Time { get; private set; }
    public static ContentManager ContentManager { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static GraphicsDevice GraphicsDevice { get; set; }
    public static Point GameWindow { get; private set; } = new(1366, 768);

    public static void Update(GameTime gameTime)
    {
        Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}