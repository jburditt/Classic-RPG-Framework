using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;

namespace MonoGame
{
    public class Battle
    {
        private Texture2D[] battlebg;

        public Battle(ContentManager Content)
        {
            battlebg = new Texture2D[1];
            for (var i = 0; i < battlebg.Length; i++)
            {
                battlebg[i] = Content.Load<Texture2D>($"battlebg\\{i+1}");
            }
        }

        public void Draw(SpriteBatch spriteBatch, Dialog dialog, SpriteFont spriteFont, IEnumerable<Actor> actors)
        {
            spriteBatch.Draw(battlebg[0], new Vector2(0, 0), Color.White);
            dialog.Draw(spriteBatch, new Rectangle(0, 330, 640, 150), 0);

            var i = 0;

            foreach (var actor in actors)
            {
                DrawActorInfo(i, actor, spriteBatch, spriteFont);
                i++;
            }
        }

        public void DrawActorInfo(int i, Actor actor, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, actor.Name, new Vector2(280, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "HP: " + actor.Hp.ToString(), new Vector2(360, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "/", new Vector2(410, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, actor.MaxHp.ToString(), new Vector2(415, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "MP: " + actor.Mp.ToString(), new Vector2(460, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "/", new Vector2(510, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, actor.MaxMp.ToString(), new Vector2(520, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "Limit " + actor.Limit, new Vector2(550, 350 + i * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "%", new Vector2(610, 350 + i * 20), Color.White);
        }
    }
}