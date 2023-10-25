using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day8
    {
        public static void Main()
        {
            var input = @"rect 1x1
rotate row y=0 by 10
rect 1x1
rotate row y=0 by 10
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 4
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate row y=1 by 12
rotate row y=0 by 10
rotate column x=0 by 1
rect 9x1
rotate column x=7 by 1
rotate row y=1 by 3
rotate row y=0 by 2
rect 1x2
rotate row y=1 by 3
rotate row y=0 by 1
rect 1x3
rotate column x=35 by 1
rotate column x=5 by 2
rotate row y=2 by 5
rotate row y=1 by 5
rotate row y=0 by 2
rect 1x3
rotate row y=2 by 8
rotate row y=1 by 10
rotate row y=0 by 5
rotate column x=5 by 1
rotate column x=0 by 1
rect 6x1
rotate row y=2 by 7
rotate row y=0 by 5
rotate column x=0 by 1
rect 4x1
rotate column x=40 by 2
rotate row y=2 by 10
rotate row y=0 by 12
rotate column x=5 by 1
rotate column x=0 by 1
rect 9x1
rotate column x=43 by 1
rotate column x=40 by 2
rotate column x=38 by 1
rotate column x=15 by 1
rotate row y=3 by 35
rotate row y=2 by 35
rotate row y=1 by 32
rotate row y=0 by 40
rotate column x=32 by 1
rotate column x=29 by 1
rotate column x=27 by 1
rotate column x=25 by 1
rotate column x=23 by 2
rotate column x=22 by 1
rotate column x=21 by 3
rotate column x=20 by 1
rotate column x=18 by 3
rotate column x=17 by 1
rotate column x=15 by 1
rotate column x=14 by 1
rotate column x=12 by 1
rotate column x=11 by 3
rotate column x=10 by 1
rotate column x=9 by 1
rotate column x=8 by 2
rotate column x=7 by 1
rotate column x=4 by 1
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 34x1
rotate column x=44 by 1
rotate column x=24 by 1
rotate column x=19 by 1
rotate row y=1 by 8
rotate row y=0 by 10
rotate column x=8 by 1
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=5 by 2
rotate column x=3 by 1
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 9x1
rotate row y=0 by 40
rotate column x=43 by 1
rotate row y=4 by 10
rotate row y=3 by 10
rotate row y=2 by 5
rotate row y=1 by 10
rotate row y=0 by 15
rotate column x=7 by 2
rotate column x=6 by 3
rotate column x=5 by 2
rotate column x=3 by 2
rotate column x=2 by 4
rotate column x=0 by 2
rect 9x2
rotate row y=3 by 47
rotate row y=0 by 10
rotate column x=42 by 3
rotate column x=39 by 4
rotate column x=34 by 3
rotate column x=32 by 3
rotate column x=29 by 3
rotate column x=22 by 3
rotate column x=19 by 3
rotate column x=14 by 4
rotate column x=4 by 3
rotate row y=4 by 3
rotate row y=3 by 8
rotate row y=1 by 5
rotate column x=2 by 3
rotate column x=1 by 3
rotate column x=0 by 2
rect 3x2
rotate row y=4 by 8
rotate column x=45 by 1
rotate column x=40 by 5
rotate column x=26 by 3
rotate column x=25 by 5
rotate column x=15 by 5
rotate column x=10 by 5
rotate column x=7 by 5
rotate row y=5 by 35
rotate row y=4 by 42
rotate row y=2 by 5
rotate row y=1 by 20
rotate row y=0 by 45
rotate column x=48 by 5
rotate column x=47 by 5
rotate column x=46 by 5
rotate column x=43 by 5
rotate column x=41 by 5
rotate column x=38 by 5
rotate column x=37 by 5
rotate column x=36 by 5
rotate column x=33 by 1
rotate column x=32 by 5
rotate column x=31 by 5
rotate column x=30 by 1
rotate column x=28 by 5
rotate column x=27 by 5
rotate column x=26 by 5
rotate column x=23 by 1
rotate column x=22 by 5
rotate column x=21 by 5
rotate column x=20 by 1
rotate column x=17 by 5
rotate column x=16 by 5
rotate column x=13 by 1
rotate column x=12 by 3
rotate column x=7 by 5
rotate column x=6 by 5
rotate column x=3 by 1
rotate column x=2 by 3";
            var inputs = input.Split('\n');
            var grid = new char[6][];
            for (int i = 0; i < 6; i++)
            {
                grid[i] = new char[50];
                for (int j = 0; j < 50; j++)
                {
                    grid[i][j] = ' ';
                }
            }
            var regexRect = new Regex(@"^rect (?<A>[0-9]+)x(?<B>[0-9]+)");
            var regexRotateRow = new Regex(@"^rotate row y=(?<A>[0-9]+) by (?<B>[0-9]+)");
            var regexRotateCol = new Regex(@"^rotate column x=(?<A>[0-9]+) by (?<B>[0-9]+)");
            Match match;
            foreach (var instruction in inputs)
            {
                match = regexRect.Match(instruction);
                if (match.Success)
                {
                    TurnOn(grid, int.Parse(match.Groups["A"].Value), int.Parse(match.Groups["B"].Value));
                    continue;
                }
                match = regexRotateRow.Match(instruction);
                if (match.Success)
                {
                    RotateRow(grid, int.Parse(match.Groups["A"].Value), int.Parse(match.Groups["B"].Value));
                    continue;
                }
                match = regexRotateCol.Match(instruction);
                if (match.Success)
                {
                    RotateCol(grid, int.Parse(match.Groups["A"].Value), int.Parse(match.Groups["B"].Value));
                    continue;
                }
                throw new ArgumentException();
            }
            Console.WriteLine(grid.Select(row => row.Count(c => c == '#')).Sum());
            Console.WriteLine(string.Join("\n", grid.Select(row => new string(row))));
        }

        private static void RotateCol(char[][] grid, int col, int shift)
        {
            int n = grid.Length;
            int g = gcd(n, shift);
            for (int i = 0; i < g; i++)
            {
                var c = grid[i][col];
                int loop = n / g;
                int prev;
                int next = ((i - shift) % n + n) % n;
                for (int j = 0; j < loop - 1; j++)
                {
                    prev = ((i - j * shift) % n + n) % n;
                    next = ((i - (j + 1) * shift) % n + n) % n;
                    grid[prev][col] = grid[next][col];
                }
                grid[next][col] = c;
            }
        }

        private static void RotateRow(char[][] grid, int row, int shift)
        {
            int n = grid[row].Length;
            int g = gcd(n, shift);
            for (int i = 0; i < g; i++)
            {
                var c = grid[row][i];
                int loop = n / g;
                int prev;
                int next = ((i - shift) % n + n) % n;
                for (int j = 0; j < loop - 1; j++)
                {
                    prev = ((i - j * shift) % n + n) % n;
                    next = ((i - (j + 1) * shift) % n + n) % n;
                    grid[row][prev] = grid[row][next];
                }
                grid[row][next] = c;
            }
        }
        public static int gcd(int a, int b)
        {
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        private static void TurnOn(char[][] grid, int col, int row)
        {
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    grid[r][c] = '#';
        }
    }
}
