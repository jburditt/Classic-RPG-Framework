using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class EnemyManager
    {
        public Dictionary<string, Texture2D> Enemies = new Dictionary<string, Texture2D>();

        public EnemyManager(ContentManager Content)
        {
            var filepaths = FileManager.GetFilepaths("../../../Content/enemy");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Enemies.Add(filename, Content.Load<Texture2D>("enemy\\" + filename));
            }
        }
    }
}