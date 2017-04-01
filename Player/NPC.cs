using Common;

namespace Player
{
    public class NPC
    {
        public WalkAnimation animation = new WalkAnimation();
        public Direction direction;

        public string Name { get; set; }
        public string CharSet { get; set; }
        public string Dialog { get; set; }
        public Vector Pos { get; set; }

        private Movement _movement;
        private Vector _destination;

        public void Update()
        {
            //switch (_movement)
            //{
            //    case Movement.Walking:

            //        if (Pos == _destination)
            //            _destination = NextDestination();
            //        break;
            //}
        }

        public Vector NextDestination()
        {
            int x = Random.Next(100);
            int y = 100 - x;
            x *= Random.Sign();
            y *= Random.Sign();

            return new Vector(x, y) + Pos;
        }
    }
}