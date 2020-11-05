using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

enum Relation
{
    Eq,
    Neq,
    Leq,
    Geq,
}

struct Entry
{
    public string Line;
    public string FirstName;
    public string LastName;
    public string Group;
    public int Rating;
    public decimal Gpa;
}

static class RelationExt
{
    public static Expression<Func<Entry, bool>> Compare<T>(this Relation rel, Expression<Func<Entry, T>> sel, T match)
    {
        return rel switch
        {
            Relation.Eq => Expression.Lambda<Func<Entry, bool>>(
                Expression.Equal(sel.Body, Expression.Constant(match)),
                sel.Parameters
            ),
            Relation.Neq => Expression.Lambda<Func<Entry, bool>>(
                Expression.NotEqual(sel.Body, Expression.Constant(match)),
                sel.Parameters
            ),
            Relation.Leq => Expression.Lambda<Func<Entry, bool>>(
                Expression.LessThanOrEqual(sel.Body, Expression.Constant(match)),
                sel.Parameters
            ),
            Relation.Geq => Expression.Lambda<Func<Entry, bool>>(
                Expression.GreaterThanOrEqual(sel.Body, Expression.Constant(match)),
                sel.Parameters
            )
        };
    }
}

partial class Program
{
    private static void AddChar(char ch, ref string curr, ref string next)
    {
        if (char.IsWhiteSpace(ch))
        {
            if (curr != "")
            {
                next = "";
            }
        }
        else
        {
            curr += ch;
        }
    }

    private static Expression<Func<Entry, bool>> ParseQuery(string query)
    {
        string col = "";
        string rel = null;
        string val = null;

        foreach (var ch in query)
        {
            if (val != null)
            {
                if (!char.IsWhiteSpace(ch) || val != "")
                {
                    val += ch;
                }
            }
            else if (rel != null)
            {
                AddChar(ch, ref rel, ref val);
            }
            else
            {
                AddChar(ch, ref col, ref rel);
            }
        }

        if (col == null || rel == null || val == null)
        {
            return null;
        }

        if (val.Any(char.IsWhiteSpace))
        {
            return null;
        }

        Relation? maybeRelation = rel switch
        {
            "==" => Relation.Eq,
            "<>" => Relation.Neq,
            "<=" => Relation.Leq,
            ">=" => Relation.Geq,
            _ => null
        };
        if (maybeRelation == null)
        {
            return null;
        }

        var relation = maybeRelation.Value;

        var numbers = relation == Relation.Geq || relation == Relation.Leq;
        var strings = relation == Relation.Eq || relation == Relation.Neq;
        switch (col.ToLower())
        {
            case "first_name" when strings:
                return relation.Compare(e => e.FirstName, val.ToLower());
            case "last_name" when strings:
                return relation.Compare(e => e.LastName, val.ToLower());
            case "group" when strings:
                return relation.Compare(e => e.Group, val.ToLower());
            case "rating" when numbers:
                if (int.TryParse(val, out var n))
                    return relation.Compare(e => e.Rating, n);
                else
                    return null;
            case "gpa" when numbers:
                if (decimal.TryParse(val, out var d))
                    return relation.Compare(e => e.Gpa, d);
                else
                    return null;
            default:
                return null;
        }
    }

    private static bool ValidateQuery(string query, out string[] queryParameters)
    {
        queryParameters = new[] {query};
        return ParseQuery(query) != null;
    }

    delegate void Setter(ref Entry e, string value);

    private static IEnumerable<Entry> ParseDb(string pathToDatabase)
    {
        var lines = File.ReadAllLines(pathToDatabase);

        var setters = lines[0]
            .Split(';')
            .Select(column => (Setter) (column.ToLower() switch
            {
                "first_name" => (ref Entry e, string value) => e.FirstName = value.ToLower(),
                "last_name" => (ref Entry e, string value) => e.LastName = value.ToLower(),
                "group" => (ref Entry e, string value) => e.Group = value.ToLower(),
                "rating" => (ref Entry e, string value) => e.Rating = int.Parse(value),
                "gpa" => (ref Entry e, string value) => e.Gpa = decimal.Parse(value),
            }))
            .ToArray();

        foreach (var line in lines.Skip(1))
        {
            var entry = new Entry
            {
                Line = line
            };
            var splitted = line.Split(';');
            for (var index = 0; index < splitted.Length; index++)
            {
                setters[index](ref entry, splitted[index]);
            }

            yield return entry;
        }
    }

    private static List<string> ProcessQuery(string[] queryParameters, string pathToDatabase)
    {
        var filter = ParseQuery(queryParameters[0]).Compile();
        var db = ParseDb(pathToDatabase);
        var res = db.Where(filter).Select(x => x.Line).ToList();
        return res;
    }
}