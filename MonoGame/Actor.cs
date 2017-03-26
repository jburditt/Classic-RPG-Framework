using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        public int Order { get; set; }

        private Texture2D battleChar;
        private Texture2D charSet;
        private Animation animation;

        public Actor(ContentManager Content, string battleCharFileName, string charSetFileName)
        {
            battleChar = Content.Load<Texture2D>(battleCharFileName);
            charSet = Content.Load<Texture2D>(charSetFileName);
            animation = new Animation { X = 1, Y = 5 };
        }
    }
}