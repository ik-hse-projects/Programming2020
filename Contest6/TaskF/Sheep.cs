using System;

public class Sheep
{
    public int _id;
    public string _name;
    public string _sound;

    public Sheep(int id, string name, string sound)
    {
        if (id <= 0 || id >= 1000)
        {
            throw new ArgumentException("Incorrect input");
        }
        _id = id;
        _name = name;
        _sound = sound;
    }
    
    public override string ToString() => $"[{_id}-{_name}]: {_sound}...{_sound}";
}