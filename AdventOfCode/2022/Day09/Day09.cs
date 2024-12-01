using System;
using System.Security.Cryptography.X509Certificates;

namespace AdventCalendar;

public class Day09
{
    public static void Part1()
    {
        var instructions = File.ReadAllText($"{Environment.CurrentDirectory}\\day09\\input-day9.txt");
        //var instructions = File.ReadAllText($"{Environment.CurrentDirectory}\\day09\\input-day9-demo.txt");

        var rope = new Rope(0, 0);

        foreach (string data in instructions.Split("\r\n"))
        {
            var instruction = data.Split(" ");

            rope.Move(instruction[0], int.Parse(instruction[1]));
        }

        Console.WriteLine("Day 9 - Part 1");
        Console.WriteLine(rope.TailPositions.Count);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var instructions = File.ReadAllText($"{Environment.CurrentDirectory}\\day09\\input-day9.txt");
        //var instructions = File.ReadAllText($"{Environment.CurrentDirectory}\\day09\\input-day9-demo-part2.txt");

        var rope = new RopeWithKnots(0, 0);

        foreach (string data in instructions.Split("\r\n"))
        {
            var instruction = data.Split(" ");

            rope.Move(instruction[0], int.Parse(instruction[1]));
        }

        Console.WriteLine("Day 9 - Part 2");
        Console.WriteLine(rope.TailPositions.Count);
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
            TailPositions = new List<Position>();
            TailPositions.Add(new Position(Tail.X, Tail.Y));
        }

        public List<Position> TailPositions { get; protected set; }

        public void Move(string direction, int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case "L":
                        Head.X--;                       
                        break;

                    case "R":
                        Head.X++;                        
                        break;

                    case "U":
                        Head.Y--;                       
                        break;

                    case "D":
                        Head.Y++;                       
                        break;
                }
                
                if (!Head.IsAdjacent(Tail)) MakeAdjacent();
            }
        }

        private void MakeAdjacent()
        {
            // in the same row
            if (Head.X == Tail.X)
            {
                if (Head.X - Tail.X >= 2)
                {
                    Tail.X++;
                }
                else if (Head.X - Tail.X <= 2)
                {
                    Tail.X--;
                }
            }

            // in the same column
            if (Head.Y == Tail.Y)
            {
                if (Head.Y - Tail.Y >= 2)
                {
                    Tail.Y++;
                }
                else if (Head.Y - Tail.Y <= 2)
                {
                    Tail.Y--;
                }
            }

            // diagonally adjacent - top left
            if (Head.X < Tail.X && Head.Y < Tail.Y)
            {
                Tail.X--;
                Tail.Y--;
            }

            // diagonally adjacent - top right
            if (Head.X > Tail.X && Head.Y < Tail.Y)
            {
                Tail.X++;
                Tail.Y--;
            }

            // diagonally adjacent - bottom left
            if (Head.X < Tail.X && Head.Y > Tail.Y)
            {
                Tail.X--;
                Tail.Y++;
            }

            // diagonally adjacent - bottom right
            if (Head.X > Tail.X && Head.Y > Tail.Y)
            {
                Tail.X++;
                Tail.Y++;
            }

            if (!TailPositions.Contains(Tail)) TailPositions.Add(new Position(Tail.X, Tail.Y));

        }
        
    }

    public class RopeWithKnots
    {
        public List<Position> Knots { get; private set; }    
        public Position Head { get => Knots.First(); }
        public Position Tail { get => Knots.Last(); }

        public RopeWithKnots(int startX, int startY)
        {
            Knots = new List<Position>();
            for (int i = 0; i < 10; i++)
            {
                Knots.Add(new Position(startX, startY));
            }            
            TailPositions = new List<Position>();
            TailPositions.Add(new Position(startX, startY));
        }

        public List<Position> TailPositions { get; protected set; }

        public void Move(string direction, int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case "L":
                        Head.X--;
                        break;

                    case "R":
                        Head.X++;
                        break;

                    case "U":
                        Head.Y--;
                        break;

                    case "D":
                        Head.Y++;
                        break;
                }

                for (var j = 1; j < Knots.Count; j++)
                {
                    if (!Knots[j - 1].IsAdjacent(Knots[j])) MakeAdjacent(Knots[j - 1], Knots[j]);
                }

                if (!TailPositions.Contains(Tail)) TailPositions.Add(new Position(Tail.X, Tail.Y));
            }
        }

        private void MakeAdjacent(Position pos1, Position pos2)
        {
            // in the same row
            if (pos1.X == pos2.X)
            {
                if (pos1.X - pos2.X >= 2)
                {
                    pos2.X++;
                }
                else if (pos1.X - pos2.X <= 2)
                {
                    pos2.X--;
                }
            }

            // in the same column
            if (pos1.Y == pos2.Y)
            {
                if (Head.Y - pos2.Y >= 2)
                {
                    pos2.Y++;
                }
                else if (pos1.Y - pos2.Y <= 2)
                {
                    pos2.Y--;
                }
            }

            // diagonally adjacent - top left
            if (pos1.X < pos2.X && pos1.Y < pos2.Y)
            {
                pos2.X--;
                pos2.Y--;
            }

            // diagonally adjacent - top right
            if (pos1.X > pos2.X && pos1.Y < pos2.Y)
            {
                pos2.X++;
                pos2.Y--;
            }

            // diagonally adjacent - bottom left
            if (pos1.X < pos2.X && pos1.Y > pos2.Y)
            {
                pos2.X--;
                pos2.Y++;
            }

            // diagonally adjacent - bottom right
            if (pos1.X > pos2.X && pos1.Y > pos2.Y)
            {
                pos2.X++;
                pos2.Y++;
            }                        

        }

    }

    public class Position : IEquatable<Position> 
    {        
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;  
        }

        public bool Equals(Position? other)
        {
            if (other == null) return false;
            return X == other.X && Y == other.Y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        public bool IsAdjacent(Position item)
        {
            //equal
            if (X == item.X && Y == item.Y) return true;

            // in the same row or column
            if (X == item.X) return (Y == item.Y + 1 || Y == item.Y - 1);
            if (Y == item.Y) return (X == item.X + 1 || X == item.X - 1);

            // diagonally adjacent
            return (X == item.X - 1 && Y == item.Y - 1) || // top left
                   (X == item.X + 1 && Y == item.Y - 1) || // top right                   
                   (X == item.X - 1 && Y == item.Y + 1) || // bottom left
                   (X == item.X + 1 && Y == item.Y + 1);   // bottom right
        }        

    }   

}