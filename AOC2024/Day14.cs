using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AOC2024
{
    internal class Day14
    {
        private static int w = 101, h = 103, move1 = 100;
        private static void part1(List<string> input)
        {
            var quadrant = new int[4];
            var robots = new List<(int px, int py, int vx, int vy)>();
            foreach (var arr in input)
            {
                var l = arr.Split(new char[] { '=', ',', ' ' });
                var r = (int.Parse(l[1]), int.Parse(l[2]), int.Parse(l[4]), int.Parse(l[5]));
                robots.Add(r);
                int endx = ((move1 * r.Item3 + r.Item1) % w + w) % w;
                int endy = ((move1 * r.Item4 + r.Item2) % h + h) % h;
                if (endx == w / 2 || endy == h / 2) continue;
                int q = (endx > w / 2 ? 1 : 0) + (endy > h / 2 ? 2 : 0);
                quadrant[q]++;
            }
            Console.WriteLine(quadrant[0] * quadrant[1] * quadrant[2] * quadrant[3]);
        }
        private static void print(char[][] grid)
        {
            Console.WriteLine(string.Join("\n", grid.Select(l => string.Join("", l))));
        }
        private static void part2(List<string> input)
        {
            var quadrant = new int[4];
            var robots = new List<(int px, int py, int vx, int vy)>();
            var grid = new char[h][];
            for (int i = 0; i < h; i++)
            {
                grid[i] = new char[w];
            }
            init(grid);
            foreach (var arr in input)
            {
                var l = arr.Split(new char[] { '=', ',', ' ' });
                var r = (int.Parse(l[1]), int.Parse(l[2]), int.Parse(l[4]), int.Parse(l[5]));
                robots.Add(r);
                grid[r.Item2][r.Item1] = '#';
            }
            int seconds = 0;
            while (true)
            {
                init(grid);
                for (int i = 0; i < robots.Count; i++)
                {
                    var r = robots[i];
                    r.px = ((r.px + r.vx) % w + w) % w;
                    r.py = ((r.vy + r.py) % h + h) % h;
                    grid[r.py][r.px] = '#';
                    robots[i] = r;
                }
                seconds++;
                if (seconds % 103 == 28 || seconds % 101 == 77)
                {
                    print(grid);
                    Console.WriteLine(seconds);
                    Console.ReadLine();
                }
            }

        }

        private static void init(char[][] grid)
        {
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    grid[i][j] = ' ';
        }

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
    }
}
