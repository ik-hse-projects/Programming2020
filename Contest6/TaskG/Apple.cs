using System;

public class Apple
{
    private double _weight;

    public double Weight
    {
        get => _weight;
        set
        {
            if (value <= 0 || value > 1000)
            {
                throw new ArgumentException("Incorrect input");
            }

            _weight = value;
        }
    }

    private string _color;

    public string Color
    {
        get => _color;
        set
        {
            if (value.Length == 0 || value.Length > 5 || !char.IsUpper(value[0]))
            {
                throw new ArgumentException("Incorrect input");
            }

            _color = value;
        }
    }

    public override string ToString() => $"{Color} Apple. Weight = {Weight:f2}g.";
}