using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day23
    {

        public static void Main()
        {
            var input = @"cpy a b
dec b
cpy a d
cpy 0 a
cpy b c
inc a
dec c
jnz c -2
dec d
jnz d -5
dec b
cpy b c
cpy c d
dec d
inc c
jnz d -2
tgl c
cpy -16 c
jnz 1 c
cpy 86 c
jnz 77 d
inc a
inc d
jnz d -2
inc c
jnz c -5";
            var monorail = new Monorail2(input);
            monorail.A = 7;
            monorail.Execute();
            Console.WriteLine($"ending with a = {monorail.A}");
            monorail.Reset();
            monorail.A = 12;
            monorail.Execute();
            Console.WriteLine($"ending second run with a = {monorail.A}");

        }
    }

    public class Monorail2
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
        private string input;
        public Monorail2(string commands)
        {
            input = commands;
            Commands = input.Split('\n').ToList();
            instruction = 0;
        }

        public void Execute()
        {
            while (instruction < Commands.Count)
            {
                //Console.WriteLine(instruction + " " +Commands[instruction]);
                var tokens = Commands[instruction].Split();
                switch (tokens[0])
                {
                    case "inc": Add(tokens[1], 1); instruction++; break;
                    case "dec": Add(tokens[1], -1); instruction++; break;
                    case "cpy": Copy(tokens[1], tokens[2]); instruction++; break;
                    case "jnz": instruction += read(tokens[1]) != 0 ? read(tokens[2]) : 1; break;
                    case "tgl": Toggle(read(tokens[1])); instruction++; break;
                }
            }
        }

        private void Toggle(int x)
        {
            int target = instruction + x;
            if (target < 0 || target >= Commands.Count) return;

            var tokens = Commands[target].Split(new[] { ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens.Length)
            {
                case 2:
                    if (tokens[0] == "inc")
                        tokens[0] = "dec";
                    else tokens[0] = "inc";
                    break;
                case 3:
                    if (tokens[0] == "jnz")
                        tokens[0] = "cpy";
                    else tokens[0] = "jnz";
                    break;
            }
            Commands[target] = string.Join(" ", tokens);
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
            Commands = input.Split('\n').ToList();
        }
    }

}
