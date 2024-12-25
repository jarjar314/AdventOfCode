using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day25
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
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        static List<int[]> keys = new List<int[]>();
        static List<int[]> locks = new List<int[]>();
        private static void Process(List<string> lines)
        {
            int[] res = new int[5];
            if (lines[0][0] == '#')
            {
                for (int c = 0; c< 5; c++)
                {
                    int r = 0;
                    while (lines[r][c] == '#')
                        r++;
                    res[c] = r - 1;
                }
                locks.Add(res);
            }
            else
            {
                for (int c = 0; c < 5; c++)
                {
                    int r = 0;
                    while (lines[r][c] == '.')
                        r++;
                    res[c] = 6 - r;
                }
                keys.Add(res);
            }
            
        }
        private static void part1(List<string> lines)
        {
            int start = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    Process(lines[start..i]);
                    start = i + 1;
                }
            }
            Process(lines[start..]);
            long count = 0;
            foreach (var k in keys)
            {
                foreach (var l in locks)
                {
                    bool overlap = false; ;
                    for (int c = 0; c < 5; c++)
                    {
                        if (l[c] + k[c] >= 6)
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if (!overlap)
                        count++;
                }
            }
            Console.WriteLine($"part1: {count}");
        }
    }
}
