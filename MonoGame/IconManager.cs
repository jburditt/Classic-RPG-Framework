using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class IconManager : IIconManager
    {
        private readonly SpriteBatch _spriteBatch;

        public Dictionary<string, Texture2D> Icons = new Dictionary<string, Texture2D>();

        public IconManager(ContentManager Content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            var filepaths = FileManager.GetFilepaths("../../../Content/icon");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Icons.Add(filename, Content.Load<Texture2D>("icon\\" + filename));
            }
        }

        public void Draw(string iconName, int x, int y, ColorStruct? color = null)
        {
            _spriteBatch.DrawTexture(Icons[iconName], x, y, color.ToColor());
        }
    }
}