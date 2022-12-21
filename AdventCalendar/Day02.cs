namespace AdventCalendar;

public class Day02
{
    const int Rock = 1;
    const int Paper = 2;
    const int Scissors = 3;
    const int Loss = 0;
    const int Draw = 3;
    const int Win = 6;

    public static void Part1()
    {
        var score = 0;

        foreach (var game in File.ReadAllLines("C:\\Temp\\advent\\input-day2.txt"))
        {
            var results = game.Split(" ");
            score += GetScorePart1(results[0], results[1]);
        }

        Console.WriteLine("Day 2 - Part 1");
        Console.WriteLine(score);
        Console.WriteLine();        
    }   

    protected static int GetScorePart1(string opponent, string yourAttempt)
    {
        switch (opponent)
        {
            case "A": //Rock
                if (yourAttempt == "X") return Rock + Draw; 
                if (yourAttempt == "Y") return Paper + Win;
                if (yourAttempt == "Z") return Scissors + Loss;
                break;

            case "B": // Paper
                if (yourAttempt == "X") return Rock + Loss;
                if (yourAttempt == "Y") return Paper + Draw;
                if (yourAttempt == "Z") return Scissors + Win;
                break;

            case "C": // Scissors
                if (yourAttempt == "X") return Rock + Win;
                if (yourAttempt == "Y") return Paper + Loss;
                if (yourAttempt == "Z") return Scissors + Draw;
                break;  
        }
        return 0;
    }

    public static void Part2()
    {
        var score = 0;

        foreach (var game in File.ReadAllLines("C:\\Temp\\advent\\input-day2.txt"))
        {
            var results = game.Split(" ");
            score += GetScorePart2(results[0], results[1]);
        }

        Console.WriteLine("Day 2 - Part 2");
        Console.WriteLine(score);
        Console.WriteLine();
    }

    protected static int GetScorePart2(string opponent, string yourAttempt)
    {
        switch (opponent)
        {
            case "A": //Rock
                if (yourAttempt == "X") return Scissors + Loss; //Must Lose
                if (yourAttempt == "Y") return Rock + Draw; // Must Draw
                if (yourAttempt == "Z") return Paper + Win; // Must Win
                break;

            case "B": // Paper
                if (yourAttempt == "X") return Rock + Loss; //Must Lose
                if (yourAttempt == "Y") return Paper + Draw; // Must Draw
                if (yourAttempt == "Z") return Scissors + Win; // Must Win
                break;

            case "C": // Scissors
                if (yourAttempt == "X") return Paper + Loss; //Must Lose
                if (yourAttempt == "Y") return Scissors + Draw; // Must Draw
                if (yourAttempt == "Z") return Rock + Win; // Must Win
                break;
        }
        return 0;
    }


}