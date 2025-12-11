using System;

namespace AOC2025
{
    internal static class Day8
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day8
            Console.WriteLine("AOC2025 Day8 placeholder");
            Process("Day8/Day8-small.txt", 10);
            Process("Day8/Day8.txt", 1000);
            Process2("Day8/Day8-small.txt");
            Process2("Day8/Day8.txt");
        }
        public static void Process(string fileName, int joint)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<long[]>();
            while (!reader.EndOfStream)
            {
                l.Add([.. reader.ReadLine()!.Split(',').Select(long.Parse)]);
            }
            int m = l.Count;
            var uf = new UnionFind(m);
            var sorted = new SortedSet<(long d, int i, int j)>();
            for (int i = 0; i < m; i++)
            {

                for (int j = i + 1; j < m; j++)
                {
                    long dx = l[i][0] - l[j][0], dy = l[i][1] - l[j][1], dz = l[i][2] - l[j][2];
                    long dist = dx * dx + dy * dy + dz * dz;
                    sorted.Add((dist, i, j));
                }
            }
            foreach(var (d, i, j) in sorted.Take(joint))
            {
                uf.Union(i, j);
            }
            var counting = new Dictionary<int, int>();
            for (int i = 0; i < m; i++)
            {
                int k = uf.Find(i);
                counting.TryGetValue(k, out int value);
                counting[k] = value + 1;
            }
            count = counting.Values.OrderByDescending(x => x).Take(3).Aggregate(1, (a, b) => a * b);

            Console.WriteLine($"Part 1 : {fileName} : {count}");
        }
        public static void Process2(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<long[]>();
            while (!reader.EndOfStream)
            {
                l.Add([.. reader.ReadLine()!.Split(',').Select(long.Parse)]);
            }
            int m = l.Count;
            var uf = new UnionFind(m);
            var sorted = new SortedSet<(long d, int i, int j)>();
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    long dx = l[i][0] - l[j][0], dy = l[i][1] - l[j][1], dz = l[i][2] - l[j][2];
                    long dist = dx * dx + dy * dy + dz * dz;
                    sorted.Add((dist, i, j));
                }
            }
            foreach (var pair in sorted)
            {
                uf.Union(pair.i, pair.j);
                int k = uf.Find(0);
                bool single = true;
                for (int i = 1; i < m; i++)
                {
                    if (uf.Find(i) == k) continue;
                    single = false;
                    break;
                }
                if (single)
                {
                    count = l[pair.i][0] * l[pair.j][0];
                    break;
                }
            }

            Console.WriteLine($"Part 2 : {fileName} : {count}");
        }
    }
    public class UnionFind
    {
        private readonly int n;
        public UnionFind(int n)
        {
            parent = new int[n];
            this.n = n;
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < n; i++)
                parent[i] = i;
        }

        public readonly int[] parent;
        public int Find(int v)
        {
            if (v == parent[v]) return v;
            return parent[v] = Find(parent[v]);
        }
        public bool Union(int a, int b)
        {
            int pa = Find(a), pb = Find(b);
            if (pa != pb)
            {
                parent[pa] = pb;
                return true;
            }
            return false;
        }
    }

}
