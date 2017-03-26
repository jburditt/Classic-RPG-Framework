using Microsoft.Xna.Framework;

namespace Player
{
    public class Animation
    {
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public int spriteWidth = 24;
        public int spriteHeight = 32;

        public Rectangle DrawRect(int x, int y)
        {
            return new Rectangle(x, y, spriteWidth, spriteHeight);
        }

        public Rectangle SourceRect {
            get {
                return new Rectangle(X * spriteWidth, Y * spriteHeight, spriteWidth, spriteHeight);
            }
        }
    }

    public class WalkAnimation : Animation
    {
        public int frame { get; set; }
        private int totalFrames = 3, delay = 10, step = 0;
        public override int X { get { return sequence[frame]; } }
        private int[] sequence = new int[4] { 0, 1, 2, 1 };
         
        public void Step()
        {
            step++;
            if (step > delay)
            {
                step = 0;
                frame++;
                if (frame > totalFrames)
                    frame = 0;
            }
        }
    }
}