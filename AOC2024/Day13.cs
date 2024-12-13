using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace AOC2024
{
    internal class Day13
    {
        /*
         * Button A: X+40, Y+81
Button B: X+51, Y+15
Prize: X=12271, Y=14153


         * 
         * 
         */


        private static long ComputeToken(int xa, int ya, int xb, int yb, int xx, int yx)
        {
            int token = int.MaxValue;
            for (int a = 0; a <= 100; a++)
            {
                int remx = xx - a * xa, remy = yx - a * ya;
                if (remx % xb != 0 || remy % yb != 0) continue;
                if (remx / xb != remy / yb) continue;
                token = Math.Min(token, 3 * a + remx / xb);
            }
            int num = xb * yx - yb * xx;
            int den = xb * ya - yb * xa;
            int ta = num / den;
            int tb = (xx - ta * xa) / xb;
            return num % den == 0 ? 3 * ta + tb : 0;
        }
        static void part1(List<string> input)
        {
            int n = input.Count;
            long total = 0;
            for (int i = 0; i < n; i += 4)
            {
                var aa = input[i].Split(new char[] { '+', ',' });
                int xa = int.Parse(aa[1]), ya = int.Parse(aa[3]);
                var bb = input[i+1].Split(new char[] { '+', ',' });
                int xb = int.Parse(bb[1]), yb = int.Parse(bb[3]);
                var x = input[i+2].Split(new char[] { '=', ',' });
                int xx = int.Parse(x[1]), yx = int.Parse(x[3]);
                total += ComputeToken(xa, ya, xb, yb, xx, yx);
            }
            Console.WriteLine(total);
        }

        static long ComputeToken2(long xa, long ya, long xb, long yb, long xx, long yx)
        {
            long num = xb * yx - yb * xx;
            long den = xb * ya - yb * xa;
            if (num % den != 0) return 0;
            long ta = num / den;
            if ((xx - ta * xa) % xb != 0) return 0;
            long tb = (xx - ta * xa) / xb;
            return 3 * ta + tb;
        }
        static void part2(List<string> input)
        {
            int n = input.Count;
            long total = 0;
            for (int i = 0; i < n; i += 4)
            {
                var aa = input[i].Split(new char[] { '+', ',' });
                long xa = long.Parse(aa[1]), ya = long.Parse(aa[3]);
                var bb = input[i + 1].Split(new char[] { '+', ',' });
                long xb = long.Parse(bb[1]), yb = long.Parse(bb[3]);
                var x = input[i + 2].Split(new char[] { '=', ',' });
                long xx = 10_000_000_000_000 + long.Parse(x[1]), yx = 10_000_000_000_000 + long.Parse(x[3]);
                total += ComputeToken2(xa, ya, xb, yb, xx, yx);
            }
            Console.WriteLine(total);
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
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }
    }
}
