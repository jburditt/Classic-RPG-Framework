using System.Collections.Generic;

namespace Player.Manager
{
    public interface IEnemyManager
    {
        Dictionary<string, Enemy> Enemies { get; }

        void Draw(string enemyName, int x, int y);
    }
}