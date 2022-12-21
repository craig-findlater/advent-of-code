namespace AdventCalendar;

public class Day06
{
    public static void Part1()
    {
        var data = File.ReadAllText($"{Environment.CurrentDirectory}\\day06\\input-day6.txt");
               
        var index = 0;        
        var markerQueue = new Queue<char>();

        foreach (char c in data)
        {
            if (markerQueue.Count == 4) continue;

            index++;

            while (markerQueue.Contains(c))
            {
                markerQueue.Dequeue();
            }

            markerQueue.Enqueue(c);

        }

        Console.WriteLine("Day 6 - Part 1");
        Console.WriteLine(index);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var data = File.ReadAllText($"{Environment.CurrentDirectory}\\day06\\input-day6.txt");

        var index = 0;
        var markerQueue = new Queue<char>();

        foreach (char c in data)
        {
            if (markerQueue.Count == 14) continue;

            index++;

            while (markerQueue.Contains(c))
            {
                markerQueue.Dequeue();
            }

            markerQueue.Enqueue(c);

        }

        Console.WriteLine("Day 6 - Part 2");
        Console.WriteLine(index);
        Console.WriteLine();
    }

}