using System;
using System.Linq;


public class Group
{
    private Student[] students;
    
    public Group(Student[] students)
    {
        if (students.Length < 5)
        {
            throw new ArgumentException("Incorrect group");
        }
        this.students = students;
    }

    public int IndexOfMaxGrade()
    {
        var max = students[0];
        var idx = 0;
        for (var i = 0; i < students.Length; i++)
        {
            var student = students[i];
            if (student.Grade > max.Grade)
            {
                max = student;
                idx = i;
            }
        }

        return idx;
    }

    public int IndexOfMinGrade()
    {
        var min = students[0];
        var idx = 0;
        for (var i = 0; i < students.Length; i++)
        {
            var student = students[i];
            if (student.Grade < min.Grade)
            {
                min = student;
                idx = i;
            }
        }

        return idx;
    }

    public Student this[int i] => students[i];
}