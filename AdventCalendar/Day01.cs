namespace AdventCalendar;

public class Day1
{
    public static void Part1()
    {
        var elfCalories = 0;
        var maxCalories = 0;

        foreach (var line in File.ReadAllLines("C:\\Temp\\advent\\input-day1.txt"))
        {
            int lineCalories;
            if (int.TryParse(line, out lineCalories))
            {
                elfCalories += int.Parse(line);
            }
            else
            {
                if (elfCalories > maxCalories) maxCalories = elfCalories;
                elfCalories = 0;                
            }
        }

        Console.WriteLine("Day 1 - Part 1");
        Console.WriteLine(maxCalories);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var elfCalories = 0;
        var elfs = new List<int>();

        foreach (var line in File.ReadAllLines("C:\\Temp\\advent\\input-day1.txt"))
        {
            int lineCalories;
            if (int.TryParse(line, out lineCalories))
            {
                elfCalories += int.Parse(line);
            }
            else
            {
                elfs.Add(elfCalories);
                elfCalories = 0;
            }
        }
                
        Console.WriteLine("Day 1 - Part 2");
        Console.WriteLine(elfs.OrderByDescending(x => x).Take(3).Sum());
        Console.WriteLine();        
    }
}