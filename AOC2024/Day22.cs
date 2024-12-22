using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day22
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<int>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(int.Parse(sr.ReadLine()!));
                }
            }
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        static Dictionary<(int a, int b, int c, int d), int> bananas = new Dictionary<(int a, int b, int c, int d), int>();
        static long prune = 16777216;
        static long Compute2(long n, int round)
        {
            var localBananas = new Dictionary<(int a, int b, int c, int d), int>();
            long secret = n;
            var prices = new List<int>();
            prices.Add((int)(secret % 10));
            for (int i = 0; i < round; i++)
            {
                secret = (secret ^ (secret << 6)) % prune;
                secret = (secret ^ (secret >> 5)) % prune;
                secret = ((secret << 11) ^ secret) % prune;
                prices.Add((int)(secret % 10));
            }
            for (int i = 4; i < round; i++)
            {
                int d1 = prices[i - 3] - prices[i - 4];
                int d2 = prices[i - 2] - prices[i - 3];
                int d3 = prices[i - 1] - prices[i - 2];
                int d4 = prices[i] - prices[i - 1];
                localBananas.TryAdd((d1, d2, d3, d4), prices[i]);
            }
            foreach (var kvp in localBananas)
            {
                bananas.TryGetValue(kvp.Key, out var count);
                bananas[kvp.Key] = count + kvp.Value;
            }
            return secret;
        }
        private static void part2(List<int> lines)
        {
            foreach (var l in lines) Compute2(l, 2000);
            Console.WriteLine(bananas.Values.Max());
        }
        static long Compute(long n, int round)
        {
            long secret = n;
            for (int i = 0; i < round; i++)
            {
                secret = (secret ^ (secret<<6)) % prune;
                secret = (secret ^ (secret >> 5)) % prune;
                secret = ((secret << 11) ^ secret) % prune;
            }
            return secret;
        }
        private static void part1(List<int> lines)
        {
            Console.WriteLine(lines.Sum(l => Compute(l, 2000)));
        }
    }
}
