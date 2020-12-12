using System;

public class Polygon
{
    private double _area;

    private double _perimeter;

    public virtual double Area => _area;

    public virtual double Perimeter => _perimeter;

    protected Polygon()
    {
    }

    public Polygon(double area, double perimeter)
    {
        if (area <= 0 || perimeter <= 0)
        {
            throw new ArgumentException("Input parameters should be greater than zero.");
        }

        _area = area;
        _perimeter = perimeter;
    }

    public override string ToString() => $"area: {Area:f3}; perimeter: {Perimeter:f3}";
}