using System;

public class Point
{
    public readonly int X;
    public readonly int Y;
    public readonly int Z;

    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    protected bool Equals(Point other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((Point) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public override string ToString() => $"{X} {Y} {Z}";
}