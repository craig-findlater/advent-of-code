using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AdventCalendar;

public class Day07
{
    public static void Part1()
    {
        var root = new ElfDirectory("/", null);
        BuildDirectories(ref root);

        var smallDirectories = new List<ElfDirectory>();
        GetSmallDirectories(ref smallDirectories, root);

        var size = smallDirectories.Sum(x => x.GetSize());

        Console.WriteLine("Day 7 - Part 1");
        Console.WriteLine(size);
        Console.WriteLine();
    }

    public static void Part2()
    {
        var root = new ElfDirectory("/", null);
        BuildDirectories(ref root);

        var free = 30000000 - (70000000 - root.GetSize()); //40,389,918

        var largeDirectories = new List<ElfDirectory>();
        GetLargeDirectories(ref largeDirectories, root, free);

        var size = largeDirectories.Min(x => x.GetSize());

        Console.WriteLine("Day 7 - Part 2");
        Console.WriteLine(size);
        Console.WriteLine();
    }

    private static void BuildDirectories(ref ElfDirectory root)
    {
        var current = root;

        foreach (var data in File.ReadAllLines($"{Environment.CurrentDirectory}\\day07\\input-day7.txt"))
        {
            if (data.StartsWith("$"))
            {
                var m = Regex.Match(data, @"\$\s(\w*)\s?(.*)");

                switch (m.Groups[1].Value)
                {
                    case "cd":
                        if (m.Groups[2].Value == "/")
                        {
                            current = root;
                        }
                        else if (m.Groups[2].Value == "..")
                        {
                            current = current.Parent ?? root;
                        }
                        else
                        {
                            current = current.Directories.Where(x => x.Path == m.Groups[2].Value).First();
                        }
                        break;

                    case "ls":
                        break;

                }
            }
            else
            {
                var x = data.Split(" ");

                if (x[0] == "dir")
                {
                    current.Directories.Add(new ElfDirectory(x[1], current));
                }
                else
                {
                    current.Files.Add(new ElfFile(x[1], long.Parse(x[0])));
                }

            }
        }
    }

    private static void GetLargeDirectories(ref List<ElfDirectory> largeDirectories, ElfDirectory dir, long minSize)
    {
        if (dir.GetSize() >= minSize)
        {
            largeDirectories.Add(dir);
        }
        foreach (ElfDirectory subDir in dir.Directories)
        {
            GetLargeDirectories(ref largeDirectories, subDir, minSize);
        }
    }

    private  static void GetSmallDirectories(ref List<ElfDirectory> smallDirectories, ElfDirectory dir)
    {
        if (dir.GetSize() <= 100000)
        {
            smallDirectories.Add(dir);
        }
        foreach (ElfDirectory subDir in dir.Directories)
        {
            GetSmallDirectories(ref smallDirectories, subDir);
        }    
    }

    public record ElfDirectory(string Path, ElfDirectory? Parent)
    {
        public List<ElfDirectory> Directories { get; set;} = new List<ElfDirectory>();
        public List<ElfFile> Files { get; set; } = new List<ElfFile>();

        public long GetSize()
        {
            long size = 0;
            size += Files.Sum(x => x.Size);
            size += Directories.Sum(x => x.GetSize());
            return size;
        }
    }

    public record ElfFile(string Name, long Size)
    {     
    }

}