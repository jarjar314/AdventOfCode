using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day19
    {
        static string[] stripes;
        static Dictionary<int, bool> cache = new Dictionary<int, bool>();
        static Dictionary<int, long> cache2 = new Dictionary<int, long>();
        static void part1(List<string> lines)
        {
            stripes = lines[0].Split(", ");
            int count = 0;
            for (int i = 2; i < lines.Count; i++)
            {
                if (isPossible(lines[i]))
                    count++;
            }
            Console.WriteLine($"part1: {count}");
        }
        static bool isPossible(string line)
        {
            cache.Clear();
            return found(line, 0);
        }
        static bool found(string a, int index)
        {
            if (index == a.Length) return true;
            if (cache.TryGetValue(index, out var res)) return res;
            foreach (var s in stripes)
            {
                if (index + s.Length > a.Length) continue;
                if (a[index..(index + s.Length)] == s)
                {
                    res |= found(a, index + s.Length);
                }
                if (res) break;
            }
            return cache[index] = res;
        }
        static long possibility(string a, int index)
        {
            if (index == a.Length) return 1;
            if (cache2.TryGetValue(index, out var res)) return res;
            foreach (var s in stripes)
            {
                if (index + s.Length > a.Length) continue;
                if (a[index..(index + s.Length)] == s)
                {
                    res += possibility(a, index + s.Length);
                }
            }
            return cache2[index] = res;
        }
        static void part2(List<string> lines)
        {
            stripes = lines[0].Split(", ");
            long count = 0;
            for (int i = 2; i < lines.Count; i++)
            {
                cache2.Clear();
                count+= possibility(lines[i], 0);
            }
            Console.WriteLine($"part2: {count}");
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
