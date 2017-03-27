using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Common;
using System.IO;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using MonoGame.Effect;

namespace MonoGame
{
    public class Battle
    {
        private Party Party { get; set; }
        private List<IEffect> Effects = new List<IEffect>();
        private Dictionary<string, Texture2D> BattleBg = new Dictionary<string, Texture2D>();

        private SpriteBatch SpriteBatch;
        private EnemyParty EnemyParty;
        private ActorManager ActorManager;
        private EnemyManager EnemyManager;
        private IconManager IconManager;
        private Dialog Dialog;
        private SpriteFont SpriteFont;
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

        public void Init(SpriteBatch spriteBatch, ActorManager actorManager, EnemyManager enemyManager, IconManager iconManager, EnemyParty enemyParty, Party party, Dialog dialog, SpriteFont spriteFont)
        {
            SpriteBatch = spriteBatch;
            ActorManager = actorManager;
            EnemyManager = enemyManager;
            IconManager = iconManager;
            EnemyParty = enemyParty;
            Party = party;
            Dialog = dialog;
            SpriteFont = spriteFont;
        }

        public bool Update()
        {
            switch(battleState)
            {
                case BattleState.Running:
                    foreach (var enemy in EnemyParty.Enemies)
                        if (enemy.TimeLapse(timeIncrement))
                        {
                            enemy.Action(Party);
                            Effects.Add(new DialogEffect(SpriteBatch, Dialog, SpriteFont, $"{enemy.Name} attacked."));
                        }
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
                        Party.ActivePlayer = null;

                        battleState = BattleState.Running;

                        if (EnemyParty.IsDead())
                            return true;
                    }
                    break;
            }

            return false;
        }

        public void Draw()
        {
            SpriteBatch.DrawTexture(BattleBg["1"], 0, 0);
            Dialog.Draw(SpriteBatch, new Rectangle(200, 330, 440, 150), 0);

            if (battleState == BattleState.Idle)
            {
                SpriteBatch.DrawTexture(IconManager.Icons["attack"], 50, 350, Color.White * (KeyboardHelper.Down(Keys.Up) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["magic"], 20, 380, Color.White * (KeyboardHelper.Down(Keys.Left) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["defend"], 80, 380, Color.White * (KeyboardHelper.Down(Keys.Right) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["item"], 50, 410, Color.White * (KeyboardHelper.Down(Keys.Down) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["run"], 20, 410, Color.White * 0.7f);
            }

            var i = 0;
            foreach (var actor in Party.Actors)
            {
                DrawActor(i);
                DrawActorInfo(i, actor);
                i++;
            }

            // draw enemies
            SpriteBatch.DrawTexture(EnemyManager.Sprites["DarkTroll"], 60, 200);

            // draw effects
            foreach (var effect in Effects)
            {
                effect.Draw();
                effect.Update();
                if (effect.Lifespan <= 0)
                {
                    Effects.Remove(effect);
                    break;  // can't iterate enumeration after removing, ok since we should never really need to have multiple effects die at once
                }
            }
        }

        public void DrawActor(int i)
        {
            var actor = Party.Actors[i];

            SpriteBatch.Draw(ActorManager.BattleChars[actor.BattleChar], new Rectangle(560 + (actor == Party.ActivePlayer ? -20 : 0), 140 + i * 48, 48, 48),
                actor.Rect.ToRectangle(), Color.White);
        }

        public void DrawActorInfo(int i, Actor actor)
        {
            SpriteBatch.DrawString(SpriteFont, actor.Name, 280, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "HP: " + actor.Hp.ToString(), 350, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "/", 410, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, actor.MaxHp.ToString(), 420, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "MP: " + actor.Mp.ToString(), 460, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "/", 510, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, actor.MaxMp.ToString(), 520, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "Limit " + actor.Limit, 550, 350 + i * 30);
            SpriteBatch.DrawString(SpriteFont, "%", 610, 350 + i * 30);
        }
    }
}