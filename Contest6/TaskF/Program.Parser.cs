using System;


public partial class Program
{
    static Sheep ParseSheep(string line)
    {
        var splitted = line.Split(' ');
        if (splitted.Length != 7
            || splitted[0] != "Sheep"
            || splitted[2] != "with"
            || splitted[3] != "Id"
            || splitted[5] != "makes"
            || !int.TryParse(splitted[4], out var id)
        )
        {
            throw new ArgumentException("Incorrect input");
        }

        var name = splitted[1];
        var sound = splitted[6];
        return new Sheep(id, name, sound);
    }
}