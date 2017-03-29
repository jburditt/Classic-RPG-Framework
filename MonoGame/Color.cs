using Microsoft.Xna.Framework;
using Player;

namespace MonoGame
{
    public static class ColorExtensions
    {
        public static Color ToColor(this ColorStruct? color)
        {
            return ToColor(color ?? ColorStruct.White);
        }
        public static Color ToColor(this ColorStruct color) {
            return new Color(color.R, color.G, color.B, color.A);
        }
    }
}