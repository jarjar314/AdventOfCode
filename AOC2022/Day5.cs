﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2022
{
    public class Day5
    {

        public static void Main()
        {
            var input = @"[P]     [L]         [T]            
[L]     [M] [G]     [G]     [S]    
[M]     [Q] [W]     [H] [R] [G]    
[N]     [F] [M]     [D] [V] [R] [N]
[W]     [G] [Q] [P] [J] [F] [M] [C]
[V] [H] [B] [F] [H] [M] [B] [H] [B]
[B] [Q] [D] [T] [T] [B] [N] [L] [D]
[H] [M] [N] [Z] [M] [C] [M] [P] [P]
 1   2   3   4   5   6   7   8   9 

move 8 from 3 to 2
move 1 from 9 to 5
move 5 from 4 to 7
move 6 from 1 to 4
move 8 from 6 to 8
move 8 from 4 to 5
move 4 from 9 to 5
move 4 from 7 to 9
move 7 from 7 to 2
move 4 from 5 to 2
move 11 from 8 to 3
move 3 from 9 to 7
move 11 from 2 to 8
move 13 from 8 to 4
move 11 from 5 to 6
move 8 from 2 to 4
move 1 from 5 to 4
move 1 from 3 to 2
move 2 from 2 to 1
move 2 from 8 to 5
move 3 from 7 to 5
move 1 from 4 to 7
move 9 from 6 to 7
move 1 from 6 to 5
move 1 from 1 to 4
move 3 from 1 to 9
move 15 from 4 to 3
move 2 from 4 to 1
move 1 from 1 to 9
move 3 from 4 to 5
move 1 from 4 to 1
move 1 from 7 to 2
move 1 from 6 to 3
move 5 from 7 to 1
move 19 from 3 to 9
move 7 from 1 to 2
move 24 from 9 to 7
move 23 from 7 to 1
move 1 from 4 to 6
move 3 from 7 to 3
move 1 from 6 to 1
move 6 from 2 to 1
move 21 from 1 to 9
move 5 from 3 to 8
move 2 from 2 to 5
move 10 from 9 to 5
move 1 from 2 to 1
move 5 from 1 to 3
move 6 from 3 to 4
move 1 from 2 to 8
move 3 from 5 to 2
move 4 from 9 to 3
move 13 from 5 to 9
move 2 from 7 to 2
move 3 from 4 to 7
move 1 from 7 to 8
move 5 from 1 to 3
move 1 from 7 to 5
move 1 from 8 to 1
move 2 from 2 to 7
move 19 from 9 to 2
move 5 from 2 to 3
move 7 from 5 to 9
move 1 from 1 to 9
move 5 from 9 to 2
move 4 from 9 to 3
move 20 from 3 to 9
move 1 from 3 to 9
move 3 from 7 to 3
move 16 from 2 to 3
move 12 from 3 to 4
move 2 from 2 to 5
move 1 from 2 to 4
move 2 from 4 to 1
move 4 from 8 to 1
move 15 from 9 to 3
move 2 from 5 to 3
move 3 from 2 to 8
move 5 from 8 to 5
move 7 from 3 to 4
move 2 from 9 to 6
move 15 from 3 to 1
move 3 from 1 to 8
move 3 from 9 to 5
move 9 from 4 to 1
move 3 from 3 to 5
move 2 from 6 to 5
move 9 from 1 to 3
move 1 from 9 to 4
move 1 from 5 to 2
move 3 from 8 to 5
move 10 from 1 to 6
move 12 from 4 to 8
move 1 from 2 to 7
move 2 from 5 to 6
move 1 from 1 to 4
move 7 from 3 to 6
move 1 from 7 to 2
move 2 from 4 to 9
move 3 from 1 to 7
move 1 from 9 to 8
move 1 from 2 to 3
move 3 from 1 to 7
move 5 from 8 to 2
move 5 from 7 to 1
move 9 from 6 to 8
move 6 from 6 to 9
move 8 from 8 to 6
move 1 from 7 to 4
move 5 from 2 to 4
move 7 from 5 to 1
move 5 from 8 to 9
move 11 from 6 to 7
move 9 from 9 to 1
move 2 from 7 to 5
move 1 from 9 to 5
move 1 from 3 to 6
move 3 from 4 to 6
move 1 from 8 to 2
move 2 from 3 to 6
move 6 from 5 to 2
move 3 from 5 to 9
move 3 from 2 to 1
move 1 from 4 to 3
move 3 from 2 to 7
move 1 from 8 to 9
move 1 from 2 to 8
move 8 from 7 to 5
move 1 from 7 to 8
move 3 from 5 to 6
move 5 from 5 to 2
move 1 from 4 to 1
move 1 from 3 to 2
move 4 from 1 to 5
move 4 from 2 to 6
move 6 from 1 to 2
move 5 from 9 to 3
move 2 from 5 to 3
move 3 from 3 to 6
move 10 from 6 to 4
move 4 from 8 to 5
move 5 from 5 to 1
move 21 from 1 to 7
move 3 from 2 to 9
move 1 from 5 to 2
move 4 from 2 to 9
move 8 from 4 to 8
move 1 from 2 to 1
move 7 from 8 to 2
move 2 from 6 to 1
move 2 from 1 to 5
move 1 from 1 to 5
move 4 from 3 to 7
move 1 from 9 to 3
move 4 from 6 to 3
move 1 from 3 to 8
move 1 from 3 to 4
move 2 from 2 to 6
move 2 from 9 to 7
move 14 from 7 to 8
move 10 from 8 to 7
move 3 from 4 to 6
move 5 from 2 to 3
move 3 from 9 to 8
move 3 from 3 to 4
move 1 from 2 to 4
move 1 from 9 to 4
move 1 from 9 to 5
move 1 from 5 to 2
move 3 from 5 to 7
move 1 from 4 to 6
move 5 from 3 to 8
move 1 from 6 to 8
move 5 from 7 to 6
move 14 from 8 to 5
move 2 from 6 to 7
move 18 from 7 to 2
move 3 from 6 to 1
move 5 from 5 to 4
move 5 from 6 to 2
move 7 from 2 to 1
move 1 from 8 to 4
move 1 from 5 to 1
move 8 from 1 to 9
move 10 from 4 to 3
move 8 from 5 to 3
move 1 from 4 to 3
move 2 from 1 to 5
move 1 from 5 to 3
move 5 from 3 to 1
move 1 from 1 to 3
move 5 from 1 to 6
move 13 from 3 to 1
move 3 from 9 to 4
move 2 from 9 to 6
move 5 from 6 to 5
move 6 from 5 to 1
move 7 from 7 to 9
move 7 from 9 to 6
move 1 from 9 to 3
move 1 from 7 to 9
move 3 from 9 to 1
move 12 from 2 to 7
move 7 from 6 to 2
move 22 from 1 to 7
move 1 from 6 to 5
move 4 from 7 to 6
move 1 from 5 to 6
move 2 from 4 to 1
move 1 from 4 to 1
move 23 from 7 to 9
move 4 from 6 to 2
move 4 from 7 to 3
move 1 from 1 to 9
move 6 from 2 to 1
move 1 from 7 to 2
move 7 from 2 to 8
move 2 from 3 to 8
move 3 from 1 to 9
move 1 from 2 to 8
move 5 from 8 to 3
move 3 from 2 to 1
move 2 from 7 to 8
move 10 from 9 to 8
move 4 from 1 to 3
move 14 from 3 to 4
move 7 from 4 to 5
move 1 from 6 to 9
move 5 from 5 to 8
move 1 from 6 to 4
move 6 from 9 to 4
move 3 from 8 to 4
move 1 from 5 to 1
move 3 from 4 to 3
move 9 from 4 to 3
move 5 from 3 to 6
move 5 from 1 to 5
move 4 from 6 to 2
move 8 from 9 to 2
move 2 from 6 to 5
move 3 from 4 to 7
move 2 from 2 to 7
move 2 from 5 to 4
move 3 from 5 to 9
move 3 from 4 to 2
move 10 from 2 to 5
move 1 from 9 to 8
move 2 from 2 to 9
move 3 from 7 to 2
move 1 from 2 to 9
move 13 from 5 to 1
move 2 from 2 to 7
move 8 from 9 to 2
move 1 from 4 to 6
move 1 from 9 to 5
move 14 from 8 to 4
move 7 from 4 to 5
move 4 from 7 to 5
move 2 from 3 to 8
move 4 from 1 to 5
move 2 from 5 to 4
move 6 from 5 to 6
move 7 from 2 to 5
move 1 from 2 to 6
move 1 from 5 to 2
move 2 from 2 to 8
move 2 from 1 to 3
move 8 from 4 to 7
move 1 from 4 to 3
move 6 from 1 to 6
move 7 from 3 to 9
move 3 from 7 to 1
move 2 from 8 to 7
move 7 from 6 to 9
move 2 from 3 to 6
move 6 from 8 to 3
move 9 from 5 to 3
move 2 from 7 to 8
move 2 from 6 to 4
move 7 from 6 to 9
move 5 from 3 to 8
move 10 from 9 to 1
move 11 from 1 to 8
move 1 from 3 to 2
move 4 from 5 to 6
move 2 from 6 to 2
move 2 from 7 to 9
move 3 from 1 to 7
move 6 from 3 to 9
move 2 from 7 to 2
move 2 from 6 to 9
move 1 from 5 to 9
move 11 from 9 to 8
move 1 from 4 to 5
move 6 from 9 to 8
move 31 from 8 to 9
move 1 from 3 to 6
move 1 from 7 to 1
move 1 from 4 to 3
move 1 from 5 to 2
move 1 from 1 to 8
move 1 from 8 to 9
move 1 from 7 to 3
move 11 from 9 to 6
move 2 from 3 to 1
move 2 from 3 to 5
move 1 from 5 to 4
move 1 from 4 to 1
move 6 from 8 to 3
move 1 from 1 to 4
move 1 from 4 to 6
move 2 from 3 to 6
move 17 from 9 to 2
move 23 from 2 to 9
move 14 from 9 to 4
move 1 from 1 to 7
move 1 from 5 to 6
move 8 from 6 to 2
move 1 from 3 to 2
move 4 from 9 to 8
move 5 from 4 to 7
move 3 from 7 to 2
move 1 from 1 to 2
move 2 from 9 to 4
move 3 from 6 to 9
move 8 from 4 to 9
move 2 from 4 to 2
move 4 from 7 to 2
move 1 from 7 to 9
move 4 from 6 to 2
move 16 from 2 to 1
move 2 from 3 to 2
move 18 from 9 to 8
move 1 from 4 to 2
move 1 from 6 to 8
move 1 from 3 to 9
move 3 from 9 to 5
move 4 from 9 to 8
move 6 from 2 to 8
move 1 from 5 to 1
move 4 from 2 to 8
move 1 from 5 to 1
move 17 from 1 to 4
move 1 from 5 to 8
move 10 from 4 to 3
move 10 from 3 to 1
move 4 from 4 to 9
move 1 from 4 to 6
move 1 from 4 to 8
move 38 from 8 to 1
move 27 from 1 to 5
move 1 from 8 to 2
move 1 from 6 to 3
move 1 from 4 to 8
move 1 from 8 to 4
move 14 from 1 to 9
move 1 from 3 to 1
move 1 from 5 to 1
move 1 from 2 to 5
move 2 from 5 to 4
move 17 from 5 to 8
move 3 from 4 to 9
move 2 from 9 to 1
move 3 from 5 to 7
move 3 from 7 to 4
move 2 from 4 to 7
move 12 from 1 to 4
move 1 from 7 to 4
move 1 from 7 to 6
move 1 from 6 to 9
move 11 from 4 to 3
move 1 from 5 to 3
move 11 from 3 to 9
move 1 from 3 to 2
move 3 from 5 to 4
move 1 from 2 to 4
move 1 from 5 to 8
move 13 from 9 to 3
move 16 from 9 to 1
move 4 from 8 to 9
move 2 from 1 to 4
move 1 from 9 to 1
move 1 from 9 to 7
move 1 from 7 to 2
move 6 from 8 to 3
move 8 from 4 to 2
move 4 from 9 to 6
move 3 from 2 to 3
move 3 from 6 to 1
move 3 from 8 to 6
move 1 from 6 to 8
move 3 from 6 to 4
move 11 from 3 to 5
move 4 from 8 to 2
move 6 from 3 to 5
move 3 from 5 to 1
move 2 from 8 to 3
move 14 from 5 to 3
move 4 from 3 to 4
move 6 from 3 to 5
move 3 from 2 to 9
move 4 from 1 to 8
move 3 from 9 to 6
move 2 from 6 to 9
move 6 from 4 to 3
move 15 from 1 to 4
move 1 from 6 to 7
move 5 from 5 to 1
move 11 from 3 to 1
move 2 from 9 to 7
move 1 from 5 to 6
move 2 from 1 to 3
move 7 from 2 to 6
move 4 from 8 to 1
move 8 from 4 to 2
move 3 from 6 to 4
move 5 from 1 to 4
move 17 from 4 to 8
move 3 from 3 to 7
move 4 from 3 to 4
move 4 from 4 to 2
move 9 from 8 to 7
move 1 from 3 to 8
move 10 from 2 to 4
move 1 from 6 to 2
move 2 from 8 to 4
move 2 from 6 to 9
move 2 from 6 to 2
move 1 from 2 to 3
move 3 from 1 to 4
move 1 from 3 to 2
move 1 from 9 to 3
move 1 from 9 to 7
move 4 from 8 to 4
move 10 from 4 to 8
move 5 from 4 to 3
move 1 from 2 to 8
move 5 from 3 to 7
move 3 from 7 to 8
move 3 from 4 to 3
move 8 from 7 to 2
move 8 from 7 to 8
move 1 from 3 to 2
move 3 from 2 to 8
move 9 from 2 to 5
move 12 from 1 to 7
move 21 from 8 to 3
move 5 from 8 to 6
move 8 from 7 to 5
move 6 from 7 to 4
move 12 from 5 to 7
move 1 from 8 to 5
move 2 from 4 to 2
move 1 from 7 to 6
move 14 from 3 to 8
move 5 from 6 to 2
move 7 from 2 to 6
move 6 from 8 to 4
move 11 from 7 to 4
move 8 from 3 to 7
move 4 from 5 to 7
move 9 from 8 to 2
move 6 from 4 to 1
move 2 from 5 to 2
move 1 from 7 to 2
move 11 from 2 to 3
move 1 from 2 to 1
move 7 from 4 to 1
move 5 from 6 to 8
move 1 from 2 to 3
move 2 from 8 to 7
move 14 from 3 to 7
move 15 from 7 to 6
move 4 from 4 to 6
move 2 from 8 to 3
move 12 from 1 to 3
move 1 from 8 to 2
move 1 from 2 to 3
move 1 from 3 to 9
move 1 from 9 to 7
move 1 from 1 to 4
move 18 from 6 to 8
move 3 from 3 to 2
move 17 from 8 to 3
move 3 from 7 to 6
move 3 from 2 to 6
move 25 from 3 to 7
move 2 from 4 to 1
move 9 from 6 to 5
move 2 from 3 to 1
move 1 from 3 to 9
move 5 from 5 to 2
move 1 from 8 to 3
move 2 from 4 to 7
move 1 from 9 to 4
move 1 from 6 to 7
move 2 from 5 to 2
move 2 from 4 to 8
move 2 from 5 to 8
move 5 from 7 to 9
move 27 from 7 to 5
move 2 from 9 to 6";
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var stacks = new Stack<char>[10];
            for (int i = 0; i < 10; i++)
                stacks[i] = new Stack<char>();
            for (int i = 0; i < 8; i++)
            {
                var line = inputs[i];
                for (int j = 0; j < 9; j++)
                {
                    if (line[4 * j + 1] != ' ')
                        stacks[j + 1].Push(line[4 * j + 1]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }

            foreach (var line in inputs.Skip(9))
            {
                var token = line.Split().ToArray();
                var crates = int.Parse(token[1]);
                var from = int.Parse(token[3]);
                var to = int.Parse(token[5]);
                for (int i = 0; i < crates; i++)
                    if (stacks[from].Any())
                        stacks[to].Push(stacks[from].Pop());
            }
            for (int i = 1; i < 10; i++)
            {
                Console.Write(stacks[i].Peek());
            }

            for (int i = 0; i < 10; i++)
                stacks[i] = new Stack<char>();
            for (int i = 0; i < 8; i++)
            {
                var line = inputs[i];
                for (int j = 0; j < 9; j++)
                {
                    if (line[4 * j + 1] != ' ')
                        stacks[j + 1].Push(line[4 * j + 1]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }

            foreach (var line in inputs.Skip(9))
            {
                var token = line.Split().ToArray();
                var crates = int.Parse(token[1]);
                var from = int.Parse(token[3]);
                var to = int.Parse(token[5]);
                var temp = new Stack<char>();
                for (int i = 0; i < crates; i++)
                    if (stacks[from].Any())
                        temp.Push(stacks[from].Pop());
                while (temp.Any())
                    stacks[to].Push(temp.Pop());
            }
            Console.WriteLine();
            for (int i = 1; i < 10; i++)
            {
                Console.Write(stacks[i].Peek());
            }
        }
    }
}
