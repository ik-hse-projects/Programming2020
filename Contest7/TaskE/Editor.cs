using System;
using System.Linq;

abstract class Editor
{
    private int salary;
    private string name;


    protected Editor(string name, int salary)
    {
        this.name = name;
        this.salary = salary;
    }

    protected string EditHeader(string header) => header + $" {name}";

    public int CountSalary(string oldStr, string newStr) => salary * Math.Abs(oldStr.Length - newStr.Length);
}