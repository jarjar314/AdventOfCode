using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019
{
    public class Day7
    {
        private static string program = @"3,8,1001,8,10,8,105,1,0,0,21,42,67,88,101,114,195,276,357,438,99999,3,9,101,3,9,9,1002,9,4,9,1001,9,5,9,102,4,9,9,4,9,99,3,9,1001,9,3,9,1002,9,2,9,101,2,9,9,102,2,9,9,1001,9,5,9,4,9,99,3,9,102,4,9,9,1001,9,3,9,102,4,9,9,101,4,9,9,4,9,99,3,9,101,2,9,9,1002,9,3,9,4,9,99,3,9,101,4,9,9,1002,9,5,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,99";
        private static void Main()
        {
            long maxi = 0;
            var possible = new int[] { 0, 1, 2, 3, 4 };
            while (true)
            {
                Console.WriteLine(string.Join(",", possible));
                maxi = Math.Max(maxi, Process(possible));

                if (NextPermutation(possible))
                    break;
            }
            Console.WriteLine($"maxi signal will be {maxi}");

            maxi = 0;
            possible = new[] { 5, 6, 7, 8, 9 };
            while (true)
            {
                maxi = Math.Max(maxi, ProcessLoop(possible));
                if (NextPermutation(possible))
                    break;
            }
            Console.WriteLine($"Maxi signal with loop will be {maxi}");
        }

        private static long ProcessLoop(int[] possible)
        {
            var l = new List<Intcode>();
            long input = 0;
            long output = 0;
            for (int i = 0; i < possible.Length; i++)
            {
                l.Add(new Intcode(program) { phase = possible[i], input = input }
                            .NeedPhaseSetting());
                l[i].Run();
                input = output = l[i].output;
                
            }
            int current = 0;
            while (true)
            {
                l[current].input = input;
                var res = l[current].Run();
                input = output = l[current].output;
                if (current == possible.Length - 1 && res.done)
                {
                    return res.output;
                }
                current = (current + 1) % possible.Length;
            }
        }
        private static long Process(int[] possible)
        {
            var l = new List<Intcode>();
            long input = 0;
            long output = 0;
            for (int i = 0; i < possible.Length; i++)
            {
                l.Add(new Intcode(program) { phase = possible[i], input = input }
                            .NeedPhaseSetting());
                l[i].Run();
                input = output = l[i].output;
            }

            return output;
        }

        public static bool NextPermutation(int[] nums)
        {
            var count = nums.Length;
            var done = true;
            for (var i = count - 1; i > 0; i--)
            {
                var curr = nums[i];
                if (curr <= nums[i - 1])
                    continue;
                done = false;
                var prev = nums[i - 1];
                var currIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    var tmp = nums[j];
                    if (tmp <= curr && tmp > prev)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }
                nums[currIndex] = prev;
                nums[i - 1] = curr;
                // Reverse the end
                for (int j = count - 1; j > i; j--, i++)
                {
                    var tmp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tmp;
                }
                break;
            }

            if (done) // higher order, just swap to get the smaller one.
            {
                int i = count - 1, j = 0;
                for (; j < i; j++, i--)
                {
                    var tmp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tmp;
                }
            }
            return done;
        }


    }
}
