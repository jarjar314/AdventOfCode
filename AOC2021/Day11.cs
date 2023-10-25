using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2021
{
    public class Day11
    {

        public static void Main()
        {
            //            var input = @"5483143223
            //2745854711
            //5264556173
            //6141336146
            //6357385478
            //4167524645
            //2176841721
            //6882881134
            //4846848554
            //5283751526";
            var input = @"7313511551
3724855867
2374331571
4438213437
6511566287
6727245532
3736868662
2348138263
2417483121
8812617112";
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var n = inputs.Length;
            var octopusGrid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                octopusGrid[i] = inputs[i].Select(c => c - '0').ToArray();
            }
            var flashId = new List<(int, int)>();
            int flashes = 0;
            int step = 0;
            bool allFlash = false;
            while (!allFlash || step < 100)
            {
                allFlash = Handle();
                if (allFlash)
                    Console.WriteLine($"synchronization at {step + 1}.");
                step++;
                if (step == 100)
                {
                    Console.WriteLine(flashes);
                    Console.WriteLine(flashId.Count);

                }
            }

            bool Handle()
            {
                var hasFlashed = new HashSet<(int, int)>();
                var q = new Queue<(int, int)>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        octopusGrid[i][j]++;
                        if (octopusGrid[i][j] > 9)
                        {
                            q.Enqueue((i, j));
                            hasFlashed.Add((i, j));
                        }
                    }
                }
                while (q.Count > 0)
                {
                    var p = q.Dequeue();
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;
                            int ni = p.Item1 + i, nj = p.Item2 + j;
                            if (ni < 0 || nj < 0 || ni == n || nj == n) continue; // border
                            if (hasFlashed.Contains((ni, nj))) continue;
                            octopusGrid[ni][nj]++;
                            if (octopusGrid[ni][nj] > 9)
                            {
                                hasFlashed.Add((ni, nj));
                                q.Enqueue((ni, nj));
                            }
                        }
                    }
                }
                flashes += hasFlashed.Count;
                foreach ((int i, int j) in hasFlashed)
                {
                    octopusGrid[i][j] = 0;
                }
                flashId.AddRange(hasFlashed);
                return hasFlashed.Count == n * n;
            }
        }
    }

}
