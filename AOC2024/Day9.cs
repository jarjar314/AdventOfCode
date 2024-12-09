using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace AOC2024
{
    internal class Day9
    {
        private static void part2(List<string> lines)
        {
            var files = new SortedSet<(long index, int size, long id)>();
            var stack = new Stack<(long index, int size, long id)>();
            var emptySpaces = new SortedSet<long>[10]; // list all indexes of empty spaces of size i
            for (int i = 0; i < 10; i++)
                emptySpaces[i] = new SortedSet<long>();

            long id = 0, block = 1, index = 0;
            foreach (var c in lines[0])
            {
                int val = c - '0';

                if (block == 0) // empty
                {
                    emptySpaces[val].Add(index);
                }
                else
                {
                    files.Add((index, val, id));
                    stack.Push((index, val, id));
                    id++;
                }
                index += val;
                block = 1 - block;
            }
            foreach (var pack in stack)
            {
                var possible = new SortedSet<(long index, int size)>();
                for (int i = pack.size; i < 10; i++)
                {
                    if (emptySpaces[i].Any() && emptySpaces[i].First() < pack.index) // we have something really on the right where we can fit
                    {
                        possible.Add((emptySpaces[i].First(), i));
                    }
                }
                if (possible.Count == 0) // pas d'endroit où se poser, on saute
                    continue;

                var first = possible.First();

                emptySpaces[first.size].Remove(first.index); // not available in i anymore
                files.Remove(pack);
                files.Add((first.index, pack.size, pack.id)); // move the pack to first index available
                int remaining = first.size - pack.size;
                if (remaining > 0) // we have some extraspaces of size remaining after first + pack.size
                {
                    emptySpaces[remaining].Add(first.index + pack.size);
                }
            }

            long res = 0;
            foreach (var pack in files)
            {
                for (int i = 0; i < pack.size; i++)
                {
                    res += pack.id * (pack.index + i);
                }
            }
            Console.WriteLine(res);
        }

        private static void part1(List<string> lines)
        {
            string input = lines[0];
            long res = 0;
            long index = 0;
            long id = 0;
            int block = 1;
            var list = new LinkedList<long[]>();
            foreach (var c in input)
            {
                list.AddLast(new[] { c - '0', block, block > 0 ? id++ : -1 });
                block = 1 - block;
            }
            var elem = list.First;
            while (elem != null)
            {
                long val = elem.Value[0];
                long identity = elem.Value[2];
                if (elem.Value[1] == 1) // an element so we add id from index to index + first element
                {
                    for (int j = 0; j < val; j++)
                    {
                        res += identity * index++;
                    }
                }
                else
                {
                    while (val > 0)
                    {
                        var last = list.Last;
                        if (last.Value[1] == 0)
                        {
                            list.RemoveLast();
                            continue;
                        }
                        if (last.Value[0] == 0)
                        {
                            list.RemoveLast();
                            continue;
                        }
                        res += last.Value[2] * index++;
                        last.Value[0]--;
                        val--;
                    }
                }
                elem = elem.Next;
            }
            Console.WriteLine(res);
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
