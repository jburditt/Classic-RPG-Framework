using Microsoft.Xna.Framework;

namespace Player
{
    public static class RectangleExtension
    {
        public static Rectangle ToRectangle(this Rect rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}