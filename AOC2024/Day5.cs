using System.Reflection;
using System.Runtime.CompilerServices;

namespace AOC2024
{
    internal class Day5
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<string>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            var before = new Dictionary<int, HashSet<int>>();
            int i = 0;
            while (i < lines.Count && lines[i] != string.Empty)
            {
                var pair = lines[i].Split('|').Select(int.Parse).ToArray();
                if (!before.TryGetValue(pair[0], out var hs))
                    before[pair[0]] = hs = new HashSet<int>();
                hs.Add(pair[1]);
                i++;
            }
            i++;
            var books = new List<List<int>>();
            while (i < lines.Count)
            {
                books.Add(lines[i].Split(',').Select(int.Parse).ToList());
                i++;
            }
            part1(books, before);
            part2(books, before);
        }

        private static void part2(List<List<int>> books, Dictionary<int, HashSet<int>> before)
        {
            Console.WriteLine(books.Where(book => !Check1(book, before)).Sum(book => fix(book, before)[book.Count / 2]));
        }

        static List<int> fix(List<int> book, Dictionary<int, HashSet<int>> before)
        {
            var graph = new Dictionary<int, HashSet<int>>();
            foreach (var p in book)
            {
                if (before.TryGetValue(p, out var prev))
                {
                    var hs = prev.Intersect(book).ToHashSet();
                    graph.Add(p, hs);
                }
                else
                    graph.Add(p, new HashSet<int>());
            }
            var res = new List<int>();
            while (graph.Count > 0)
            {
                int target = -1;
                foreach (var pair in graph)
                {
                    if (pair.Value.Count == 0)
                    {
                        target = pair.Key;
                        break;
                    }
                }
                foreach (var pair in graph)
                {
                    pair.Value.Remove(target);
                }
                graph.Remove(target);
                res.Add(target);
            }
            return res;
        }
        static void part1(List<List<int>> books, Dictionary<int, HashSet<int>> before)
        {
            Console.WriteLine(books.Where(book => Check1(book, before)).Sum(book => book[book.Count / 2]));
        }
        static bool Check1(List<int> book, Dictionary<int, HashSet<int>> before)
        {
            var prev = new HashSet<int>();
            foreach (var b in book)
            {
                if (before.TryGetValue(b, out var previous))
                {
                    if (previous.Intersect(prev).Count() > 0) return false;
                }
                prev.Add(b);
            }
            return true;
        }
    }
}
