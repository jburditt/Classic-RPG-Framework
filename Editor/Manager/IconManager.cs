using Player;
using Player.Manager;
using System.Collections.Generic;
using System.Drawing;

namespace Editor.Manager
{
    public class IconManager : IIconManager
    {
        public Graphics Graphics { get; set; }

        public Dictionary<string, Bitmap> Icons = new Dictionary<string, Bitmap>();

        public IconManager(Graphics graphics)
        {
            Graphics = graphics;
        }

        public void Draw(string iconName, int x, int y, ColorStruct? color = null)
        {
            Draw(iconName, new Vector(x, y), color);
        }

        public void Draw(string iconName, Vector vector, ColorStruct? color = null)
        {
            var sourceRect = new Rect(0, 0, Icons[iconName].Width, Icons[iconName].Height);
            var targetRect = new Rect(vector.X, vector.Y, Icons[iconName].Width, Icons[iconName].Height);

            Graphics.DrawImage(Icons[iconName], targetRect.ToRectangle(), sourceRect.ToRectangle(), GraphicsUnit.Pixel);
        }

        public void Draw(string iconName, Rect sourceRect, Rect targetRect, ColorStruct? color = null)
        {
            Graphics.DrawImage(Icons[iconName], targetRect.ToRectangle(), sourceRect.ToRectangle(), GraphicsUnit.Pixel);
        }
    }
}