using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day11
    {
        static Dictionary<(long elem, long cnt), long> cache = new Dictionary<(long elem, long cnt), long>();
        static void part1(long[] longs)
        {
            long total = 0;
            foreach (var l in longs)
               total += Count(l, 25);

            Console.WriteLine(total);
        }

        static long Count(long input, long k)
        {
            if (k == 0) return 1;
            if (cache.TryGetValue((input, k), out var count)) return count;
            if (input == 0) return cache[(input, k)] = Count(1, k - 1);
            var l = input.ToString();
            if (l.Length % 2 == 0)
                return cache[(input, k)] = Count(long.Parse(l[0..(l.Length / 2)]), k - 1) + Count(long.Parse(l[(l.Length / 2)..]), k - 1);
            return cache[(input, k)] = Count(input * 2024, k - 1);
        }

        static void part2(long[] longs)
        {
            long total = 0;
            foreach (var l in longs)
                total += Count(l, 75);

            Console.WriteLine(total);

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
            var input = lines[0].Split().Select(long.Parse).ToArray();
            var stopwatch = Stopwatch.StartNew();
            part1(input);
            part2(input);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

        }
    }
}
