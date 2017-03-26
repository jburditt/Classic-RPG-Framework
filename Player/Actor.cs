namespace Player
{
    public class Actor
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Mp { get; set; }
        public int MaxMp { get; set; }
        public int Limit { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public string CharSet { get; set; }
        public string BattleChar { get; set; }
        public Rect Rect {
            get {
                return new Rect(48, 48 * 6, 48, 48);
            }
        }

        private Animation animation;

        public Actor(string battleChar, string charSet)
        {
            this.BattleChar = battleChar;
            this.CharSet = charSet;
            animation = new Animation { X = 1, Y = 5 };
        }
    }
}