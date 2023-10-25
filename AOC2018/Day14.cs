using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day14
    {
        public static void Main()
        {
            var input = @"################################
#################..#############
#################.##############
#################.####..########
############G..G...###..########
##########...G...........#######
##########.#.......#.G##########
########...#.....#...G..########
#######G.###............G#######
###########..G..#.......########
####..#####............#########
###.G.###.......G.....G.########
###..#####....#####.......######
####..#####..#######........E..#
#.##..####..#########.........E#
#....###.GG.#########........###
##....#.G...#########.......####
#....G...G..#########......#####
#..........G#########.....######
#.....G......#######......######
#........##...#####.......######
#G###...##............#....#####
#..#######................E#####
#.########...............#######
#..#######..............########
#####..#....E...##.......#######
#####.G#.......#.E..#EE.########
#####...E....#....#..###########
#######.......E....E.###########
#######.###....###.....#########
#######.####.######.....########
################################";
            var grid = new List<char[]>();
            foreach (var line in input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                grid.Add(line.ToCharArray());
            }
            int m = grid.Count;
            int n = grid[0].Length;
            var units = new List<IUnit>();
            var goblins = new List<IUnit>();
            var elves = new List<IUnit>();
            var paths = new Dictionary<(int r, int c), List<(int r, int c)>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 'E')
                    {
                        var unit = new Elf() { Row = i, Col = j, AP = 3, HP = 200 };
                        units.Add(unit);
                        elves.Add(unit);
                    }
                    else if (grid[i][j] == 'G')
                    {
                        var unit = new Goblin() { Row = i, Col = j, AP = 3, HP = 200 };
                        units.Add(unit);
                        goblins.Add(unit);
                    }
                    if (grid[i][j] != '#')
                    {
                        paths[(i, j)] = FindPath(i, j);
                    }
                }
            }

            List<(int r, int c)> FindPath(int row, int col)
            {
                var res = new List<(int r, int c)>();


                return res;
            }



        }
    }
    public enum Classification
    {
        Elf = 0,
        Goblin = 1
    }
    public interface IUnit
    {
        public Classification GetClassification();
        public int Row { get; set; }
        public int Col { get; set; }
        public int AP { get; set; }
        public int HP { get; set; }
        public void Hit(IUnit unit);
    }
    public class Goblin : IUnit
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int AP { get; set; }
        public int HP { get; set; }

        public Classification GetClassification()
        {
            return Classification.Goblin;
        }

        public void Hit(IUnit unit)
        {
            unit.HP -= AP;
        }
    }

    public class Elf : IUnit
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int AP { get; set; }
        public int HP { get; set; }

        public Classification GetClassification()
        {
            return Classification.Elf;
        }
        public void Hit(IUnit unit)
        {
            unit.HP -= AP;
        }
    }

}
