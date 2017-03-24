using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;

namespace Classic_RPG_Framework
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
            foreach (var actor in actors)
                DrawActorInfo(actor, spriteBatch, spriteFont);
        }

        public void DrawActorInfo(Actor actor, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, actor.Name, new Vector2(280, 350 + actor.Order * 20), Color.White);
            spriteBatch.DrawString(spriteFont, actor.Hp.ToString(), new Vector2(360, 350 + actor.Order * 20), Color.White);
            spriteBatch.DrawString(spriteFont, "/", new Vector2(380, 350 + actor.Order * 20), Color.White);
            spriteBatch.DrawString(spriteFont, actor.MaxHp.ToString(), new Vector2(390, 350 + actor.Order * 20), Color.White);
        }
    }
}