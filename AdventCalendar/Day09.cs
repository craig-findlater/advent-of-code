using System.Security.Cryptography.X509Certificates;

namespace AdventCalendar;

public class Day09
{
    public static void Part1()
    {
        //var instructions = File.ReadAllText("C:\\Temp\\advent\\input-day9.txt");
        var instructions = File.ReadAllText("C:\\Temp\\advent\\input-day9-demo.txt");

        var rope = new Rope(50, 50);

        foreach (string data in instructions.Split("\r\n"))
        {
            var instruction = data.Split(" ");

            rope.Move(instruction[0], int.Parse(instruction[1]));
        }

        Console.WriteLine("Day 9 - Part 1");
        Console.WriteLine(rope.TailPositions);
        Console.WriteLine();
    }

    public static void Part2()
    {

        Console.WriteLine("Day 9 - Part 2");
        Console.WriteLine();
        Console.WriteLine();
    }

    public class Rope
    {
        public Position Head { get; private set; }
        public Position Tail { get; private set; }

        public Rope(int startX, int startY)
        {
            Head = new Position(startX, startY);
            Tail = new Position(startX, startY);
        }

        public int TailPositions { get; protected set; }

        public void Move(string direction, int distance)
        { 
            switch (direction)
            {
                case "L":
                    this.Head -= 1;
                    break;

                case "R":
                    break;

                case "U":
                    break;

                case "D":
                    break;

            }
        }
    }

    public record Position(int X, int Y)
    { 

    }

}