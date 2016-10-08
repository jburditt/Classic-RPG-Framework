namespace TiledSharp_MonoGame_Example
{
    public class Player
    {
        public int X, Y;
        public int SpeedX = 4, SpeedY = 4;

        public void MoveUp(Map map)
        {
            Y -= SpeedY;
            if (Y < 0) Y = 0;
        }

        public void MoveDown(Map map)
        {
            Y += SpeedY;
            if (Y > map.Height) Y = map.Height;
        }

        public void MoveLeft(Map map)
        {
            X -= SpeedX;
            if (X < 0) X = 0;
        }

        public void MoveRight(Map map)
        {
            X += SpeedX;
            if (X > map.Width) X = map.Width;
        }
    }
}