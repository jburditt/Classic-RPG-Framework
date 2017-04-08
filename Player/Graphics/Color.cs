using System;
using System.Drawing;

namespace Player
{
    [Serializable]
    public struct ColorStruct
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public static ColorStruct White { get { return new ColorStruct(255, 255, 255, 255); } }

        public ColorStruct(int r, int g, int b) : this(r, g, b, 255) { }

        public ColorStruct(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static bool operator ==(ColorStruct a, ColorStruct b)
        {
            return (a.A == b.A &&
                a.R == b.R &&
                a.G == b.G &&
                a.B == b.B);
        }

        public static bool operator !=(ColorStruct a, ColorStruct b)
        {
            return !(a == b);
        }

        public static ColorStruct Multiply(ColorStruct value, float scale)
        {
            byte Red = (byte)(value.R * scale);
            byte Green = (byte)(value.G * scale);
            byte Blue = (byte)(value.B * scale);
            byte Alpha = (byte)(value.A * scale);

            return new ColorStruct(Red, Green, Blue, Alpha);
        }

        public static ColorStruct operator *(ColorStruct value, float scale)
        {
            return Multiply(value, scale);
        }

        public override int GetHashCode()
        {
            return R + G * 1000 + B * 1000000 + A * 1000000000;
        }

        public override bool Equals(object obj)
        {
            return ((obj is Color) && this.Equals((Color)obj));
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