using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace AdventCalendar;

public class Day04
{
    public static void Part1()
    {
        var total = 0;

        foreach (var data in File.ReadAllLines("C:\\Temp\\advent\\input-day4.txt"))
        {
            var elfAssignments = data.Split(",");

            var elf1 = new ElfRange(elfAssignments[0]);
            var elf2 = new ElfRange(elfAssignments[1]);

            if (elf1.FullyContains(elf2) || elf2.FullyContains(elf1)) total += 1;
        }

        Console.WriteLine("Day 4 - Part 1");
        Console.WriteLine(total);
        Console.WriteLine();
    }    

    public static void Part2()
    {
        var total = 0;

        foreach (var data in File.ReadAllLines("C:\\Temp\\advent\\input-day4.txt"))
        {
            var elfAssignments = data.Split(",");

            var elf1 = new ElfRange(elfAssignments[0]);
            var elf2 = new ElfRange(elfAssignments[1]);

            if (elf1.Contains(elf2) || elf2.Contains(elf1)) total += 1;
        }

        Console.WriteLine("Day 4 - Part 2");
        Console.WriteLine(total);
        Console.WriteLine();
    }

    private class ElfRange
    {
        public int Start;
        public int End;

        public ElfRange(string range)
        {
            var data = range.Split("-");
            Start = int.Parse(data[0]);
            End = int.Parse(data[1]);
        }

        public bool FullyContains(ElfRange range)
        {
            return Start >= range.Start && End <= range.End;
        }

        public bool Contains(ElfRange range)
        {
            return range.Start <= End && range.End >= Start;
        }

    }

}