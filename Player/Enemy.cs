namespace Player
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Mp { get; set; }
        public int MaxMp { get; set; }
        public int Dexterity { get; set; }
        public int Speed { get; set; }
        public string SpriteName { get; set; }
        public EnemyState State { get; set; }

        public bool TimeLapse(int timeIncrement)
        {
            Speed += timeIncrement;
            if (Speed > 100)
            {
                Speed -= 100;
                State = EnemyState.Ready;
                return true;
            }

            return false;
        }

        public Actor Action(Party party)
        {
            var target = party.GetRandom();
            target.Hp -= 1;

            if (target.Hp <= 0)
                target.State = ActorState.Dead;

            return target;
        }
    }
}