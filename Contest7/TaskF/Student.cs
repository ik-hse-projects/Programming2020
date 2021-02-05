using System;

public class Student
{
    private readonly string name;
    public readonly int Grade;

    private Student(string name, int grade)
    {
        this.name = name;
        Grade = grade;
    }

    public static Student Parse(string line)
    {
        var splitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (splitted.Length != 2)
        {
            throw new ArgumentException();
        }

        if (!int.TryParse(splitted[1], out var grade))
        {
            throw new ArgumentException("Incorrect input mark");
        }

        if (splitted[0].Length < 3 || char.IsLower(splitted[0][0]))
        {
            throw new ArgumentException("Incorrect name");
        }

        if (grade < 0 || grade > 10)
        {
            throw new ArgumentException("Incorrect mark");
        }

        return new Student(splitted[0], grade);
    }

    public override string ToString() => $"{name} got a grade of {Grade}.";
}