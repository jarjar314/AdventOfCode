using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day18
    {
        private static int[] moves = [0, 1, 0, -1, 0];
        static int find_steps(List<string> bytes, int max, int limit)
        {
            var input = bytes.Select(row => row.Split(',')).Select(r => (int.Parse(r[0]), int.Parse(r[1]))).ToList<(int r, int c)>();
            var grid = new bool[max][];
            for (int r = 0; r < max; r++)
            {
                grid[r] = new bool[max];
            }
            for (int i = 0; i < limit; i++)
            {
                var point = input[i];
                grid[point.r][point.c] = true;
            }
            var q = new Queue<(int r, int c, int step)>();
            q.Enqueue((0, 0, 0));
            var visited = new HashSet<(int r, int c)>() { ( 0, 0 ) };
            while(q.Count > 0)
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int dr = p.r + moves[i], dc = p.c + moves[i + 1];
                    if (dr < 0 || dc < 0 || dr == max || dc == max) continue;
                    if (grid[dr][dc]) continue; // there's a byte there !
                    if (dr == max - 1 && dc == max - 1)
                    {
                        return p.step + 1;
                    }
                    if (visited.Add((dr, dc))) q.Enqueue((dr, dc, p.step + 1));
                }
            }
            return -1;
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
        static string bst(List<string> bytes, int max)
        {
            int l = 0, r = bytes.Count;
            while (l < r - 1)
            {
                int mid = (l + r) >> 1;
                if (find_steps(bytes, max, mid + 1) == -1)
                    r = mid;
                else l = mid;
            }
            return bytes[r];
        }
        private static void part2(List<string> lines)
        {
            Console.WriteLine(bst(lines, 71));
        }

        private static void part1(List<string> lines)
        {
            Console.WriteLine(find_steps(lines, 71, 1024));
        }
    }
}
