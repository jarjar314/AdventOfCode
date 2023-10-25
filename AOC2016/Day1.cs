using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016
{
    public class Day1
    {

        public static void Main()
        {
            var input = @"R1, R1, R3, R1, R1, L2, R5, L2, R5, R1, R4, L2, R3, L3, R4, L5, R4, R4, R1, L5, L4, R5, R3, L1, R4, R3, L2, L1, R3, L4, R3, L2, R5, R190, R3, R5, L5, L1, R54, L3, L4, L1, R4, R1, R3, L1, L1, R2, L2, R2, R5, L3, R4, R76, L3, R4, R191, R5, R5, L5, L4, L5, L3, R1, R3, R2, L2, L2, L4, L5, L4, R5, R4, R4, R2, R3, R4, L3, L2, R5, R3, L2, L1, R2, L3, R2, L1, L1, R1, L3, R5, L5, L1, L2, R5, R3, L3, R3, R5, R2, R5, R5, L5, L5, R2, L3, L5, L2, L1, R2, R2, L2, R2, L3, L2, R3, L5, R4, L4, L5, R3, L4, R1, R3, R2, R4, L2, L3, R2, L5, R5, R4, L2, R4, L1, L3, L1, L3, R1, R2, R1, L5, R5, R3, L3, L3, L2, R4, R2, L5, L1, L1, L5, L4, L1, L1, R1";
            int direction = 0;
            var directions = new (int x, int y)[4] { (0, 1), (1, 0), (0, -1), (-1, 0) }; // N / E / S / W

            int x = 0, y = 0;
            var visited = new HashSet<(int x, int y)>
            {
                (x, y)
            };
            bool first = true;
            foreach (var move in input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (move[0] == 'R')
                    direction = (direction + 1) % 4;
                else
                    direction = (direction + 3) % 4;
                int step = int.Parse(move.Substring(1));
                for (int i = 0; i < step; i++)
                {
                    x += directions[direction].x;
                    y += directions[direction].y;
                    if (visited.Contains((x, y)) && first)
                    {
                        first = false;
                        Console.WriteLine($"first visited twice is {x} {y} => {Math.Abs(x) + Math.Abs(y)}");
                    }
                    visited.Add((x, y));
                }
            }
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));

        }

    }
}
