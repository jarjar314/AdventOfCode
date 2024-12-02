using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace AOC2024
{
    internal class Day2
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                var l1 = new List<List<int>>();
                while (!sr.EndOfStream)
                {
                    l1.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
                }
                Console.WriteLine(l1.Count(c => increasing(c) || decreasing(c)));
                Console.WriteLine(l1.Count(c => increasing(c) || decreasing(c) || dampen(c)));

            }

            bool increasing(List<int> l)
            {
                int last = int.MinValue;
                foreach (var n in l)
                {
                    if (n <= last) return false;
                    if (last != int.MinValue && n - last > 3) return false;
                    last = n;
                }
                return true;
            }
            bool decreasing(List<int> l)
            {
                int last = int.MaxValue;
                foreach (var n in l)
                {
                    if (n >= last) return false;
                    if (last != int.MaxValue && last - n > 3) return false;
                    last = n;
                }
                return true;
            }

            bool dampen(List<int> l)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    var l2 = new List<int>();
                    for (int j = 0; j < l.Count; j++)
                    {
                        if (j == i) continue;
                        l2.Add(l[j]);
                    }
                    if (increasing(l2)) return true;
                    if (decreasing(l2)) return true;
                }
                return false;
            }
        }
    }
}
