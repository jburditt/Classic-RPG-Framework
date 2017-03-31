using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class IconManager
    {
        public Dictionary<string, Texture2D> Icons = new Dictionary<string, Texture2D>();

        public IconManager(ContentManager Content)
        {
            var filepaths = FileManager.GetFilepaths("../../../Content/icon");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Icons.Add(filename, Content.Load<Texture2D>("icon\\" + filename));
            }
        }
    }
}