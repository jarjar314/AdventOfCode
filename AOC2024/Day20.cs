using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day20
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<string>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine()!);
                }
            }
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        private static void part2(List<string> lines)
        {
            int[][] grid = null;
            int rStart = 0, cStart = 0, rEnd = 0, cEnd = 0;
            m = lines.Count;
            n = lines[0].Length;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (lines[r][c] == 'E')
                    {
                        rEnd = r;
                        cEnd = c;
                        grid = Generate(lines, r, c);
                    }
                    if (lines[r][c] == 'S')
                    {
                        rStart = r;
                        cStart = c;
                    }
                }
            }
            var shortcuts = new Dictionary<int, int>();
            var q = new Queue<(int r, int c)>();
            q.Enqueue((rStart, cStart));

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                for (int i = -20; i < 21; i++)
                {
                    for (int j = -20; j < 21; j++)
                    {
                        int time = Math.Abs(i) + Math.Abs(j);
                        if (time > 20) continue;
                        int nr = p.r + i, nc = p.c + j;
                        if (nr < 0 || nc < 0 || nr >= m || nc >= n) continue; // hors grille
                        if (grid[nr][nc] == 0) continue;
                        int diff = grid[p.r][p.c] - grid[nr][nc] - time;
                        if (diff > 0)
                        {
                            shortcuts.TryGetValue(diff, out var count);
                            shortcuts[diff] = count + 1;
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + moves[i], nc = p.c + moves[i + 1];
                    if (grid[nr][nc] == grid[p.r][p.c] - 1) q.Enqueue((nr, nc));
                }
            }
            Console.WriteLine($"part2: {shortcuts.Where(p => p.Key >= 100).Sum(p => p.Value)} over 100 ps");
        }
        private static int m, n;
        private static void part1(List<string> lines)
        {
            int[][] grid = null;
            int rStart = 0, cStart = 0, rEnd = 0, cEnd = 0;
            m = lines.Count;
            n = lines[0].Length;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (lines[r][c] == 'E')
                    {
                        rEnd = r;
                        cEnd = c;
                        grid = Generate(lines, r, c);
                    }
                    if (lines[r][c] == 'S')
                    {
                        rStart = r;
                        cStart = c;
                    }
                }
            }
            var shortcuts = new Dictionary<int, int>();
            var q = new Queue<(int r, int c)>();
            q.Enqueue((rStart, cStart));

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + 2 * moves[i], nc = p.c + 2 * moves[i + 1];
                    if (nr < 0 || nc < 0 || nr >= m || nc >= n) continue; // hors grille
                    if (grid[nr][nc] == 0) continue;
                    int diff = grid[p.r][p.c] - grid[nr][nc] - 2;
                    if (diff > 0)
                    {
                        shortcuts.TryGetValue(diff, out var count);
                        shortcuts[diff] = count + 1;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + moves[i], nc = p.c + moves[i + 1];
                    if (grid[nr][nc] == grid[p.r][p.c] - 1) q.Enqueue((nr, nc));
                }
            }
            Console.WriteLine($"part1: {shortcuts.Where(p => p.Key >= 100).Sum(p => p.Value)} over 100 ps");
        }

        private static int[] moves = new int[] { 0, 1, 0, -1, 0 };
        private static int[][] Generate(List<string> lines, int r, int c)
        {
            var grid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                grid[i] = new int[n];
            }
            grid[r][c] = 1;
            var q = new Queue<(int r, int c)>();
            q.Enqueue((r, c));
            while (q.Any())
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + moves[i], nc = p.c + moves[i + 1];
                    if (lines[nr][nc] == '#') continue;
                    if (grid[nr][nc] > 0) continue; // already on this path
                    grid[nr][nc] = grid[p.r][p.c] + 1;
                    if (lines[nr][nc] == 'S') return grid;
                    q.Enqueue((nr, nc));
                }
            }
            return grid;
        }
    }
}
