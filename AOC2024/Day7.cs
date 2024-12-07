using System.Reflection;

namespace AOC2024
{
    internal class Day7
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<long[]>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine()!.Split([' ',':'], StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray());
                }
            }
            part1(lines);
            part2(lines);
        }
        private static bool canFixOperatorPipe(long[] l)
        {
            long target = l[0];
            var possible = new HashSet<long>() { l[1] };
            for (int i = 2; i < l.Length; i++)
            {
                var temp = new HashSet<long>();
                foreach (var p in possible)
                {
                    temp.Add(p + l[i]);
                    temp.Add(p * l[i]);
                    if (long.TryParse($"{p}{l[i]}", out var res))
                        temp.Add(res);
                }
                possible = temp;
            }
            return possible.Contains(target);
        }
        private static bool canFixOperator(long[] l)
        {
            long target = l[0];
            var possible = new HashSet<long>() { l[1] };
            for (int i = 2; i < l.Length; i++)
            {
                var temp = new HashSet<long>();
                foreach (var p in possible)
                {
                    temp.Add(p + l[i]);
                    temp.Add(p * l[i]);
                }
                possible = temp;
            }
            return possible.Contains(target);
        }
        private static void part2(List<long[]> lines)
        {
            Console.WriteLine(lines.Where(l => canFixOperatorPipe(l)).Sum(l => l[0]));
        }

        private static void part1(List<long[]> lines)
        {
            Console.WriteLine(lines.Where(l => canFixOperator(l)).Sum(l => l[0]));
        }


    }
}
