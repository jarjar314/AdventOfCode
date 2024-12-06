using System.ComponentModel;
using System.Reflection;

namespace AOC2024
{
    internal class Day6
    {
        private static int startR, startC,m,n;
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
            var possible = part1(lines);
            part2(lines, possible);

        }

        private static HashSet<(int r, int c)> part1(List<string> lines)
        {
            n = lines.Count;
            m = lines[0].Count();
            startR = 0; 
            startC = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (lines[r][c] == '^')
                    {
                        startR = r;
                        startC = c;
                        break;
                    }
                }
            }
            int direction = 0;
            var dm = new[] { -1, 0, 1, 0, -1 };
            var visited = new HashSet<(int r, int c)>();
            visited.Add((startR, startC));
            int cr = startR, cc = startC;
            while (true)
            {
                int nr = cr + dm[direction], nc = cc + dm[direction + 1];
                if (nr < 0 || nc < 0 || nr == n || nc == m) break;
                if (lines[nr][nc] == '#')
                {
                    direction = (direction + 1) % 4;
                    continue;
                }
                visited.Add((nr, nc));
                cr = nr;cc = nc;
            }

            Console.WriteLine(visited.Count);
            visited.Remove((startR, startC));
            return visited;
        }

        private static void part2(List<string> lines, HashSet<(int r, int c)> obstacles)
        {
            var ca = lines.Select(c => c.ToCharArray()).ToArray();
            Console.WriteLine(obstacles.Count(c => isLoop(ca, c)));
        }
        
        private static bool isLoop(char[][] ca, (int r, int c) obstacle)
        {
            ca[obstacle.r][obstacle.c] = '#';
            int direction = 0;
            var dm = new[] { -1, 0, 1, 0, -1 };
            var visited = new HashSet<(int r, int c, int direction)>();
            visited.Add((startR, startC, 0));
            int cr = startR, cc = startC;
            bool loop = false;
            while (true)
            {
                int nr = cr + dm[direction], nc = cc + dm[direction + 1];
                if (nr < 0 || nc < 0 || nr == n || nc == m) break;
                if (ca[nr][nc] == '#')
                {
                    direction = (direction + 1) % 4;
                    continue;
                }
                if (!visited.Add((nr, nc, direction))){
                    loop = true;
                    break;
                }
                cr = nr; cc = nc;
            }
            ca[obstacle.r][obstacle.c] = '.';
            return loop;
        }

    }
}
