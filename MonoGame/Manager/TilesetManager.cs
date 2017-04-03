using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class TilesetManager : ITilesetManager
    {
        private readonly ContentManager _content;
        private readonly SpriteBatch _spriteBatch;
        private readonly Dictionary<string, Texture2D> _tilesets = new Dictionary<string, Texture2D>();

        public TilesetManager(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;

            _tilesets = ManagerHelper.LoadFolder<Texture2D>("tileset", content);
        }

        public void Draw(string tilesetName, Rect targetRect, Rect sourceRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(_tilesets[tilesetName], targetRect.ToRectangle(), sourceRect.ToRectangle(), color.ToColor());
        }
    }
}