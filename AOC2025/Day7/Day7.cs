using System;

namespace AOC2025
{
    internal static class Day7
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day7
            Console.WriteLine("AOC2025 Day7 placeholder");
            Process("Day7/Day7-small.txt");
            Process("Day7/Day7.txt");
            Process2("Day7/Day7-small.txt");
            Process2("Day7/Day7.txt");
        }
        public static void Process(string fileName)
        {
            long res = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<char[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!.ToCharArray());
            }
            int m = l.Count, n = l[0].Length;
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (l[i][j] == 'S')
                    {
                        HashSet<int> beams = new HashSet<int>() { j };
                        int r = i + 1;
                        while (r < m)
                        {
                            var next = new HashSet<int>();
                            foreach (var b in beams)
                            {
                                if (l[r][b] == '.')
                                {
                                    next.Add(b);
                                    continue;
                                }
                                else
                                {
                                    count++;
                                    next.Add(b - 1);
                                    next.Add(b + 1);
                                }
                            }
                            next.Remove(-1);
                            next.Remove(n);
                            beams = next;
                            r++;
                        }
                    }
                }
            }

            Console.WriteLine($"Part 1 : {fileName} : {count}");
        }
        public static void Process2(string fileName)
        {
            long res = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<char[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!.ToCharArray());
            }
            int m = l.Count, n = l[0].Length;
            Dictionary<int, long> beams = new Dictionary<int, long>();
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (l[i][j] == 'S')
                    {
                        beams.Add(j, 1);
                        int r = i + 1;
                        while (r < m)
                        {
                            var next = new Dictionary<int, long>();
                            foreach (var (b, cnt) in beams)
                            {
                                if (l[r][b] == '.')
                                {
                                    Add(next, b , cnt);
                                    continue;
                                }
                                else
                                {
                                    count++;
                                    Add(next, b - 1, cnt);
                                    Add(next, b + 1, cnt);
                                }
                            }
                            beams = next;
                            r++;
                        }
                    }
                }
            }

            Console.WriteLine($"Part 2 : {fileName} : {count} => {beams.Values.Sum()}");

        }
        private static void Add(Dictionary<int, long> map, int key, long val)
        {
            map.TryGetValue(key, out long value);
            map[key] = value + val;
        }
    }
}
