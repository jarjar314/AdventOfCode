using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day23
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<string[]>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine()!.Split('-'));
                }
            }
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        private static void part2(List<string[]> lines)
        {
            HashSet<string> hs;
            var graph = new Dictionary<string, HashSet<string>>();
            foreach (var l in lines)
            {
                if (!graph.TryGetValue(l[0], out hs)) graph[l[0]] = hs = new HashSet<string>();
                hs.Add(l[1]);
                if (!graph.TryGetValue(l[1], out hs)) graph[l[1]] = hs = new HashSet<string>();
                hs.Add(l[0]);
            }
            var nodes = graph.Keys.ToList();
            var res = new HashSet<string>();
            int maxSet = 0;
            var current = new HashSet<string>();
            dfs(0);

            Console.WriteLine($"part2: {string.Join(",", res.OrderBy(c => c))}");


            void dfs(int index)
            {
                if (index == nodes.Count)
                {
                    if (current.Count > maxSet)
                    {
                        res = new HashSet<string>(current);
                        maxSet = res.Count;
                    }
                    return;
                }
                string node = nodes[index];
                bool partOfLan = true;
                foreach (var c in current)
                {
                    if (!graph[node].Contains(c))
                    {
                        partOfLan = false;
                        break;
                    }
                }
                if (partOfLan)
                {
                    current.Add(node);
                    dfs(index + 1);
                    current.Remove(node);
                }
                dfs(index + 1);
            }
        }

        private static void part1(List<string[]> lines)
        {
            HashSet<string> hs;
            var graph = new Dictionary<string, HashSet<string>>();
            foreach (var l in lines)
            {
                if (!graph.TryGetValue(l[0], out hs)) graph[l[0]] = hs = new HashSet<string>();
                hs.Add(l[1]);
                if (!graph.TryGetValue(l[1], out hs)) graph[l[1]] = hs = new HashSet<string>();
                hs.Add(l[0]);
            }
            int count = 0;

            foreach (var g1 in graph)
            {
                foreach (var g2 in g1.Value)
                {
                    foreach (var g3 in g1.Value)
                    {
                        if (graph[g2].Contains(g3))
                        {
                            if (g1.Key[0] == 't' || g2[0] == 't' || g3[0] == 't') count++;
                        }
                    }
                }
            }

            Console.WriteLine($"part1: {count / 6}");
        }
    }
}
