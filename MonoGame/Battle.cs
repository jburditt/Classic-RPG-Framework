using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Player;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using MonoGame.Effect;
using MonoGame.Manager;

namespace MonoGame
{
    public class Battle
    {
        private Party Party { get; set; }
        private List<IEffect> Effects = new List<IEffect>();

        private SpriteBatch SpriteBatch;
        private BattleManager BattleManager;
        private EnemyParty EnemyParty;
        private ActorManager ActorManager;
        private EnemyManager EnemyManager;
        private IconManager IconManager;
        private InputManager InputManager;
        private Dialog Dialog;
        private SpriteFont SpriteFont;
        private BattleState battleState = BattleState.Running;
        private int timeIncrement = 1;

        public void Init(SpriteBatch spriteBatch, BattleManager battleManager, ActorManager actorManager, EnemyManager enemyManager, IconManager iconManager, InputManager inputManager, EnemyParty enemyParty, Party party, Dialog dialog, SpriteFont spriteFont)
        {
            SpriteBatch = spriteBatch;
            BattleManager = battleManager;
            ActorManager = actorManager;
            EnemyManager = enemyManager;
            IconManager = iconManager;
            InputManager = inputManager;
            EnemyParty = enemyParty;
            Party = party;
            Dialog = dialog;
            SpriteFont = spriteFont;
        }

        public bool Update()
        {          
            switch (battleState)
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
                            break;
                        }
                    }
                    break;

                case BattleState.Idle:

                    if (InputManager.JustPressed(Input.FaceButtonDown, Input.Up))
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
            BattleManager.Draw("1");
            Dialog.Draw(new Rectangle(200, 330, 440, 150));

            if (battleState == BattleState.Idle)
            {
                SpriteBatch.DrawTexture(IconManager.Icons["attack"], 50, 350, Color.White * (InputManager.IsPressed(Keys.Up) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["magic"], 20, 380, Color.White * (InputManager.IsPressed(Keys.Left) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["defend"], 80, 380, Color.White * (InputManager.IsPressed(Keys.Right) ? 1f : 0.7f));
                SpriteBatch.DrawTexture(IconManager.Icons["item"], 50, 410, Color.White * (InputManager.IsPressed(Keys.Down) ? 1f : 0.7f));
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