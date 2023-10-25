using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2018
{
    public class Day9
    {

        public static void Main()
        {
            var input = @"458 players; last marble is worth 71307 points";
            var players = 458;
            var marbles = 71307;
            long[] scores = GetScores(players, marbles + 1);
            Console.WriteLine(scores.Max());
            Console.WriteLine(GetScores(players, 100 * marbles + 1).Max());
        }

        private static long[] GetScores(int players, int marbles)
        {
            var scores = new long[players];
            var marb = new List<int>() { 0, 2, 1, 3 };
            var next = new List<int>();
            var temp = new Stack<int>();
            int j = 0;
            for (int i = 4; i < marbles; i++)
            {
                if (i % 23 != 0)
                {
                    if (temp.Count > 0)
                    {
                        next.Add(temp.Pop());
                        next.Add(i);
                    }
                    else
                    {
                        next.Add(marb[j++]);
                        next.Add(i);
                        if (marb.Count == j)
                        {
                            marb = next;
                            next = new List<int>();
                            j = 0;
                        }
                    }
                    continue;
                }
                scores[i % players] += i;
                for (int k = 0; k < 7; k++)
                {
                    if (next.Count > 0)
                    {
                        temp.Push(next[^1]);
                        next.RemoveAt(next.Count - 1);
                    }
                    else
                    {
                        temp.Push(marb[^1]);
                        marb.RemoveAt(marb.Count - 1);
                    }
                }
                if (next.Count > 0)
                {
                    scores[i % players] += next[^1];
                    next.RemoveAt(next.Count - 1);
                }
                else
                {
                    scores[i % players] += marb[^1];
                    marb.RemoveAt(marb.Count - 1);
                }
                next.Add(temp.Pop());
            }

            return scores;
        }
    }

}
