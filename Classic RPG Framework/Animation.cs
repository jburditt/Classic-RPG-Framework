namespace Player
{
    public class Animation
    {

        public int frame { get; set; }
        private int totalFrames = 3, delay = 10, step = 0;
        public int x { get { return sequence[frame]; } }
        public int y { get; private set; }
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