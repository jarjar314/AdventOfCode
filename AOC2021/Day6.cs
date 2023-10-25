using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2021
{
    public class Day6
    {

        public static void Main()
        {
            var input = @"2,1,2,1,5,1,5,1,2,2,1,1,5,1,4,4,4,3,1,2,2,3,4,1,1,5,1,1,4,2,5,5,5,1,1,4,5,4,1,1,4,2,1,4,1,2,2,5,1,1,5,1,1,3,4,4,1,2,3,1,5,5,4,1,4,1,2,1,5,1,1,1,3,4,1,1,5,1,5,1,1,5,1,1,4,3,2,4,1,4,1,5,3,3,1,5,1,3,1,1,4,1,4,5,2,3,1,1,1,1,3,1,2,1,5,1,1,5,1,1,1,1,4,1,4,3,1,5,1,1,5,4,4,2,1,4,5,1,1,3,3,1,1,4,2,5,5,2,4,1,4,5,4,5,3,1,4,1,5,2,4,5,3,1,3,2,4,5,4,4,1,5,1,5,1,2,2,1,4,1,1,4,2,2,2,4,1,1,5,3,1,1,5,4,4,1,5,1,3,1,3,2,2,1,1,4,1,4,1,2,2,1,1,3,5,1,2,1,3,1,4,5,1,3,4,1,1,1,1,4,3,3,4,5,1,1,1,1,1,2,4,5,3,4,2,1,1,1,3,3,1,4,1,1,4,2,1,5,1,1,2,3,4,2,5,1,1,1,5,1,1,4,1,2,4,1,1,2,4,3,4,2,3,1,1,2,1,5,4,2,3,5,1,2,3,1,2,2,1,4";
            input = "3,4,3,1,2";
            var lanterns = input.Split(',').Select(int.Parse).GroupBy(c => c).ToDictionary(gr => gr.Key, gr => (long)gr.Count());
            int days = 80;
            for (int i = 0; i < days; i++)
            {
                var next = new Dictionary<int, long>();
                for (int j = 0; j < 9; j++)
                {
                    next[j] = 0;
                }
                foreach (var kvp in lanterns)
                {
                    if (kvp.Key == 0)
                    {
                        next[6] += kvp.Value;
                        next[8] += kvp.Value;
                    }
                    else
                        next[kvp.Key - 1] += kvp.Value;
                }
                lanterns = next;
            }
            Console.WriteLine(lanterns.Values.Sum());
            for (int i = 80; i < 256; i++)
            {
                var next = new Dictionary<int, long>();
                for (int j = 0; j < 9; j++)
                {
                    next[j] = 0;
                }
                foreach (var kvp in lanterns)
                {
                    if (kvp.Key == 0)
                    {
                        next[6] += kvp.Value;
                        next[8] += kvp.Value;
                    }
                    else
                        next[kvp.Key - 1] += kvp.Value;
                }
                lanterns = next;

            }
            Console.WriteLine(lanterns.Values.Sum());
        }
    }
}
