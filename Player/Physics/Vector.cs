using System;

public struct Vector
{
    public int X;
    public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Vector a, Vector b)
    {
        return (a.X == b.X && a.Y == b.Y);
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y);
    }

    //public override bool Equals(object obj)
    //{
    //    this.Equals(obj);
    //}

    public static int Distance(Vector a, Vector b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}

public struct VectorF
{
    public float X;
    public float Y;

    public VectorF(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(VectorF a, VectorF b)
    {
        return (a.X == b.X && a.Y == b.Y);
    }

    public static bool operator !=(VectorF a, VectorF b)
    {
        return !(a == b);
    }

    public static VectorF operator +(VectorF a, VectorF b)
    {
        return new VectorF(a.X + b.X, a.Y + b.Y);
    }

    public static VectorF operator -(VectorF a, VectorF b)
    {
        return new VectorF(a.X - b.X, a.Y - b.Y);
    }

    public static VectorF operator /(VectorF a, VectorF b)
    {
        return new VectorF(a.X / b.X, a.Y / b.Y);
    }

    public static VectorF operator *(VectorF a, VectorF b)
    {
        return new VectorF(a.X * b.X, a.Y * b.Y);
    }

    //public override bool Equals(object obj)
    //{
    //    this.Equals(obj);
    //}

    public static float Distance(VectorF a, VectorF b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}

public static class VectorExtensions
{
    public static Vector ToVector(this VectorF n)
    {
        return new Vector((int)n.X, (int)n.Y);
    }
}