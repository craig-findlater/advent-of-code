using AdventOfCode.Shared;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day02;

internal static class Day02
{
    public static void Part1()
    {
        int total = 0;
        foreach (string line in Input.ReadInput(2))
        {
            var game = Regex.Match(line, @"Game\s(\d*):\s(.*)");

            int maxBlue = 0;
            int maxGreen = 0;
            int maxRed = 0;
            var reveals = game.Groups[2].Value.Split(";");

            foreach (var reveal in reveals)
            {
                var blue = GetRevealedAmount(reveal, @"(\d+)\sblue");
                if (maxBlue < blue) maxBlue = blue;

                var green = GetRevealedAmount(reveal, @"(\d+)\sgreen");
                if (maxGreen < green) maxGreen = green;

                var red = GetRevealedAmount(reveal, @"(\d+)\sred");
                if (maxRed < red) maxRed = red;                
            }

            if (maxRed <= 12 && maxGreen <= 13 && maxBlue <= 14)
            {
                total += int.Parse(game.Groups[1].Value);
            }
        }

        Output.Write(2, 1, total);
    }

    public static void Part2()
    {
        int total = 0;
        foreach (string line in Input.ReadInput(2))
        {
            var game = Regex.Match(line, @"Game\s(\d*):\s(.*)");

            int maxBlue = 0;
            int maxGreen = 0;
            int maxRed = 0;
            var reveals = game.Groups[2].Value.Split(";");

            foreach (var reveal in reveals)
            {
                var blue = GetRevealedAmount(reveal, @"(\d+)\sblue");
                if (maxBlue < blue) maxBlue = blue;

                var green = GetRevealedAmount(reveal, @"(\d+)\sgreen");
                if (maxGreen < green) maxGreen = green;

                var red = GetRevealedAmount(reveal, @"(\d+)\sred");
                if (maxRed < red) maxRed = red;
            }

            total += (maxBlue * maxGreen * maxRed);
        }

        Output.Write(2, 2, total);
    }

    public static int GetRevealedAmount(string input, string regex)
    {
        var m = Regex.Match(input, regex);
        if (m.Success)
        {
            return int.Parse(m.Groups[1].Value);
        }
        return 0;
    }
}