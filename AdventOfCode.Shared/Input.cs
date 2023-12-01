using System.Runtime.CompilerServices;

namespace AdventOfCode.Shared;

public static class Input
{
    public static string[] ReadDayInput(int day) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\day{day:00}\\input-day{day:00}.txt");

    public static string[] ReadDayInput(int day, int part) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\day{day:00}\\input-day{day:00}-{part}.txt");
}