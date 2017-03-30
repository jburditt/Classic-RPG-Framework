using Microsoft.Xna.Framework.Graphics;
using Player.Graphics;

namespace MonoGame
{
    public class Graphics : IGraphics
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _spriteFont;

        public Graphics(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            _spriteBatch = spriteBatch;
            _spriteFont = spriteFont;
        }

        public void DrawString(string text, int x, int y)
        {
            _spriteBatch.DrawString(_spriteFont, text, x, y);
        }
    }
}