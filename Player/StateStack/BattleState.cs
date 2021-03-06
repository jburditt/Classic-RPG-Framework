﻿using System.Collections.Generic;
using System.Linq;
using Player.Graphics;
using Player.Manager;
using Player.Effect;
using Player.Inputs;

namespace Player.StateStack
{
    public class BattleState : IState
    {
        private Party Party { get; set; }
        private EnemyParty EnemyParty;
        private List<IEffect> Effects = new List<IEffect>();

        private IDialogManager _dialog;
        private IGraphics _graphics;
        private IBattleManager _battleManager;
        private IActorManager _actorManager;
        private IEnemyManager _enemyManager;
        private IIconManager _iconManager;
        private IInputManager _inputManager;
        private ISongManager _songManager;

        private WorldState _worldState;
        private BattleStateEnum battleState = BattleStateEnum.Running;
        private int timeIncrement = 1;

        public BattleState(
            IGraphics graphics, IBattleManager battleManager, IActorManager actorManager, IEnemyManager enemyManager, 
            IIconManager iconManager, IInputManager inputManager, ISongManager songManager, IDialogManager dialog, WorldState worldState)
        {
            _graphics = graphics;
            _battleManager = battleManager;
            _actorManager = actorManager;
            _enemyManager = enemyManager;
            _iconManager = iconManager;
            _inputManager = inputManager;
            _songManager = songManager;
            _dialog = dialog;
            _worldState = worldState;
        }

        public void OnLoad()
        {
            _songManager.Play("Battle of the Mind");

            Party = _worldState.Party;

            for (var i = 0; i < Party.Actors.Count; i++)
            {
                Party.Actors[i].X = 560;
                Party.Actors[i].Y = 140 + i * 48;
            }

            EnemyParty = new EnemyParty(new List<Enemy> { _enemyManager.Enemies["DarkTroll"] });
            EnemyParty.Init();
        }

        public void OnClose()
        {
            _songManager.Stop();

            EnemyParty = null;
        }

        public bool Update(float elapsedTime)
        {          
            switch (battleState)
            {
                case BattleStateEnum.Running:

                    foreach (var enemy in EnemyParty.Enemies)
                        if (enemy.TimeLapse(timeIncrement))
                        {
                            var target = enemy.Action(Party);
                            Effects.Add(new DialogEffect(_graphics, _dialog, $"{enemy.Name} attacked."));
                            Effects.Add(new HpEffect(_graphics, "1", target.X, target.Y));
                        }

                    foreach (var actor in Party.Actors)
                    {
                        if (actor.TimeLapse(timeIncrement))
                        {
                            battleState = BattleStateEnum.Idle;
                            Party.ActivePlayer = actor;
                            break;
                        }
                    }
                    break;

                case BattleStateEnum.Idle:

                    if (_inputManager.JustPressedInput((int)Input.FaceButtonDown, (int)Input.Up))
                    {
                        var enemy = EnemyParty.Enemies.First();
                        int damage = Party.ActivePlayer.Attack(enemy);
                        Effects.Add(new HpEffect(_graphics, damage.ToString(), 60, 200));

                        Party.ActivePlayer = null;

                        battleState = BattleStateEnum.Running;

                        if (EnemyParty.IsDead())
                            return false;
                    }
                    break;
            }

            return true;
        }

        public void Draw()
        {
            _battleManager.Draw("02doukutsu");
            _dialog.Draw(new Rect(200, 330, 440, 150));

            if (battleState == BattleStateEnum.Idle)
            {
                _iconManager.Draw("attack", new Vector(50, 350), ColorStruct.White * (_inputManager.IsPressedKey((int)Keys.Up) ? 1f : 0.7f));
                _iconManager.Draw("magic", new Vector(20, 380), ColorStruct.White * (_inputManager.IsPressedKey((int)Keys.Left) ? 1f : 0.7f));
                _iconManager.Draw("defend", new Vector(80, 380), ColorStruct.White * (_inputManager.IsPressedKey((int)Keys.Right) ? 1f : 0.7f));
                _iconManager.Draw("item", new Vector(50, 410), ColorStruct.White * (_inputManager.IsPressedKey((int)Keys.Down) ? 1f : 0.7f));
                _iconManager.Draw("run", new Vector(20, 410), ColorStruct.White * 0.7f);
            }

            var i = 0;
            foreach (var actor in Party.Actors)
            {
                DrawActor(i);
                DrawActorInfo(i, actor);
                i++;
            }

            // draw enemies
            _enemyManager.Draw("DarkTroll", 60, 200);

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

            _actorManager.DrawBattle(actor.BattleChar, new Rect(actor.X + (actor == Party.ActivePlayer ? -20 : 0), actor.Y, 48, 48), actor.Rect);
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