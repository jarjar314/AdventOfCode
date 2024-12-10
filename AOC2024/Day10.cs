using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day10
    {
        static void part1(char[][] carte)
        {
            Dictionary<(int r, int c), HashSet<(int r, int c)>> numbers = new Dictionary<(int r, int c), HashSet<(int r, int c)>>();
            int m = carte.Length, n = carte[0].Length;
            for (int r = 0; r < m; r++)
                for (int c = 0; c < n; c++)
                    if (carte[r][c] == '9')
                        numbers.Add((r, c), new HashSet<(int r, int c)>() { (r, c)});

            var move = new[] { 0, 1, 0, -1, 0 };

            for (int i = 8; i >= 0; i--)
            {
                char target = (char)('0' + i);
                var next = new Dictionary<(int r, int c), HashSet<(int r, int c)>>();
                foreach (var p in numbers)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int dr = p.Key.r + move[j], dc = p.Key.c + move[j + 1];
                        if (dr < 0 || dc < 0 || dr == m || dc == n) continue;
                        if (carte[dr][dc] != target) continue;
                        if (!next.TryGetValue((dr, dc), out var count)) next[(dr, dc)] = count = new HashSet<(int r, int c)>();
                        count.UnionWith(p.Value);
                    }
                }
                numbers = next;
            }

            Console.WriteLine($"part1 : {numbers.Values.Sum(c => c.Count)}");

        }
        static void part2(char[][] carte) {
            Dictionary<(int r, int c), long> numbers = new Dictionary<(int r, int c), long>();
            int m = carte.Length, n = carte[0].Length;
            for (int r = 0; r < m; r++)
                for (int c = 0; c < n; c++)
                    if (carte[r][c] == '9')
                        numbers.Add((r, c), 1);

            var move = new[] { 0, 1, 0, -1, 0 };

            for (int i = 8; i >= 0; i--)
            {
                char target = (char)('0' + i);
                var next = new Dictionary<(int r, int c), long>();
                foreach (var p in numbers)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int dr = p.Key.r + move[j], dc = p.Key.c + move[j + 1];
                        if (dr < 0 || dc < 0 || dr == m || dc == n) continue;
                        if (carte[dr][dc] != target) continue;
                        next.TryGetValue((dr, dc), out var count);
                        next[(dr, dc)] = count + p.Value;
                    }
                }
                numbers = next;
            }

            Console.WriteLine($"part1 : {numbers.Values.Sum()}");
        }
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<char[]>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine()!.ToCharArray());
                }
            }
            var ca = lines.ToArray();
            var stopwatch = Stopwatch.StartNew();
            part1(ca);
            part2(ca);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }
    }
}
