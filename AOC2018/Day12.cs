using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day12
    {
        // Size of given matrix

        public static void Main()
        {
            var input = @"initial state: ###......#.#........##.###.####......#..#####.####..#.###..#.###.#..#..#.#..#..#.##...#..##......#.#

..#.# => .
#..## => #
..### => .
###.# => .
#...# => #
###.. => #
.##.# => #
#..#. => #
#.##. => #
####. => .
.#.## => #
...#. => .
.#..# => #
.###. => .
##..# => #
.##.. => #
.#### => #
.#.#. => #
##### => .
#.#.# => #
...## => #
..##. => .
....# => .
##... => .
##.#. => #
..#.. => #
..... => .
##.## => .
#.### => .
#.#.. => .
.#... => #
#.... => .";
            var inputs = input.Split('\n').ToArray();
            var head = Initialize(inputs[0]);
            var maps = new Dictionary<string, char>();
            for (int i = 2; i < inputs.Length; i++)
            {
                var tokens = inputs[i].Split(" => ").ToArray();
                maps[tokens[0]] = tokens[1][0];

            }
            var generationsList = new Dictionary<int, LinkedList<(char, int)>>();
            var generations = new Dictionary<string, int>();
            int count = Compte(head);
            generationsList.Add(0, head);
            Console.WriteLine($"{0}:{string.Join("", head.Select(c => c.Item1))}");
            int j = 0;
            while (true)
            {
                j++;
                head = NextGeneration(head);
                TrimList(head);
                var generation = string.Join("", head.Select(c => c.Item1));
                if (generations.TryGetValue(generation, out var past))
                {
                    Console.WriteLine($"{j} = {past}");
                    Console.WriteLine($"{head.First().Item2} vs in history {generationsList[past].First().Item2}");
                    Console.WriteLine(head.Select(c => c.Item1 == '#' ? c.Item2 : 0).Sum());
                }
                generations[generation] = j;
                generationsList[j] = head;
                if (j == 20) Console.WriteLine(head.Select(c => c.Item1 == '#' ? c.Item2 : 0).Sum());

            }
            Console.WriteLine((50000000000 - 130) * 42 + 5888);
            // 5888 is the sum of pot for the 130th generation and each generation after 120 is invariant and just translating 42 pots from 1 to the right thus the formula above.
            Console.WriteLine(count);
            Console.WriteLine(head.Select(c => c.Item1 == '#' ? c.Item2 : 0).Sum());

            int Compte(LinkedList<(char, int)> list)
            {
                return list.Count(c => c.Item1 == '#');
            }

            LinkedList<(char, int)> NextGeneration(LinkedList<(char, int)> list)
            {
                var head = new LinkedList<(char, int)>();
                var s = "...." + string.Join("", list.Select(c => c.Item1)) + "....";
                int index = list.First().Item2 - 2;
                for (int i = 2; i < s.Length - 2; i++, index++)
                {
                    head.AddLast((maps[s.Substring(i - 2, 5)], index));
                }
                return head;
            }

            LinkedList<(char, int)> Initialize(string line)
            {
                var head = new LinkedList<(char, int)>();
                var r = line.Split().ToArray()[2];

                for (int i = 0; i < r.Length; i++)
                {
                    head.AddLast((r[i], i));
                }
                TrimList(head);

                return head;
            }
        }

        private static void TrimList(LinkedList<(char, int)> head)
        {
            while (head.First().Item1 == '.')
                head.RemoveFirst();
            while (head.Last().Item1 == '.')
                head.RemoveLast();
        }
    }

}
