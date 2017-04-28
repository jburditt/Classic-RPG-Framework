using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;

namespace MonoGame.Manager
{
    public class ActorManager : IActorManager
    {
        private readonly SpriteBatch _spriteBatch;

        private Dictionary<string, Texture2D> Charsets { get; set; } = new Dictionary<string, Texture2D>();
        private Dictionary<string, Texture2D> BattleChars { get; set; } = new Dictionary<string, Texture2D>();

        public ActorManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            Charsets = ManagerHelper.LoadFolder<Texture2D>("charset", contentManager);
            BattleChars = ManagerHelper.LoadFolder<Texture2D>("battlechar", contentManager);
        }

        public void Draw(string charSetName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(Charsets[charSetName], targetRect.ToRectangle(), sourceRect.ToRectangle(), color.ToColor());
        }

        public void DrawBattle(string battleCharName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(BattleChars[battleCharName], sourceRect.ToRectangle(), targetRect.ToRectangle(), color.ToColor());
        }
    }
}