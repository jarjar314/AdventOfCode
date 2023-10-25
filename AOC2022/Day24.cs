using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2022
{
    /*
     * 
     * 
     * 
     * 
     * 
     */
    public class Day24
    {

        public static void Main()
        {
            var input2 = @"#.######
#>>.<^<#
#.<..<<#
#>v.><>#
#<^v^^>#
######.#";
            var inputs = input.Split(new char[] { '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rmax = inputs.Length - 2;
            int rmin = 0;
            int cmax = inputs[0].Length - 2;
            int rounds = lcm(rmax, cmax);
            var map = new bool[rounds][][];
            var directions = new Dictionary<char, (int dr, int dc)>() { { '>', (0, 1) }, { 'v', (1, 0) }, { '<', (0, -1) }, { '^', (-1, 0) } };
            var blizzards = new HashSet<(int r, int c, (int dr, int dc) direction)>();
            for (int r0 = 0; r0 < rmax; r0++)
            {
                for (int c0 = 0; c0 < cmax; c0++)
                {
                    var ch = inputs[r0 + 1][c0 + 1];
                    if (ch == '.') continue;
                    blizzards.Add((r0, c0, directions[ch]));
                }
            }
            for (int round = 0; round < rounds; round++)
            {
                map[round] = new bool[rmax][];
                for (int r0 = 0; r0 < rmax; r0++)
                {
                    map[round][r0] = new bool[cmax];
                    for (int c0 = 0; c0 < cmax; c0++)
                        map[round][r0][c0] = false;
                }
            }
            foreach (var b in blizzards)
            {
                int r0 = b.r, c0 = b.c, dr = b.direction.dr, dc = b.direction.dc;
                for (int i = 0; i < rounds; i++)
                {
                    map[i][((r0 + i * dr) % rmax + rmax) % rmax][((c0 + i * dc) % cmax + cmax) % cmax] = true;
                }
            }
            //            map[rounds][row][col] = true si un blizzard y est et que je ne peux pas m'y déplacer.

            int time = GoTo(-1, 0, 0, rmax, cmax - 1);
            Console.WriteLine($"PROCESS 1: {time}");
            time = GoTo(rmax, cmax - 1, time, -1, 0);
            Console.WriteLine($"PROCESS 2 way back:{time}");
            time = GoTo(-1, 0, time, rmax, cmax - 1);
            Console.WriteLine($"PROCESS 2 done:{time}");


            int GoTo(int sr0, int sc0, int t0, int tr0, int tc0)
            {
                var q = new Queue<(int r, int c, int time)>();
                q.Enqueue((sr0, sc0, t0));
                int[] dx = new[] { 0, 0, 1, 0, -1, 0 }; // WAIT, RIGHT, DOWN, LEFT, UP
                var visited = new HashSet<(int, int, int)>();
                while (q.Any())
                {
                    var p = q.Dequeue();
                    int r0 = p.r, c0 = p.c, t = p.time;
                    if (r0 == sr0 && c0 == sc0 && !visited.Contains((r0, c0, t + 1)))
                    {
                        visited.Add((r0, c0, t + 1));
                        q.Enqueue((r0, c0, t + 1)); // we can always wait in entrance.
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        int nr = r0 + dx[i], nc = c0 + dx[i + 1];
                        if (nr == tr0 && nc == tc0)
                        {
                            // FINITO
                            Console.WriteLine($"PROCESS to [{sr0}, {sc0}] to [{tr0}, {tc0}] done at {t + 1}");
                            return t + 1;
                        }
                        if (nr == sr0 && nc == sc0 && !visited.Contains((nr, nc, t + 1)))
                        {
                            visited.Add((nr, nc, t + 1));
                            q.Enqueue((nr, nc, t + 1));
                        }
                        if (nr <= -1 || nc <= -1 || nr >= rmax || nc >= cmax) continue;
                        if (map[(t + 1) % rounds][nr][nc]) continue; // il y aura du blizzard, on ne bouge pas.
                        if (visited.Contains((nr, nc, t + 1))) continue;
                        visited.Add((nr, nc, t + 1));
                        q.Enqueue((nr, nc, t + 1));
                    }
                }
                return -1;
            }

        }

        static int lcm(int a, int b)
        {
            return a / gcd(a, b) * b;
        }
        static int gcd(int a, int b)
        {
            while (a % b > 0)
            {
                var R = a % b;
                a = b;
                b = R;
            }
            return b;
        }
        static string input = @"#.######################################################################################################################################################
#.v><><<>^^^<><<>.^v<>v^>v^v^^<..^v>^>^vv.>v^<<>^.v<vvv<.>><v>><^>><>^<><v<>>>><v>v<^<>^.v..v^vv<v<<vv.v>>v<>v.<..^<vv<^v^v.v>>v>><^v>^<.vv^^<<><<>v>><#
#.vv<vv<>.v<<<<<>>vv<>^v^^<^<>><.<^>^<^>^<v<<<<v>v>><.><.^><>vv<^^><<<<>^<.<v^.vv^vv>v>^.<<<><v<.v.<><<v^^v>^^<^>>^.<v^v.v><<v^vv<<v>^v>><^^<^<v>^>><v<#
#<v^>v^vv<><v><<^<>^<^vv>v>>^^><<<vv><v.v.^><<^><>v>^<^v<<^>v<vv><v<<^.vv^>>>.^v>v.><v>v<^<^^<><<>><<^^^>v<^>>^v>>vv.<>^<><<^v>><^.>v^v><<^^^^<v<>^v<v.#
#<<^<vv^<^><>^><>^vv.v^v>><^^<>^<>>^><^.^^<.v...>^^.^<<v<vvv>>>v^..^v.v<^><>.>v^.vv<^^vv>vv^.^.vv<v>>^>v.^^^<v<>><vv^>>^^.v>.v^^<^>vvv^<<v^<v<^><^>v<>>#
#<.<^>>^<v><^>^^.>>v^<v^vvv>>vv.v^<>^^>v<<vv^<>^v.<<<^>>>.^>vvv.^^^<^><<^><v>><^.^>vv^^vv.><<v<^<v^^^.>v>^>v.^^<<^^^>^><><<vv<.<>v>vv>><^^v>>vvv^<...<<#
#><v.v>vv>^^^>>><v>^^v>^>>><vv^<^<^<<<>.<<.<.<..><><v.v^^.v..v^>>>^v><.^^><<>v^<^<>^>>.v^v.v.>v>^>>>v>>^>><^<.v.v<^<<<<<^^>^^^^>^^<v^>>v><>.<>v><>.>><>#
#<><<.>^<>^^v<v>^><^>v^.>><vv^vv^<v<<>.>.>>.vv.v<.^<^<>>^><><^.v>>v^^v><>><<<vv<<>v><>^.>>^>v^^><^<v<<><vv^>>.<^<.^<^>vvv>^<.v<^<>.><.>>v<^>^v<<.^<v>^<#
#<>.<v^>.^<<^v^.<<^>v^^vv<^><^<^>><v^^vvv<<vvvv>>^v><<>^>vvvvv^<<v^.>^<.<^>.^>^><v^<>>.<<^^vv>>>^>vv><vvv^v.>^vv><<<<>^v^^^.>.^>>^^v^v>v>vv^<<^vv^<>v<>#
#<<>v>v>>v^^v><^<.vv<^>^^>.v^<.^^vv>.<>^<>v>^>vvv<vv^>v^><<<v>vv<..^v^v>v.v><^.<^>.v<v><v>v^>^<<<<<>^.v<^.<v.<<^>v^^^<^<<>v.<<^<<<<.<^><<<^<v<v>>v>.><>#
#>>.>vvv<<..>^^vv^>.<.v..v^^>^v<<>>>vv.<v>vv^<vv^v><v^^.<<.><..><^><<>^<<><v<.<v.<^<^.^<^<<><><<^v^>.<<v^^>.^<...v.^<^^<><><>v^<><^>^>^v^.>^^>^.vv.<v^>#
#>.<><v>v<v>v>^v^^v>.v^.v>v>.<>>>^vv<<v>>^>^.^<^vv.vvvv<<>v<^^.>v<^v<<^><^.^^v<>.v<vv><v<v>vvv>^^>v>..<<<v..>v..<^^^<v>^^<<vv<>>^^v^.vv<><^>>.^<<^>>v.>#
#><v..vv^<v^<>>v<>..<^>v^^><.>vv^vv^<^^v<>vv<.vv^^<>^>>^v<^^<<>^vv>v><>v<^vvv^<>><>^^^v^<v.v^<<^^>>>>><^^>><^v>>vv^v><^>^<<^.v>vv>^.v^<vv^v>>>vv>v^v<^>#
#...>><v.<v<>^.v.v..^>^<><vv^><<<vv^<vv.><^.vv>>><v^v^>^v>>v<.^<^^<v^<>v<^<><<<.^<<vv.<>>^v^^.v>.<v>^.^>v^.v><^<<>>>^.<<<^v<<<><^>.^.^v><>^>><vv<v.<.^>#
#<^vv>>v>v<^><^^^<^>vv<>vv>^^^.><><^>v>><v.<>vv^^<^<<<v^<><v>v^v>^<><><><><>^^>><>..^^>v<...vv<^>><.vv<^<v><v<vv^.><>v^<>v.^>>>v<<^<<^vv.>^<.^<>^<v^^^>#
#>>^vv^.<<.<.<>>vvv<<<..<v><^<>^><<>^.<<^^^<v^<<v.<vv<^<>>vv^>.v^v<^<>>vv<<^>>.v>.v>^^^vvv^v<^><v^><>><^<.>v^^^<vv^>^v<v^<vv><>..^><.>^^<^>>..^.v^<^<v>#
#<<><^^><v^v<^^<vv>><v..>>>^><>>>v>v>v>v><>>^vv><>>v>>vvvv<<^><>v^>vv>^.>>v.^<v<^.>>>^^v>>><vvv>><.<v<^<v<^v<v<<vvv..^^<<^<.<><<<<^<>v<<<^^>.^v>^^v<^^<#
#>v^^^<v>^^<v<<<vv><^v.v<v^^^vvv<<><><^^><^^>>>>>><^>^^.>vv>^><<<v<<<^vv.^^^<v>v<^^^^>.^^vv<^<.<v^<vv^^^>><..><^>v><<v>v>^v^>>^^>vv.v^^^>^^vv.<<v.^><<.#
#<^v<<^^vvv.>v>v>.v><v<^^>^>^>^^v>v^vv^<.^.>>>>>v<>.<<.<^<<vvv..<^>^><^>^<^<<>><^>v<v^v>^v^^^>>>>v>^>>^<v..><.>>^^><^<^.<v^>^.v>^^vv^v.<>>>>.v.<<>^^vv>#
#<v^v.>.>^v>^<v.<^<^>v^>^^.>.>v<>>>^>vv<>v<>^>v^<<^<.<<^>v^<><>><^^<^^v<>>vv<<.<>v>.>^^^>><^^<^vv.><v<.<<^^>^>><>v><^vv.>v^v^v..<vvv..<<v<v^<<v>^<^>><<#
#<^v<v^^v^>^<>v^<^<>>..>><>v<.^<.>v.>^v.>>^^<^v>>v^.v>^><>>vv.<<<>v>^.>v>..<<<v.<v^<>^>^<>v<^<v<><^>^v><.<<^^^<^.<<<^.^v^^.>^.<<vv>^v><<>^<^v^^>^v><<^>#
######################################################################################################################################################.#";
    }
}
