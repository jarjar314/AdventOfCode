using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day13
    {
        static readonly int[] dx = new int[] { 1, 0, -1, 0, 1 };
        static readonly int input = 1358;
        public static void Main()
        {
            var q = new Queue<(int x, int y, int step)>();
            var visited = new Dictionary<(int x, int y), int>();
            q.Enqueue((1, 1, 0));
            visited.Add((1, 1), 0);
            bool notFound = true;
            while (q.Count > 0 && notFound)
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    var nx = p.x + dx[i];
                    var ny = p.y + dx[i + 1];
                    if (!IsOpenSpace(nx, ny)) continue;
                    if (visited.ContainsKey((nx, ny))) continue;
                    visited.Add((nx, ny), p.step + 1);
                    if (nx == 31 && ny == 39)
                    {
                        notFound = false;
                        break;
                    }
                    q.Enqueue((nx, ny, p.step + 1));
                }

            }
            Console.WriteLine(visited[(31, 39)]);
            Console.WriteLine(visited.Count(k => k.Value <= 50));
        }
        static bool IsOpenSpace(int x, int y)
        {
            if (x < 0 || y < 0) return false;
            return CountBit(x * x + 3 * x + 2 * x * y + y + y * y + input) % 2 == 0;
        }
        static int CountBit(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count++;
                n &= n - 1;
            }
            return count;
        }
    }

}
