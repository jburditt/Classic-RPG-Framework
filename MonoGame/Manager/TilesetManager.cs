using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
namespace MonoGame.Manager
{
    public class TilesetManager : ITilesetManager
    {
        private readonly ContentManager _content;
        private readonly SpriteBatch _spriteBatch;
        private Texture2D[] tileset;    // make this a dictionary

        public TilesetManager(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        } 

        public void Load(string[] tilesets)
        {
            tileset = new Texture2D[tilesets.Length];
            for (var i = 0; i < tilesets.Length; i++)
                tileset[i] = _content.Load<Texture2D>(tilesets[i]);
        }

        public void Draw(int i, Rect targetRect, Rect sourceRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(tileset[i], targetRect.ToRectangle(), sourceRect.ToRectangle(), color.ToColor());
        }
    }
}