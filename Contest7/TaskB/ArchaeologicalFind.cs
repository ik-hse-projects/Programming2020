using System;
using System.Collections.Generic;
using System.Linq;

public class ArchaeologicalFind
{
    public readonly int Age;
    public readonly int Weight;
    public readonly string Name;

    public readonly int Index;

    public ArchaeologicalFind(int age, int weight, string name)
    {
        if (age <= 0)
        {
            throw new ArgumentException("Incorrect age");
        }

        if (weight <= 0)
        {
            throw new ArgumentException("Incorrect weight");
        }

        if (name == "?")
        {
            throw new ArgumentException("Undefined name");
        }

        Age = age;
        Weight = weight;
        Name = name;
        Index = TotalFindsNumber;
        TotalFindsNumber++;
    }

    public static int TotalFindsNumber { get; internal set; }

    /// <summary>
    /// Добавляет находку в список.
    /// </summary>
    /// <param name="finds">Список находок.</param>
    /// <param name="archaeologicalFind">Находка.</param>
    public static void AddFind(ICollection<ArchaeologicalFind> finds, ArchaeologicalFind archaeologicalFind)
    {
        if (finds.Any(x => x.Equals(archaeologicalFind)))
        {
            return;
        }

        finds.Add(archaeologicalFind);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is ArchaeologicalFind find))
        {
            return false;
        }

        return find.Age == this.Age && find.Name == this.Name && find.Weight == this.Weight;
    }

    public override string ToString() => $"{Index} {Name} {Age} {Weight}";
}