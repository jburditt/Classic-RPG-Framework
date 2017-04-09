using System.Drawing;
using Player;

namespace RPGPlugin
{
    public class TileCursor
    {
        public Vector Pos { get; set; }
        public Size Size { get; set; }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.White, 1), Pos.X + 1, Pos.Y + 1, Size.Width - 2, Size.Height - 2);
        }
    }
}