using System.Reflection;

namespace AOC2024
{
    internal class Day8
    {
        static void part1(List<string> list)
        {
            var antennas = new HashSet<(int r, int c)>();
            var antinodes = new HashSet<(int r, int c)>();
            int m = list.Count, n = list[0].Length;
            var dico = new Dictionary<char, List<(int r, int c)>>();
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    var ch = list[r][c];
                    if (list[r][c] == '.') continue;
                    antennas.Add((r, c));
                    if (dico.TryGetValue(ch, out var l))
                    {
                        foreach (var e in l)
                        {
                            int dr1 = 2 * e.r - r, dc1 = 2 * e.c - c, dr2 = 2 * r - e.r, dc2 = 2 * c - e.c;
                            if (0 <= dr1 && dr1 < m && 0 <= dc1 && dc1 < n) antinodes.Add((dr1, dc1));
                            if (0 <= dr2 && dr2 < m && 0 <= dc2 && dc2 < n) antinodes.Add((dr2, dc2));
                        }
                        l.Add((r, c));
                    }
                    else
                    {
                        dico[ch] = new List<(int r, int c)>() { (r, c) };
                    }
                }
            }
            Console.WriteLine(antinodes.Count);
        }
        static void part2(List<string> list)
        {
            var antinodes = new HashSet<(int r, int c)>();
            int m = list.Count, n = list[0].Length;
            var dico = new Dictionary<char, List<(int r, int c)>>();
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    var ch = list[r][c];
                    if (list[r][c] == '.') continue;
                    if (dico.TryGetValue(ch, out var l))
                    {
                        foreach (var e in l)
                        {
                            antinodes.Add((r, c));
                            antinodes.Add((e.r, e.c));
                            int dr = e.r - r, dc = e.c - c;
                            int nr = e.r + dr, nc = e.c + dc;
                            while( 0 <= nr && nr < m && 0 <= nc && nc < n)
                            {
                                antinodes.Add((nr, nc));
                                nr += dr;nc += dc;
                            }
                            nr = r - dr;nc = c - dc;
                            while (0 <= nr && nr < m && 0 <= nc && nc < n)
                            {
                                antinodes.Add((nr, nc));
                                nr -= dr; nc -= dc;
                            }

                        }
                        l.Add((r, c));
                    }
                    else
                    {
                        dico[ch] = new List<(int r, int c)>() { (r, c) };
                    }
                }
            }
            Console.WriteLine(antinodes.Count);
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
            part1(lines);
            part2(lines);
        }
    }
}
