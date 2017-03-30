namespace Player
{
    public class Actor
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Mp { get; set; }
        public int MaxMp { get; set; }
        public int Speed { get; set; }
        public int Limit { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }

        public string CharSet { get; set; }
        public string BattleChar { get; set; }
        public ActorState State { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Animation animation { get; set; }

        public Rect Rect {
            get {
                return new Rect(48, 48 * 6, 48, 48);
            }
        }

        public Actor(string battleChar, string charSet)
        {
            this.BattleChar = battleChar;
            this.CharSet = charSet;
            animation = new Animation { X = 1, Y = 5 };
        }

        public bool TimeLapse(int timeIncrement)
        {
            Speed += timeIncrement;
            if (Speed > 100)
            {
                Speed -= 100;
                State = ActorState.Ready;
                return true;
            }

            return false;
        }

        public void Attack(Enemy enemy)
        {
            enemy.Hp -= 1;
            if (enemy.Hp <= 0)
                enemy.State = EnemyState.Dead;

            State = ActorState.Waiting;
        }
    }
}