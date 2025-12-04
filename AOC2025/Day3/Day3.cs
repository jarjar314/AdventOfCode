using System;
using System.Text;

namespace AOC2025
{
    internal static class Day3
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day03
            Console.WriteLine("AOC2025 Day3 placeholder");
            Process("Day3/Day3-small.txt");
            Process("Day3/Day3.txt");
            Process2("Day3/Day3-small.txt");
            Process2("Day3/Day3.txt");

        }
        private static List<string> Read(string fileName)
        {
            var batteries = new List<string>();
            using var reader = new System.IO.StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line is not null)
                {
                    batteries.Add(line);
                }
            }
            return batteries;
        }
        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            var batteries = Read(fileName);
            long sum = 0;
            foreach (var batt in batteries)
            {
                long b = long.Parse(FindMax(batt, 2));
                sum += b;
            }
            Console.WriteLine($"Part 1 : {fileName} : {sum}");
        }
        public static void Process2(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            var batteries = Read(fileName);
            long sum = 0;
            foreach (var batt in batteries)
            {
                long b = long.Parse(FindMax(batt, 12));
                sum += b;
            }
            Console.WriteLine($"Part 2 : {fileName} : {sum}");
        }
        private static string FindMax(string s, int parts)
        {
            int n = s.Length;
            var sb = new StringBuilder(parts);
            int start = 0;
            for (int i = 0; i < parts; i++)
            {
                char c = s[start..(n-parts + i+1)].Max();
                sb.Append(c);
                start = s.IndexOf(c, start) + 1;
            }
            return sb.ToString();
        }

        private static long FindMaxOther(string s, int parts)
        {
            int n = s.Length;
            var res = new long[parts + 1];
            foreach (var c in s)
            {
                long d = c - '0';
                for (int i = parts; i > 0; i--)
                {
                    res[i] = Math.Max(res[i], res[i - 1] * 10 + d);
                }
            }
            return res[parts];
        }
    }
}
