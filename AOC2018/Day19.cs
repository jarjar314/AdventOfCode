using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day19
    {
        private static int ReadInt(Match match, string key)
        {
            return int.Parse(match.Groups[key].Value);
        }

        public static void Main()
        {
            var input = @"#ip 1
addi 1 16 1
seti 1 5 5
seti 1 2 3
mulr 5 3 2
eqrr 2 4 2
addr 2 1 1
addi 1 1 1
addr 5 0 0
addi 3 1 3
gtrr 3 4 2
addr 1 2 1
seti 2 6 1
addi 5 1 5
gtrr 5 4 2
addr 2 1 1
seti 1 8 1
mulr 1 1 1
addi 4 2 4
mulr 4 4 4
mulr 1 4 4
muli 4 11 4
addi 2 5 2
mulr 2 1 2
addi 2 12 2
addr 4 2 4
addr 1 0 1
seti 0 4 1
setr 1 4 2
mulr 2 1 2
addr 1 2 2
mulr 1 2 2
muli 2 14 2
mulr 2 1 2
addr 4 2 4
seti 0 3 0
seti 0 7 1";
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var instructionPointer = int.Parse(inputs[0].Split()[1]);
            var processor = new Processor2018(6) { InstructionPointer = instructionPointer };



        }

    }
    public class Processor2018
    {
        public int InstructionPointer { get; set; }
        readonly int[] registers;
        public int[] Registers { get { return registers; } }
        public Processor2018(int size)
        {
            registers = new int[size];
        }
        public void addr(int A, int B, int C)
        {
            registers[C] = registers[A] + registers[B];
        }
        public void addi(int A, int B, int C)
        {
            registers[C] = registers[A] + B;
        }
        public void mulr(int A, int B, int C)
        {
            registers[C] = registers[A] * registers[B];
        }
        public void muli(int A, int B, int C)
        {
            registers[C] = registers[A] * B;
        }
        public void banr(int A, int B, int C)
        {
            registers[C] = registers[A] & registers[B];
        }
        public void bani(int A, int B, int C)
        {
            registers[C] = registers[A] & B;
        }
        public void borr(int A, int B, int C)
        {
            registers[C] = registers[A] | registers[B];
        }
        public void bori(int A, int B, int C)
        {
            registers[C] = registers[A] | B;
        }
        public void setr(int A, int B, int C)
        {
            registers[C] = registers[A];
        }
        public void seti(int A, int B, int C)
        {
            registers[C] = A;
        }
        public void gtir(int A, int B, int C)
        {
            registers[C] = A > registers[B] ? 1 : 0;
        }
        public void gtri(int A, int B, int C)
        {
            registers[C] = registers[A] > B ? 1 : 0;
        }
        public void gtrr(int A, int B, int C)
        {
            registers[C] = registers[A] > registers[B] ? 1 : 0;
        }
        public void eqir(int A, int B, int C)
        {
            registers[C] = A == registers[B] ? 1 : 0;
        }
        public void eqri(int A, int B, int C)
        {
            registers[C] = registers[A] == B ? 1 : 0;
        }
        public void eqrr(int A, int B, int C)
        {
            registers[C] = registers[A] == registers[B] ? 1 : 0;
        }

    }
}
