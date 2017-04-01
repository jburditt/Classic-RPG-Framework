namespace Player
{
    public class Animation
    {
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public int spriteWidth = 24;
        public int spriteHeight = 32;

        public Rect DrawRect(Vector n)
        {
            return new Rect(n.X, n.Y, spriteWidth, spriteHeight);
        }

        public Rect DrawRect(VectorF n)
        {
            return new Rect((int)n.X, (int)n.Y, spriteWidth, spriteHeight);
        }

        public Rect DrawRect(int x, int y)
        {
            return new Rect(x, y, spriteWidth, spriteHeight);
        }

        public Rect SourceRect {
            get {
                return new Rect(X * spriteWidth, Y * spriteHeight, spriteWidth, spriteHeight);
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