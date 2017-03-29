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

        private Graphics _graphics;
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

        public void Init(Graphics graphics, BattleManager battleManager, ActorManager actorManager, EnemyManager enemyManager, IconManager iconManager, InputManager inputManager, EnemyParty enemyParty, Party party, Dialog dialog, SpriteFont spriteFont)
        {
            _graphics = graphics;
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
                            //Effects.Add(new DialogEffect(SpriteBatch, Dialog, SpriteFont, $"{enemy.Name} attacked."));
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
                IconManager.Draw("attack", 50, 350, ColorStruct.White * (InputManager.IsPressed(Keys.Up) ? 1f : 0.7f));
                IconManager.Draw("magic", 20, 380, ColorStruct.White * (InputManager.IsPressed(Keys.Left) ? 1f : 0.7f));
                IconManager.Draw("defend", 80, 380, ColorStruct.White * (InputManager.IsPressed(Keys.Right) ? 1f : 0.7f));
                IconManager.Draw("item", 50, 410, ColorStruct.White * (InputManager.IsPressed(Keys.Down) ? 1f : 0.7f));
                IconManager.Draw("run", 20, 410, ColorStruct.White * 0.7f);
            }

            var i = 0;
            foreach (var actor in Party.Actors)
            {
                DrawActor(i);
                DrawActorInfo(i, actor);
                i++;
            }

            // draw enemies
            EnemyManager.Draw("DarkTroll", 60, 200);

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

            ActorManager.Draw(actor.BattleChar, new Rect(560 + (actor == Party.ActivePlayer ? -20 : 0), 140 + i * 48, 48, 48), actor.Rect);
        }

        public void DrawActorInfo(int i, Actor actor)
        {
            _graphics.DrawString(actor.Name, 280, 350 + i * 30);
            _graphics.DrawString("HP: " + actor.Hp.ToString(), 350, 350 + i * 30);
            _graphics.DrawString("/", 410, 350 + i * 30);
            _graphics.DrawString(actor.MaxHp.ToString(), 420, 350 + i * 30);
            _graphics.DrawString("MP: " + actor.Mp.ToString(), 460, 350 + i * 30);
            _graphics.DrawString("/", 510, 350 + i * 30);
            _graphics.DrawString(actor.MaxMp.ToString(), 520, 350 + i * 30);
            _graphics.DrawString("Limit " + actor.Limit, 550, 350 + i * 30);
            _graphics.DrawString("%", 610, 350 + i * 30);
        }
    }
}