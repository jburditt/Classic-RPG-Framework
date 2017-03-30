using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class Graphics : IGraphics
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly SpriteFont _spriteFont;
        private Dictionary<string, Texture2D> Sprite = new Dictionary<string, Texture2D>();

        public Graphics(ContentManager content, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            _spriteBatch = spriteBatch;
            _spriteFont = spriteFont;

            var filepaths = FileManager.GetFilepaths("../../../Content/sprite");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Sprite.Add(filename, content.Load<Texture2D>("sprite\\" + filename));
            }
        }

        public void DrawSprite(string spriteName, int x, int y, ColorStruct? color = null)
        {
            _spriteBatch.Draw(Sprite[spriteName], new Vector2(x, y), color.ToColor());
        }

        public void DrawSprite(string spriteName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(Sprite[spriteName], sourceRect.ToRectangle(), targetRect.ToRectangle(), color.ToColor());
        }

        public void DrawString(string text, int x, int y)
        {
            _spriteBatch.DrawString(_spriteFont, text, x, y);
        }
    }
}