namespace AdventOfCode.Shared;

public static class Output
{
    public static void Write<T>(int day, int part, T output)
    {
        Console.WriteLine($"Day {day:00} - Part {part}");
        Console.WriteLine(output);
        Console.WriteLine();
    }
}