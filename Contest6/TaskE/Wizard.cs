using System;
using System.IO;

public class Wizard : LegendaryHuman
{
    private string _rank;
    private int _rankNum;

    public Wizard(string name, int healthPoints, int power, string rank) : base(name, healthPoints, power)
    {
        _rank = rank;
        _rankNum = DecodeRank(rank);
    }

    private static int DecodeRank(string rank)
    {
        return rank switch
        {
            "Neophyte" => 1,
            "Adept" => 2,
            "Charmer" => 3,
            "Sorcerer" => 4,
            "Master" => 5,
            "Archmage" => 6,
            _ => throw new ArgumentException("Invalid wizard rank.")
        };
    }

    public override void Attack(LegendaryHuman enemy)
    {
        if (HealthPoints < 0 || enemy.HealthPoints < 0)
        {
            return;
        }
        Console.WriteLine($"{this} attacked {enemy}");
        var strength = Power * Math.Pow(_rankNum, 1.5) + HealthPoints / 10d;
        enemy.HealthPoints -= (int) strength;
        if (enemy.HealthPoints < 0)
        {
            Console.WriteLine($"{enemy} is dead." );
        }
    }

    public override string ToString()
    {
        return $"{_rank} Wizard {Name} with HP {HealthPoints}";
    }
}