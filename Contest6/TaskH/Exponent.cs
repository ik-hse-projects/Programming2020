using System;

public class Exponent : Function
{
    public override double GetValueInX(double x) => Math.Exp(1 / x);
}
