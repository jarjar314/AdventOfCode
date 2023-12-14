using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace AOC2023
{
    public class Day14
    {

        public static void Main()
        {
            var input = @"..#..#......#...O.O#O#..#O.O#.O..O.O.#.O..OO.O......###...#..#....OO..O.#.....#.O...#.#OO#O#..O.O#O.
#.#..OOO..#..#...O......#.###O..O.O...#..........#..O......O.#O#......#....O..O#OO.........OO.##O...
..O.#....O.O...O#O...#.##O#OO.#OO.....#.O....O....#OO.O#....O.O.#.......O......O#.O.O...#.....#O.O.O
#OO.O...#.#......#.......##.O#...OO..O....#...#OO....O...#.#....O#.#.#.O.....#..O..O..#.#...O.#.O..O
O##O...O.#O....#.#O#........O....#.#.O.O#O..O...O.#OO.O###.#.#.O..........O##O#......O..##....#O##..
O..#..........O....O.O.O.OO.OO.OOOO...#..OOO..O..#O.##...#..OOOO.O####....O#....#O##.O.........O...O
.##...OO..O..#...O.O...O#.O.O.O..OO..O..##O.##...#.OOO.#O.....O...O....OOO.#O...#O#.......#.O.OO.O..
.O....O..#.OO...###....#.##...O.O#...O.#.O.#....O...#..#.#O.O.#.....O#O#O..OO..#.O.O...OO.O..##.#.O.
.#.##O#.OO....#..###.#.O...#.#O.OO.#..O..O......O...#....OO..##.#O#O.O..O.....#.#..#..O.#...#O....O.
...#.O..#OO...O#....O...#......O#.#..O.O#OOO#.#OO..O.....#.....#O.O#O...O.#.#..#O.#...##O..#..O.O#..
.##....O#.......##........#.#.O...O.O#.#.O........O......#.#O.O...O##.....OO..#O..O#.O....#...#O....
.#O..O.#..O#OO#..O.......#.O#O#...O...#O.O...OO#....#....O....#....O#O..OO....O.......#.....O.O#O##.
#....#..#.#..O#.#.OO....##...#O.O###.....O.##O#OO#......O.....O#.#O..O...#...#.O.O.O.#...#.....#.OO#
.#..OO.#...##.O...#......O...#O#.O.#O.#.#....#.#.....OO#.OO.......#O...OO.O.#....#.......#.#.##....O
...O....O.##O.O....#O...#....#OOOO......#..O..O..##O....#O.......O.#.O...O#..#O.O...#O.##..O....O...
#..#...##.##..#..O.#...#..O..#.....#...O.......#O#...O.#..#O#.#...#..O#....OO....O#..#O..O.O#.O#..#.
.OO.......##...O...#.#....#O#.#O..#.#O.#......O.O.#.......#O.O........#.#.O.#.OO.#..OO#..#O..O.#...#
...O..O..O#...#......O...#.OO.O....O.........O#O.O..#.#O..##..........O.O..#OO.O.#O..O...O...#......
...O.#...#.O##.#..OO#OO..#....O.#...#........#...O#...O..#..O..##.....O..##.O..#..#.OO...O.#.#.OO.#.
..O.#..O.O..#......O.....OO..O..OO.O.....O....#....##....OO....#..O#....O....#O#....#...##.....O#..#
OO.....#.##.OO#........O..##.....O.#.O#.....#.OO.OO.O...O.OO...#....#.#.O#.#...#OO...#..O#...O#O.O..
##...O#.#.O............O....#OOOOOO.....#.O#OO#O.OO....O#.#.O............#...OO.....#.....O#.....O..
..O...#....O##.O#.#.O#O...O..O...O.O....O..#..#...OO.O.OO..O.#.#..#..O#.....O.##........O......O....
...O.#.O...O.##..#.....O.#.........OO#....O......#OOOOO..........##.O......#.......##.##..O.#.....O#
#...#..#O..#.O.#....O..#.O.OOO#..O...#.#..O.OO.#...##..O..#.#..##.OOO....#..O.O.O.#.OO.O.O#..O#.....
..O.#......#..#.##.#.#.O.#.#.....O..#..O.#O#.#..#...O.O.O#.##....#.O.O.O....O..#.O.O......O..O......
..#O......O#.....#..#.#.....#.#.#.....#..O..........O...#.##.......O.#.....O...O##..O.O...#.....O.OO
..O...O.##.......#...#...#...O.........#...O...#.O.O....#.OO..#..OO...O...OOO#O...OO.O#..O.OO.....#O
.....O..#..OOO......##O..O.OO.#....O..O.##.#O..#..O.OOO...O#...OO.O..#.#.O#....#O..O..##.O....O.O..#
O#..O..........O....O##..OO....O.O..O.OOOO....O.......#...#O.#.###O.............#....O.O##..#O.....#
......#.OO#....O..O.........O..#.#O#O....O....OO#O..#.....#.O.#.#.O.OO...O.........#.##..OOO..#...#.
...#..O.....O##.....#O.O.O#....OOO.OO..O.OO.....#O.##O#.#...O.#..#....#..#..O.O...#O.O.##...O###O.#.
...O.#O#....#.#O..O....O.O..#...#.#..#......#....O.....#......##...O....#.#...#..O.....#....O#.....O
O.O#..#.O.O.....#..#O.....#..#O....#....O.O.O..#..O###O.#..O#...O##.O.......#........O..O#..OO..#...
#O..O..##OO....OO.O.....#...O...O...#..O#.#.......#O.OO##.....O.O...O...OOOO...OO....O......O.#....#
OOOO....O..##..OO....O#..##..OOO.#..O.OO.O#O....O.#.#.....OOO.##....O.O.O..#OO..O...#...#O.O.OO...O.
.#..OO.O...##..#......O..........#.O.....#........###..O#..#.O.O#.....O..O..O.#...O....#.O..O......O
....O.#O..#O.#..O...###..OO...O.OOO..#...O...OO.....#.O.#O..O........#..#...##.OOO.OO..#..O...#....O
..OO.....O#........OO#O.O.........#..#.....#.......#.O..#......#O#.O.O.O..OO..O.......O...O......#O.
##....O.....#..#.OOO..O.#.O.###..O...OOOO.#.......O..#...O.O#OO.O#...O....#.O.O..#.....O...O#...#..#
.O#..#..O..#O#.#.........O......O.O##...#..#...O....O..O.#....#...O..OOO..O....#..#.OO.O#.....#....#
.O#.OO.#.....#.O.#.O##O#......O......O.#O..#O#....#..OO.OO#.O.O.O..#OO#.#........###..........##....
...#O#....#....OO.....O.#..O..O....#..OOO##.......O......##..#...O#...#O#........O.....#..#.O.#.#.O#
.O.O....O.O....OO#.#...O#.OO..O.#...#...#...#.#.......#..#.O..#...O#..O...O..#..#.O.O.....O..#O.O..#
....O.O#...OO##OO....O.OO...O#...#.....O....OO..O.O...#....OO....O#.#.OO.O...........#.#.O..O.#.....
O.O.#.......#O.#O.....#...#OO....#.OO...#O.#..OO#.O....#.O#..........#OO#.......#O..#...#....O#.....
#.#..#.O...O...OOO.#.#..O....O..##O.O......#.O.#......O....O..#O......#O..#..O..O...O#..O......#O#.O
#.......#......O........O...##..#.#.O...O.......#..O......O#O.........#OO#...O.#...O..#.....#...#...
#...#..#.....O#.O#O..O#......#O...O..##....##....####..O......O..##..OO...........O#.......OO..O##..
..#O.#O...O.#....O#...#...#....#...#.......O.O.O..#...#.O.O....O..O.....O#O....###..O..O.#.OO##..O#.
O......#..........#.#..O###...O...#.#........#.O..O......#O#O.......#.#.O.#..OO#O.O..##.#.....O..O.O
.O.O.O#.O...O...O..#O.....O.#OOO..O.O.....O.#.#.#.#...#.......#O........O.#O.O...#.O.#..O...O.#O...O
.O....#O.O.#...###...O........O#O..#.O.OO#..OO...O.O......#..O.##..O#.#.#.#...O#O.......#..O.#.#O..#
..#...O..###O#..O..#...O...#OO...O.#..#.O.........OOOO.O...........#..O......#...#.#...##...O.......
....O#.OO...#....O#...#O.......OO.OOO..O......#......#...........####...O.##O.#.....O......#.......O
O...O..O.O.#O.##...OO#.O#O.#...#.#...OO...#O.O.OO.....#.................##.#..O.O.O..O.O.#.......O.O
O.O.#..#...O.O....O........##.#.....OO....O..O.......#..#O.#OO.OO.....##....O.O##....#.....#O.....OO
O.#.....#.......#O..O#......O..O..O#.O..O...#.O...##O#....O.#O....#O#...O......OO.O..O.#O#.#O..#....
#O.O#....#.....#O........#........#..O.OOO.O......#O#.....#.##.....##.#OO#.O......OO.OOOO.#.O#....O.
O.............#.....OO..OO.#.O#.#.......OO.......O#....#.#.#..........O..#...O.....O#..O...O.O#...#.
O.#O#.........#.#..O#O#..OOO#O#...#....##.#.O.##.O....OO....O......O.O#.O...O#O.#.##..........#OOO.O
...O.......OO...O#O#..O...O...O..OO..O..#..O.........##........O#....O..#.OO...OO...OO..#.##O#....#.
#....#O....O.#..O...O..#O#.....#OO.O#..O..#.....#..##........O..#O#O..........O....#OO..O#...O.O...O
O........O.O.O#..O....O###......O..##O.....O.....#O..O.#.....##.....#OO...OO...#..O#.#...#O.OO##.O..
.#O.........##.......#O......O#..OOOOOO#O....#..O#.#O#.......O.O...O...O#...#....O....#..#...#O.#.OO
.O.O...#.....OO.#.O..#OO.....#.........O....OO.....#.#.#.#.#..O...##...O..O...OO....#.O.......OO....
##OO.OOO#.#O#..O....O.O.O...O...O#..#O...O..#......OO.O..#...#O..O.#.OOOO.O...O......#.##O.#O.#...##
OO...O....#.#...#.#.O.#..#..O.O.O..#...#......O.......O......O.O.O......O.....OO##.#..O.............
....#.O.#......#..OO......O#.O.#...O.O.#.O...#O.....#..#............O..#O#.#.O..OO...O.OO..O.#...OO#
O#O..#O...#..OO............#.O..#..O.##OO.....OO.##..O.......O.#.O.....O...OO...OO.O.#......O...O#..
OO.##.#OO#O.......OO.O...#.OOO...O#....O.O#.O....OO.#..O..OO#OO.#....#..O##O.O.O....OOOO...###..#..O
....OO...#..O..........O.....O..O#.O.......##O.##OOO..OOO...O#.O.O...O..O#O..O.#O.#..O#.....O...OOO.
#..OOOO.#O......#...........O.##..##....#...O##O#......O.O..#...#O#....OO.#..OO..#..OO#.O...##......
.#O.....#O..O.#O.O.##.#.....OO....O#..##....O#..O.....#...#.O..OOO...##....OO...O..O...OO...OO...#O.
....O..O#.O#....OO#..#.#....OO##.O#O.##.....O........O#O...#.........O.....#.#.O.O...OO...O....O#.#.
...........O#OO#...#O.O..OO..O...O.....O.O..#.............O..O............#.O..O#...........#..#....
O.#.O........O.O..#..#O.#O.#......#.O#.O##..#O#O..O#O....#.##..#O....#........O.....#...#...O.......
.#.#O.O....OO.........O..#.....OOO.#...##.O.O.....#.OO..#...O.O........O#...O...O..#O...O.#......O..
....O..O...#O.O.OO.O.#...O#...O..#..O...#O#.#.....OO#..O..#...O#.O..#OO..#...OO.OO.#.#.....#....#.O#
..OOO.#......O..O.......#.......#...#....O.O#...O#.OO...#..#OO.O....#.#.#..O....O.....O.O.O#...O.O..
O......O.#.O.OO..O..#..O..#.....OO.O.OOOO#..O#....O.#..#...#.##.OO.....O.O.#.#.#.O.#O...OO.O.#.#...O
O...OO..###.O##........O..O.#.....OO..#....#.#.#..#.#O...O...###...#O..#O........#..#O.#.....###.OOO
.O..###O........OO###......#....##.....O.OO.....O.#...#.....O##O..OO.#..O...O#....OO#....O..#..#.OO.
.O..O..O#......O..O...###.....O..#.#....#........#....#.#..O#...O.#.#####O#O.......#O..O..##..O..O..
.OOO.OO.O###...........#.......O.O......O.....O...O.....OO.O#............#.OO.........OO...O#......#
....#.O#...#.#..OOO.#O.O.O...OO....#...##..O..OOO.......OOO....O#.O....O..O.###..O..O..#...##..O....
.......#O#.O..#...O#.O.O..O..O..O.O...OO.....O.O......#......#..##O.....O##...O...#.O..##..##.O...#O
OOOO..##............OO..O.....O...O.#.....#..#...O.#.O..O.#.##.....O..#..#...#O..OO....O..O...O.....
O..#OO.OO.....OO.O........#...O.O...OO.#.#......#....O...#OO...OO..#.O...#.O.......O...O...O#O##.O##
O.O.O.OO...##....#.......#...#......#..#O.......##.#.#O..#OO......O......#....OO...OO.#.....O.O..##.
O..O......##.....O...#...#.OO..OO.......###.#.......#.....O#OOO..#O.OO#......O..O.#.O..O..OO...#..#.
.....O...#.##.#.##...O#.#..O..OO.#O##O....O#O.O..OO.#O....O....#OO..O.O...OO...O....#....O.##O#...O.
.#.#....#..OOO.....#.....##.##..........#.O...##..O.#O.......OOOO#O.O.O#.O..O..O....O.....#......OO.
O..O##OO#....#O.....OO.O.O.##O.O............OOO..O#.....O...#O...#...........#OO..#.##.#.#.....O#...
.##.OO......#..##..O..OO...O..#...O..#O#.OO.O.OOO...#.OO..O.OO#..O.......#..#..##...O.O##O..OO...O..
......#....O..#O.#.O.#.#O.O......#.O.....O##.O......#....#.###O.O#..O#O.....O..O..O..##..#O#..O..O..
#O....#..O.#OO....#.....#....O.#...#.#..O..#.##..#.O.O.O......#.......#OO..O.#.O#OO.##.O.......OO..#
##....#...#.O..#.#..OOO...O...O..##...O.O..#..#...#.....O#.#O...O..#.#.....O....O#......O#O.O...O#O#
#..........O#...#.O#O.O.O.#..#O.O..#.#O.#.O......O.#......#.......O..#.#..#..##O..O.#...#..O#.##.O.O
O..#.O...O.........#...#........#.O..OO..O.#O.##.O..O..OO#.OO#O..OO...O#.O.#..#.#O#.#......O.#...#.O";
            var sample = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }
        private static void part2(string input)
        {
            long count = 0;
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToCharArray()).ToArray();
            var map = new Dictionary<string, int>();
            var first = string.Join("\n", inputs.Select(row => string.Join("", row)));
            map.Add(first, 0);
            int max = 1_000_000_000;
            for (int i = 0; i < max; i++)
            {
                RollNorth(inputs);
                RollWest(inputs);
                RollSouth(inputs);
                RollEast(inputs);
                var state = string.Join("\n", inputs.Select(row => string.Join("", row)));
                if (map.TryGetValue(state, out var instance))
                {
                    // already in this position in instance, now we are at i + 1 cycles
                    int cycle = i + 1 - instance; // loop is cycle long
                    int remaining = (max - i - 1) % cycle;
                    for (int j = 0; j < remaining; j++)
                    {
                        RollNorth(inputs);
                        RollWest(inputs);
                        RollSouth(inputs);
                        RollEast(inputs);
                    }
                    count = Compte(inputs);
                    break;
                }
                map.Add(state, i+1);
            }
            Console.WriteLine($"2nd star answer is {count}");
        }
        private static int Compte(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length, compte = 0;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (inputs[r][c] == 'O')
                        compte += m - r;
                }
            }
            return compte;
        }
        private static void RollNorth(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int c = 0; c < n; c++)
            {
                int firstpossible = 0;
                for (int r = 0; r < m; r++)
                {
                    if (inputs[r][c] == '#')
                    {
                        firstpossible = r + 1; continue;
                    }
                    if (inputs[r][c] == 'O')
                    {
                        inputs[r][c] = '.';
                        inputs[firstpossible][c] = 'O';
                        firstpossible++;
                        continue;
                    }
                }
            }
        }
        private static void RollSouth(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int c = 0; c < n; c++)
            {
                int firstpossible = m - 1;
                for (int r = m - 1; r >= 0; r--)
                {
                    if (inputs[r][c] == '#')
                    {
                        firstpossible = r - 1; continue;
                    }
                    if (inputs[r][c] == 'O')
                    {
                        inputs[r][c] = '.';
                        inputs[firstpossible][c] = 'O';
                        firstpossible--;
                        continue;
                    }
                }
            }
        }
        private static void RollWest(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int r = 0; r < m; r++)
            {
                int firstpossible = 0;
                for (int c = 0; c < n; c++)
                {
                    if (inputs[r][c] == '#')
                    {
                        firstpossible = c + 1; continue;
                    }
                    if (inputs[r][c] == 'O')
                    {
                        inputs[r][c] = '.';
                        inputs[r][firstpossible] = 'O';
                        firstpossible++;
                        continue;
                    }
                }
            }
        }
        private static void RollEast(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int r = 0; r < m; r++)
            {
                int firstpossible = n - 1;
                for (int c = n - 1; c >= 0; c--)
                {
                    if (inputs[r][c] == '#')
                    {
                        firstpossible = c - 1; continue;
                    }
                    if (inputs[r][c] == 'O')
                    {
                        inputs[r][c] = '.';
                        inputs[r][firstpossible] = 'O';
                        firstpossible--;
                        continue;
                    }
                }
            }
        }

        private static void part1(string input)
        {
            int count = 0;
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToCharArray()).ToArray();
            int m = inputs.Length, n = inputs[0].Length;
            for (int c = 0; c < n; c++)
            {
                int firstpossible = 0;
                for (int r = 0; r < m; r++)
                {
                    if (inputs[r][c] == '#')
                    {
                        firstpossible = r + 1; continue;
                    }
                    if (inputs[r][c] == 'O')
                    {
                        count += m - firstpossible;
                        inputs[r][c] = '.';
                        inputs[firstpossible][c] = 'O';
                        firstpossible++;
                        continue;
                    }

                }
            }
            Console.WriteLine($"1st star answer is {count}");
        }

    }

}