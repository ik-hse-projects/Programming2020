using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


class RandomProxy
{
    private StreamWriter log;
    private Random random = new Random(1579);
    private Dictionary<string, int> users = new Dictionary<string, int>();

    public RandomProxy(StreamWriter log)
    {
        this.log = log;
    }

    public void Register(string login, int age)
    {
        if (users.ContainsKey(login))
        {
            throw new ArgumentException($"User {login}: login is already registered");
        }

        users[login] = age;
        log.WriteLine($"User {login}: login registered");
    }

    public int Next(string login)
    {
        if (!users.TryGetValue(login, out var age))
        {
            throw new ArgumentException($"User {login}: login is not registered");
        }

        var number = random.Next(0, age < 20 ? 1000 : int.MaxValue);
        log.WriteLine($"User {login}: generate number {number}");
        return number;
    }

    public int Next(string login, int maxValue)
    {
        return Next(login, 0, maxValue);
    }

    public int Next(string login, int minValue, int maxValue)
    {
        if (!users.TryGetValue(login, out var age))
        {
            throw new ArgumentException($"User {login}: login is not registered");
        }

        if (age < 20 && maxValue - minValue > 1000)
        {
            throw new ArgumentOutOfRangeException($"User {login}: random bounds out of range");
        }

        var number = random.Next(minValue, maxValue);
        log.WriteLine($"User {login}: generate number {number}");
        return number;
    }
}