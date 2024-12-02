using System.Reflection;

namespace AOC2024
{
    internal class Day1
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            using (var sr= new StreamReader($"Resources/{className}.txt"))
            {
                var l1 = new List<int>();
                var l2 = new List<int>();
                while (!sr.EndOfStream)
                {
                    var pair = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    l1.Add(int.Parse(pair[0]));
                    l2.Add(int.Parse(pair[1]));
                }
                l1.Sort();
                l2.Sort();
                long res = 0;
                for (int i = 0; i < l1.Count; i++)
                {
                    res += Math.Abs(l1[i] - l2[i]);
                }
                Console.WriteLine(res);
                var group = l2.GroupBy(c => c).ToDictionary(gr => gr.Key, gr => gr.Count());
                long sum = 0;
                for(int i = 0; i < l1.Count; i++)
                {
                    group.TryGetValue(l1[i], out var c);
                    sum += l1[i] * c;
                }
                Console.WriteLine(sum);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
