using System;

class Program
{
    static void Main(string[] args)
    {
        var s = Console.ReadLine();
        Console.WriteLine(
            s != null && s.Length == 1 && s[0] >= 'a' && s[0] <= 'z'
            ? (s[0] - 'a' + 1).ToString()
            : "Incorrect input"
        );
    }
}
