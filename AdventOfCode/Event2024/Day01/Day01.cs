using AdventOfCode.Shared;
using System.Data.Common;
using System.Numerics;

namespace AdventOfCode.Event2024;

internal class Day01
{

    public static void Part1()
    { 
        var input = Input.ReadSampleInput(1);
        var side1 = new List<int>();
        var side2 = new List<int>();

        foreach (var line in input)
        {
            var sides = line.Split("\t");
            if (sides == null) continue;

            side1.Add(int.Parse(sides[0]));
            side2.Add(int.Parse(sides[1]));
        }

        side1.Sort();
        side2.Sort();

        var total = 0;

        for (var i = 0; i < side1.Count; i++)
        {
            var diff = side1[i] - side2[i];
            total += diff;
        }

        Console.Write($"Total: {total}");
    }

    public static void Part2() 
    { 
    
    }

}