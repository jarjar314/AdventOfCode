using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;


namespace AOC2018
{
    public class Day25
    {

        public static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new HashSet<(int x, int y, int z, int t)>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var l = sr.ReadLine()!.Split(',').Select(int.Parse).ToArray();
                    lines.Add((l[0], l[1], l[2], l[3]));
                }
            }
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }
        private static int Abs(int a) => Math.Abs(a);
        private static void part1(HashSet<(int x, int y, int z, int t)> lines)
        {
            int count = 0;
            while (lines.Count > 0)
            {
                count++;
                var f = lines.First();
                lines.Remove(f);
                var q = new Queue<(int x, int y, int z, int t)>();
                q.Enqueue(f);
                while (q.Count > 0)
                {
                    var p = q.Dequeue();
                    for (int dx = -3; dx <= 3; dx++)
                    {
                        for (int dy = -3; dy <= 3; dy++)
                        {
                            if (Abs(dx) + Abs(dy) > 3) continue;
                            for (int dz = -3; dz <= 3; dz++)
                            {
                                if (Abs(dx) + Abs(dy) + Abs(dz) > 3) continue;
                                for (int dt = -3; dt <= 3; dt++)
                                {
                                    if (Abs(dx) + Abs(dy) + Abs(dz) + Abs(dt) > 3) continue;
                                    var target = (p.x + dx, p.y + dy, p.z + dz, p.t + dt);
                                    if (lines.Remove(target))
                                    {
                                        q.Enqueue(target);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
