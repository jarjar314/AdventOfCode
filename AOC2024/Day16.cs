using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace AOC2024
{
    internal class Day16
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
            int m = lines.Count, n = lines[0].Length;
            int rE = 0, cE = 0, rS = 0, cS = 0;
            for (int r = 0; r < m; r++)
                for (int c = 0; c < n; c++)
                {
                    if (lines[r][c] == 'E')
                    {
                        rE = r;
                        cE = c;

                    }
                    if (lines[r][c] == 'S')
                    {
                        rS = r;
                        cS = c;
                    }
                }
            var visited = new Dictionary<(int r, int c, int d), int>();
            var positions = new SortedSet<(int cost, int r, int c, int direction)>();
            positions.Add((0, rS, cS, 2));
            while (positions.Any())
            {
                var p = positions.First();
                positions.Remove(p);
                if (p.r == rE && p.c == cE)
                {
                    visited.Add((p.r, p.c, p.direction), p.cost);
                    Console.WriteLine($"part1 : {p.cost}");
                    // now backtrack the solution and count how much tiles are in an element
                    Console.WriteLine($"part2 : {backtrack(visited, rE, cE, p.direction, rS, cS, 2)}"); // in the path, there is only one direction to come but another puzzle could have another way 
                    return;
                }
                // not already visited
                if (visited.TryAdd((p.r, p.c, p.direction), p.cost))
                {
                    // on essaie de rotationer le robot
                    int left = (p.direction + 3) % 4;
                    int right = (p.direction + 1) % 4;
                    positions.Add((p.cost + 1000, p.r, p.c, left));
                    positions.Add((p.cost + 1000, p.r, p.c, right));

                    int nr = p.r + moves[p.direction], nc = p.c + moves[p.direction + 1];
                    if (lines[nr][nc] == '#') continue;
                    if (!visited.ContainsKey((nr, nc, p.direction)))
                    {
                        positions.Add((p.cost + 1, nr, nc, p.direction));
                    }
                }
            }
        }

        private static int backtrack(Dictionary<(int r, int c, int d), int> visited, int rE, int cE, int direction, int rS, int cS, int v)
        {
            var q = new Queue<(int r, int c, int d)>();
            q.Enqueue((rE, cE, direction));
            var path = new HashSet<(int r, int c)>();
            path.Add((rE, cE));
            int cout;
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                int cost = visited[p];
                // est-ce que j'ai tourné ? 
                int left = (p.d + 1) % 4;
                int right = (p.d + 3) % 4;
                if (visited.TryGetValue((p.r, p.c, left), out cout) && cout == (cost - 1000))q.Enqueue((p.r, p.c, left));
                if (visited.TryGetValue((p.r, p.c, right), out cout) && cout == (cost - 1000))q.Enqueue((p.r, p.c, right));
                // est-ce que je viens de la ligne droite ?
                int nr = p.r - moves[p.d], nc = p.c - moves[p.d + 1];
                if (visited.TryGetValue((nr, nc, p.d), out cout) && cout == (cost - 1))
                {
                    q.Enqueue((nr, nc, p.d));
                    path.Add((nr, nc));
                }
            }
            return path.Count;
        }

        static int[][] costs = [[0, 1], [1, 1001], [3, 1001]];
        static int[] moves = [0, -1, 0, 1, 0];
        private static void part1(List<string> lines)
        {
            int m = lines.Count, n = lines[0].Length;
            int rE = 0, cE = 0, rS = 0, cS = 0;
            for (int r = 0; r < m; r++)
                for (int c = 0; c < n; c++)
                {
                    if (lines[r][c] == 'E')
                    {
                        rE = r;
                        cE = c;

                    }
                    if (lines[r][c] == 'S')
                    {
                        rS = r;
                        cS = c;
                    }
                }
            var visited = new HashSet<(int r, int c, int d)>();
            var positions = new SortedSet<(int cost, int r, int c, int direction)>();
            positions.Add((0, rS, cS, 2));
            while (positions.Any())
            {
                var p = positions.First();
                positions.Remove(p);
                if (p.r == rE && p.c == cE)
                {
                    Console.WriteLine($"part1 : {p.cost}");
                    return;
                }
                // not already visited
                if (visited.Add((p.r, p.c, p.direction)))
                {
                    foreach (var i in costs)
                    {
                        int nd = (p.direction + i[0]) % 4, cost = p.cost + i[1];
                        int nr = p.r + moves[nd], nc = p.c + moves[nd + 1];
                        if (lines[nr][nc] == '#') continue;
                        if (!visited.Contains((nr, nc, nd)))
                        {
                            positions.Add((cost, nr, nc, nd));
                        }
                    }
                }
            }




        }
    }
}
