using System;

public class Triangle
{
    private readonly Point a;
    private readonly Point b;
    private readonly Point c;

    private double AB2 => GetSquaredLengthOfSide(a, b);
    private double AC2 => GetSquaredLengthOfSide(a, c);
    private double BC2 => GetSquaredLengthOfSide(b, c);

    private double AB => Math.Sqrt(AB2);
    private double AC => Math.Sqrt(AC2);
    private double BC => Math.Sqrt(BC2);

    public Triangle(Point a, Point b, Point c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double GetPerimeter()
    {
        return AB + AC + BC;
    }

    public double GetSquare()
    {
        var p = GetPerimeter() / 2;
        return Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC));
    }

    public bool GetAngleBetweenEqualsSides(out double angle)
    {
        if (AB2 == AC2)
        {
            angle = GetAngleBetween(b, a, c);
            return true;
        }

        if (AB2 == BC2)
        {
            angle = GetAngleBetween(a, b, c);
            return true;
        }

        if (AC2 == BC2)
        {
            angle = GetAngleBetween(a, c, b);
            return true;
        }

        angle = default;
        return false;
    }

    public bool GetHypotenuse(out double hypotenuse)
    {
        if (AB2 == AC2 + BC2)
        {
            hypotenuse = AB;
            return true;
        }

        if (AC2 == AB2 + BC2)
        {
            hypotenuse = AC;
            return true;
        }

        if (BC2 == AC2 + AB2)
        {
            hypotenuse = BC;
            return true;
        }

        hypotenuse = default;
        return false;
    }

    private static double GetAngleBetween(Point a, Point b, Point c)
    {
        var first = new Point(b.GetX() - a.GetX(), b.GetY() - a.GetY());
        var second = new Point(b.GetX() - c.GetX(), b.GetY() - c.GetY());
        var t = first.GetX() * second.GetX() + first.GetY() * second.GetY();
        var l = Math.Sqrt(GetSquaredLengthOfSide(a, b) * GetSquaredLengthOfSide(b, c));
        return Math.Acos(t / l);
    }

    private static double GetSquaredLengthOfSide(Point first, Point second)
    {
        var x = first.GetX() - second.GetX();
        var y = first.GetY() - second.GetY();
        return x*x + y*y;
    }
}