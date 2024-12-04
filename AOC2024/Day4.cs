using System.Reflection;
using System.Xml.Serialization;

namespace AOC2024
{
    internal class Day4
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                var lines = new List<string>();
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
                part1(lines);
                part2(lines);
            }

        }

        private static void part2(List<string> lines)
        {
            int count = 0, m = lines.Count, n = lines[0].Length;
            for (int r = 1; r < m-1; r++)
                for (int c = 1; c < n-1; c++)
                {
                    if (lines[r][c] != 'A') continue;
                    var d1 = ""+lines[r - 1][c - 1] + lines[r + 1][c + 1];
                    var d2 = ""+lines[r + 1][c - 1] + lines[r - 1][c + 1];
                    if ((d1 == "MS" || d1 == "SM") && (d2 == "MS" || d2 == "SM")) count++;
                }
            Console.WriteLine(count);
        }

        private static bool xmas(int r, int c, int dr, int dc, List<string> lines)
        {
            try
            {
                if (lines[r][c] != 'X') return false;
                r += dr; c += dc;
                if (lines[r][c] != 'M') return false;
                r += dr; c += dc;
                if (lines[r][c] != 'A') return false;
                r += dr; c += dc;
                if (lines[r][c] != 'S') return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static void part1(List<string> lines)
        {
            int count = 0;
            int m = lines.Count, n = lines[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (xmas(i, j, -1, -1, lines)) count++;
                    if (xmas(i, j, -1, 0, lines)) count++;
                    if (xmas(i, j, -1, 1, lines)) count++;
                    if (xmas(i, j, 0, 1, lines)) count++;
                    if (xmas(i, j, 0, -1, lines)) count++;
                    if (xmas(i, j, 1, -1, lines)) count++;
                    if (xmas(i, j, 1, 0, lines)) count++;
                    if (xmas(i, j, 1, 1, lines)) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
