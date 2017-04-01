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
}