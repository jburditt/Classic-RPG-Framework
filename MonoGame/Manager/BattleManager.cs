using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Manager
{
    public class BattleManager : IBattleManager
    {
        private Dictionary<string, Texture2D> BattleBg = new Dictionary<string, Texture2D>();

        private SpriteBatch _spriteBatch;

        public BattleManager(ContentManager Content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            var filepaths = FileManager.GetFilepaths("../../../Content/battlebg");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                BattleBg.Add(filename, Content.Load<Texture2D>("battlebg\\" + filename));
            }
        }

        public void Draw(string battleBgName)
        {
            _spriteBatch.DrawTexture(BattleBg[battleBgName], 0, 0);
        }
    }
}