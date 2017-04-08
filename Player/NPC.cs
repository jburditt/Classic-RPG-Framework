using Common;

namespace Player
{
    public class NPC
    {
        public WalkAnimation Animation = new WalkAnimation();
        public Direction Direction;

        public string Name { get; set; }
        public string CharSet { get; set; }
        public string Dialog { get; set; }
        public Vector Pos;
        public Movement Movement;

        private Vector _destination;
        private int _step;

        public void Update(MapEngine map)
        {
            switch (Movement)
            {
                case Movement.Walking:

                    if (Pos == _destination || (_destination.X == 0 && _destination.Y == 0) || _step > 100)
                        _destination = NextDestination();

                    var oldPos = Pos;

                    // move towards destination
                    if (Pos.X > _destination.X && Pos.X > 0 && !map.IsCollision(Pos, Direction.Left))
                        Pos.X--;
                    else if (Pos.X < _destination.X && Pos.X < map.Width && !map.IsCollision(Pos, Direction.Right))
                        Pos.X++;

                    if (Pos.Y > _destination.Y && Pos.Y > 0 && !map.IsCollision(Pos, Direction.Up))
                        Pos.Y--;
                    else if (Pos.Y < _destination.Y && Pos.Y < map.Height && !map.IsCollision(Pos, Direction.Down))
                        Pos.Y++;

                    _step++;

                    Animation.Step();

                    break;
            }
        }

        public Vector NextDestination()
        {
            _step = 0;

            int x = Random.Next(-100, 100);
            int y = Random.Next(-100, 100);

            if (x > y)
            {
                if (x > 0)
                    Direction = Direction.Right;
                else
                    Direction = Direction.Left;
            }
            else
            {
                if (y > 0)
                    Direction = Direction.Down;
                else
                    Direction = Direction.Up;
            }

            return new Vector(x, y) + Pos;
        }

        public void Talk()
        {
            
        }
    }
}