using Player;
using System.Drawing;

namespace Editor
{
    public static class ColorExtensions
    {
        public static Color ToColor(this ColorStruct color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}