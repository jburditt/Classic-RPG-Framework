using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class EnemyManager : IEnemyManager
    {
        private readonly SpriteBatch _spriteBatch;

        public Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
        public Dictionary<string, Enemy> Enemies { get; private set; } = new Dictionary<string, Enemy>();

        public EnemyManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            // load textures
            Sprites = ManagerHelper.LoadFolder<Texture2D>("enemy", contentManager);

            // load enemies
            var filepaths = FileManager.GetFilepaths("../../../../Data/enemy");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Enemies.Add(filename, Serializer.XmlDeserialize<Enemy>(filepath));
            }
        }

        public void Draw(string enemyName, int x, int y)
        {
            _spriteBatch.DrawTexture(Sprites[enemyName], new Vector(x, y));
        }
    }
}