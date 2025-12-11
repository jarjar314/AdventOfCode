using System;

namespace AOC2025
{
    internal static class Day11
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day11
            Console.WriteLine("AOC2025 Day11 placeholder");
            Process("Day11/Day11-small.txt");
            Process("Day11/Day11.txt");
            Process2("Day11/Day11-small2.txt");
            Process2("Day11/Day11.txt");
        }
        static Dictionary<string, List<string>> graph = [];

        public static void Process(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            graph.Clear();
            cache.Clear();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                graph[line[0]] = line.Skip(1).ToList();
            }
            count = Path("you");

            Console.WriteLine($"Part 1 : {fileName} : {count}");
        }
        static Dictionary<string, long> cache = [];
        private static long Path(string v)
        {
            if (v == "out") return 1;
            if (cache.TryGetValue(v, out var result)) return result;
            foreach (var child in graph[v])
            {
                result += Path(child);
            }
            return cache[v] = result;
        }

        static Dictionary<(string, bool, bool), long> cache2 = [];
        public static void Process2(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            graph.Clear();
            cache2.Clear();
            cache2.Add(("out", true, true), 1);
            cache2.Add(("out", true, false), 0);
            cache2.Add(("out", false, false), 0);
            cache2.Add(("out", false, true), 0);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                graph[line[0]] = line.Skip(1).ToList();
            }
            count = Path2("svr", false, false);

            Console.WriteLine($"Part 2 : {fileName} : {count}");

        }

        private static long Path2(string source, bool dac, bool fft)
        {
            if (cache2.TryGetValue((source, dac, fft), out var res)) return res;
            foreach (var child in graph[source])
            {
                res += Path2(child, dac || child == "dac", fft || child == "fft");
            }

            return cache2[(source, dac, fft)] = res;
        }
    }
}