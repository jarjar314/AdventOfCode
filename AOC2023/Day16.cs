﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace AOC2023
{
    public class Day16
    {

        public static void Main()
        {
            var input = @"\....\..-...........|..\........|.........|./.\..............\................/.....-............./...........
......-........../.........--........................|..-../.............................-\.....|.............
....-.-........................................................../..........................|...|......\|.....
....\.-......\|...............................-|........\.............................../......\..............
..|.|.|...-..-...-..................--........../.......................|.\-.../....................-....\....
....\...................|..............|..../../.......................\......................................
...............\.|..............\........\.\.-...--..-...\........................|.|.........................
..........-........\............-....|...|.............\.\...............\./............./....................
...\.....\.\...............||...........................................-...............-...../...|...........
......./......./....-..../...-........./././\..||.......-.|.......\.........\|................./........-.....
......................|./...|......................./...|....\................-....|....|.\...|.../......../..
.\...........\-......\.\|..\\..-|//../............/...............................-........|..|............-..
..|.............../.............|..-./..\....-|...........................-.|......|....\\......-..../...\....
............\......\|.../...............-......./.........\.\.\.../.|.........................................
....\-......./-........../....................|.........-......../........-.............\..|...../...-........
|.................|....................-.............|...........-.-....-...-......-................./|.\.....
|................/......./.........|.........................-/...........|.................\-/|.........\../.
...................-..............\................|..../.||.-....\...............-......................\..\.
.......|......\..-....-...............\.....|../..\..-...........|......../....\.././..........\.|........-..\
..\..|............|....\......../............-.\.................................-............-............\..
.........|.....\...........................................|....|............../..-.............../...........
...........-................................\...../....|.....|..............|.................................
./........................\..\...........................|.|................................-.................
......|\./....................|..../.........\......|.\..-.|.....|........./........|.........-.-.............
.........\.....................-.................\.....|...................../........./..............|.......
.................-.........\........\.....-...................\.....-..\........../........................./|
............|...........-....\..\............-....-........................|...|........../.............\.....
........................................../............/..................\............\..../......\../.......
......../..........-.....-...................../......................-......\..../..\.-...../....|.|....-....
\.........\.......-.................\.......\-......|.......\......................\......................-...
.........../.................|....................................|...\..../.../|.............................
..\.......................\...........-..\...../.................\.\..-................-...........|..........
...../.../............................\............................../.-../........\.-...|....................
...|....\.\...\...........-............\.............|............\.........................../........./.....
........../......../................/.../........................|............-......................\......./
.../............................-.....-...|.......\....................|...............\......................
......|..-|\..\............../.\.............-....-.......\................./.././/......../.....|....../|....
.............\.........\.......\........-...........||.......|...-.............\........./................/.|.
...\...../.-.....................-..........................-..-............../...../......|..|......|......\.
...|................|.............................|........./....\.....\...................................\..
..............-......................../........\.......................|.\/................-.........\.......
.\........\..\.....-.......\.-.-......................\..-........../................../..................--..
........|.....-.......|.../../..........|........\..|...../..\....../..|...............\|.....................
..........|...../........|....../..........-..-................../....-..........|............................
|...............-......../......./..................\.............\..........|.......\............||..........
........|.........|...............|.........../|..-\..........|....|...\..|\.\...............|-..-............
/......./.............-.....-.......\......-./.......\..\............|...\..\...../...............-.\.........
.-.........|....../.............|........|.......|.....-..............-....../............|............-/\....
..-...|........-...............-........\......../.-........................-................../-.......|.....
...\.-.....................-............................\...................||.....-..........\......\..../...
..........\./........\.||\...|..........-...../.......\.///......../...|...................../....--..........
.....\........./../.............-|...-..---.................../....|...\.../.....|./..........|...../.........
/..........-...../........-.................../..................\./.|..............-...-...............|.....
............\.............\..................................\|....|.../.....|..........\..................|..
...........\........./......\.................................../...-.....\.............\..|...........-......
.............\..-......................\.......|.../...............\.....-...|...|............................
................|-...................../|...|......................................\.............|.......|....
..|........./.................../...................../.....|.-...\............-.............................\
|.\........\.-..........|..|.........|\.-|\\.-....-...............................|....|...........-..|.....-.
./................|.|..|......\.....................-..........\........-...................../......|........
........../.........../............../...||..-.........|....\.\.......|..../.......|............./.-......./..
.........\.\.......-................/.../....|...................\.\|./...../........\.....................|..
..............|........-................|..............|.....-.-................\.........|......./......-....
.........................../.-.-...........................-................-.....-.............|.........\.\.
....|....|.../..........................|............................-...........--....../..|.............\\|.
......./...../..............-...............\|............/-..............................-/.....-.\..........
....-........-....\\.....|../.....-......../.............|.............|...../.......\\....../.........|......
......................-.../.................................................................-..../........|.-/
.................|...........-..|.-.......|............/................./......-.....................-.|.....
|...|.........\.|\..\....../..........-......\\......\.....................\/../.........../..../..-...|.|....
.|.|....|.....|\............./.|......-......-............/....-...-......../-|...............................
....../..............\............../....\..............\............|..\.........|....................|......
.........................\|.......-..........................................................\|...............
...............\.........|../.....-......\..................-.........................-..............-......|.
.....|...|.-...........................\..........\......\../.................-...............-........\......
.|........../........../..............|..../...../...|........-......../.\..........\......................-..
.............-|..................../.......-.../......-.../......./......|..........-./.......................
...\.........|.|...................|../.|...........|....................///....-.........-......./.......|...
.\........-.\..................................-\../...../..\......\...................../|.......-...........
........\..................\.......|...|................../\............|........-............\||.../..-../...
.............\..|/...................../....|.|...//....../|............\..\..|.......-..............-........
.........|/..................-............/....../............/....||.........................................
.|............-........|.........-//..........-................../........../..-...............|..|.......\...
........|.../......-..|.\..|..................|./....|.....-................................/.........../.....
..............-..........|......../.................................../.....\.............../.../..\..|/......
--................\...............|.........-.....|...../.........................-.....-.\\..........\.......
.......\.........\.................-..................../......\.....................\.................-......
....|....|......|...\.........\......../............/..../....\.......\...\....\.........|...................|
..........|....\\.............|........./.....|............../...-/...-.||......./......\.....................
..-./..-./.|...............-/.-.............|...............................\.....-...........................
/......|..|\........\........../...................-.\.......-...............-..\.......|.......|..-..........
./..\................................/.-..................-................-......../.......-.....|...........
............|..|.....\............\.\............\......|.-....../........\..|............../...........|.....
...|....|............|......../....|.|............./......................................|....../.|..-.......
............\......\........-.../....................-./....-.../.\....|........|......-...\........../.......
...........................-................./.......\...........................-.......\....................
.-.-.......|.......|.......-..................................../......-\......./..\.-.............-..........
.............../............-...................|..........................\.-..............\.................
..................................../|..............................|.../....\............/|.........\......./
.\...../\.-.........../....-.-|................./.../..../..........|..................................|.....-
..|......................\..................-...........\....-........\......-...-..-........................|
..-.......-......................\....-...........................|.......-../-...-......................|....
.............-..........................|..................................\./.........................-...../
....\......|........................|..................../........................|.|\.......\......../......\
.../........./..................\..../.../\............|.......|...\.\...../...\.....-...........|..|.\.......
....\../..................\...|.........|../..../.......................|..........-...|....\../............./
../......-......\.......\...........\|.......|...-./..........|................|../|......./..................
........../\/............................-.....|...-..|...............|.........................-.\...........
......................|..........\..................../..-........-...../.........-........./.........../.....
/.........-...................\.-\..............\...\....\.......\...|....................../.........|.......";
            var sample = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }
        //                        UP RI DW  LE
        static int[] dr = new[] { -1, 0, 1, 0 };
        static int[] dc = new[] { 0, 1, 0, -1 };
        private static bool isValid(int r, int c, int rows, int cols)
        {
            if (r < 0 || c < 0 || r == rows || c == cols) return false;
            return true;
        }
        private static void part1(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToCharArray()).ToArray();
            Console.WriteLine($"1st star answer is {FireBeam(inputs, 0, 0, 1)}");
        }

        private static void part2(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToCharArray()).ToArray();
            int maxi = 0;
            int m = inputs.Length, n = inputs[0].Length;

            for (int c = 0; c < n; c++)
            {
                maxi = Math.Max(maxi, Math.Max(FireBeam(inputs, 0, c, 2), FireBeam(inputs, m - 1, c, 0)));
            }
            for (int r = 0; r < m; r++)
            {
                maxi = Math.Max(maxi, Math.Max(FireBeam(inputs, r, 0, 1), FireBeam(inputs, r, n - 1, 3)));
            }
            Console.WriteLine($"2nd star answer is {maxi}");
        }

        private static int FireBeam(char[][] inputs, int startR, int startC, int startD)
        {
            int m = inputs.Length, n = inputs[0].Length;
            var visited = new HashSet<(int r, int c)>();
            var visitedWithDirection = new HashSet<(int r, int c, int d)>();
            var q = new Queue<(int r, int c, int d)>();
            visited.Add((startR, startC));
            visitedWithDirection.Add((startR, startC, startD));
            q.Enqueue((startR, startC, startD));

            while (q.Count > 0)
            {
                var (r, c, d) = q.Dequeue();
                if (inputs[r][c] == '.')
                {
                    gostraight(r, c, d); continue;
                }
                if (inputs[r][c] == '|')
                {
                    if (d % 2 == 0)
                    {
                        gostraight(r, c, d); continue;
                    }
                    else
                    {
                        split(r, c, d); continue;
                    }
                }
                if (inputs[r][c] == '-')
                {
                    if (d % 2 == 1)
                    {
                        gostraight(r, c, d); continue;
                    }
                    else
                    {
                        split(r, c, d); continue;
                    }
                }
                if (inputs[r][c] == '/')
                {
                    if (d % 2 == 0) turnright(r, c, d);
                    else turnleft(r, c, d);
                    continue;
                }
                if (inputs[r][c] == '\\')
                {
                    if (d % 2 == 0) turnleft(r, c, d);
                    else turnright(r, c, d);
                }
            }
            return visited.Count;

            void turnleft(int r, int c, int d)
            {
                gostraight(r, c, (d + 3) % 4);
            }
            void turnright(int r, int c, int d)
            {
                gostraight(r, c, (d + 1) % 4);
            }

            void gostraight(int r, int c, int d)
            {
                int nr = r + dr[d], nc = c + dc[d];
                if (!isValid(nr, nc, m, n)) return;
                if (visitedWithDirection.Contains((nr, nc, d))) return;
                visitedWithDirection.Add((nr, nc, d));
                visited.Add((nr, nc));
                q.Enqueue((nr, nc, d));
            }

            void split(int r, int c, int d)
            {
                turnleft(r, c, d);
                turnright(r, c, d);
            }
        }
    }

}