using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integer = System.Int32;

static class Program
{
    public static void Main(string[] args)
    {
        var expression = Console.ReadLine();
        expression = expression.Replace(" ", "");
        Console.WriteLine(Evaluate(Tokenize(expression)));
    }

    private static Integer Int(this object obj)
    {
        return (Integer) obj;
    }

    private static IEnumerable<object> Tokenize(string expression)
    {
        StringBuilder number = new StringBuilder();
        foreach (var symbol in expression)
        {
            if (char.IsDigit(symbol) || symbol == ',' || symbol == '.')
            {
                number.Append(symbol);
            }
            else
            {
                if (number.Length != 0)
                {
                    yield return Integer.Parse(number.ToString());
                    number.Clear();
                }

                yield return symbol;
            }
        }

        if (number.Length != 0)
        {
            yield return Integer.Parse(number.ToString());
        }
    }

    private static IEnumerable<object> Debracket(IEnumerable<object> expression)
    {
        var depth = 0;
        var buffer = new List<object>();
        foreach (var elem in expression)
        {
            if (elem is '(')
            {
                if (depth != 0)
                {
                    buffer.Add(elem);
                }

                depth++;
            }
            else if (elem is ')')
            {
                depth--;
                if (depth == 0)
                {
                    yield return Evaluate(buffer);
                    buffer.Clear();
                }
                else
                {
                    buffer.Add(elem);
                }
            }
            else if (depth != 0)
            {
                buffer.Add(elem);
            }
            else
            {
                yield return elem;
            }
        }
    }

    private static void Operator(Func<Integer, Integer, Integer> op, ref int index, List<object> expression)
    {
        Integer left;
        if (index != 0)
        {
            left = expression[index - 1].Int();
            expression.RemoveAt(index - 1);
            index--;
        }
        else
        {
            left = 0;
        }

        var right = expression[index + 1].Int();
        expression.RemoveAt(index + 1);

        expression[index] = op(left, right);
    }

    private static Integer Evaluate(IEnumerable<object> expression)
    {
        var expr = expression.ToList();
        var simplified = Debracket(expr).ToList();
        for (var index = 0; index < simplified.Count;)
        {
            var op = simplified[index];
            if (op is '*')
            {
                Operator((a, b) => a * b, ref index, simplified);
            }
            else if (op is '/')
            {
                Operator((a, b) => a / b, ref index, simplified);
            }
            else
            {
                index++;
            }
        }

        //Console.Write(string.Join(" ", expr.Select(i => i.ToString())));
        //Console.Write(" = " + string.Join(" ", simplified.Select(i => i.ToString())));
        for (var index = 0; index < simplified.Count;)
        {
            var op = simplified[index];
            if (op is '-')
            {
                Operator((a, b) => a - b, ref index, simplified);
            }
            else if (op is '+')
            {
                Operator((a, b) => a + b, ref index, simplified);
            }
            else
            {
                index++;
            }
        }
        
        //Console.WriteLine(" = " + string.Join(" ", simplified.Select(i => i.ToString())));
        return simplified[0].Int();
    }
}