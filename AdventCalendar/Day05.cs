using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventCalendar;

public class Day05
{
    public static void Part1()
    {
        var stacks = InitStacks();

        foreach (var movement in File.ReadAllLines("C:\\Temp\\advent\\input-day5-movement.txt"))
        {
            var m = Regex.Match(movement, @"move (\d*) from (\d*) to (\d*)");

            for (var i = 0; i < int.Parse(m.Groups[1].Value); i++)
            {
                char crate;
                if (stacks[int.Parse(m.Groups[2].Value) - 1].TryPop(out crate))
                {
                    stacks[int.Parse(m.Groups[3].Value) - 1].Push(crate);
                }                
            }
        }

        var result = new StringBuilder();
        for (var i = 0; i < stacks.Count(); i++) 
        {            
            result.Append(stacks[i].Peek());
        }

        Console.WriteLine("Day 5 - Part 1");
        Console.WriteLine(result);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var stacks = InitStacks();

        foreach (var movement in File.ReadAllLines("C:\\Temp\\advent\\input-day5-movement.txt"))
        {
            var m = Regex.Match(movement, @"move (\d*) from (\d*) to (\d*)");

            var moveStack = new Stack<char>();

            for (var i = 0; i < int.Parse(m.Groups[1].Value); i++)
            {
                char crate;
                if (stacks[int.Parse(m.Groups[2].Value) - 1].TryPop(out crate))
                {
                    moveStack.Push(crate);
                }
            }

            while (moveStack.Count > 0)
            {
                stacks[int.Parse(m.Groups[3].Value) - 1].Push(moveStack.Pop());
            }

        }

        var result = new StringBuilder();
        for (var i = 0; i < stacks.Count(); i++)
        {
            result.Append(stacks[i].Peek());
        }

        Console.WriteLine("Day 5 - Part 2");
        Console.WriteLine(result);
        Console.WriteLine();
    }

    private static Stack<char>[] InitStacks()
    {
        var stacks = new Stack<char>[9];

        for (int i = 0; i < stacks.Count(); i++)
        {
            stacks[i] = new Stack<char>();
        }

        var data = File.ReadAllLines("C:\\Temp\\advent\\input-day5-crates.txt");

        for(int r = data.Count() - 2; r >= 0; r--)
        {            
            if (!string.IsNullOrWhiteSpace(data[r][1].ToString())) stacks[0].Push(data[r][1]);
            if (!string.IsNullOrWhiteSpace(data[r][5].ToString())) stacks[1].Push(data[r][5]);
            if (!string.IsNullOrWhiteSpace(data[r][9].ToString())) stacks[2].Push(data[r][9]);
            if (!string.IsNullOrWhiteSpace(data[r][13].ToString())) stacks[3].Push(data[r][13]);
            if (!string.IsNullOrWhiteSpace(data[r][17].ToString())) stacks[4].Push(data[r][17]);
            if (!string.IsNullOrWhiteSpace(data[r][21].ToString())) stacks[5].Push(data[r][21]);
            if (!string.IsNullOrWhiteSpace(data[r][25].ToString())) stacks[6].Push(data[r][25]);
            if (!string.IsNullOrWhiteSpace(data[r][29].ToString())) stacks[7].Push(data[r][29]);
            if (!string.IsNullOrWhiteSpace(data[r][33].ToString())) stacks[8].Push(data[r][33]);
        }

        return stacks;
    }

}