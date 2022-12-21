using System.Net.Security;

namespace AdventCalendar;

public class Day03
{
    public static void Part1()
    {
        var total = 0;

        foreach (var rucksack in File.ReadAllLines("C:\\Temp\\advent\\input-day3.txt"))
        {
            var compartment1 = rucksack.Substring(0, (rucksack.Length / 2));
            var compartment2 = rucksack.Substring(rucksack.Length / 2);

            var duplicateItem = GetDuplicateItem(compartment1, compartment2);

            var priority = GetItemPriority(duplicateItem);

            total += priority;
        }

        Console.WriteLine("Day 3 - Part 1");
        Console.WriteLine(total);
        Console.WriteLine();
    }

    public static char GetDuplicateItem(string compartment1, string compartment2)
    { 
        for (var c1=0; c1 <compartment1.Length; c1++)
        {
            for (var c2 = 0; c2 < compartment2.Length; c2++)
            {
                if (compartment1[c1] == compartment2[c2]) return compartment1[c1];
            }
        }
        throw new ApplicationException("Could not find the duplicate item in the rucksack!");
    }

    protected static int GetItemPriority(char item)
    {
        var value = (int)item;

        if (value >= 97) // lowercase
        {
            return value - 96;
        }
        if (value >= 65) // uppercase 
        {
            return value - 64 + 26;
        }
        throw new ApplicationException("Invalid item found in the rucksack!");
    }

    public static void Part2()
    {
        var total = 0;
        var group = new List<string>();

        foreach (var rucksack in File.ReadAllLines("C:\\Temp\\advent\\input-day3.txt"))
        {
            group.Add(rucksack);

            if (group.Count == 3)
            {
                var badge = GetBadge(group);

                total += GetItemPriority(badge);

                group = new List<string>();
            }            
        }

        Console.WriteLine("Day 3 - Part 2");
        Console.WriteLine(total);
        Console.WriteLine();
    }

    protected static char GetBadge(List<string> group)
    {
        foreach (char c in group.First())
        {
            if (group[1].Contains(c) && group[2].Contains(c)) return c;
        }
        throw new ApplicationException("Badge could not be found!");
    }
}