using System.ComponentModel;
using System.ComponentModel.Design;

namespace AdventCalendar;

public class Day08
{
    public static void Part1()
    {
        var count = 0;
        var input = GetInput();
        for (var row = 0; row < input.GetLength(0); row++)
        {
            for (var col = 0; col < input.GetLength(1); col++)
            {
                if (IsVisible(input, row, col)) count++;
            }
        }

        Console.WriteLine("Day 8 - Part 1");
        Console.WriteLine(count);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var highest = 0;
        var input = GetInput();
        for (var row = 0; row < input.GetLength(0); row++)
        {
            for (var col = 0; col < input.GetLength(1); col++)
            {
                var scenicScore = GetScenicScore(input, row, col);
                if (scenicScore > highest) highest = scenicScore;
            }
        }


        Console.WriteLine("Day 8 - Part 2");
        Console.WriteLine(highest);
        Console.WriteLine();
    }

    private static int[,] GetInput()
    {
        var data = File.ReadAllText($"{Environment.CurrentDirectory}\\day08\\input-day8.txt");
        //var data = File.ReadAllText($"{Environment.CurrentDirectory}\\day08\\input-day8.txt");

        var rows = data.Split("\r\n");

        var input = new int[rows.Count(), rows[0].Length];

        for (var r = 0; r < rows.Count(); r++)
        {
            for (var c = 0; c < rows[r].Length; c++)
            {
                input[r, c] = int.Parse(rows[r][c]!.ToString());
            }
        }

        return input;
    }

    private static bool IsVisible(int[,] input, int row, int col)
    {
        var left = true;
        var right = true;
        var top = true;
        var bottom = true;
        var rowCount = input.GetLength(0);
        var columnCount = input.GetLength(1);

        var treeHeight = input[row, col];

        // check border
        if (row == 0 || col == 0 || row == rowCount - 1 || col == columnCount - 1) return true;

        // check left
        for (var i = col - 1; i >= 0; i--)
        {
            if (input[row, i] >= treeHeight) left = false;
        }
        // check right
        for (var i = col + 1; i < columnCount; i++)
        {
            if (input[row, i] >= treeHeight) right = false;
        }
        // check top
        for (var i = row - 1; i >= 0; i--)
        {
            if (input[i, col] >= treeHeight) top = false;
        }
        // check bottom
        for (var i = row + 1; i < rowCount; i++)
        {
            if (input[i, col] >= treeHeight) bottom = false;
        }

        return left || right || top || bottom;
    }
    private static int GetScenicScore(int[,] input, int row, int col)
    {
        var left = 0;
        var right = 0;
        var top = 0;
        var bottom = 0;
        var rowCount = input.GetLength(0);
        var columnCount = input.GetLength(1);
        var treeHeight = input[row, col];

        // check border
        if (row == 0 || col == 0 || row == rowCount - 1 || col == columnCount - 1) return 0;

        // check left
        for (var i = col - 1; i >= 0; i--)
        {            
            left++;
            if (input[row, i] >= treeHeight) break;            
        }
        // check right
        for (var i = col + 1; i < columnCount; i++)
        {
            right++;
            if (input[row, i] >= treeHeight) break;
        }
        // check top
        for (var i = row - 1; i >= 0; i--)
        {
            top++;
            if (input[i, col] >= treeHeight) break;
        }
        // check bottom
        for (var i = row + 1; i < rowCount; i++)
        {
            bottom++;
            if (input[i, col] >= treeHeight) break;
        }

        return left * right * top * bottom;
    }
    
}