namespace Player
{
    public struct Rect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rect(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }

    public static class RectExtensions
    {
        public static bool Intersects(this Rect a, Rect b)
        {
            return a.X >= b.X && a.X <= b.X + b.Width && a.Y >= b.Y && a.Y <= b.Y + b.Height;
        }
    }
}