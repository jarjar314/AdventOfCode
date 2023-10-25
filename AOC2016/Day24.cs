﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day24
    {

        public static void Main()
        {
            var input = @"#####################################################################################################################################################################################
#.....#...#.#...............#...........#.......#.#...#.......#...#.......#.....#.............#.........#...#.........#.......#.#.#4....#.....#...#.......#.........#.#.....#.......#
###.###.#.#.###.###.#.#####.#.###.#.###.#.#.#.#.#.#.#.###.###.#.#.#.###.#.#.###.#.###.#.#.#######.#.#.#.###.#.#.#.###.#.#####.#.#.###.###.#.###.#.###.#.#.#.###.###.#.#.#.#.#.#.#.###
#...#.....#.....#...#.......#.#.#.#.#...#.....#.#...#.....#...#...#.#...#.#.......#.....#.#.........#...#.#.#...#...#.........#...#.......#.#...#.........#.#...#...#.#.#.#.....#...#
#.###.###.#.#.#.#.#######.#.#.#.#.#.###.#.#.###.#.###.#.###.#.#.#.#########.###.#.#.#.###.###.#.###.###.#.#.#.#.#####.#.###.#.#.###.#.#.#.#.###.###.#.#####.#.#####.#.###.#.###.#.#.#
#.#.....#.#.....#.....#...#.....#.#...#...#.#.......#.#.#.....#.......#...#...#.#.#.#.....#...#.#.#.....#...#.#.#...........#...#...#.#.#.....#...........#.#.#.......#.............#
#.#####.#####.#.#####.#.#.#.###.#.#.#.#.#.#####.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.###.#.###.#.#.#.###.#.#.#.###.#.#.#.###.#.#.###########.#.###.#.#.#.#.#.#.#.#####.#.###.#.#####.###.#.#
#...#.....#.......#.#.#.#...#...#...#.#.#.......#.....#.........#.#...........#.#.........#.#.....................#.......#.....#.............#.........#.....#.....#...#.#.#.......#
#.###.#.#.#.#.#.#.#.###.#.#.#.#.#.#.#.#####.#####.#.###.#.#.###.#.#####.###.#.#.#.#######.#.#.#######.#.#.###.#.#.#.#######.###.###.###.#######.#.#####.#.#.#.#.###.###.#.#.#######.#
#...............#...#.#6..#...#...#...#...#.........#...#.#.....#.....#...#.#.....#.......#...#.#.....#...#.....#.........#...........#.#...........#...#0..#.............#.#...#...#
#.#.#####.#########.#.#####.#.#.#######.#.#.#.#.###.###.#.###.#.#####.#.#.#.#########.#.#######.#.#.#.#.#.#.#.#.#.###.###.#.#.#######.###.#########.#.#.###.#.#.#.#.#.###.#.#.###.#.#
#.#.....#.#.#...#.....#.....#...#.............#...#.......#...#...#...#.#.#.....#.#...#.......#.#...#.......#.#...#...#.......#.....#...#...#...#.#...#.....#.#...#...#.#...#.#...#.#
#.###.#.###.#.#.#.###.###.#.###.#.#.###.#####.#####.#.#####.###.#.#######.###.#.#.#########.###.#.#.#.###.#.#.###.###.#.###.###.###.#.#.#####.###.#.#.###.#.#.###.#.###.#####.#.###.#
#.#.........#.#.........#.......#...#.........#.................#.....#.#.......#.#.....#.#.....#.#.........#.....#.#.......#.#.............#.....#...#.....#.....#.......#.......#.#
###.#####.#.#.#.#.#.###.#.#.#.#.#.#.#.#.#.###.#.#.#.#.###.###.#.#.#.###.#.#.###.#.#.#.###.#.#.#####.###.###.#.###.#.###.###.#.###.#.###.#####.#.#.#.#####.#.#.#.#####.###.#.#.###.#.#
#...#...#.#...#.....#...#...#...#...#.#.......#.#.#.....#...#.#.....#.........#.#...#.......#.......#.#...#.....#...#.............#...............#.....#.#.....#...#.#...#.........#
#.###.#.#.#.#.#.#.#.#.#####.#####.#.#####.#######.#####.#.#########.###.#.###.#.#.###.#.#.#.#.#.#.#.#.#.#.###.#.###.#.#.#.#.###.#.#.#.###.#####.###.#.#.#.#.#.#.#.#.#.#.#.#.#####.###
#.#.....#...#.......#...#.#.#.#.#...#...#...#...#...................#...........#.....#.#...#.........#.#.......#.#...#.#.#.#...................#...#...#.#...#.....#.#1#.....#.....#
###.#.#####.#.#.#.#.###.#.###.#.#.#.#.#.###.#.#.#.#.#.#.#####.###.###.#.#.#.#.#.#.###.#.#.#.###.#######.#.###.#.#.#.#.###.#.#########.#.#.#.#.#.###.#.#.#####.###.#.#########.#.#.#.#
#.#...#.....#.....#...#.#.#...#.......#...#.....#.#...#.....#...#.....#...#.#.....#.......#...#...#.......#...#...#...#...#...........#.#.....#...#.........#.#.....#.#.#.......#...#
#.#.#.#.#####.#.#.###.#.#.#.#.#.###.#.###.#.#.###.#.#.###.#.###.#.###.#####.#.#.#.#.#.#.###.#.#.#.#.#.###.#####.#.#.###.#.#.###.#.#.#.#.#.#.#.#####.#.#.###.#.#.###.#.#.###.#.#.###.#
#.....#7#.#...#.#.................#...............#.#.#...#.#...#.#...#.....#...#.....#...#.#.#.......#...#...........#...........#.#.....#...#.........#.#.......#.#.#.....#.......#
#.#.#.###.#.#.###.#.#.#.#.#.#.###.#.#.#.###.#.###.#.#.#.#.#.#.#.###.#.#.#.#####.#.#.#.###.#.#.#####.#.#.###########.#.#####.#.#.#.###.#.#.#.#.#####.#.###.###.#.###.#.#.###.#.#######
#.#.....#.#.#.#...........#.#.#.......#...........#...#.......#...#.#...#.....#.#.....#...#.....#.#.......#.#.#.......#.#.......#.............#.#...#.#.#.#...........#.......#.....#
#.#####.#####.#.#.###.#.#.#.#.#####.#.#.#.###.###.#.#.#.#.#######.#.#.#.#.###.#.#.#.#.#.#.#######.#.###.###.#.#.#.#.#.#.#.#.#####.#.#.#######.#.#.###.#.#.#####.###.###.#.#.#.#.#.#.#
#.......#.#...#.....#...#.......#...#...#.....#...#.#...#...#.....#.#.#.#.....#.#.....#.....#...#...#...#.....#.#...#.#...#...#.............#.#...#.....#...#.....#.....#.#.....#.#.#
#.#.#####.#.###.#########.###.#.#.#.###.#.#.###.#.#.#.#.#.#.#.###.#.###.###.###.#####.#.###.#.#.#.#.#.#.#.###.#####.#.#.#.#.#.###.#.#.#.###.#.###.###.#.#.#.#.###.#.###.###.###.#.###
#...#.....#.#.#.#.........#...#.....#.........#...#.....#.....#.....#...................#.......#...#...#.....#.......#...#...#.......#.....#.#...#.#...#.#.........#.#.#...#.#.#...#
###.#.#.#.#.#.#.#.###.#.#.#######.###.#######.#####.#.#.#.###.#.#.###.#######.###.#.###.###########.#.#####.###.#####.#.#######.#########.###.###.#.#.#.#.#.#.#.#.#.#.###.#.#.#.#.#.#
#.....#...............#.............#...#.#.#.........#.#.....#...#.....#...#.....#.#.....#...#.#...#.#.....#.........#.#...............#.#.#...#.......#.#.....#.#...............#.#
#.#.###.#.###.###.#.#.#.#.###.#.#.#.#.#.#.#.#####.#.###.#.#.#.#.#.#.#.###.#.###.#.#.#.#.#.###.#.#.#.###.###.#.#####.#.#.#.#.#.#.#######.#.#.###.###.#.#.#.#.#.#.#.#.#####.#####.#.###
#...#...#...............#.......#...#.....#.....#.#...#.........#.#...#...#.....#...#.#...#...#...#...#.....#.#.....#.....#.#...#.....#.........#.........#.......#.......#3........#
#####.#.###.#.#.###.#####.#.#.#.###.#.#.#####.#.#.###.#.#.###.#.###.#.#.#.#.#.#.#.#.#.#.#.###.#.#####.#.#.#.#.#######.###.#.#####.#.#.#.#####.#.#.#######.#.###.###.#.#####.#.#.#.#.#
#.#...#...#...#.......#.....#...#.#...............#.#...#...#.#.....#.#.....#.#.#...#...#.........#.....#...#...........#.#.#.........#...........#...................#.....#.#.....#
#.#.###.#.#.#.#.#.###.#.#.#.#.#.#.#.#####.#.#######.#.###.###############.#.###.#.#.#.#.#####.###.#.#####.#.#.#.#.#.###.#.#.#.#.###.#.#.###.#.#####.#.#.#####.#########.#####.###.###
#.#.#.....#.....#...#...#...#.....#.........#.#...#...#.........#...#...#.......#.............#.............#.#.....#.#...#.#.......#...#.#.#...#.....#.#.......#...#...#.....#...#.#
#.#.#.#.#.#######.#.#.###.###.###.###.#.###.#.#.#.#.#.#.#.#.###.#.#.#########.#.#.###.###.#.#.#.#.#.#.#######.#.#####.#.#.#######.#.#.#.#.###.#.#.###.#.#####.#.#.#.#.#.#.#######.#.#
#.#.#.#...#...........#.#.....#.#...#.#.#.#.......#.#.....#...#.#...#.#.#...#...#.#.#.......#...#.#.....#.........#.....#.....#.#.....#...#.#.....#...#...#.......#.....#.....#.....#
#.#.#.###.#.#.###.###.#.#.#.#.#.#######.#.###.#####.###.#.#.#.###.#.#.#.###.#.###.#.###.#.###.#.#.#.###.#.#.#####.###.###.#.###.###.#.#.###.#####.#.#.###.###.###.#.###.###.#.#.#.#.#
#...#.................#.............#...#...#.......#.....#.#.#.........#...#...#.......#.#...#.....#...#.#.......#.#.......#.#...#.#.#.............#.....#...#.#...#.....#.#.#.....#
#.#.#####.#.#.#.###.#.###.#########.#.#.###.#.#.###.#.###.#.###.#####.#.#.#.#.#.#.#####.#.#.#.#####.#.#.#######.#.#.#.#####.#.#.#.#####.#.#.#.###.#####.#.#.###.#.#.#.###.#.###.#.#.#
#5....#...#.#...........#...#...#.#.#.#...#.#.#.....#...........#...#.#.......#.....#...#.........#.#.#.#.......#.#...#...#...#.#.#........2#...#.#...#...#.#...#.#...#.......#...#.#
#####################################################################################################################################################################################";
            var grid = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = grid.Length;
            int cols = grid[0].Length;
            var nodes = new Dictionary<int, Node>();
            int targetMask = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (char.IsDigit(grid[r][c]))
                    {
                        int id = grid[r][c] - '0';
                        var node = new Node() { Id = id, R = r, C = c };
                        nodes[id] = node;
                        targetMask |= 1 << id;
                    }
                }
            }
            foreach (var kvp in nodes)
            {
                Flood(kvp.Value, grid);
            }
            int minimumToReturn = int.MaxValue;
            int minimumFirstFullPath = int.MaxValue;
            var q = new Queue<(int distance, int id, int currentMask)>();
            q.Enqueue((0, 0, 1));
            while (q.Count > 0)
            {
                (int dist, int id, int mask) = q.Dequeue();
                var node = nodes[id];
                if (mask == targetMask)
                {
                    minimumFirstFullPath = Math.Min(dist, minimumFirstFullPath);
                    minimumToReturn = Math.Min(dist + node.distances[0], minimumToReturn);
                }
                foreach (var next in node.distances)
                {
                    if ((mask & 1 << next.Key) > 0) // already went to this point so no reason to go back , and to go to another one with this one either, we can go through.
                        continue;
                    q.Enqueue((dist + next.Value, next.Key, mask | 1 << next.Key));
                }
            }
            Console.WriteLine($"should be first full path with distance {minimumFirstFullPath}");
            Console.WriteLine($"should be first full path with distance and puting the robot back in place {minimumToReturn}");
        }
        private static int[] d = new[] { 1, 0, -1, 0, 1 };
        private static void Flood(Node value, string[] grid)
        {
            int startRow = value.R;
            int startCol = value.C;
            var visited = new HashSet<(int r, int c)>();
            var q = new Queue<(int r, int c, int distance)>();
            q.Enqueue((startRow, startCol, 0));
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                int r = p.r, c = p.c, distance = p.distance;
                for (int i = 0; i < 4; i++)
                {
                    int dr = r + d[i];
                    int dc = c + d[i + 1];
                    if (grid[dr][dc] == '#') continue;
                    if (visited.Contains((dr, dc))) continue;
                    visited.Add((dr, dc));
                    if (char.IsDigit(grid[dr][dc]))
                    {
                        var nextNode = grid[dr][dc] - '0';
                        value.distances[nextNode] = distance + 1;
                    }
                    q.Enqueue((dr, dc, distance + 1));
                }
            }
        }
    }

    public class Node
    {
        public int R;

        public int C;
        public int Id;
        public Dictionary<int, int> distances = new Dictionary<int, int>();
        public Node()
        {

        }

    }
}
