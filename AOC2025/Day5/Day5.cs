using System;
using System.Net.WebSockets;

namespace AOC2025
{
    internal static class Day5
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day05
            Console.WriteLine("AOC2025 Day5 placeholder");
            Process("Day5/Day5-small.txt");
            Process("Day5/Day5.txt");
            Process2("Day5/Day5-small.txt");
            Process2("Day5/Day5.txt");

        }
        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var ranges = new List<(long start, long end)>();
            var ingredients = new List<long>();
            bool readIngredient = false;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    readIngredient = true;
                    continue;
                }
                if (readIngredient)
                {
                    ingredients.Add(long.Parse(line));
                }
                else
                {
                    var l = line.Split('-');
                    ranges.Add((long.Parse(l[0]), long.Parse(l[1])));
                }
            }
            int count = 0;
            foreach (var ing in ingredients)
            {
                foreach ((long start, long end) in ranges)
                {
                    if (start <= ing && ing <= end)
                    {
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine($"Part 1 : {fileName} : {count}");
            //Console.WriteLine(string.Join("\n", l.Select(row => string.Join("", row))));
        }
        public static void Process2(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var ranges = new List<long[]>();
            var ingredients = new List<long>();
            bool readIngredient = false;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    readIngredient = true;
                    continue;
                }
                if (readIngredient)
                {
                    ingredients.Add(long.Parse(line));
                }
                else
                {
                    var l = line.Split('-');
                    ranges.Add(new[] { long.Parse(l[0]), long.Parse(l[1]) });
                }
            }
            long count = 0;
            var res = Merge(ranges.ToArray());
            foreach (var range in res)
            {
                count += range[1] - range[0] + 1;
            }
            Console.WriteLine($"Part 2 : {fileName} : {count}");
        }

        public static long[][] Merge(long[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return intervals;
            var l = intervals.OrderBy(i => i[0]).ToList();
            var res = new List<long[]>();
            var curr = l[0];
            var end = curr[1];
            var start = curr[0];
            for (int i = 1; i < l.Count; i++)
            {
                var next = l[i];
                if (next[0] > end)
                {
                    res.Add(new long[] { start, end });
                    start = next[0];
                    end = next[1];
                }
                else
                {
                    end = Math.Max(next[1], end);
                }
            }
            res.Add(new long[] { start, end });
            return res.ToArray();
        }

    }
}
