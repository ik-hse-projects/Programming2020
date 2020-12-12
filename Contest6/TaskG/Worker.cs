using System;
using System.Collections.Generic;
using System.Linq;

public class Worker
{
    private Apple[] _apples;
    
    public Worker(Apple[] apples)
    {
        _apples = apples;
    }

    public IEnumerable<Apple> GetSortedApples() => _apples.OrderBy(apple => apple.Weight);
}