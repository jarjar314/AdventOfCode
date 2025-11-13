using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day12
    {
        public static void Main()
        {
            var input = @"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 17 c
cpy 18 d
inc a
dec d
jnz d -2
dec c
jnz c -5";
            var monorail = new Monorail(input);
            monorail.Execute();
            Console.WriteLine(monorail.A);
            monorail.Reset();
            monorail.C = 1;
            monorail.Execute();
            Console.WriteLine(monorail.A);

        }
    }

    class Monorail
    {
        private int a = 0;
        private int b = 0;
        private int c = 0;
        private int d = 0;
        public List<string> Commands { get; set; }
        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }
        public int D { get => d; set => d = value; }
        private int instruction;
        public Monorail(string commands)
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
                }
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
        }
    }
}
