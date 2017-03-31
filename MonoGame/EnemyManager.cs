using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class EnemyManager
    {
        public Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
        public Dictionary<string, Enemy> Enemies = new Dictionary<string, Enemy>();

        public EnemyManager(ContentManager Content)
        {
            // load textures
            var filepaths = FileManager.GetFilepaths("../../../Content/enemy");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Sprites.Add(filename, Content.Load<Texture2D>("enemy\\" + filename));
            }

            // load enemies
            filepaths = FileManager.GetFilepaths("../../../../Data/enemy");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Enemies.Add(filename, Serializer.XmlDeserialize<Enemy>(filepath));
            }
        }
    }
}