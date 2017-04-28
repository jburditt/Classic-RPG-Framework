using Player;
using System.Drawing;

namespace RPGPlugin
{
    public static class RectangleExtensions
    {
        public static Rectangle ToRectangle(this Rect r)
        {
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        public static RectangleF ToRectangleF(this Rect r)
        {
            return new RectangleF(r.X, r.Y, r.Width, r.Height);
        }
    }
}