using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day22
    {
        private const int modulo = 20183;

        public static void Main()
        {
            int depth = 7740;
            int X = 12;
            int Y = 763;
            ComputeRiskLevel(510, 10, 10);
            ComputeRiskLevel(depth, X, Y);
            FindPath(510, 10, 10);
            FindPath(depth, X, Y);
        }
        private enum Equipment
        {
            Neither = 0,
            Torch = 1,
            ClimbingGear = 2
        }
        private static int[] move = { 1, 0, -1, 0, 1 };
        private static void FindPath(int depth, int X, int Y)
        {
            var erosions = new Dictionary<(int x, int y), int>();

            var q = new SortedSet<(int time, int x, int y, Equipment equipment)>();
            var visited = new HashSet<(int x, int y, Equipment equipment)>();
            q.Add((0, 0, 0, Equipment.Torch));
            int timeToFind = int.MaxValue;
            while (q.Count > 0)
            {
                var first = q.First();
                if (first.time >= timeToFind)
                {
                    Console.WriteLine(timeToFind);
                    return;
                }
                q.Remove(first);
                if (visited.Contains((first.x, first.y, first.equipment))) continue;
                if (first.x == X && first.y == Y)
                {
                    if (first.equipment == Equipment.Torch)
                    {
                        timeToFind = Math.Min(timeToFind, first.time);
                    }
                    else
                    {
                        // need to equip the torch
                        timeToFind = Math.Min(timeToFind, first.time + 7);
                    }
                    continue;
                }
                visited.Add((first.x, first.y, first.equipment));

                int type = ErosionLevel(first.x, first.y) % 3;
                for (int i = 0; i < 4; i++)
                {
                    int nx = first.x + move[i];
                    int ny = first.y + move[i + 1];
                    if (nx < 0 || ny < 0) continue;
                    int destType = ErosionLevel(nx, ny) % 3;
                    if (CanMoveIn(destType, first.equipment))
                    {
                        q.Add((first.time + 1, nx, ny, first.equipment));
                    }
                    else
                    {
                        // change gear
                        q.Add((first.time + 7 + 1, nx, ny, (Equipment)(3 - type - destType)));
                    }
                }
            }


            int ErosionLevel(int x, int y)
            {
                if (erosions.TryGetValue((x, y), out var res))
                    return res;
                if (x == 0 && y == 0 || x == X && y == Y)
                {
                    res = (0 + depth) % modulo;
                    erosions[(x, y)] = res;
                    return res;
                }
                if (x == 0)
                {
                    res = (y * 48271 + depth) % modulo;
                    erosions[(x, y)] = res;
                    return res;
                }
                if (y == 0)
                {
                    res = (x * 16807 + depth) % modulo;
                    erosions[(x, y)] = res;
                    return res;
                }
                res = (ErosionLevel(x - 1, y) * ErosionLevel(x, y - 1) + depth) % modulo;
                erosions[(x, y)] = res;
                return res;
            }
        }

        private static bool CanMoveIn(int destType, Equipment equipment)
        {
            return destType != (int)equipment;
        }

        private static void ComputeRiskLevel(int depth, int X, int Y)
        {
            var erosion = new int[Y + 1][];
            for (int row = 0; row <= Y; row++)
            {
                erosion[row] = new int[X + 1];
            }
            for (int row = 0; row <= Y; row++)
            {
                erosion[row][0] = (row * 48271 + depth) % modulo;
            }
            for (int col = 0; col <= X; col++)
            {
                erosion[0][col] = (col * 16807 + depth) % modulo;
            }
            for (int row = 1; row <= Y; row++)
            {
                for (int col = 1; col <= X; col++)
                {
                    erosion[row][col] = (erosion[row - 1][col] * erosion[row][col - 1] + depth) % modulo;
                }
            }
            //Console.WriteLine(string.Join("\n", erosion.Select(row => string.Join("", row.Select(level => (level % 3) switch
            //{
            //    0 => '.',
            //    1 => '=',
            //    2 => '|',
            //    _ => '?'
            //}
            //)))));
            Console.WriteLine(erosion.Select(er => er.Select(level => level % 3).Sum()).Sum() - erosion[Y][X] % 3);
        }
    }

}
