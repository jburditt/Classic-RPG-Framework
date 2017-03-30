using Player.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Player
{
    public class GameEngine
    {
        public Party Party { get; private set; }
        public EnemyParty EnemyParty { get; private set; }

        public GameEngine(ISongManager songManager, IEnemyManager enemyManager)
        {
            Party = new Party
            {
                Actors = new List<Actor> {
                    new Actor("gus", "gus") { Name = "Gus", Hp = 40, MaxHp = 58, Mp = 2, MaxMp = 8, Limit = 23 },
                    new Actor("fitz", "fitz") { Name = "Fitz", Hp = 32, MaxHp = 52, Mp = 5, MaxMp = 12, Limit = 17 },
                    new Actor("sorah", "sorah") { Name = "Sorah", Hp = 102, MaxHp = 252, Mp = 8, MaxMp = 12, Limit = 37 },
                    new Actor("sheba", "sheba") { Name = "Sheba", Hp = 44, MaxHp = 52, Mp = 8, MaxMp = 12, Limit = 5 }
                }
            };

            EnemyParty = new EnemyParty(new List<Enemy> { enemyManager.Enemies["DarkTroll"] });

            //songManager.Play("01 - Namazu");
            songManager.Play("Battle of the Mind");
        }
    }
}