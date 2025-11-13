using System;
using System.Collections.Generic;
using System.Diagnostics;
using AOC2016;
namespace AdventQuick
{
    class Program
    {
        public static void Main()
        {
            AOC2016.Day25.Main();
            var diag = Stopwatch.StartNew();
            var dico = new Dictionary<int, int>();
            for (int i = 0; ; i++)
            {
                int k = i.ToString().GetHashCode();
                if (dico.ContainsKey(k))
                {
                    Console.WriteLine($"{k} is hashcode of {dico[k]} {i}");
                    break;
                }
                else
                    dico[k] = i;
            }
            diag.Stop();
            Console.WriteLine(diag.ElapsedMilliseconds);
            var line = Console.ReadLine();
            line = Console.ReadLine();
            var q1 = new Queue<int>();
            int c1 = 0, c2 = 0;
            while (!string.IsNullOrWhiteSpace(line))
            {
                q1.Enqueue(int.Parse(line));
                c1++;
                line = Console.ReadLine();
            }
            var q2 = new Queue<int>();
            line = Console.ReadLine();
            line = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(line))
            {
                c2++;
                q2.Enqueue(int.Parse(line));
                line = Console.ReadLine();
            }
            while (c1 > 0 && c2 > 0)
            {
                var card1 = q1.Dequeue();
                var card2 = q2.Dequeue();
                if (card1 > card2)
                {
                    q1.Enqueue(card1);
                    q1.Enqueue(card2);
                    c1++;
                    c2--;
                }
                else
                {
                    q2.Enqueue(card2);
                    q2.Enqueue(card1);
                    c2++;
                    c1--;

                }
            }
            long score = 0;
            while (c1 > 0)
            {
                score += q1.Dequeue() * c1--;
            }
            while (c2 > 0)
            {
                score += q2.Dequeue() * c2--;
            }
            Console.WriteLine(score);

        }
    }
}
