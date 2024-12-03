using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day25
    {
        public static void Main()
        {
            var input = @"cpy a d
cpy 7 c
cpy 362 b
inc d
dec b
jnz b -2
dec c
jnz c -5
cpy d a
jnz 0 0
cpy a b
cpy 0 a
cpy 2 c
jnz b 2
jnz 1 6
dec b
dec c
jnz c -4
inc a
jnz 1 -7
cpy 2 b
jnz c 2
jnz 1 4
dec b
dec c
jnz 1 -4
jnz 0 0
out b
jnz a -19
jnz 1 -21";
            var monorail = new Monorail25(input);
            int a = 0;
            while (true)
            {
                monorail.Reset();
                monorail.A = a;
                monorail.Execute();
                Console.WriteLine($"{a} generates " + string.Join(",", monorail.Out));
                a++;
            }
            monorail.Execute();
            Console.WriteLine(monorail.A);
            monorail.Reset();
            monorail.C = 1;
            monorail.Execute();
            Console.WriteLine(monorail.A);

        }
    }

    class Monorail25
    {
        private int a = 0;
        private int b = 0;
        private int c = 0;
        private int d = 0;
        private List<int> _out = new List<int>();
        public List<string> Commands { get; set; }
        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }
        public int D { get => d; set => d = value; }
        public List<int> Out { get => _out; }
        private int instruction;
        public Monorail25(string commands)
        {
            Commands = commands.Split('\n').ToList();
            instruction = 0;
        }

        public void Execute()
        {
            while (instruction < Commands.Count)
            {
                var tokens = Commands[instruction].Split();
                switch (tokens[0])
                {
                    case "inc": Add(tokens[1], 1); instruction++; break;
                    case "dec": Add(tokens[1], -1); instruction++; break;
                    case "cpy": Copy(tokens[1], tokens[2]); instruction++; break;
                    case "jnz": instruction += read(tokens[1]) != 0 ? read(tokens[2]) : 1; break;
                    case "out":
                        _out.Add(read(tokens[1])); instruction++; break;
                }
                if (_out.Count > 1 && (_out[^1] ^ _out[^2]) != 1) return;
            }
        }

        private int read(string register)
        {
            if (int.TryParse(register, out var reading))
                return reading;
            return register switch
            {
                "a" => a,
                "b" => b,
                "c" => c,
                "d" => d,
                _ => int.MaxValue
            };
        }

        private void Copy(string from, string to)
        {
            int input = read(from);
            switch (to)
            {
                case "a": a = input; break;
                case "b": b = input; break;
                case "c": c = input; break;
                case "d": d = input; break;
            }
        }

        private void Add(string v1, int v2)
        {
            switch (v1)
            {
                case "a": a += v2; break;
                case "b": b += v2; break;
                case "c": c += v2; break;
                case "d": d += v2; break;
            }
        }

        internal void Reset()
        {
            A = 0;
            B = 0;
            C = 0;
            D = 0;
            instruction = 0;
            _out.Clear();
        }
    }
}
