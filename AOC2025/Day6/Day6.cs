using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AOC2025
{
    internal static class Day6
    {
        public static void Run()
        {
            Console.WriteLine("AOC2025 Day6 placeholder");
            Process("Day6/Day6-small.txt");
            Process("Day6/Day6.txt");
            Process2("Day6/Day6-small.txt");
            Process2("Day6/Day6.txt");
        }
        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<string[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }
            long count = 0;
            int n = l.Count - 1;
            int m = l[0].Length;
            long[] res = new long[m];
            for (int i = 0; i < m; i++)
            {
                res[i] = long.Parse(l[0][i]);
            }
            for (int r = 1; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (l[^1][c] == "+") res[c] += long.Parse(l[r][c]);
                    else res[c] *= long.Parse(l[r][c]);

                }
            }
            for (int c = 0; c < m; c++) count += res[c];
            Console.WriteLine($"Part 1 : {fileName} : {count}");
            //Console.WriteLine(string.Join("\n", l.Select(row => string.Join("", row))));
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
            int m = l.Count - 1;
            int n = l[0].Length;
            var li = new List<long>();
            for (int c = n-1; c >= 0; c--)
            {
                int num = 0;
                for (int r = 0; r < m; r++)
                {
                    if (l[r][c] == ' ') continue;
                    num = 10 * num + (l[r][c] - '0');
                }
                if (num != 0) li.Add(num);

                if (l[^1][c] == ' ') continue;
                if (l[^1][c] == '+')
                {
                    count += li.Sum();
                    li.Clear();
                }
                if (l[^1][c] == '*')
                {
                    count += Mult(li);
                    li.Clear();
                }
            }
            Console.WriteLine($"Part 2 : {fileName} : {count}");

        }
        private static long Mult(List<long> l)
        {
            var r = 1L;
            foreach (var i in l) r *= i;
            return r;
        }
    }
}
