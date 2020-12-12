using System;

public class RegularPolygon : Polygon
{
    private double _side;
    private int _numberOfSides;
    
    public RegularPolygon(double side, int numberOfSides)
    {
        if (side <= 0)
        {
            throw new ArgumentException("Side length value should be greater than zero.");
        }
        _side = side;

        if (numberOfSides < 3)
        {
            throw new ArgumentException("Number of sides value should be greater than 3.");
        }
        _numberOfSides = numberOfSides;
    }

    public override double Perimeter => _numberOfSides * _side;

    public override double Area => _numberOfSides * _side*_side / Math.Tan(Math.PI / _numberOfSides) / 4;

    public override string ToString() =>
        $"side: {_side}; numberOfSides: {_numberOfSides}; area: {Area:f3}; perimeter: {Perimeter:f3}";
}