using AdventOfCode.Shared;

namespace AdventOfCode2023.Day01;

internal static class Day01
{
    public static void Part1()
    {
        int total = 0;
        foreach (string line in Input.ReadDayInput(1))
        {
            var f = line.ToCharArray().Where(x => char.IsNumber(x)).FirstOrDefault();
            var l = line.ToCharArray().Where(x => char.IsNumber(x)).LastOrDefault();

            total += int.Parse(string.Concat(f, l));
        }

        Output.Write(1, 1, total);
    }

    public static string[] numbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public static void Part2()
    {
        int total = 0;
        foreach (string line in Input.ReadDayInput(1))
        {
            var f = GetFirstNumber(line);
            var l = GetLastNumber(line);

            total += int.Parse(string.Concat(f, l));
        }

        Output.Write(1, 2, total);
    }

    private static int GetFirstNumber(string input)
    {   
        int result;

        for (var i = 0; i < input.Length; i++)
        {
            if (int.TryParse(input[i].ToString(), out result))
            {
                return result;
            }
            else
            {
                for (var x = 0; x < 9; x++) 
                {
                    if (input.Substring(i).StartsWith(numbers[x]))
                    {
                        return x + 1;
                    }
                }
            };
        }
        return 0;
    }

    private static int GetLastNumber(string input)
    {
        int result;

        for (var i = input.Length - 1; i >= 0; i--)
        {
            if (int.TryParse(input[i].ToString(), out result))
            {
                return result;
            }
            else
            {
                for (var x = 0; x < 9; x++)
                {
                    if (input.Substring(i).StartsWith(numbers[x]))
                    {
                        return x + 1;
                    }
                }
            };
        }
        return 0;
    }


}