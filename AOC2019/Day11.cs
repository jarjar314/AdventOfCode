﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019
{
    public class Day11
    {
        public static (int dx, int dy)[] Moves = { (0, -1), (1, 0), (0, 1), (-1, 0) };
        public static string program = @"3,8,1005,8,305,1106,0,11,0,0,0,104,1,104,0,3,8,1002,8,-1,10,101,1,10,10,4,10,1008,8,0,10,4,10,1002,8,1,29,3,8,102,-1,8,10,1001,10,1,10,4,10,108,1,8,10,4,10,1002,8,1,50,1,104,20,10,1,1102,6,10,1006,0,13,3,8,102,-1,8,10,101,1,10,10,4,10,108,1,8,10,4,10,102,1,8,83,1,1102,0,10,1006,0,96,2,1004,19,10,3,8,1002,8,-1,10,101,1,10,10,4,10,108,0,8,10,4,10,101,0,8,116,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,1,8,10,4,10,102,1,8,138,1006,0,60,1,1008,12,10,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,0,10,4,10,102,1,8,168,1006,0,14,1006,0,28,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,0,8,10,4,10,101,0,8,195,2,1005,9,10,1006,0,29,3,8,1002,8,-1,10,101,1,10,10,4,10,108,1,8,10,4,10,1002,8,1,224,2,1009,8,10,1,3,5,10,3,8,1002,8,-1,10,101,1,10,10,4,10,108,1,8,10,4,10,102,1,8,254,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,0,10,4,10,1002,8,1,277,1,1003,18,10,1,1104,1,10,101,1,9,9,1007,9,957,10,1005,10,15,99,109,627,104,0,104,1,21101,0,666681062292,1,21102,322,1,0,1105,1,426,21101,847073883028,0,1,21102,333,1,0,1105,1,426,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21101,0,179356855319,1,21102,1,380,0,1105,1,426,21102,1,179356998696,1,21102,1,391,0,1105,1,426,3,10,104,0,104,0,3,10,104,0,104,0,21101,0,988669698816,1,21101,0,414,0,1106,0,426,21102,1,868494500628,1,21102,425,1,0,1106,0,426,99,109,2,21202,-1,1,1,21102,1,40,2,21102,457,1,3,21102,1,447,0,1105,1,490,109,-2,2105,1,0,0,1,0,0,1,109,2,3,10,204,-1,1001,452,453,468,4,0,1001,452,1,452,108,4,452,10,1006,10,484,1102,0,1,452,109,-2,2105,1,0,0,109,4,1201,-1,0,489,1207,-3,0,10,1006,10,507,21102,0,1,-3,22101,0,-3,1,21202,-2,1,2,21101,1,0,3,21102,1,526,0,1106,0,531,109,-4,2105,1,0,109,5,1207,-3,1,10,1006,10,554,2207,-4,-2,10,1006,10,554,22101,0,-4,-4,1106,0,622,21201,-4,0,1,21201,-3,-1,2,21202,-2,2,3,21102,573,1,0,1106,0,531,21202,1,1,-4,21101,1,0,-1,2207,-4,-2,10,1006,10,592,21102,1,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,614,22101,0,-1,1,21102,614,1,0,105,1,489,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2105,1,0";
        static void Main()
        {
            var blacks = new HashSet<(int x, int y)>();
            var whites = new HashSet<(int x, int y)>();
            var painted = new HashSet<(int x, int y)>();
            Call(blacks, whites, painted);
            Console.WriteLine(painted.Count);

            blacks.Clear();
            whites.Clear();
            whites.Add((0, 0));
            painted.Clear();

            Call(blacks, whites, painted);
            Print(whites);
        }

        private static void Print(HashSet<(int x, int y)> whites)
        {
            var xmin = int.MaxValue; var xmax = int.MinValue;
            var ymin = int.MaxValue; var ymax = int.MinValue;
            foreach (var w in whites)
            {
                xmin = Math.Min(xmin, w.x);
                xmax = Math.Max(xmax, w.x);
                ymin = Math.Min(ymin, w.y);
                ymax = Math.Max(ymax, w.y);
            }
            int width = xmax - xmin + 1;
            int height = ymax - ymin + 1;
            var grid = new char[height][];
            for (int i = 0; i < height; i++)
            {
                grid[i] = new char[width];
                for (int j = 0; j < width; j++)
                {
                    grid[i][j] = ' ';
                }
            }
            foreach (var w in whites)
            {
                grid[w.y - ymin][w.x - xmin] = '#';
            }
            foreach (var row in grid)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static long Call(HashSet<(int x, int y)> blacks, HashSet<(int x, int y)> whites, HashSet<(int x, int y)> painted)
        {
            long input;
            var ic = new Intcode(program);
            int x = 0, y = 0, direction = 0; // direction being 0 up, 1 right, 2 down, 3 left.
            while (true)
            {
                if (whites.Contains((x, y)))
                    input = 1;
                else
                    input = 0;
                ic.input = input;
                var r1 = ic.Run();
                var r2 = ic.Run();

                // paint the hull
                var paint = r1.output;
                painted.Add((x, y));
                whites.Remove((x, y));
                blacks.Remove((x, y));
                if (paint == 1)
                    whites.Add((x, y));
                else
                    blacks.Add((x, y));
                if (r2.output == 0)
                    direction = (direction + 3) % 4;
                else
                    direction = (direction + 1) % 4;
                x += Moves[direction].dx;
                y += Moves[direction].dy;
                if (r2.done) break;
            }

            return input;
        }
    }
}
