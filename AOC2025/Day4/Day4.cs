using System;

namespace AOC2025
{
    internal static class Day4
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day04
            Console.WriteLine("AOC2025 Day4 placeholder");
            Process("Day4/Day4-small.txt");
            Process("Day4/Day4.txt");
            Process2("Day4/Day4-small.txt");
            Process2("Day4/Day4.txt");

        }
        private static List<char[]> l;
        private static int m, n;
        private static char Roll = '@';
        private static char Empty = '.';
        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            l = new List<char[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine().ToCharArray());
            }
            m = l.Count;
            n = l[0].Length;
            int count = 0;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (l[r][c] != Roll) continue;
                    count += IsReachable(r, c) ? 1 : 0;
                }
            }
            Console.WriteLine($"Part 1 : {fileName} : {count}");
            //Console.WriteLine(string.Join("\n", l.Select(row => string.Join("", row))));
        }
        private static bool IsReachable(int r, int c)
        {
            int count = 0;
            for (int dr = -1; dr < 2; dr++)
            {
                if (r + dr < 0 || r + dr == m) continue;
                for (int dc = -1; dc < 2; dc++)
                {
                    if (c + dc < 0 || c + dc == n) continue;
                    if (l[r + dr][c + dc] != Empty) count++;
                }
            }
            if (count < 5) l[r][c] = 'x';
            return count < 5;
        }
        public static void Process2(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            l = new List<char[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine().ToCharArray());
            }
            m = l.Count;
            n = l[0].Length;
            int count = 0;
            var removed = new HashSet<(int r, int c)>();
            while (true)
            {
                removed.Clear();
                for (int r = 0; r < m; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (l[r][c] != Roll) continue;
                        if (IsReachable(r, c))
                        {
                            count++;
                            removed.Add((r, c));
                        }
                    }
                }
                if (removed.Count == 0) break;
                foreach ((int r, int c) in removed) l[r][c] = Empty;

            }
            Console.WriteLine($"Part 2 : {fileName} : {count}");
        }
    }
}
