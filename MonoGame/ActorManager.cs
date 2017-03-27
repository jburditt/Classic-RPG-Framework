using Common;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using System.Collections.Generic;
using System.IO;

namespace MonoGame
{
    public class ActorManager
    {
        public Dictionary<string, Texture2D> Charsets { get; set; } = new Dictionary<string, Texture2D>();
        public Dictionary<string, Texture2D> BattleChars { get; set; } = new Dictionary<string, Texture2D>();

        public ActorManager(ContentManager Content)
        {
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
    }
}