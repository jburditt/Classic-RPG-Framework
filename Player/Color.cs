using System.Drawing;

namespace Player
{
    public struct ColorStruct
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public ColorStruct(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override string ToString()
        {
            return R + "," + G + "," + B + "," + A;
        }
    }

    public static class ColorExtensions {

        public static ColorStruct ToStruct(this Color color)
        {
            return new ColorStruct { R = color.R, G = color.G, B = color.B, A = color.A };
        }
    }
}