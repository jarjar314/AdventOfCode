using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day18
    {
        static char tree = '|';
        static char open = '.';
        static char lumber = '#';
        public static void Main()
        {
            char[][] grid = Init();
            int round = 10;

            //Console.WriteLine($"start {ResourceValue(grid)}");
            for (int i = 0; i < round; i++)
            {
                grid = Next(grid);
                //Console.WriteLine($"{i} {ResourceValue(grid)}");
            }

            Console.WriteLine(ResourceValue(grid));
            // 2nd star
            grid = Init();
            var states = new Dictionary<string, int>();
            var steps = new List<char[][]>() { grid };
            states[State(grid)] = 0;
            round = 1000000000;
            for (int i = 0; i < round; i++)
            {
                grid = Next(grid);
                //Console.WriteLine($"{i} {ResourceValue(grid)}");
                var state = State(grid);
                if (states.TryGetValue(state, out var previousStep))
                {
                    // Let's close the loop :)
                    var loopingTime = i - previousStep;
                    var remainingTime = (round - i) % loopingTime;
                    Console.WriteLine(ResourceValue(steps[previousStep + remainingTime]));
                    break;
                }
                states[state] = i;
                steps.Add(grid);
            }
        }

        private static int ResourceValue(char[][] grid)
        {
            return grid.Select(r => r.Count(c => c == tree)).Sum() * grid.Select(r => r.Count(c => c == lumber)).Sum();
        }

        private static char[][] Init()
        {
            var input = @".|#.#|..#...|..##||...|#..##..#..|#|....#.#|.|....
.||....#..#...|#....#.||....||...||...|..#|..||..|
......|.|.#.#.#..|.....#.###.....#........|.||..#|
..|.....||...#||#.#|#.....|##.|.|....|#....#|..#.#
|...#.|..#|#.#....|.#.#.|.#...#..#|#.....##|#..#.|
#....|#|......#.|||..#..#..||...#.#...|||##|..|#..
.#||.|....|.......#|##...|.#.....#.##...|.|.#...#|
....#|.|.|...##.......|#.....|..#......#...#|.#..#
...#.|....#.|.#...|||......##..|#|||#..#...|.|#.#.
.#..|...|..#.|##.#.#......#...||.||.#...|.#.#.#|..
|...#.|||...#|.#||.......|.##.....|..||...####...|
.##..|..##|...##.#...#...#.#|.|###...#............
|.....||...#.......|.#..|#.....|.|#.|..||.##.|#|..
.#..##|.#|.|..|.#..#.|.#..#|......##...#.#.......#
...#.##.|..|.#.....#....#..#.............|.|##||..
||.##.||.|.|..|..#.|.|.##|.|...|.#.|#.......#.|...
..|#.##..#|.#|#.#...........|.|........#...#|...#|
....|.#|..|.#|#|...|.|.#..#.....#|##|||##.#....#..
...###.#.....#.||......#|#..##...|#....#....|#|.#.
.##.|.##|.#.||....#|....|.#.|#.|....##..#.##|.....
|...|...#|....#....#...#|#...|..#.#.|.|.....|.#|..
.|.|.#.#.#|.#.|#....|.|###..#......|...|...#.|#...
..|...||.|..##|...|..|#|...|......#.||.#...#..|#.|
........|..#||..|....|.....|.|#..#....|#..|.#.....
#.|.|#....#...|..|....|.#.....||.....|..|........#
...||||....|.#.|....#..#....|###....|...#...##....
|||........|.#|.|......||#.|.....|.||#|.##....#|..
.....|#|#..||#...|##.|..||....####.|#.|..#....|.#.
.||..#||....#.....#.#|.|....|.##|..|.#..|##....##.
.|#.#|#|#|.....||..|.|.|.#......#..|.#..#..|.#||#.
|.|#.......|..#|#|....|.#.#.#.|...|.......##.|||#|
..|.....#...||.|....|##|...#..#.#.....|##|##.##...
.|.|..##.#|..|.|#.......#....#||.|...||#...|......
|.|##.#....|#..|....#..#..|##.|.##..#......#|##|..
..#....#.|#...#.#...|.....|.||.#.#|.#.|###..|..#.#
..|.##...........|..###.||.|.##.|....|.|.#|#.#.|#|
..|....|.|#|...#|#...|.#......#.#||...|.#|...#.|#.
..#.......|.||.....||.|....|#||..........#...|#...
.|..#....|#|||#..##||..#|.......|..|###..|.#...|.|
|..|.#|.#...#....|.....#.....#....#...|..|.|.#.|.#
....###.#....|.#..#...#...###.|.|.....#|...#.....|
..#....##.....##..|.#.||#.|.#|#||..|...#|..|.#....
|#..#.#|||#.|#..#........#......||...#.|..#|....#|
......#|...#.|...#...|.|...|#|#......#|.##.#|.|.#|
#||.#......#.##......#..||.##|.|.||..|#....#..#...
#.#...#.|.#|#||#.#......#....|##|.........##.#|...
.....###...#||....|####..#|||...#..#|.|....#|..#..
......|#..#.#.#..|.#|#||..||.|...#....##...|......
...#...|..#..##.||.#.#.....|.###.....##|#||..#..#|
.#..#||.#....||....|##..|||...|.||...#..##.#....#.";
            /*  input = @".#.#...|#.
  .....#|##|
  .|..|...#.
  ..|#.....#
  #.#|||#|#|
  ...#.||...
  .|....|...
  ||...#|.#|
  |.||||..|.
  ...#.|..|.";*/
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var size = inputs.Length;
            var grid = new char[size + 2][];
            grid[0] = new string('.', size + 2).ToCharArray();
            grid[size + 1] = grid[0];
            for (int i = 0; i < size; i++)
            {
                grid[i + 1] = ("." + inputs[i] + ".").ToCharArray();
            }
            return grid;
        }

        private static string State(char[][] grid) => string.Join("\n", grid.Select(row => string.Join("", row)));
        private static char[][] Next(char[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var res = new char[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new string('.', n).ToCharArray();
            }

            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    int trees = 0;
                    int lumberyard = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (k == 0 && l == 0) continue;
                            if (grid[i + k][j + l] == tree) trees++;
                            if (grid[i + k][j + l] == lumber) lumberyard++;
                        }
                    }
                    if (grid[i][j] == open && trees >= 3)
                        res[i][j] = tree;
                    if (grid[i][j] == tree)
                    {
                        if (lumberyard >= 3)
                            res[i][j] = lumber;
                        else
                            res[i][j] = tree;
                    }
                    if (grid[i][j] == lumber && trees > 0 && lumberyard > 0)
                    {
                        res[i][j] = lumber;
                    }
                }
            }

            return res;
        }
    }

}
