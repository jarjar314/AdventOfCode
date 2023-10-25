using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace AOC2022
{
    public class Day10
    {

        public static void Main()
        {
            #region change input

            /*  input = @"addx 15
  addx -11
  addx 6
  addx -3
  addx 5
  addx -1
  addx -8
  addx 13
  addx 4
  noop
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx -35
  addx 1
  addx 24
  addx -19
  addx 1
  addx 16
  addx -11
  noop
  noop
  addx 21
  addx -15
  noop
  noop
  addx -3
  addx 9
  addx 1
  addx -3
  addx 8
  addx 1
  addx 5
  noop
  noop
  noop
  noop
  noop
  addx -36
  noop
  addx 1
  addx 7
  noop
  noop
  noop
  addx 2
  addx 6
  noop
  noop
  noop
  noop
  noop
  addx 1
  noop
  noop
  addx 7
  addx 1
  noop
  addx -13
  addx 13
  addx 7
  noop
  addx 1
  addx -33
  noop
  noop
  noop
  addx 2
  noop
  noop
  noop
  addx 8
  noop
  addx -1
  addx 2
  addx 1
  noop
  addx 17
  addx -9
  addx 1
  addx 1
  addx -3
  addx 11
  noop
  noop
  addx 1
  noop
  addx 1
  noop
  noop
  addx -13
  addx -19
  addx 1
  addx 3
  addx 26
  addx -30
  addx 12
  addx -1
  addx 3
  addx 1
  noop
  noop
  noop
  addx -9
  addx 18
  addx 1
  addx 2
  noop
  noop
  addx 9
  noop
  noop
  noop
  addx -1
  addx 2
  addx -37
  addx 1
  addx 3
  noop
  addx 15
  addx -21
  addx 22
  addx -6
  addx 1
  noop
  addx 2
  addx 1
  noop
  addx -10
  noop
  noop
  addx 20
  addx 1
  addx 2
  addx 2
  addx -6
  addx -11
  noop
  noop
  noop";/* */
            #endregion

            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = inputs.Length;
            int cycle = 0;
            int x = 1;
            var l = new List<int>();
            for (int i = 0; i < n; i++)
            {
                l.Add(x);
                if (inputs[i] == "noop")
                {
                    continue;
                }
                l.Add(x);
                var line = inputs[i].Split();
                int V = int.Parse(line[1]);
                x += V;
            }
            l.Add(x); // last cycle
            int sum = 0;
            foreach (var i in new[] { 20, 60, 100, 140, 180, 220 })
            {
                sum += i * l[i - 1];
                Console.WriteLine(i * l[i - 1]);
            }
            Console.WriteLine($"sum is {sum}");

            var sb = new StringBuilder(40);
            for (int i = 0; i < l.Count; i++)
            {
                int crt = i % 40;
                if (Math.Abs(l[i] - crt) < 2)
                    sb.Append('#');
                else
                    sb.Append('.');
                if ((i + 1) % 40 == 0)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }
            Console.WriteLine(sb.ToString());

        }

        static string input = @"addx 1
addx 4
addx 1
noop
addx 4
addx 3
addx -2
addx 5
addx -1
noop
addx 3
noop
addx 7
addx -1
addx 1
noop
addx 6
addx -1
addx 5
noop
noop
noop
addx -37
addx 7
noop
noop
noop
addx 5
noop
noop
noop
addx 9
addx -8
addx 2
addx 5
addx 2
addx 5
noop
noop
addx -2
noop
addx 3
addx 2
noop
addx 3
addx 2
noop
addx 3
addx -36
noop
addx 26
addx -21
noop
noop
noop
addx 3
addx 5
addx 2
addx -4
noop
addx 9
addx 5
noop
noop
noop
addx -6
addx 7
addx 2
noop
addx 3
addx 2
addx 5
addx -39
addx 34
addx 5
addx -35
noop
addx 26
addx -21
addx 5
addx 2
addx 2
noop
addx 3
addx 12
addx -7
noop
noop
noop
noop
noop
addx 5
addx 2
addx 3
noop
noop
noop
noop
addx -37
addx 21
addx -14
addx 16
addx -11
noop
addx -2
addx 3
addx 2
addx 5
addx 2
addx -15
addx 6
addx 12
addx -2
addx 9
addx -6
addx 7
addx 2
noop
noop
noop
addx -33
addx 1
noop
addx 2
addx 13
addx 15
addx -21
addx 21
addx -15
noop
noop
addx 4
addx 1
noop
addx 4
addx 8
addx 6
addx -11
addx 5
addx 2
addx -35
addx -1
noop
noop";

    }

    class Cpu : IEnumerable<(int cycle, int x)>
    {
        public int X;
        public int cycles;
        public string[] execution;
        int currentInstruction;


        public Cpu(string[] exec)
        {
            Reset();
            execution = exec;
        }
        public void Reset()
        {
            X = 1;
            cycles = 0;
            currentInstruction = 0;
        }

        public IEnumerator<(int cycle, int x)> GetEnumerator()
        {
            yield return (cycles, X);
            if (currentInstruction != execution.Length)
            {
                var line = execution[currentInstruction++];
                if (line == "noop")
                {

                }


            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
