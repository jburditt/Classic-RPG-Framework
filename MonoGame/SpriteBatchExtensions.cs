using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public static class SpriteBatchExtensions
    {
        public static void DrawTexture(this SpriteBatch spriteBatch, Texture2D texture, int x, int y, Color? color = null)
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, texture.Width, texture.Height), color ?? Color.White);
        }
    }
}