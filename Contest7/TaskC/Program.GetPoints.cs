using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Program
{
    /// <summary>
    /// Считывает точки в список.
    /// </summary>
    /// <returns>Список точек.</returns>
    private static List<Point> GetPoints()
    {
        return File.ReadLines(InputPath).Select(ln =>
        {
            var splitted = ln.Split().Select(int.Parse).ToArray();
            return new Point(splitted[0], splitted[1], splitted[2]);
        }).ToList();
    }

    /// <summary>
    /// Получает коллекцию уникальных точек.
    /// </summary>
    /// <param name="points">Список исходных точек.</param>
    /// <returns>Коллекция точек.</returns>
    private static HashSet<Point> GetUnique(List<Point> points) => points.ToHashSet();
}