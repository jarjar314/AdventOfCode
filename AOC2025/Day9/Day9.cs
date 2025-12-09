using System;
using System.Reflection.PortableExecutable;

namespace AOC2025
{
    internal static class Day9
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day9
            Console.WriteLine("AOC2025 Day9 placeholder");
            Process("Day9/Day9-small.txt");
            Process("Day9/Day9.txt");
            Process2("Day9/Day9-small.txt");
            Process2("Day9/Day9.txt");
        }

        public static void Process(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<long[]>();
            while (!reader.EndOfStream)
            {
                l.Add([.. reader.ReadLine()!.Split(',').Select(long.Parse)]);
            }
            int m = l.Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    count = Math.Max(count, (Math.Abs(l[i][0] - l[j][0]) + 1) * (Math.Abs(l[i][1] - l[j][1]) + 1));
                }
            }
            Console.WriteLine($"Part 1 : {fileName} : {count}");
        }
        public static void Process2(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<long[]>();
            while (!reader.EndOfStream)
            {
                l.Add([.. reader.ReadLine()!.Split(',').Select(long.Parse)]);
            }
            int m = l.Count;
            var xs = l.Select(p => p[0]).ToList();
            var ys = l.Select(p => p[1]).ToList();
            xs.Add(0);
            ys.Add(0);
            xs.Sort();
            ys.Sort();
            xs.Add(xs[^1] + 1);
            ys.Add(ys[^1] + 1);
            var compressed = l.Select(p => new int[] { xs.IndexOf(p[0]), ys.IndexOf(p[1]) }).ToList();
            int m2 = m + 2;
            var grid = new int[m2][];
            for (int i = 0; i < m2; i++)
            {
                grid[i] = new int[m2];
                for (int j = 0; j < m2; j++)
                {
                    grid[i][j] = 0;
                }
            }
            int x1 = compressed[^1][0], y1 = compressed[^1][1];
            for (int i = 0; i < m; i++)
            {
                int x2 = compressed[i][0], y2 = compressed[i][1];
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
                    for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
                        grid[x][y] = 2;
                x1 = x2;
                y1 = y2;
            }
            var q = new Queue<(int x, int y)>();
            q.Enqueue((0, 0));
            grid[0][0] = 1;
            var moves = new List<(int x, int y)>() { (0, 1), (1, 0), (-1, 0), (0, -1) };
            while (q.Count > 0)
            {
                (int x, int y) = q.Dequeue();
                foreach ((int dx, int dy) in moves)
                {
                    int nx = x+dx, ny = y+dy;
                    if (nx < 0 || nx == m2 || ny < 0 || ny == m2) continue;
                    if (grid[nx][ny] == 0)
                    {
                        grid[nx][ny] = 1;
                        q.Enqueue((nx, ny));
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                long x = compressed[i][0], y = compressed[i][1];
                for (int j = i+1; j < m; j++)
                {
                    long x2 = compressed[j][0], y2 = compressed[j][1];
                    long size = (1 + Math.Abs(l[i][0] - l[j][0])) * (1 + Math.Abs(l[i][1] - l[j][1]));
                    if (size < count) continue; // aire trop petite de toute façon
                    bool rectangle = true;
                    for (long r = Math.Min(x, x2); rectangle && r <= Math.Max(x, x2); r++)
                    {
                        for (long c = Math.Min(y, y2); c <= Math.Max(y, y2);c++)
                        {
                            if (grid[r][c] == 1)
                            {
                                rectangle = false;
                                break;
                            }
                        }
                    }
                    if (rectangle)
                        count = size;
                }
            }

            Console.WriteLine($"Part 2 : {fileName} : {count}");
        }
    }
}
