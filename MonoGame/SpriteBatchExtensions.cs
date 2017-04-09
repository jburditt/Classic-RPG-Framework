using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Player;

namespace MonoGame
{
    public static class SpriteBatchExtensions
    {
        public static void DrawTexture(this SpriteBatch spriteBatch, Texture2D texture, Vector vector, Color? color = null)
        {
            spriteBatch.Draw(texture, new Rectangle(vector.X, vector.Y, texture.Width, texture.Height), color ?? Color.White);
        }

        public static void DrawString(this SpriteBatch spriteBatch, SpriteFont spriteFont, string text, int x, int y, Color? color = null)
        {
            spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), color ?? Color.White);
        }
    }
}