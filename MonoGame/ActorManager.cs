using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Player.Manager;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class ActorManager : IActorManager
    {
        private readonly SpriteBatch _spriteBatch;

        public Dictionary<string, Texture2D> Charsets { get; set; } = new Dictionary<string, Texture2D>();
        public Dictionary<string, Texture2D> BattleChars { get; set; } = new Dictionary<string, Texture2D>();

        public ActorManager(ContentManager Content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;

            // charset
            var filepaths = FileManager.GetFilepaths("../../../Content/charset");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                Charsets.Add(filename, Content.Load<Texture2D>("charset\\" + filename));
            }

            // battlechar
            filepaths = FileManager.GetFilepaths("../../../Content/battlechar");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                BattleChars.Add(filename, Content.Load<Texture2D>("battlechar\\" + filename));
            }
        }

        public void Draw(string battleCharName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            _spriteBatch.Draw(BattleChars[battleCharName], sourceRect.ToRectangle(), targetRect.ToRectangle(), color.ToColor());

        }
    }
}