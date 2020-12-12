using System;
using System.Collections.Generic;
using System.Linq;

public class Grassland
{
    private List<Sheep> _sheeps;
    
    public Grassland(List<Sheep> sheeps)
    {
        _sheeps = sheeps;
    }

    public List<Sheep> GetEvenSheeps() => _sheeps.Where(sheep => sheep._id % 2 == 0).ToList();

    public List<Sheep> GetOddSheeps() => _sheeps.Where(sheep => sheep._id % 2 == 1).ToList();

    public List<Sheep> GetSheepsByContainsName(string name) =>
        _sheeps.Where(sheep => sheep._name.Contains(name)).ToList();
}
