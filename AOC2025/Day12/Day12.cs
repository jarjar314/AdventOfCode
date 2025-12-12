using System;

namespace AOC2025
{
    internal static class Day12
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day12
            Console.WriteLine("AOC2025 Day12 placeholder");
            //Process("Day12/Day12-small.txt");
            Process("Day12/Day12.txt");
            //Process2("Day12/Day12-small.txt");
            Process2("Day12/Day12.txt");
        }

        public static void Process(string fileName)
        {
            long count = 0, count2 = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<int[]>();
            while (!reader.EndOfStream)
            {
                var arr = reader.ReadLine()!.Split(new char[] { ':', 'x', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                l.Add(arr);
                // let's consider that it is big enough and numbers of items are big enough to be able to fit if there is enough squares available as the input has big x*y values
                if (arr[0] * arr[1] >= arr.Skip(2).Sum() * 9)
                    count++;
                if (arr[0] * arr[1] >= arr.Skip(2).Sum() * 7)
                    count2++;
            }
            Console.WriteLine($"part 1 : {fileName} : {count}  // {count2}");
        }
        public static void Process2(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<string>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!);
            }
            Console.WriteLine($"part 2 : {fileName} : {count}");
        }
    }
}