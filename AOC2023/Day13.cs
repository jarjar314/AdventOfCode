﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace AOC2023
{
    public class Day13
    {

        public static void Main()
        {
            var input = @".##.##....##...
.....#.#.#..#.#
.....#.#.#..#.#
.##.##....##...
..###.#.##..#.#
#.###.#.#######
##..#..###.####
##.#.#.######.#
..#.#....##..#.
..###..##......
....#...#.#...#
....#...#.#...#
..###..##.#....
..#.#....##..#.
##.#.#.######.#

##..#...#.#..#.
##.###...###..#
...#.#####....#
..##.#####....#
##.###...###..#
##..#...#.#..#.
..#..###.#####.

###......#.###.
#..#.##....##.#
##.#.##....##.#
###......#.###.
#..###.#..#....
..#.....##....#
#..##..###.#..#
#..##..###.#..#
..#.....##....#
#..###.#..#....
###......#.###.

#####..#..##..#..
##..#............
.##.##..######..#
#..#.#.#..##..#.#
.#.#..##..##..##.
...#....##..##...
##.#..##.#..#.##.
.##..#.########.#
..#####.##..##.##
.###.#.#.#..#.#.#
.###.#.#.#..#.#.#
..#####.##..##.##
.##..#.########.#
##.#..##.#..#.##.
...#....##..##...
.#.#..##..##..##.
#.##.#.#..##..#.#

#.#.#######
#...#.#.##.
##..#.#.##.
#.#.#######
##.#.##.##.
.##..#.#..#
#..#####..#
#.##.#.####
.##.####..#

......##...###.
.###.#.#..#.#.#
#.#....###.###.
..#..#.#####..#
#.#...#.#...##.
#.#...#.#...##.
..#..#.#####..#
#.#....###.###.
.###.#.#..#.#.#
......##...###.
.#..####...####
.####.######...
.####.#######..

...####...#.#..##
###....#####..#..
...####.....###..
.##....##..##..##
..######..##..#.#
...####.....#.##.
....##.....#.##..
##..##..###.#####
...#..#.....###.#
##.####.###.#....
##..##..##.#.####

#..###...###...
#.##..#.#...##.
#.#...#.#.####.
###....##...##.
##.....#.###...
.#.....#.##...#
.#.....#.##...#
##.....#.###...
###....##...##.
#.#...#.#.####.
#.##..#.....##.
#..###...###...
.##.####.#####.
.####.##...##.#
.####.##...##.#

..#.#####....
..#.#####....
#.#.#.###..#.
.#.#.....#.##
..#.###.....#
.##...##.....
#....#.....##
..####.#.....
.#.###..##.##
#..#####.#.##
#..#####.#.##
.#.###..#####
..####.#.....

.#.##.###..
#...##.#.##
..#.#...#.#
..#.#...#.#
#...##.#.##
.####.###..
##..#.##.#.
.####.#...#
...###.#.##
.#.#...###.
.#.#...###.
...###.#.##
.####.#...#
##..#.##.#.
.####.###..

.#..#..#..##.
##..#..#..##.
####..#...###
.#..####....#
.###.#.#....#
.#.##..#..#.#
.....##......
....##..#..#.
###.##.#..##.
#.#....###...
#.#....###...
###.##.#..##.
....##..#..#.
.....##......
.#.##..#..#.#

..##..#
####.#.
...#...
...##..
####.#.
..##..#
..#.#.#

.##.##.##....##
#..#..#..####..
#..####..#.##..
#.#.##.#.#..#.#
..######..##..#
###.##.########
#.######.####.#

#.##.##..##.#
..##..######.
...#.##.###..
.#..##.#.#.#.
.#.#.#.##..##
.#.#.#.##..##
.#..##.#.#.##
...#.##.###..
..##..######.
#.##.##..##.#
##..#...#..#.
.#.#..#..##.#
##..#####.#..
##....##.#.##
##....##.#.##
##..#####.#..
.#.#..#..##.#

#.##.##
...##..
##..##.
#...#..
#...#..
##..##.
#..##..
#.##.##
##.#..#
##.#..#
#.##.##

....##.....
##.####.###
##..##..###
.########..
.#......#..
.########..
..######...
###.##.####
..#.##.#...
....##.....
##.#..#.###
####..#####
##.####.###
..#....#...
##..##..###
##.####.###
.....#.....

###..###...##..
###..###..#.###
.######.####...
..####....#####
##.##.##..#.###
#......#.#..#..
#.#..#.###..#..
#..##..##.#....
#.####.#.####..
.#.##.#.##.####
.######...###..
##....##.#.###.
........#.#####
##....###..##..
#########..##..
.######..####..
##.##.#####.###

##...#.#.###..#
#.####..#.##.#.
.##.##..#.##.#.
###..#..#.##.#.
.#.##...##..##.
.#...#..######.
.###.#.........
.###.#####..###
.###.#####..###

########.#.##
########.#.##
..#.#.#.###.#
#..#.###..#.#
..#..######.#
###....#.#.##
..#..#.#..###
..#..#####...
...###.#.#..#
##....#.#..#.
....#....##..
.....#####...
###.###.#....
..###..#...#.
##.#...##...#
###...##.##..
##.#....#.#.#

....######.
#..###..###
.....#..#..
#####.##.##
.##...##...
....######.
....##..###
.##.#.##.#.
.##.######.
.##........
....######.
.##..#..#..
#..#.#..#.#
.##.#....#.
####..##..#
....######.
#..#..##..#

##.#....#######
..###...##..##.
..###......###.
...#...#....##.
######.##.###..
..###.......#.#
##.#.###..##.##
###.###.######.
##...###.#...#.
..##.##.#.###..
..#.#..###..#..
...#..#..###.##
..##.....#..#..
..##.....#..#..
...#..#..###.##
..#.#..###..#..
..##.##.#..##..

.#..####.#.
.#..####.#.
..........#
.#..######.
.#...##.##.
#####.####.
#..#....###
#..#....###
#####.####.
.#...##.##.
.#..######.
#.........#
.#..####.#.

####.#.
##..#.#
###..#.
..#.#..
..#.#..
###..#.
##..#.#
.###.#.
.###.#.
##..#.#
###..#.

.#....##.#.###.
.....####.#..##
....##.####.##.
##...##..###.##
.#.#..#.###..##
####.#.#.##...#
.#.###.##.#..#.
.#.######..##.#
.#.######..##.#
.#.###.##.#..#.
####.#.#.##...#
.#.#..#.##...##
##...##..###.##
....##.####.##.
.....####.#..##
.#....##.#.###.
.#....##.#.###.

###..########
########..###
.##..##....##
##.##.##..##.
###..########
.#....#.##.#.
.##..##....##
..#..#..##..#
.######....##
.##..##.##.##
##.##.######.
..#..#..##..#
.#.##.#....#.
#.####.####.#
.##..##....##
##.##.##..##.
..#..#...#..#

##..#...#
.##.#.##.
......#..
##.####..
...###..#
###.##.#.
###.##.#.

###..###.####..
###..###.####..
#.####.#..##...
........#....#.
##....##..##...
#.#..#######...
..####...#.##.#
..#..#....#.#.#
..####...####..

####.##..###..###
...##.###...###..
..###.#.#####.#..
##.#..#####.#.#..
.#..#.#.#...#.###
...##..##...##.##
...#..#.###..#...
..###.##.#.#.....
#.##..##..#.#..##
.######...####...
.######...####...
#.##..##..#.#..##
..###..#.#.#.....

..##.####
.#....##.
.##..#..#
..#.#.###
.##..#..#
##.#.#..#
##.#.#..#

..###..#..#....#.
...##..##.######.
...##..##.######.
..###..#..#....#.
..##.##.##.#..#.#
#...#.###..####..
.##....#..##..##.
######...########
######.#####..###
.#....#..#......#
##....#.#.######.
.##.###.#..####.#
#.#.#####..#..#..
#####.#.##.#..#.#
#.#######........

..#########
...##.##.##
###........
##..##..##.
..#........
..##..##..#
###..####..
...#.#..#.#
##..#....#.
..#...##...
...##....##
##.#.#..#.#
####...#..#
..##.####.#
...#..##..#

...#.####
..###..##
.###.#..#
###.##.##
.##...###
###.##...
###.##...
.##...###
###.##.##
.###.#..#
...##..##
...#.####
.##....##
.##....##
...#.####

..#...##.
#.#.##..#
######..#
...#.#..#
#...#....
.#...####
.#...####
##..#....
...#.#..#

..#..###.#.
..#.####.#.
.###....##.
##.#...###.
#..##..#..#
#..##..#..#
##.#...###.

...########...#
#.#........#.#.
#....#..#....#.
...#......#...#
.#...#..#...#.#
#.#..#####.#.##
..#..####..#...
..###....###...
..#.#.##.#.#..#
..#...##...#..#
..#...##...#..#

..#..###.##..##.#
..#..#.#.##..##.#
##....#.#.####.#.
#.#.###..........
...#..##.#....#.#
...###..#.#..#.#.
...##...#.#..#.#.
#..#.##.###..###.
#..##.####....###
.#.#...#.##..##.#
#....##..##..##..
#.#.....#.#..#.#.
##.#.###..#..#..#
.##.....#......#.
#..#....########.

#####..
..####.
..####.
###.#..
..#....
###...#
.#..##.
...#.##
...##..
.#...#.
.#...#.
.######
.######
.#...#.
.#...#.
...##..
...#.##

.#.####
.#.#..#
#......
#..####
###....
.#.####
###....
###....
##.####
###....
#..####
#......
.#.#..#

...##.#.#..###..#
###.#...#...#..#.
.#.#.##.#.#..##.#
.#.####.#.#..##.#
###.#...#...#..#.
...##.#.#..###..#
#....#...##..#.##
#.#...#####....#.
#.#...#####....#.
#....#...##..#.##
...##.#.#..###..#
###.#...#...#..#.
.#.####.#.#..##.#

..####.#...
..##.#..#..
..##.#..#..
..####.#...
..#..#.#.##
...##..##.#
..#.#.##.##
....#.#..##
#####..#..#
###.#.#.###
...#.####.#
.....##....
#.#.....#..
....##...#.
##....##...

#####....###..###
#####..#.###..###
#####.####....#..
.#..#....#.#.#.##
#....#......#..##
#..#.##.##..#.#..
.###..##.#.#.....
..#..#.###..#####
..#....#..#.##...
#.#.###.#.#.#....
..#.....###..####
.##.###.##.##..##
#.#.##....##...##

##..#.####.#..#
###.########.##
.#..#......#..#
######.##.#####
##..#......#..#
##..##....##..#
#.##.#.##.#.##.

##.####..##
..#.#..##..
...#.######
.###.######
###....##..
##...######
.###...##..
..#.#..##..
.##...#..#.
.##........
#..#.######
#...###..##
#....######
.#.........
#.###..##..
###....##..
#.#########

#.##...###..##..#
#.###.###...#.#..
#.###.###...#.#..
#.##...###..###.#
#...#....#...#.#.
#....##.##..#####
..##..#####.##..#
###.#####.#.###.#
#####..##.#####..
.#..#.##.#.#...##
##.....#.#.#.###.
##.....#.#.#.###.
.#..#.##.#.#...##

...####.###.###..
###.#.#..###.#.##
...#######..#....
...####..#..##...
......#.#########
....#.#..####.###
.....#....##..##.
....#..##..#.#.##
..#..#...#.##.#..
...#..##.#.##..##
...#.#.#.#.#.##..
###.#.##...#..###
..####..###..#...
..#..#.#.....####
.....#.###..##.##

..#####
#..#.#.
#..##..
.....##
#.#..##
.#.####
####.##
####...
..##...
.#.....
.#.....
..##...
####...
####.##
.#.####

.##.##.##..
.##.##.##..
###....###.
#.##..##.##
#...##...#.
.#.####...#
####..####.

#..##.#.#..#....#
####.##.###..##..
##....#.##..####.
#...#####.#######
#....####.#######
##....#.##..####.
####.##.###..##..
#..##.#.#..#....#
#..####.###......
##..#..##.#######
..#.#....#.#....#

###.#..#.
.#.#...##
.###...##
###.#..#.
...#..###
###.##.##
.#.#.#..#
#.....#.#
.###.##.#
#.#.#...#
..#......
#.#..###.
....##...
#.#....#.
.....####
.....####
#.#....#.

..##.##.##....###
..##.##.##...#.#.
##..#..#..##..##.
.##......##.#..#.
.##......##.#..#.
##..#..#..##..##.
..##.##.##...#.##
..##.##.##....###
..#.#..#.#..#.##.
.##.####.##.##..#
##..####..####...
.###....###.####.
.#........#.#...#

..#####..#..#..
##......#.##.#.
####.##.##..##.
###..##.#....#.
##.##..##....##
##..#..#..##..#
#...#..##....##
..#..#.........
..###.#.#.##.#.
...#..#..#..#..
.....##.######.

####.#..#.##.
####.####.###
...#.#..#.#..
##.#......#.#
...#.#..#.#..
..####..####.
###.#.##.#.##

..###..##..
.#.#.#....#
.###.##..##
..#..#.##.#
.#.##.#....
..##.##..##
#...###..##
#...###..##
..##.##..##

..##.#.#.##
#.##..#####
#..........
#....#.....
#.##..#####
..##.#.#.##
###.#..#..#
...##.##..#
#.####.##.#
...#..#....
.#.##....##
.#.##....##
...#..#....

###..#.
...#..#
..#.###
###.###
...#..#
###..#.
...####
...####
..##.##
..#...#
...#.##
##..#..
..#....
..#..##
..#.###

#....#.#.#...
#.###.###.###
.####..##.#..
....#...##.##
.#####.......
.#####.......
....#..###.##

..##..##..#
##...#.####
#...##.#..#
##...######
##.##..####
#.....#.##.
#..#..#.##.

.#..#...#...##.
.#..#...#.#.##.
###...####..##.
###...##.#.....
.#.#..#....####
.#...####.#.##.
...#####...####
##.##.#.###.##.
####..##...#..#

.....#.
.....#.
###....
######.
##..#..
#.#...#
#......
#......
#.##..#

########.##.#
######.##..##
#.##.###.##.#
.......######
.#..#..######
##..##..#..#.
.####.#######
..##....####.
#.##.########
#.##.###.....
#....#..####.
##..##.#.##.#
#....#.#....#
.####........
......#.####.

.#.#.#..###
..#.#####..
.#...#...##
###..#.#.##
.####..#...
.#.#.#...##
...##......
#.....##.##
.##...#..##
#######.#..
.######.#..
.##...#..##
#.....##.##
...##......
.#.#.#...##

#####........#.
...#.##.##..#.#
..#.#.###.#.###
...###.####....
##...#.#..#....
##...#.#..#....
...###.####....
..#.#.###.#.###
...#.##.##..#.#
#####........#.
.#...##...#.##.
.#.####.##.#.#.
.#.####.##.#.##

.#...#.##..
##.##.#.###
##.#.....##
.........##
..##.#..###
.#.#.#.##..
#.......###
#.......###
.#.#.#.##..
..##.#..###
.........##
##.#.....##
##.####.###

....#..#....#....
##...##...##..##.
#.##.##.##.####.#
###.####.########
###.#..#.########
..###..###......#
.#.######.#....#.
..#.#..#.#......#
.#..####..#....#.
..#..##..#..##..#
##.#.##.#.##..##.
#..##..##..####..
####.##.#########
#.#.#..#.#.####.#
...#.##.#........

##.##.##.#.#..#.#
#.####.##########
...##...#..####..
..#..#..#.######.
.#....#.##..##..#
.#....#.#.##..##.
#..#...#.........
..#..#.....####..
.#....#.###....##
..........##..##.
..#..#..#########
..........#.##.#.
.#....#.#........
...##............
..#..#..#.######.
.######.#...##...
###..###.###..###

...#....##.##
###.####.###.
###.####.###.
...#....##.##
.#..####.##.#
..#...#....#.
#..#..#..##..
###.##..#..#.
..#####.###..
####.........
.####.##..##.
.#.#.###..##.
.#.#.###..##.
.####.##..##.
####.........
..#####.##...
###.##..#..#.

.#.############
#....#.####.#..
#.#.#...##.#.#.
..##.##....##.#
....##.#..#.##.
..##..######..#
#####........##
.#.##...##...##
.##############
####.########.#
####.########.#
.##############
.#.##...##...##

##..#########
##..#.##.#.##
..###...#.###
#####...##.#.
#####...##.#.
..###...#.###
##..#.##.#.#.
##..#########
#####.#.##.##
##....#...#..
##.#.####.#.#
##.##.###....
...#.#.#....#
##.#..###.###
...#.##....#.

####.###.
.######.#
.##.##.##
#..#.##.#
....#.#..
#..#..##.
....#.###
########.
########.

....#...#
#####....
#####....
....#...#
#..#.####
#..#..#..
.##...#.#
.##...#.#
.#.....##
#..#..##.
########.

.#..####...#.##
.#..#####..#.##
##.#.#..#.#....
#.#.##.#.##....
.#.##..##..####
.#....##...##..
#.###..#.#.#.##

#.#...#
#...##.
.#.....
.#.###.
.#.###.
.#.....
#...##.
#.##..#
#.##..#
#...##.
.#.....

######.
#......
..####.
.######
#......
.#.##.#
.#.##.#
#......
.######
..####.
#......

..#######
#.##.##.#
#.#######
.########
....#..#.
..#......
#.#......
.#.#....#
.##.####.
#........
.#...##..
.#...##..
#.#......

##...##...#
##.#....#.#
.....##....
####....###
..##....##.
.....##....
##.##..####
..#..##..#.
###..##..##
.....##....
##.######.#

#..##.#....#.
#....#..###.#
#....#..###.#
#..##.#....#.
.##.#.....##.
.#.######.##.
.###.##.####.
..##.##.####.
.#.######.##.
.##.#.....##.
#..##.#....#.

.##....
#..#..#
..##..#
####..#
.##.##.
#.#....
.#.....
#.#....
###....

##.#.......#...#.
##...#....##..###
.#..#.#...###.###
.###.#..###.#.#..
######..........#
######..........#
.###.#..##..#.#..
.#..#.#...###.###
##...#....##..###
##.#.......#...#.
#####..##.#####.#
#..#.##...##.####
#..#.##...##.####

..#..#..###..
.####.##...#.
.###..######.
.###...#####.
.####.##...#.
...#.#.##...#
#...#..#.##.#
.######.##..#
#.##.##.#.###
#.##.##.#.###
.######.##..#
#...#..#.##.#
...#.#.##...#
.####.##...#.
.###...#####.
.###..######.
.####.##...#.

#.#........
..#.##.####
##...######
..###......
##.##.##..#
......##..#
.#.##..####
##..#.#....
..##.#.####
.#.#....##.
#####.#.##.
.####.#.##.
.#.#....##.
..##.#.####
##..#.#....
.#.##..####
......##..#

#####.#..##
#..###.###.
.##..####.#
.##..####..
#..###.###.
#####.#..##
.........#.
.##...#.###
.##.####..#
....###.###
#######.#..

#.###.#.#.#.#.#
.##..###..###..
..#.##...####.#
..#.##...#.##.#
.##..###..###..
#.###.#.#.#.#.#
.....#....##.#.
.........#####.
......#.......#
..###.#####.###
.###..###.#.###
.##.#..#####.##
.##.#..#####.##
.###..###.#.###
..###.#####.###
......#.......#
.........#####.

.#.##..##
...#..#..
###..#.##
##...#.##
##.####..
.#..##.#.
.#..##.#.
##..###..
##...#.##
##...#.##
##..###..
.#..##.#.
.#..##.#.
##.####..
##...#.##

.#.###....###.#
######....#####
######....#####
.#.###....###.#
.####..##..####
##..##....##..#
.##.###..###.##
....#.#..#.#...
##.#.######.#.#
#.###..##..###.
..##.######.##.
##.#.######.#.#
..#.#.####.#.#.
.#....####.#..#
#.#..#....#..#.

##.#.#...#.##
#...#..##.#..
#...#..##.#..
##.#.#...#.##
....##.##....
.#....####.##
...#...##..#.
###.#..#...#.
....##...#.##
.#..##...#.##
###.#..#...#.

........#..#.#.##
#.#..#.######.#..
.#....#..#.######
..####...#...#...
#..##..#.##.##...
##.######.#.#..##
#......#..#..#.##

###.##..#..##..##
##.#.##.##..####.
..#.#.##.#..#..#.
##...#..#...####.
###.##.....#.##.#
...#.....#.#....#
...####..##.#....
##.##.##..#......
###...#..#.#....#

##..##..######.
###....########
###.##.########
#........#..#.#
.#.####.#.##.#.
...####...##...
##########..###
##.#..#.##..##.
.##....##....##
##..##..##..##.
....##.........
##......##..##.
.#.####.#.##.#.
.##....##.##.##
.#.####.#.##.#.
.#.####.#.##.#.
#.#....#.####.#

####..###..##
.#......####.
#...#########
#....#.......
.#.##.#.####.
.....##......
.....##......
.#.##.#.####.
#....#.......
#...#########
.#......####.
####..###..##
###..##.#..#.
.#..#.#......
##..#.##.##..

#.##.##
....#..
#..##..
....###
.##.###
....###
####.##

##.####
..###..
..###..
##.####
##..###
.#.....
#..#.#.
.#####.
...#.##
..#.##.
.#.....
....###
#.##...
..#.##.
..#.#..

####.##
..###.#
##.###.
..#.#.#
##.#.##
##.#.##
..#.#.#
##.###.
..###.#
##.#.##
##.#.##
##..###
##..#.#
..##...
##.#..#

#.#.###
#####..
#.#.#..
...##..
..#.#..
#..####
.####..
.##.#..
###....
###.###
##.####
.#.####
##..#..
.#.#...
.#..###
#.#.#..
#.###..

..####..####.##.#
###..###..#######
..####....###..##
...##...###..##..
..........###..##
##.##.####...##..
.#.......#.......
#......##.#######
.##..##.#.#.####.

#####.###
..######.
####..###
####..###
##......#
###.##.##
..######.

.#.#....#
#.......#
#..#.###.
...#.#...
...#.##..
#..#.###.
#.......#
.#.#....#
##....##.
.##.###.#
.##.###.#

.###.####
.#.#..#..
###..#...
#..#..#..
#.#####.#
.####..##
.####..##
#.#####.#
#..#..#..
###..#...
.#.#..#..
.###.####
......##.
...#..#..
......#..

#.#..##..#.
#...#..#...
..###..###.
#..##..##..
.....##.#..
##........#
..##.##.##.
.##......##
.##......##

..##.######
#.##.######
###..######
##..#######
.#.#..####.
....#......
.#.#.......
#.#.#######
##.##......
.###.#.##.#
......#..#.
.##........
###.#......
#...##.##.#
#.#..##..##

##..##...##..
##..##...##..
#.##.#.#.#.##
.#..#.###.#..
#....###.#.#.
##..##.#.####
##..##....###
#........##.#
#.##.##..##.#";
            var sample = @"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }
        private static void part2(string input)
        {
            long count = 0;
            var inputs = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int m = inputs.Length, n = inputs[0].Length;
            for (int i = 0; i < m; i++)
            {
                var hv = solve2(inputs[i]);
                count += 100 * hv.v + hv.h;
            }
            Console.WriteLine($"2nd star answer is {count}");
        }

        private static (int h, int v) solve2(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.ToCharArray()).ToArray();
            int m = inputs.Length, n = inputs[0].Length;
            var reference = solve12(inputs);
            int complement = '.' + '#';
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    inputs[r][c] = (char)(complement - inputs[r][c]);
                    var temp = solveFor2(inputs, reference.h, reference.v);
                    if (temp.h != -1)
                    {
                        if (temp.h != reference.h || temp.v != reference.v) return temp;
                    }
                    inputs[r][c] = (char)(complement - inputs[r][c]);
                }
            }
            return (-1, -1);
        }
        private static (int h, int v) solveFor2(char[][] inputs, int href, int vref)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int i = 1; i < m; i++) // try to match i with i-1, i + 1 with i-2
            {
                bool symmetric = true;
                for (int j = 0; j < i && j + i < m && symmetric; j++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (inputs[i + j][c] != inputs[i - j - 1][c])
                        {
                            symmetric = false;
                            break;
                        }
                    }
                }
                if (symmetric)
                {
                    if (i != vref)
                        return (0, i);
                }
            }
            for (int i = 1; i < n; i++) // try to match i with i-1, i + 1 with i-2
            {
                bool symmetric = true;
                for (int j = 0; j < i && j + i < n && symmetric; j++)
                {
                    for (int r = 0; r < m; r++)
                    {
                        if (inputs[r][i + j] != inputs[r][i - j - 1])
                        {
                            symmetric = false;
                            break;
                        }
                    }
                }
                if (symmetric)
                {
                    if (i != href)
                        return (i, 0);
                }
            }
            return (-1, -1);
        }
        private static void part1(string input)
        {
            int count = 0;
            var inputs = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int m = inputs.Length, n = inputs[0].Length;
            for (int i = 0; i < m; i++)
            {
                var hv = solve1(inputs[i]);
                count += 100 * hv.v + hv.h;
            }
            Console.WriteLine($"1st star answer is {count}");
        }

        private static (int h, int v) solve1(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.ToCharArray()).ToArray();
            return solve12(inputs);
        }

        private static (int h, int v) solve12(char[][] inputs)
        {
            int m = inputs.Length, n = inputs[0].Length;
            for (int i = 1; i < m; i++) // try to match i with i-1, i + 1 with i-2
            {
                bool symmetric = true;
                for (int j = 0; j < i && j + i < m && symmetric; j++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (inputs[i + j][c] != inputs[i - j - 1][c])
                        {
                            symmetric = false;
                            break;
                        }
                    }
                }
                if (symmetric) return (0, i);
            }
            for (int i = 1; i < n; i++) // try to match i with i-1, i + 1 with i-2
            {
                bool symmetric = true;
                for (int j = 0; j < i && j + i < n && symmetric; j++)
                {
                    for (int r = 0; r < m; r++)
                    {
                        if (inputs[r][i + j] != inputs[r][i - j - 1])
                        {
                            symmetric = false;
                            break;
                        }
                    }
                }
                if (symmetric) return (i, 0);
            }
            return (-1, -1);
        }
    }

}