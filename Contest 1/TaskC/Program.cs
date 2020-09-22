using System;

class Program
{
    static void Main(string[] args)
    {
       uint a;
       Console.WriteLine(
           uint.TryParse(Console.ReadLine(), out a)
               ? (a % 10).ToString()
               : "Incorrect input"
       );
    }
}
