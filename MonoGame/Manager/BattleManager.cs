using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player.Manager;
using System.Collections.Generic;

namespace MonoGame.Manager
{
    public class BattleManager : IBattleManager
    {
        private Dictionary<string, Texture2D> BattleBg = new Dictionary<string, Texture2D>();

        private SpriteBatch _spriteBatch;

        public BattleManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            BattleBg = ManagerHelper.LoadFolder<Texture2D>("battleBg", contentManager);
        }

        public void Draw(string battleBgName)
        {
            _spriteBatch.DrawTexture(BattleBg[battleBgName], new Vector(0, 0));
        }
    }
}