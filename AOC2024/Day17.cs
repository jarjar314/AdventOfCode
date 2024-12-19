using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

namespace AOC2024
{
    internal class Day17
    {
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

        static long A, B, C;
        static int instruction;
        static List<int> outs = new List<int>();
        static long read(int operand)
        {
            if (operand < 4) return operand;
            if (operand == 4) return A;
            if (operand == 5) return B;
            if (operand == 6) return C;
            throw new NotImplementedException();
        }
        static void adv(int operand){A = A >> (int)read(operand);}
        static void bdv(int operand) { B = A >> (int)read(operand); }
        static void cdv(int operand) { C = A >> (int)read(operand); }
        static void print(int operand) { outs.Add((int)(read(operand)%8)); }
        static void bxc(int operand) { B ^= C; }
        static void bst(int operand) { B = read(operand)%8 ; }
        static void bxl(int operand) { B ^= operand; }
        static void jnz(int operand)
        {
            if (A == 0) return;
            instruction = (operand-2);
        }
        static List<int> program = new List<int>();
        private static void execute()
        {
            instruction = 0;
            while (true)
            {
                switch (program[instruction])
                {
                    case 0: adv(program[instruction + 1]); break;
                    case 1: bxl(program[instruction + 1]); break;
                    case 2: bst(program[instruction + 1]); break;
                    case 3: jnz(program[instruction + 1]); break;
                    case 4: bxc(program[instruction + 1]); break;
                    case 5: print(program[instruction + 1]); break;
                    case 6: bdv(program[instruction + 1]); break;
                    case 7: cdv(program[instruction + 1]); break;
                }
                instruction += 2;
                if (instruction >= program.Count)
                    break;
            }
        }
        private static void part1(List<string> lines)
        {
            outs.Clear();
            A = long.Parse(lines[0].Split()[2]);
            B = long.Parse(lines[1].Split()[2]);
            C = long.Parse(lines[2].Split()[2]);
            program = lines[4].Split()[1].Split(',').Select(int.Parse).ToList();
            execute();
            Console.WriteLine(string.Join(",", outs));
        }
        private static long min = long.MaxValue;
        private static long[] powers = new long[16];
        private static void dfs(int[] starts, int index)
        {
            if (index == -1) return;
            for (int i = 0; i < 8; i++)
            {
                starts[index] = i;
                long start = 0;
                for (int j = 0; j < 16; j++) start += starts[j] * powers[j];
                A = start;
                B = 0;
                C = 0;
                outs.Clear();
                execute();
                if (program.SequenceEqual(outs))
                {
                    min = Math.Min(start, min);
                    Console.WriteLine($"STT {start} : {string.Join(",", starts)}");
                    Console.WriteLine($"OUT {start} : {string.Join(",", outs)}");
                    Console.WriteLine($"PGM {start} : {string.Join(",", program)}");
                    return;
                }
                bool ok = true;
                if (outs.Count != program.Count) continue;
                for (int ind = 15; ind >= index; ind--)
                {
                    if (outs[ind] != program[ind])
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                dfs(starts, index - 1);

            }
        }
        private static void part2(List<string> lines)
        {
            powers[0] = 1;
            for (int i = 1; i < 16; i++)
            {
                powers[i] = 8 * powers[i - 1];
            }
            B = long.Parse(lines[1].Split()[2]);
            C = long.Parse(lines[2].Split()[2]);
            program = lines[4].Split()[1].Split(',').Select(int.Parse).ToList();
            var starts = new int[16];
            dfs(starts, 15);

            Console.WriteLine($"part2:{min}");
        }


        private static long Power(long a, long p)
        {
            if (a == 0 && p == 0) { return 1; }
            if (p == 0) return 1;
            if (a == 0) return 0;
            long res = 1;
            long pow = a;
            while (p  > 0) {
                if ((p & 1) == 1)
                    res *= pow;
                pow *= pow;
                p >>= 1;
            }
            return res;
        }
    }
}
