namespace AdventOfCode.Shared;

public static class Input
{
    public static string[] ReadInput(int day) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\event2024\\day{day:00}\\input.txt");

    public static string[] ReadInput(int day, int part) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\event2024\\day{day:00}\\input-day{day:00}-{part}.txt");

    public static string[] ReadSampleInput(int day) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\event2024\\day{day:00}\\sample-input.txt");

    public static string[] ReadSampleInput(int day, int part) =>
        File.ReadAllLines($"{Environment.CurrentDirectory}\\event2024\\day{day:00}\\sample-input-{part}.txt");
}