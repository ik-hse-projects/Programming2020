using System;

class Boat
{
    public int Value;
    public bool IsAtThePort;
    
    public Boat(int value, bool isAtThePort)
    {
        this.Value = value;
        this.IsAtThePort = isAtThePort;
    }

    public int CountCost(int weight)
    {
        return Value * weight;
    }
}


