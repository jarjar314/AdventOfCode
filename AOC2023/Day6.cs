using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AOC2023
{
    public class Day6
    {

        public static void Main()
        {
            var input = @"Time:        48     93     85     95
Distance:   296   1928   1236   1391";
            var sample = @"Time:      7  15   30
Distance:  9  40  200";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }



        private static void part2(string input)
        {
            var inputs = input.Replace(" ", "").Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var times = inputs[0].Split(':', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            var records = inputs[1].Split(':', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
            long ways = 1;
            for (int i = 0; i < times.Length; i++)
            {
                ways *= Way(times[i], records[i]);
            }
            Console.WriteLine("Let's the fun begin");
            Console.WriteLine($"réponse à 1 est {ways}");

            long Way(long t, long r)
            {
                long res = 0;
                for (long i = 1; i < t; i++)
                {
                    if (i * (t - i) > r)
                        res++;
                }
                return res;
            }

        }
        private static void part1(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var times = inputs[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            var records = inputs[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            long ways = 1;
            for (int i = 0; i < times.Length; i++)
            {
                ways *= Way(times[i], records[i]);
            }
            Console.WriteLine("Let's the fun begin");
            Console.WriteLine($"réponse à 1 est {ways}");

            int Way(int t, int r)
            {
                int res = 0;
                for (int i = 1; i < t; i++)
                {
                    if (i * (t - i) > r)
                        res++;
                }
                return res;
            }

        }
    }
}
