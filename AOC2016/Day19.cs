using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day19
    {
        public static void Main()
        {
            int elves = 3005290;
            //elves = 5;
            int elf = StealNextElf(elves);
            Console.WriteLine(elf);
            Console.WriteLine(StealOppositeElf(elves));
        }

        private static int StealOppositeElf(int elves)
        {
            var stealer = new Queue<int>();
            var stealee = new Queue<int>();
            for (int i = 1; i <= elves / 2; i++)
            {
                stealer.Enqueue(i);
            }
            for (int i = elves / 2 + 1; i <= elves; i++)
            {
                stealee.Enqueue(i);
            }
            int count = elves;
            while (count > 1)
            {
                stealee.Enqueue(stealer.Dequeue()); // put the stealer at the end
                stealee.Dequeue(); // remove the first that were opposite of stealer
                if (stealee.Count == stealer.Count + 2) // equilibrate
                {
                    stealer.Enqueue(stealee.Dequeue());
                }
                count--;
            }
            return stealee.Dequeue();
        }

        private static int StealNextElf(int elves)
        {
            var q = new Queue<int>();
            for (int i = 1; i < elves + 1; i++)
            {
                q.Enqueue(i);
            }
            while (q.Count > 1)
            {
                q.Enqueue(q.Dequeue());
                q.Dequeue();
            }
            var elf = q.Dequeue();
            return elf;
        }
    }

}
