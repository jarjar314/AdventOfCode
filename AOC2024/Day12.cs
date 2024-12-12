using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day12
    {
        private static int m, n;
        private static (long p, long a) GetPerimeterArea(char[][] map, int r, int c)
        {
            var region = GetRegion(map, r, c);
            int perimeter = 4 * region.Count;
            foreach (var pair in region)
            {
                map[pair.r][pair.c] = '*';
                for (int i = 0; i < 4; i++)
                {
                    if (region.Contains((pair.r + move[i], pair.c + move[i + 1])))
                        perimeter--;
                }
            }

            return (perimeter, region.Count);
        }
        private static int[] move = new[] { 0, 1, 0, -1, 0 };
        private static HashSet<(int r, int c)> GetRegion(char[][] map, int r, int c)
        {
            char target = map[r][c];
            var q = new Queue<(int r, int c)>();
            var visited = new HashSet<(int r, int c)>();
            q.Enqueue((r, c));
            visited.Add((r, c));
            while (q.Any())
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + move[i], nc = p.c + move[i + 1];
                    if (nr < 0 || nc < 0 || nr == m || nc == n) continue; // hors grille
                    if (map[nr][nc] != target) continue;
                    if (visited.Add((nr, nc))) q.Enqueue((nr, nc));
                }
            }
            return visited;
        }
        static void part1(List<string> lines)
        {
            var map = lines.Select(l => l.ToCharArray()).ToArray();
            var region = new List<(long p, long a)>();
            m = map.Length;
            n = map[0].Length;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (map[r][c] != '*')
                        region.Add(GetPerimeterArea(map, r, c));
                }
            }
            Console.WriteLine(region.Sum(pair => pair.p * pair.a));
        }
        static long p1 = 0;
        static long ComputeFence(HashSet<(int r, int c)> zone)
        {
            var fences = new SortedDictionary<(int r1, int c1, int r2, int c2), int>();
            foreach (var f in zone)
            {
                var up = (2 * f.r - 1, 2 * f.c - 1, 2 * f.r - 1, 2 * f.c + 1);
                var down = (2 * f.r + 1, 2 * f.c - 1, 2 * f.r + 1, 2 * f.c + 1);
                var left = (2 * f.r - 1, 2 * f.c - 1, 2 * f.r + 1, 2 * f.c - 1);
                var right = (2 * f.r - 1, 2 * f.c + 1, 2 * f.r + 1, 2 * f.c + 1);
                if (!fences.TryAdd(up, 0)) fences.Remove(up);
                if (!fences.TryAdd(down, 1)) fences.Remove(down);
                if (!fences.TryAdd(left, 0)) fences.Remove(left);
                if (!fences.TryAdd(right, 1)) fences.Remove(right);
            }
            p1 += zone.Count * fences.Count;
            // so now I have each individual fence. Now, I take the first one, and I try to match left and right and remove the items.
            int bulk = 0;
            while (fences.Count > 0)
            {
                bulk++;
                var first = fences.First();
                fences.Remove(first.Key);
                int nr1 = first.Key.r1, nr2 = first.Key.r2, nc1 = first.Key.c1, nc2 = first.Key.c2;
                int dr = nr2 - nr1, dc = nc2 - nc1;
                nr1 += dr;
                nr2 += dr;
                nc1 += dc;
                nc2 += dc;
                while (fences.TryGetValue((nr1, nc1, nr2, nc2), out var bord) && bord == first.Value)
                {
                    fences.Remove((nr1, nc1, nr2, nc2));
                    nr1 += dr;
                    nr2 += dr;
                    nc1 += dc;
                    nc2 += dc;
                }

            }
            return bulk;
        }
        static void part2(List<string> lines)
        {
            var map = lines.Select(l => l.ToCharArray()).ToArray();
            var regions = new List<HashSet<(int r, int c)>>();
            m = map.Length;
            n = map[0].Length;
            long total = 0;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (map[r][c] != '*')
                    {
                        var region = GetRegion(map, r, c);
                        regions.Add(region);
                        foreach (var pair in region) map[pair.r][pair.c] = '*';
                        total += ComputeFence(region) * region.Count;
                    }
                }
            }
            Console.WriteLine($"part2={total}");
            Console.WriteLine($"part1={p1} to check.");
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
