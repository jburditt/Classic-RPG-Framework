using System.Collections.Generic;

namespace Player
{
    public class EnemyParty
    {
        public List<Enemy> Enemies = new List<Enemy>();

        public EnemyParty(List<Enemy> enemies)
        {
            Enemies = enemies;
        }

        public void Init()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Hp = enemy.MaxHp;
                enemy.Mp = enemy.MaxMp;
            }
        }

        public bool IsDead()
        {
            foreach (var enemy in Enemies)
                if (enemy.State != EnemyState.Dead)
                    return false;

            return true;
        }
    }
}
