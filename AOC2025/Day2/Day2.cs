using Microsoft.Win32.SafeHandles;
using System;
using System.Reflection.Metadata.Ecma335;

namespace AOC2025
{
    internal static class Day2
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day02
            Console.WriteLine("AOC2025 Day02 placeholder");
            Process("Day2/Day2-small.txt");
            Process("Day2/Day2.txt");
            Process2("Day2/Day2-small.txt");
            Process2("Day2/Day2.txt");
        }

        public static void Process2(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var ranges = reader.ReadLine().Split(',');
            long sum = 0;
            var invalidIds = new List<long>();
            foreach (var r in ranges)
            {
                var range = r.Split('-').Select(long.Parse).ToArray();
                long start = range[0], end = range[1];
                while (start <= end)
                {
                    var s = start.ToString();
                    for (int i = 1; i <= s.Length / 2; i++)
                    if (isInvalid(start.ToString(), i))
                    {
                        invalidIds.Add(start);
                        sum += start;
                    }
                    start++;
                }
            }
            Console.WriteLine($"part2={sum}");
        }

        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var ranges = reader.ReadLine().Split(',');
            long sum = 0;
            var invalidIds = new List<long>();
            foreach (var r in ranges)
            {
                var range = r.Split('-').Select(long.Parse).ToArray();
                long start = range[0], end = range[1];
                while(start <= end)
                {
                    var s = start.ToString();
                    var n = s.Length;
                    
                    if (n % 2 == 0 && isInvalid(start.ToString(), start.ToString().Length / 2))
                    {
                        invalidIds.Add(start);
                        sum += start;
                    }
                    start++;
                }
            }
            Console.WriteLine($"part1={sum}");
        }

        private static bool isInvalid(string s, int n)
        {
            if (n == 0) return false; // use case s of size 1.
            if (s.Length % n != 0) return false;
            for (int i = n; i < s.Length; i++)
            {
                if (s[i] != s[i - n]) return false;
            }
            return true;
        }
    }
}
