using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Common;
using System.IO;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace MonoGame
{
    public class Battle
    {
        private Party Party { get; set; }

        private Dictionary<string, Texture2D> BattleBg = new Dictionary<string, Texture2D>();
        private EnemyParty EnemyParty;
        private BattleState battleState = BattleState.Running;
        private int timeIncrement = 1;

        public Battle(ContentManager Content)
        {
            var filepaths = FileManager.GetFilepaths("../../../Content/battlebg");

            foreach (var filepath in filepaths)
            {
                var filename = Path.GetFileNameWithoutExtension(filepath);
                BattleBg.Add(filename, Content.Load<Texture2D>("battlebg\\" + filename));
            }
        }

        public void Init(EnemyParty enemyParty, Party party)
        {
            EnemyParty = enemyParty;
            Party = party;
        }

        public bool Update()
        {
            switch(battleState)
            {
                case BattleState.Running:
                    foreach (var enemy in EnemyParty.Enemies)
                        if (enemy.TimeLapse(timeIncrement))
                            enemy.Action(Party);
                    foreach (var actor in Party.Actors)
                    {
                        if (actor.TimeLapse(timeIncrement))
                        {
                            battleState = BattleState.Idle;
                            Party.ActivePlayer = actor;
                        }
                    }
                    break;

                case BattleState.Idle:
                    if (KeyboardHelper.Down(Keys.Up) && KeyboardHelper.Down(Keys.Space))
                    {
                        Party.ActivePlayer.Attack(EnemyParty.Enemies.First());
                        battleState = BattleState.Running;

                        if (EnemyParty.IsDead())
                            return true;
                    }
                    break;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Dialog dialog, SpriteFont spriteFont, ActorManager actorManager, EnemyManager enemyManager, IconManager iconManager)
        {
            spriteBatch.DrawTexture(BattleBg["1"], 0, 0);
            dialog.Draw(spriteBatch, new Rectangle(200, 330, 440, 150), 0);

            if (battleState == BattleState.Idle)
            {
                spriteBatch.DrawTexture(iconManager.Icons["attack"], 50, 350, Color.White * (KeyboardHelper.Down(Keys.Up) ? 1f : 0.7f));
                spriteBatch.DrawTexture(iconManager.Icons["magic"], 20, 380, Color.White * (KeyboardHelper.Down(Keys.Left) ? 1f : 0.7f));
                spriteBatch.DrawTexture(iconManager.Icons["defend"], 80, 380, Color.White * (KeyboardHelper.Down(Keys.Right) ? 1f : 0.7f));
                spriteBatch.DrawTexture(iconManager.Icons["item"], 50, 410, Color.White * (KeyboardHelper.Down(Keys.Down) ? 1f : 0.7f));
                spriteBatch.DrawTexture(iconManager.Icons["run"], 20, 410, Color.White * 0.7f);
            }

            var i = 0;
            foreach (var actor in Party.Actors)
            {
                DrawActor(i, actorManager, spriteBatch);
                DrawActorInfo(i, actor, spriteBatch, spriteFont);
                i++;
            }

            // draw enemies
            spriteBatch.DrawTexture(enemyManager.Sprites["DarkTroll"], 60, 200);
        }

        public void DrawActor(int i, ActorManager actorManager, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(actorManager.BattleChars[Party.Actors[i].BattleChar], new Rectangle(560, 140 + i * 48, 48, 48),
                Party.Actors[i].Rect.ToRectangle(), Color.White);
        }

        public void DrawActorInfo(int i, Actor actor, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.DrawString(spriteFont, actor.Name, new Vector2(280, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "HP: " + actor.Hp.ToString(), new Vector2(350, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "/", new Vector2(410, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, actor.MaxHp.ToString(), new Vector2(420, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "MP: " + actor.Mp.ToString(), new Vector2(460, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "/", new Vector2(510, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, actor.MaxMp.ToString(), new Vector2(520, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "Limit " + actor.Limit, new Vector2(550, 350 + i * 30), Color.White);
            spriteBatch.DrawString(spriteFont, "%", new Vector2(610, 350 + i * 30), Color.White);
        }
    }
}