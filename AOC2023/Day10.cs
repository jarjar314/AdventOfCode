﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AOC2023
{
    public class Day10
    {

        public static void Main()
        {
            var input = @"-F|..FF.F77|7-777FLF7F|7-F--F--FF7F7F.FL-|-|777F-7FL7F77---|-7-77.F-LLF7FF|-F-7.FF77F|7---F7.7FF7-J7-FF.F77F--.-|.F.F7L7--J.FLL7J7L|J7L|.F77
..|--7LJ7.LJF7J-|-7F|-JL7L77|JF7--L-L|.|-77.L-LL7|7.FJ|77-FJJF..F7.7JL7L|J|LJFJFFF777.LFFL||.F7||.FF.-J-F-F|7|-L-7J7J||L|JJF7J-L|L7.LF.--JL|
F-7LLJF-JF|-L|JF|FLFLJ-FJ|.FLJLJJ-F|7L|7.JJ-||.FJL77L7L77F77--JJ7|-FJ||L|J7F|--FLJLF77-F-7|L7|||L77.-LJL7.JLFJ777|||.---F.L7JFF.J-LL-J-|-7FL
F|L7.|.L7F--J.FL7F-||||F7L|7|FLLJFFJ-FJ|-J|.JJ-L-7L7FL7L77JLL7JJ7FFJ-F7-7.FF7-F7.LJL|77L7LJFJ|||FJ|.|J..|..F|FFF-L-LFJLFJ--|7--7.|7FJ7||.FL.
F-.F-77|F|-J.FF-|JFL|-F-J7.L-|7FFL.|.F-L--7.||F77|FJF7|FJ-77FFF.||.7-FF7|-FJ|F||7.L7.-J.L-7L7||||F7FJJL7L7.FL|L-7|7-L77J-|LJJ.|7F777JLFJLJ.F
|JL7L|F-F|-..F-J|F|LF-J-|7-.L-7F7JFJ|JLJ-|F-77|L-J|J|LJL7L|7L-JFL|-F-L|L-7|FJFJ|77F77LLFF7L7||||||L7JF.L7---.LF7|JJ-L|-F---J.F--7JL77|LF-77|
||.|.L|J|.FJ--|7L|J.||-7.7FJFLL|||.F|JJ.F7L7L7L--7L-JF7FJ7L|FL.77|.7..L7FJ||FJFJF7F7F7F-JL7|||LJLJFJF77FF7.L|7LLJL--|JLFL7|F-7|.LJLLF7.LF7|J
L-JF7.|FFL7.FF|-J|LLJ|F-7LFJ--FJFFJL|--FJL7L7L7FFJF7FJ|L7J.F--L--J-LFF-JL7|||FJ||LJLJ|L--7LJLJF7F7L7||F7||F7JF|LL7LF--F|J7||LF--...FJ-|7L|J7
7..L..7FL.|F7-LJFJFL-LJ-FJ|L7.L|-JJ7|J|L-7L7L7|FJFJLJ.|FJ|FJL-7JFJ|7LL7F7LJLJL-7|F--7|FF7L--7FJLJL-J|||LJLJ|--7.L-7F7.LJFF|J-|7LL7--|F--7JLF
|.LJ|7|7.F-LJJ|FJF|7.LJLL-JLJ--J.L.7JFF-7L7|F||L7L--7-||----F7L-JLF77FLJL-7F---J||F-JL7|L7F-J|F7F-7FJLJF---J.|L-7-7JF|JLJJ|--L--L|.7LF7-.FFL
L||L|-F7---J.F7JL|JF77L7-|JFLJL77F-FF7L7|FJ|FJL-JF-7L7LJ7|F7-JJ|FFJLL-F---JL7F-7LJL-7FJ|FJL-7||||FJL7F-JJF7F7-J7||JJFF--|LLF7.L---7JF|F.F7||
FF7.7.JL||F-7-|J.|7LL7|.77JFJ.LFF-.FJ|FJ|L7||F--7L7L7L--7F|J7LLFFJL.|FL----7||FJ.FF7|L7|L7F-JLJLJL7FJL7FFJ|||..|--7F|JJFFJLLJ-7JJLF.FFJF-|.-
|JJL|F|F|-|-|7|.FL-7LF-F-77|-|-L||FL7|L7|J|LJ|F-JFJLL---JF7J|-F7|7.--F7JF7FJLJL7F7||L7|L7|L-7F----JL7FJFJFJ|L--7J|FF7J.FJ7-|7LJ-7J|-.|F7-7..
J7LF|7FFJ|F7|7|-7|LL-JLL7L-7-F77F-7L|L-JL7|F7|L-7|F7|F7LFJ|7|-||-F7-FJL7|LJF7F-J||||J||-||7FJL---7F-JL7|FJFJF--J-F-JJJ.7.J7L77|.7JLLF|7|FFJ7
LF-7.|FJJFLL7|FF|7.F||LLL7FJFJL7L7L7L--7FJLJ||F-JLJL7||FJFJF7.||FJL7L-7|L7FJ||F7|||L7||FJL-JF7F7FJ|F--J|L7L7|F-7-|.||JF-7-|JLL-7L-.FFL-|-JL|
-L7|7L7J|F7||-F-JL.77|.|.|L7L7FJFL7L-7FJL7F7LJL--7F7LJ|L7|7||FJ||F7L7FJ|7LJFJ|||||L7|||L----J||LJFJ|F7FJFJFJLJFJ.-FF-F7|FF7FL|L|FJ-7F|.L|7L|
L7JL7-J--FF7|-|--JFFJ.FF-JFJ.||F--JF7|L-7||L7FF-7||L--JFJL7||L7|LJL7|L7|F7-L7LJ|||FJ||L--7F7FJ|F7L7LJ||FJ.|F--J.|.7|-||F7|L77JJLJFJL--7-|7.J
FFF.LF-7FF|-FFJ|LJ|.J--L-7L-7||L--7|LJF7|||FJFJFJ||FF--JF-J||FJL-7FJ||||||F7L7FJ||L7|L-7FJ||L7||L7L7FJ|L-7||F7F7F7LF7|||||FJ7-.|.7L-77|JL7J.
7JL||.FLL-L--JFLJJ7..LL-LL7FJ||F7FJL7FJ||||L7|FJFJL7|F-7L7FJ|L7F-JL7L-JLJLJL-JL7|L7||F7|L-J|FJ||FJFJL-JF-J|||||LJ|FJLJ||LJL-7-JJ7|7-LF.FFJ.-
7||L|7FLLLJF|7LL7F-7-7||.FJL7||||L-7|L7|||L7|||||F-J|L7L-JL7|FJ|F-7L--7F--7F--7||FJ|LJ|L-7FJL7|||FJF---JF-JLJLJF-JL--7||F---J77FF|JJ-|77|FJ7
F-7FJL-J.F|7F|JF77J||FFF-JF7LJLJL-7||FJLJL-JLJL7||F7L7L7F7-|LJFJL7|F-7LJF7LJF7||||FJF-JF-JL-7||||L7|JF77|F-----J7F---JLJ|F7-F--7JJL|.LJFL7L7
L.L|L-F-|77-JJ7LF7F-7-FJF7||F----7|||L--------7|||||FL7LJL7L7FJF-J|L7L-7|L--JLJLJLJFJF7L7F7FJ|||L-JL-JL-J|.F7F7F7L----7FJ|L7|F-JJF-7LJ7|LJL|
L--L-JF||LLJ|-FF|||FJ-L-JLJLJF---J|||F7F7F-7F-J||||L7FJF7FJFJL7|F-JFL7FJL----7F----JFJL7LJ||FJ||F-7F--7F7L7|LJ|||F7F7FJL7|FJ||F7F7.FJ|L--L-|
.L7FJ-FJJ.LFJ7-FJLJL7F---7JF7L---7LJ||||||FJL-7LJ||FJ|FJLJFJF-J|L7.F7||F7F---JL7F7F7L7FJF-J|L7||L7|L-7||L-JL7FJ|LJ||LJF7LJL-JLJLJL-7.LF7.J7J
FF||L7L7|F.|F|7L7F--JL--7|FJ|F7F7L-7||||||L7F-JF-J||FJ|F7|L7|F7|FJFJLJ|||L---7FJ||||FJL7|F7L-JLJFJL--JLJF-7FJ|FJF-JL7FJL----7F7F7F-J..|L7F-.
FLJJ7|-7-F|-7J-FJL--7.F7||L7LJLJL7FJ||||LJFJL-7L-7||L7LJL7FJLJ||L7L--7|||F7JFJL7||||L7FJLJL7F7F7L-7F7FF7L7||FJL7|JF-JL-----7||LJ||J.F7.7L|L7
|F7F|LFJL||JL||L7F--JFJLJ|LL-7F7FJL7LJ|L7FJ7F7L-7|||7L7F-JL7F-J|FJF7FJLJ||L7L-7||LJL7||F-77LJLJL7FJ|L7|L7|LJ|F-JL7L-7F-----JLJ7FLJLFL|7JF7J|
777JLFJ7-FF-F7-L|L7F7L--7|F7|LJ||F7|F-JFJ|F7||LFJ|||F7||F7FJ|F7|L-J|L7F-JL7L7FJLJF--J|LJFJF7-F--JL-JFJ|FJ|F-JL-7FJF-JL---7F7JF7F7JFJJ|FJFJ||
J||FF|JLL-JLFF77L7|||FF-JLJL7-FJLJLJL-7|FJ|||L7L7LJLJLJ||LJFJ||L--7|FJ|.F-JFJ|F-7L-7FJF-JFJL7|F--7F7|FJL-JL--7FJ|FJF-----J||FJLJ|-|..|L-J.LF
FF--FJLF7LF-7||F-JLJL7L----7L7|F----7FJ||FJ||FJ|L-7F---JL7FJF||7F7||L7L7L-7|J||LL7FJ|FJF7L-7|LJF-J|LJL-7F----JL7||FJF7F---JLJF--JFL-FJ.L7-FJ
LJF-.|LL-.L7LJLJF--7FJF7FF7|FJLJF7F7||FJ||FJ||F7F-JL--7F7||F7||FJ|||F|FJF-JL7|L-7||FJ|L|L7-||F7L-7L7JF-J|F7F7F7|LJL-JLJF----7L7-|7.||.-LLF|J
JJ-|7.FF.|FL7F7FJJFJL-JL-JLJL7FFJ||LJLJFJ||FJ|||L-7F--J|||||LJ|L7LJ|FJ|JL--7LJF-JLJL7|FJFJFJ|||F7L7L-JF-J|||||||F---7F7L---7|FJ||JL-J-|J.LJ7
L|FJ|F-LJLJL||LJ.FJF-----7F-7L7L7|L---7|J||L7||L7FJL7F7|||||F-JL|F-JL7L7F-7L7FJF7-F7||L7|.L7|||||7L--7|F-JLJLJ||L7F7LJL---7||L--77L-JF|7-FF7
|FL-L|-LF|7FLJ.F7L-JF---7LJLL7L7|||F7FJL7|L7|||FJL-7LJ||||LJ|F7FJ|F7FJFJL7|FJL7||FJ||L7|L7FJ|||||F-7FJ||F-----J|FJ||F--7F7LJL7F-JJ77J|J7-|L-
--JFFJ7-L-FF7|7||F-7|F7FJF7F7L7|||FJ|L7FJ|FJ||||F77L7FJ|||F-J||L7|||L7|F7|||F-J||L7||FJL7||FJ||||L7||FJ||F7F--7||FJLJF-J|L-7L||.L7F-FJ.|.|LL
.|F-JLF.LL|JF7FJLJFJLJ||FJ||L-JLJ|L7|FJ|FJL7||||||F7||FJ||L7FJL7||||FJ||LJ||L-7|L7|||L7FJ||L7|||L7|||L7|LJ||F7LJLJF-7L--JF-J7LJ7FJLLJFJ.|L7J
J-J...|-7-F7||L--7L7F7||L7|L7F7F7L-J||FJL7L||LJLJ||LJLJFJL7||FFJ|||||FJ|F-J|F-JL7||||FJL7||FJ|||FJ|LJ.LJFFJ||L-7F7L7L7F7FJL|FFF7-J7JFF-7JJ.F
|F-FL7|.F-J|||F7FL7||LJ|FJL7LJLJL--7LJL-7L7|L7F--JL-7JFJF7||L7L7|||LJL7|L-7|L7F-J||||L--J||L7|||L7|F-7-F7L-JL-7||L-JJLJ||F7|F7||.||LL|JLJ.|7
FJ-J-|F7L-7LJLJ|F-J|L-7LJF7|7F----7L---7|FJ|FJL7F7F7L7L-J|||FJFJ|||F-7||F-J|FJ|F7LJ|L-7F-J|7||||LLJL7|FJ|F--7FJ|L-7F7F7LJ|L7||||.F7.F|.L-FFJ
||F|.L||.FL---7|L-7L7FJF7||L7L---7|F--7|||FLJF-J|LJ|FJ7F-J|||J|FJLJL7LJ||F7|L7||L--JF7|L-7L7||||F---JLJFJ|F7LJ|L-7LJLJL--JFJ|LJL-JL7L7-J-F7-
F-F77.||F7-F--JL7FJFJL-JLJL7L----JLJF7LJ|L-7FJF7|F-J||FJF-J||FJL-7F7L-7|||LJ.||L-7F7|||F-JFJ||||L7F7F-7L-J|L---77L7F-7F7F-JFJF--7F-J-JF..-|.
JF|L--JLJL7L--7FJL7|F7F7F77L-7F----7||F7L7FJ|FJ|||F7L7L7L7FLJ|F-7LJL7F||||F--JL7FJ|||LJL7FJFJ|||FJ||L7L7F-JF---JF7LJLLJLJF7|FJJLLJJ|LFF-FLJF
L-L--7F--7|F7FJL7FJLJLJLJ|F-7LJF---J|||L7LJF||FJ||||FJFJFJF--JL7|F-7L7LJ|||F-7FJL7|LJF7FJL7|FJ||L7|L-J7LJF7L----JL-------J||L---777.LL--JFL7
LJLF-J|F-JLJLJF7LJF-7F7F7|L7|F7L---7|LJFJF-7||L-JLJ||L|FJ.|F-7FJ|L7L7L7FJ||L7LJF7||-FJLJF-J||FJL7LJF-7F7-|L-7F7F--7F7F7F-7LJF-7FJ7.7.|7LF7L7
F7JL7FJL---7F7|L7FJFJ||||L-JLJL--7.LJF7L-JFJLJF----J|FJL7FJL7|L7|FJJL-JL7||FJF7|LJL7L-7FJF7LJL7FJF7L7LJL7L-7LJ||F7LJ||||FJF7L7|L-7-F-7FF7--L
-.FJLJ|F--7||LJL||7L7|LJL7F---7F7L---J|F7FJF7LL7F---JL7FJL7FJL7|||JF7F77||LJFJLJF--JF-JL-JL--7LJ-|L-JF-7L--JF7LJ|L-7LJLJL-J|FJ|F-J-JFLFJL7FL
.FJLFF-JF7LJL7F-JL7FJ|F--J|.F-J|L---7FLJLJ7||F-JL7F---JL-7|L-7|||L-JLJL7LJF7L--7L-7JL-7F7F---JFF7L7F7|FJF7F7|L--JF7L7F7F-7FJL7LJFJ-J|JF-JF7|
.-F.FL-7|L7F-JL-7FJL-JL---JFJF-JF---JF7F---J|L---JL7F7F7FJL--J||L7F7F--JF-JL---JF-JF--J|LJF-7F7|L7||||L-JLJLJF7F7|L-J|LJFJL7FJJ--7L7J-7|.LJ7
--L7|.LLJFJ|F---J|F7F7LF7F7L-JF-JF-7FJLJF7F7L---7F-J||||L---7.LJFJ||L-7-L7F7F7F7L77L7F7L--JFJ||L7|LJLJ.F-----JLJLJF7FJF-JF7LJ777||||.FJ|JJJF
|.L7FJ7|LL-JL--7FJ|LJL-JLJL---JF7L7LJF--JLJ|F---JL7FJLJ|F---JF7FJFJL-7L-7LJ||||L7|F-J|L7F-7L7|L7|||F7FFJF7F------7||L7L--JL7F7F77|-F7L7JLJ.|
L7FL7.|FF7F7JF7LJ7L--7F-7F---7FJL-JF7L---7FJL---7FJ|F--JL--77||L7L--7L7FJF7LJLJFJ|L7FJFJL7|FJL7LJL-J|FJFJLJF7F7F7LJL-JF----J||||F7JF|..FJ|FF
FL--L|JFJLJL7|L7F7JF-J|7LJF-7LJF---JL7F7FJL-7F7FJ|FJ|F7F7F7L-JL7L-7FJ-||FJ|.F7FJFJFJL7L7FJ|L7|L7F7F7|L7|-F7|LJ|||F--7FJF-7F-JLJLJL-7|7FF-|7J
L7..FF-L---7||FJ|L7L--JF--JFJF7L----7||||F7-LJLJFJL7LJ||||L7F-7L7F|L7L||L7|FJLJFJFJF7|FJL7L7|F7LJ||||7LJFJLJF7LJ|L-7LJFJFJL7F---7F7L7JFL7LF.
L7.7|L7FF--JLJL7|FJF7F7L--7|J|||F7FFJLJ|LJL----7L7FJF-J|LJL|L7L-J7L-J|LJFJLJF7FJ-L7|||L7FJ-|||L7-LJ|L--7L7F-JL7FJF-JF7L7|F7|L--7LJ|FJ77L-LL-
F|-JJFLL|F----7||L7||||F--JL7||FJL-JF-7|F-7F---JL||FJF7L-7FJFJ-F--7JLF--JF-7||L77-||LJLLJF7LJL7|F7LL--7L7LJF--JL-JF7||FJLJLJF7FJ|.LJ|L7.JLJJ
|-77.|JFLJF---J|L7||LJLJF7F7LJLJF7F7L7|LJ-LJF-7F7LJL-JL7FJL7L--JF-J|.|F7FJL||L7|F-J|F----JL---JLJL-7F-JFJF7L---7F-J||||F7F7FJLJLF-77|.|7J||7
JLL--|7F7FJF7F7L-J|L-7F-JLJL-7F7|LJL-JL-7LF7|FJ|L7JF7F7LJ7FJF7F7L--7-LJ|L7-LJJLJL-7|L----7F-7F-7F-7|L-7|FJL---7LJF-J||||LJLJLF7FJFJF-7||--J7
|.F-7JFJ|L-JLJL--7|F7LJF-----J|LJ7F-----JFJLJ|FJFJFJLJL--7|FJ||L--7L7JFL-J-F-----7LJ.F---J||LJ-LJFJ|F7||L----7L-7L--JLJL7F---JLJFJ-|FJ7JL-LJ
L-77J7L7L--------JLJL--JF7F7F7|LF7L7-F---JF7FJL7L-JF7F7F7|LJFJL-7FJFJL|7L7.L-7F-7L---JF--7L7F-7F7L7LJLJL----7L7|L---7F7FJ|F---7FJFL|L--7J-L|
|7||-LJ|F-------7F7F-7F-JLJLJ||FJL-JFJF---JLJ|.L7F-JLJLJ||F-JF7FJL7|JF7J.|.F-J|-|F-7F7|F-JFJL7LJL-JF-7F7F--7L-JF7F7|LJ|L-JL--7LJ|77|F--J7F7.
-L7L7LLLJF--7F--J|||FJL7F---7LJL7F-7L7|F7FF7F7-FJL7F7|F7LJ|F7||L-7LJ.|.|F|-L-7|FJL7|||||F7|F7L-7F-7|FJ|LJF7|.F7|LJL7F7|F7F7F7L7F7-FJL-7JFF|7
|L7||J7FFL-7LJF-7|||L-7|L7F7L---JL7L-JLJL-JLJL-JF7LJL-JL7FJ|||L-7L-7.|-FJL-J.LJL7FJ|||||||||L--J|JLJL7|F-JLJFJ||F--J||LJ||||L7LJL7|F7FJ7F7L7
|LLJ|-|-F.FL7FJFJ||L77||FJ||F-----JF--7F7F7F----J|F7F---JL-J||F-JF-JF-.JLFLJL7.LLJFJ||||||||F---JF---J|L---7|FJ|L---JL-7|||L7L7F-J||LJLF7-J7
7-|F|J.-JFF7LJ|L7|L-JFJ||FJ||F---7FJF7LJLJ|L---7FJ||L-7F7F7F||L7FJJ-L-FJFJ7.JJ7L|7L7|LJLJLJLJF7F7L----JF7F7LJL-JF--7F7FJ||L7|L|L--JL7F7||..|
|-F7L7JJFFJL--7LLJF--JFJLJJLJL--7|L-JL--7FJF7F-JL-J|F-J|LJL7LJ|LJ|JFJ.|FL-J7.||JLJ7LJFF7F7F7FJ||L--7F--JLJL-7F-7L-7LJLJFLJFJ|FJF7F7FJ|LJ|J-L
7.|J7LJJLL7F-7L--7L---JF7LF7LF--JL----7FJ|FJ|L----7|L--JF--J7|LJ-J-7.7--JJ.|7F7FL7LF--J|||||L7|L--7LJF-----7||FJF-JF--7F7JL-J|FJLJ|L-JF7|JJ.
L|7.L|7-|-LJ|L7F7L77F--J|FJL7L-7F7F--7LJL||FL-7F7FJ|F---JF---7J.|JFLFJJ|LFF|J|L7F-LL7F7||LJL-JL7F-JF7|F----J||L7L--JF7LJL-77FJ|F--JF7FJLJ.F|
7J777LF7-F7F-7||L7L7L--7|L-7|F7LJLJF7L7F7|L-7JLJLJJ|L----JF--J-77FJ7|J.--7F-.7FJJ7LFLJ||L-----7|L-7||||F-7F7LJ.L7F7FJL----J7L7|L-7FJLJJJ|-77
||||7F|L7|||FJLJ7L7|F7FJ|F7|LJL----JL-J||L--JF7F7F7L7F7F7FJ||||J||-FLJ..F-7.FL7JLJ.F7FJL--7F--J|F7LJLJLJFJ||.F7LLJLJF-7F7F--7LJ-FJ|7L7..LLL7
L-F|.FL7|||||F7F7FJ|||L7LJLJF--------7FJL7F--J||LJL7||||LJ|-|JFJFJFFL7F-L-|F-7.F7FFJLJF7F7LJF-7LJL--7F77L-JL-J|F----JFJ|||F-JLF7|FJ-7J-J.|7J
|-F7LF-J||||||LJ|L7LJL-JF-7FJF------7LJF-J|F--J|F--JLJ|L7-F-7F--.77-JFFLJFL--|--F-JF--J||L--J.L----7LJL-------J|F----JFJLJL---J|LJFLLJ.L7JF7
77|||L-7LJLJ|L-7|FJF7F7FJFJL7|F7F--7|F7L-7|L7F-JL---7JL7L-JFJ7.|.FJ-7-7J.|JLLJFLL--JF--J|F---7F7F7FL-------7F7FJL----7|F---7F7FJJJ-FJ-F-|J.7
|.-LF-7L---7|F7|LJFJ||||.L7FJ||LJF-JLJ|F7||FJ|F-7F--JFFJF7FJJ7-|-JJF|.|7..7-7|LJL7JLL7F-J|F-7LJLJ|F7F7F----J|LJF7F-7FJ|L--7||LJ7|.||LL|.--.-
-FJ7L7L----JLJLJF7L7|||L7FJ|-LJF7L-7F7||LJ||FJL7LJF--7L7|LJJJJ|..LFJJF7LF-|..J.FLJJ|LLJF-J|-L-7F7LJLJLJF---7|F-JLJ7LJJ|F--JLJ.L7LF|7-FJ7J.77
LJ-J-L7F7F7F7F7FJL-J||L-JL-JF--JL--J||||F-JLJF7L--JF-J7LJ.|-F-77FL|.--JF|J|7L7FF77FFFF7L-7|F-7LJL7F---7|JF7LJL--7F----JL---7F7.|-7--.F--FJ77
-F7JLLLJLJ||LJ||F---J|F-----JF-7F7F-J||LJF---JL---7L---7F-7|L7L7-FL7.|JL77||-F-J|7FJFJ|F7LJL7L---J|F--J|FJ|F7F7FJL7F7F----7||L-7-J7|.|-LJJ||
.LL-J|JF--JL7FJ|L7F7FJ|F---7FJ-LJLJF-JL-7L77F-7F-7L----J|FJJF||F--|-LJ7LL-JL-L-7L7-FJFJ|||F-JF--7FJL7F-JL7LJLJLJF7LJ|L-7F7LJ|F-J7F-JLJ|F|||7
F7L..L7L7F7FJL7|-LJ||JLJF--J|F-----JF--7L7L7L7LJFJF7JF-7||7-JLF-7FJJ7L.FL|7.FLLL7|FJFJFJL7L--JF-J|F-J|F--JF7F---JL7FJF7LJL--JL7FF7FLL.--J-FJ
LJJ7F-LJ||LJF-J|F--JL--7L--7|L------JF7L7|FJFJF7L-JL7|FJ|L7J|F|FJ-J-J-F|7LJF|7|FJ|L7L7|F7L----JF7|L--JL--7|LJF----J|FJL7F----7L-J|7F-7.F7-JJ
L|-|.|FFLJJFL-7|L-7F7F-JF7FJ|F-------JL-J|L-JFJL---7LJL-JFJ7F-JL7.|J|FJ.7.||J-L|FJFJFJLJL------JLJF7JF--7LJF-JF--7FJL-7|L---7L--7L----7||-J|
F7L7--JJLJLLF-JL7FLJLJF7||L-J|F--------7L|F-7L----7L--7F7|F7L7F-J.|-F7J-F.FJ|JL||7L7|7|.F7F7.F7F--J|FJF7|F-J7FJF-J|F--JL----JF7JL--7F-JJLLFL
|L7|.LJ-|L7LL--7|F-7F7||||F7JLJF-------JFJ|-|F7F--JF7.LJLJ|L7||JJF|F||.7.7|F7F-JL--JL7-FJLJL-J|L--7|L-J||L--7|FJ7FJL--------7|L7LF7LJJFJ.|..
LJFJ7JF.LF-7F--J|L7LJLJLJLJL-7-L-------7L7L7LJLJ|F7||F--7FJFJ|L-7F7FJL-7F||L-L--7F7F7L7|F7F7F7L---JL-7FJL---J|L--JF7F7F----7LJFJ-||J|.L.F7FF
.-J.F7|F-L7LJF-7L7L7F7F---7F7L--------7||L7L7F7F7|||||F-J|FJ7|F7||||F--J-F77JLF-J|||L7LJ|||||L------7LJF-----JF-7FJ|||L---7L--J|-||-F7-|--J7
.LFFL|7JJFJF-JFJFJ7||LJFF-J|L7F7F----7LJF7L-J|LJLJLJLJL7|||F7||LJ|||L-7F-JL-7.L7FJ||FL7FJLJLJF7JF---JF7|F-7F7FJ7|L7||L7F--JF7F-7FJL777|.F.L-
|FL|JFF.FL-JF-JFJF7LJF-7L--J7LJLJF---JF7|L-7L|F--------JFJLJLJ|F-JLJF-JL7F--JF7LJFJ|F7||F----JL7L7F-7|LJL7||LJF7L7||L7||F7FJ||FJ|F-J777F77.|
LJ7|FLJ-L-F-JF-JFJ|F7L7|JF7JF7F--JF7F7|LJF-JFJL--7F7F-7JL7F---JL---7L7F7||F77||J.L-J|LJ|L----7FJFJ||LJJF-JLJF-JL7LJL-JLJ||L7||L-J||F7J7||F-7
LL-L7|F||.L--JF7L7|||7|L-JL-J|L---JLJLJF-JF7L7F--J||L7L7FJL7F-7F--7|FJ|LJLJL7|L-7F-7L--JF---7|L7L-JF-7FJF7F7|F-7|F7F7FF7|L7|LJF--JFJ|LL7L|-|
L|7|L77-77|.F-JL7|LJL7L-----7|F7F-----7|F7||FJL-7FJL7|FJL-7||FJL-7||L7L7F---J|F-JL7|F--7L--7LJFJF-7|FJL-JLJLJL7LJ|LJL7|||FJ|F-JF7FJFJ.L|---|
..|L-J|7FLJFL--7|L-7FJ|F7F--JLJ|L----7LJ|||LJF--JL7FJ|||F7||||F77||L7L-JL7F-7||F7J||L7FJF7FJF7L7L7||||F----7F7L7FJF-7LJLJL-JL--J||FJJF-7-L-J
FLL7LFJ--J.F7F-JL--JL77||L----7L--7F-JF-J||F7L7FF7||FJL7|||LJ|||FJL7|F---JL7LJLJL7||FJL-JLJFJL7L-JLJL7L--7-LJL7LJFJFJF7F-7F-----J|L7FJFJ7.LF
F|7.|F-|J|F||L-7F-7F7L-JL---7LL--7LJF7|F-J||L7L7|||LJF-J|||F-J||L-7LJL7F--7L-7F-7|||L------JF-JF7F7F7L--7L--7.L7FJJL7|LJLLJF7F--7|FJ|FJ|7.-J
-J--7LF.FF7||F7||FJ|L--7F7F7L----JF7|LJL--JL7L7LJLJF-JF-JLJ|F7|L7-|F--J|F-JF-JL7LJ||F---7|F-JF7|||LJ|F-7L---JF7LJF7FLJ-F7F7|||F-J|L-JL-7---J
|-FLJ-FF-JLJ|||LJL-J-F-J||||F-----JLJF7F-7F7L7L---7L-7L---7||||FJFJL---JL7LL7F7L7FJ|L7F-JFJF7|||||F-J|LL-----JL--J|F7F-JLJ||||L7FJF7F--JJ7FJ
J-7|.|LL---7LJ|F77F--JF7|LJLJF7F7F7F7||L7||L-JFF-7|F7L7.F7|||LJL7L7F-7F--JF7||L7||FJFJ|F7L-J||LJLJL-7L7F----7F----J|LJF--7LJ||FJ|FJLJFF7.-7J
J..J.J-F7LFJF7LJL-JF-7|||F---JLJLJLJLJ|FJLJF7F7L7|LJL-JFJ|||L7F-JFJL7LJF7FJ|LJFJ|||LL7LJL7LFJ|F-----JFJL---7|L--7F7L-7|F7|F-J||L|L7.F-JL7FFJ
FFF7FLFJL-JFJ|F-7F7L7LJLJL-----7F7F7F7||F--JLJ|FJ|F7F-7L7|||FJL-7|F7L7FJ|L7L-7|FJ||F7L--7L7L-JL----7FJFF--7||F--J||F7|LJ|LJF-JL7|FJFJF--J-LF
-7LJ7FL-7F7||LJL|||FJF----7JF7FJ|LJLJ||||F--7FJL7||LJFJFJLJ|L7F-J||L7||FJLL-7|||FJLJL-7-|FJF-7F7F7FJ|F-JF7LJ|L---JLJLJF-JF7L7F-J|L-JFJ.LJ.FJ
L|.LF-JLLJ||F7F-J||L7L---7L-J|L-JLF--JLJ||F7LJF7|LJF-J7L--7|FJ|F-JL7LJ||F7LFJLJ|L-7F--JFJL7L7||||||FJL--JL-7L-----7F-7L--JL-J|F-JF--JF-7F-J7
F|7L-7..F7||||L7FJ|FJLF7-L7F7L---7L---7FJLJL-7|||F7L7-F7F-J||FJL7F-JF7|LJL7L--7|F7||F7FJF-JFJLJ|||||F7F7F--J-F7FF7LJ7L7F7F7F7LJF7|F7JFJL|FFJ
LJ.FJ-F-J|LJ|L-J|FJ|F-JL-7||L7F-7L----JL7F---J||||L7L7|||F7LJL7FJ|F-J|L-7FJF7FJ||LJ|||L7|F7L7F-J||LJ||||L-7F7|L-JL---7LJ||LJ|F7||LJL-7FL7FJJ
.-7|.|L-7L--JF-7|L7|L---7LJ|J|||L-----7FJL7F7FJLJL7L-J||LJ|F--JL7|L-7|F7|L7|||FJ|F-J||FJ|||FJ|F7|L7FJLJ|FFJ|||F-----7L-7|L-7|||||F7F-JFL|J7J
FLF77F--JF--7|FJ|FJ|F7F-JF7L7||F------JL7FJ||L7F7FJF7L||JFJL7F7FJL7L|||||FJ|LJ|||||FJ||FJ||L7||||FJL--7L7L-JLJL--7F7L--JL7FJ||LJLJ|L-7J.|||7
F7|JF|F--JLFJ|L7|L7||LJF7|L7|LJL---7F-7FJL7|L7LJ|L7|L7|L7L-7|||L-7L7|||||L7L-7|FJL7|FJ|L7||FJ|||||F---JFJF----7F7LJL--7F7LJL|L-7|.L7FJFFL-JJ
LLJ..LJ-LLFJFJJLJ7LJ|F-JLJFJ|F-----J|FJL-7||FJF7|FJ|FJ|FJF7||||F7|FJ|||||FJF7||L7FJ||JL7||||FJ||||L---7|7L---7LJL--7F7LJL--7L-7L--7LJJF7--7J
-JFF7JLF7LL-JJFFF---J|F---JFJL-----7|L7F-J|||FJ|||FJ|FJL7|||LJ||||L7||||||FJ||L7|L7||F7|||||L7|||L7F7FJ|F7F--JF7F-7||L7F---JF7L---J7|7J|7F|J
|||J|7|L7|7LJ.F7L7F-7||F7F7|F------J|FJL7FJ|||JLJ||-LJJFJ||L-7||||FJ||||||||LJ||L7||LJ||LJ|L7||||FJ|LJFJ||L---J||FJLJJLJF---JL---7F7F7-F--7.
|-L-L77FF-F|F-JL-J|7LJLJ||||L-----7FJL7FJL-J|L--7||F---JFJ|F-JLJLJ|FJ||LJ||F-7FJFJ||LFJ|.FJFJLJ||L7L-7|FJ|F----J||F7JF--JF7F-----J|||L7||LJ7
||J||.LL-7|F|F7F7FJF7F7JLJLJF-----J|F-JL---7|F7FJ||L-7F-JFJL7|F-7FJL7|L-7||L7LJFJFJL7L7|FJFJF--JL7|F7|LJFJL----7|LJL-JF7FJ|L7F----JLJFJ-JF7|
F|-|-|LJ7F--LJLJLJF|LJL---7FJF-7F7FJL-7F--7|||LJFJ|F-J|F-JF7L7|FJL--J|F7|||7L-7|JL7FJFJ|L7|FL--7FJ|||L-7|F7F--7LJF7F7FJLJ7L7LJF-7F-7FJ|-7-77
|LJ|LL-FL7LJJLL.F--JF-7F-7LJFJ.LJ|L7-FJL7FJ||L-7|FJL-7|L7FJL7LJL----7||LJLJF--JL-7LJJL-JF|L7F--JL7LJ|F7||||L-7|F7|LJLJ-F--7L--J||L7|L-7-J7LF
77.|-JF|--77F-.FL--7|FJ||L-7|F7F7L-JFJF7||FJ|F-JLJF--J|FLJF-JF7F7F7FJ||F-7LL-7F--JF7F7FF-JFJL7F7FJF-J|LJ||L7FJ|||L-----JF7L----7|FJL7FJ|.7..
|77|-7-L-|7-|7F|LL7||L-JF--J||LJL---JFJ||||FJL---7L-7FJF-7L7FJLJ||LJFJ|L7L---JL---JLJL7L7FJF-J|||-L-7L-7||-||L|||F7F-7F-JL---7FJ|L-7LJ-7-L77
|.F7-||L-L--JJ|.|L-LJF--JF--JL--7F7F-JFJ|||L7F--7|F-JL-JFJFJL-7FJL7JL7|FJF7F-7F-7F7F7FJFJL7L-7||L-7-|F-J||FJ|FJ|||||FJL-----7LJL|F-J-J.F7L|7
|-JJFFJ7.|L7||-L|7-JLL---JF-----J|||F-JFJ||J|L7-LJL7F7F7L7L7F7||F7L-7|||FJ||FJL7||||LJ7L--JF7|||F7|FJL-7||L7||FJ|||||F7F-7F-JFF7LJJJ||FJF-77
L||-|JJJ7LJ-J-J|L7-J7JF---JF-----J|||F7|FJL7L7|F7FFJ||||FJFJ|||LJ|F-JLJ||-LJL7FJ|||L---7F--JLJ|LJLJ|F-7|LJJ||LJ||||||||L7|L---JL-7J.|7||||LJ
FL7L|||F7F-.FJ-7J|FF7FL----JF--7-FJ|||LJL-7|7|LJL7|FJ||||JL7||L-7|L--7FJL-7F-J|FJ||F7F-JL-7F7FJF--7|L7||F7FJL--7|||||||FJ|F-7F7F-JJ.|J|7FJ.|
7F|LJ-L-7J.F7.|LF77J|F------JF7|FJFJ|L7F--JL7L---J||J||||F7|||F7||F--JL7F7|L-7|L-J|||L7F-7||||7L-7LJFJ|LJ||F7F7|LJ||||||FJL7|||L--7-|-J||LFJ
L7-77.|JLL-J.L|FL||7FL7F--7F7||LJFJ-L-JL-7F7L----7|L7|||LJ|||||S||L---7||LJFFJL-7||||FJL7LJ||L7F-JF7L7L7FJ|||||L-7|||||||F7|||L7F7L7|7F77.-.
|JL|-7L-7|FF-J||-FJ-|LLJ-FJ||||F7|F7F----J|L7F7F-J|FJLJL7FJLJ|||||F7F7|||F--JF-7|FJ||L-7L7FJ|FJL-7||FJ7|L7||LJ|F-JLJLJ||||LJ||.LJL-J-|7J|7.7
J-.LL-JL7FJ-7.7JL|7FL-|JLL7|||LJ|LJ|L7F--7|FLJ|L-7|L--7-|L--7||LJ||||||LJ|F-7|FJ|L7|L7FJFJL7||F--J||L-7L7||L77|L-----7LJLJJL|L7JJL|JLJJ.L7-|
J7F7F-F--|JL-..FFL77-77|LFJ|LJF-JF7|FLJF-JL--7L--JL-7FJFJF7FJ||F-J||||L-7LJFJ||FJFJL7LJFJF7|||L--7|L7FJFJ||FJFJF7F-7FJF7J|LFJFJ|F-J--J.|F|-7
F-L7JL|.|L7J|FF-J77LF.L-FL-J-FJF7|||F--JF-7F7L----7FJ|JL7|LJ7LJL7FJ|||F-JF7L7||L7L7FJF-JFJ|||L7F-JL7LJJ|FJ||J|FJ||FJL7||L|7L7L-7||F-7.LJF-.|
JL-JLFJ-7.JLF|7JFLJ7LF7-|JJF7|FJLJ||L7F7|FJ||F7F7FJL-JF-JL7J-LF-J|FJ||L7L|L-J|L7|J|L7L-7L7|||FJL7F7L--7|L7|L7||FJ|L-7LJL7FJ7L--JJ--.|-L.|J-|
F-J7.|JFL7.FL|.77L|JLL7.||J|LJL7F-JL7LJ||L7||||||L---7L7F7L-7|L-7|L-JL7L7L7F7L7|L7L-JF-JFJ||||FF||L7F7|L7||FJ||L7L-7|F--JJ.FJJ|L.|7.||LFJ|.|
|77LFF-.JJ7|FJ.L-.L7||LF-FFJF7FJ|F7FJ|FJ|FJ|||LJ|F7F7L7||L-7|-J||L-77F|FJ||||FJL7L--7L7FJFJ||L7FJ|-|||L7LJ|L7||FJF-JLJJLJF7-J-FJF|-7FJ.L7J-7
LF|7.||.L-7.|F-.FJ-J-7.L.FJFJLJ.LJ||F-JFJ|FJLJF-J|LJL7|||JLLJ||-|F7|F-JL-7|||L7FJF-7||||.L7||FJ|FJFJ||FJF-JFJLJL7L-7J||FLLJ|J7|--L.LF7L7.|-J
F|.J7F7F7-F|7J-|7JJ.|.J-FJFJJL||.LLJ|F7|FJL-7FJF7||J.LJLJ.L|J7.LLJLJL--7FJ||L-J|FJL||FLJF-J|||FJL7L7|||LL-7L-7.FJF7|.FF-7L---LJFJ|.||J7LF7L|
FJ7F7|F-7FLJ77.7L7-7-7||L7|FLJ|L7JJ.LJLJL7F7||FJLJJ.LJLL7L.|.J77.L|F---J|||L-7FJL7F||JLLL--J|||F7L7LJ|L-7L|F7|FJFJLJ-|JLLJ.LFJ-|-L-F7|F|F-77
.F-LJ|7LL7J.F--L7JLJ.JJ7LLJJF-7-77|.|JFF-J|LJLJLJJ-L7F7LFJFJ7.F-7FFL---7L7|F7|L7FJFLJJJ.|LLJLJ|||FJF-JF-J.LJLJL7|JJ7LL.F|F7F-7L77.LLJ-FF-7LJ
FJ|.|L-7LL.-JL7.F-7J.|J|--|F7-7-L-J7J|FL7FJJ|-JLJ-F.7-F.-F7|.F||FF-7F--JFJLJLJ-LJLF7|-FF--L-7LLJ|L7L-7L-7J..JJFJ|7LF7L-LJ-J|---J|.|.---.LLJ7
-7FF-FL7.|-||.L.||||7FFJ|7-FJ7J|7.|JFL7.LJ|L-F.---7LL7L||L|7.7|FJL7LJF-7|F77LJF||.L7|.L7.-7LL.LFJFJF-JF-J.FL--L-J--JL|.J7F777LL7J-J.LF.|.|.F
LJ7L7|-7L7-7-|J-F---77F7LJ|.|.|FL77F|--7.FL7JLJJFFL7L7LF7JL7-JF|-|L7FJFJLJ|7FLFJ|7.|F7JJ.FF7|F-L7|FL-7|7JF|-JFLJ7.|.FL-L-FJJL-.L|.FL-7-|F-||
7|L--J.JF-7JF|JJ.|FJJFJ|7F-JJ-7|-J|FL-JLFF7|.FL-L-7F7|.-J.LFJFJ|LF7|L7L7F7|7JJ.FL|-|7J7JLJJF|L-FJ|77F|L7J-L-|-JF--|-|7L|||7.|F--FFF7|.F-|JL7
L7F--77.|JF777-77-L7FJF-7-.LL|F-JL|7J-.F-JL|.L|-|.|FL7.|-L.|.J-7-F-JFJFJ|LJJFF7JJL7.|L|-|7-FJ7.L-J|LLL-J|LFLL7-L|||7|L7|7||7FJJL-LJ7--|.FJF7
-JL||LJ.F.|L-J7LJ7|LJ|||LJ..F7FJ7|L|J.7-|J|L7.|.J7.F|L7|-.F77JF|LL7FJLL7||-L-7LLJ7L77FJ|||-L--.LL|7J|||L|.7J.|FFLFJ-|F-J|||FFJ|7L.F|J-77J-|J
.J.L7L7F|7JLJ|J|LLFJ..|7FLJF7L|L-J77.FL7J-|LF7J.F-7LF-JJ77F|J.L.FFJ|J.LLJ7.|..FJ-F7JLJ7F-|J|7L-|-L-77-LJL-J.7L77LF-JJ|J|LJ7-L-7-LL-777LL7.|J
FLL7JL|LF-77.L.|7.L7.LF|7FJL|FLFL|J|-7----7.LJF-F.FL-7-LLL||7F|FLL-J--7JLJ-77F|.F77|F7--||7F7F77FL|JJ.|-|FL7.J.F7JFJ.|.L.|JLLJL7-J-LJ|7L77.|
|.FJ|-|F|||77L|7.FF--7L-JJ|FL|.J7|LLJ|-JJ.|FFF|-J77.L||-|JFJ-|-LJFJJ|.L7FLJ.||F7|LF-|J.LLJ-LJ7|FLF7J.-L7-7--7LFJ|FJ.F77L|L||L-|.-JLL7LL.|J7L
|-|-J.--LLLF|JJ.FFLJL-J-JJL--JF-L7-|J.F.LJ.L-J|L|77--J|-J.JL|.J.LJJL-JJLJJ.-J-J-7-7-LJL7L|-L-JJLLFJF--L|J--JFJF-7-LLJL--|---F.--|7J.L-L7JJ-.";
            var sample = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }
        private static int[] dr = new[] { -1, 0, 1, 0 }; // NORTH, EAST, SOUTH, WEST
        private static int[] dc = new[] { 0, 1, 0, -1 }; // NORTH, EAST, SOUTH, WEST
        private static Dictionary<char, int> pipes = new() { { '|', 0 + 2 }, { '-', 1 + 3 }, { 'L', 0 + 1 }, { 'J', 0 + 3 }, { '7', 2 + 3 }, { 'F', 1 + 2 } };
        private static void part2(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int step = 0;
            int m = inputs.Length, n = inputs[0].Length;
            var grid = new char[m + 2][];
            grid[0] = grid[m + 1] = new char[n + 2];
            int startR = 0, startC = 0;
            for (int j = 0; j < n + 2; j++) grid[0][j] = '.';
            for (int r = 1; r < m + 1; r++)
            {
                grid[r] = new char[n + 2];
                grid[r][0] = grid[r][n + 1] = '.';
                for (int c = 1; c < n + 1; c++)
                {
                    grid[r][c] = inputs[r - 1][c - 1];
                    if (grid[r][c] == 'S')
                    {
                        startR = r;
                        startC = c;
                    }
                }
            }
            var visited = new HashSet<(int r, int c)>();
            visited.Add((startR, startC));


            var q = new Queue<(int r, int c, int previous, int step)>();
            if ("|7F".Contains(grid[startR - 1][startC])) // connecting north
            {
                q.Enqueue((startR - 1, startC, 2, 1)); // entering from south after first step
            }
            if ("|JL".Contains(grid[startR + 1][startC])) // connecting south
            {
                q.Enqueue((startR + 1, startC, 0, 1)); // entering from north after first step
            }
            if ("-J7".Contains(grid[startR][startC + 1])) // entering from west after first step
            {
                q.Enqueue((startR, startC + 1, 3, 1));
            }
            if ("-FL".Contains(grid[startR][startC - 1])) // entering from east after first step
            {
                q.Enqueue((startR, startC - 1, 1, 1));
            }
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (visited.Contains((p.r, p.c))) continue;
                visited.Add((p.r, p.c));
                step = Math.Max(step, p.step);
                int next = pipes[grid[p.r][p.c]] - p.previous;
                int nextr = p.r + dr[next];
                int nextc = p.c + dc[next];
                q.Enqueue((nextr, nextc, (next + 2) % 4, p.step + 1));
            }
            for (int i = 0; i < m + 2; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    if (!visited.Contains((i, j)))
                        grid[i][j] = '.';
                }
            }
            print(grid);
            var zoom = Zoom(grid);
            print(zoom);
            bfs(zoom, 0, 0);
            print(zoom);
            var count = zoom.Select((row, i) => i % 2 == 0 ? row.Select((c, j) => (j % 2 == 0 && c == 'I') ? 1 : 0).Sum() : 0).Sum();
            Console.WriteLine($"2nd part answer is {count}");
        }

        private static void bfs(char[][] grille, int startR, int startC)
        {
            int m = grille.Length, n = grille[0].Length;
            grille[startR][startC] = 'O';
            var q = new Queue<(int r, int c)>();
            q.Enqueue((startR, startC));
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nr = p.r + dr[i], nc = p.c + dc[i];
                    if (nr < 0 || nc < 0 || nr == m || nc == n) continue;
                    if (grille[nr][nc] != 'I') continue;
                    grille[nr][nc] = 'O';
                    q.Enqueue((nr, nc));
                }
            }
        }

        private static void print(char[][] grid)
        {
            int m = grid.Length;
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(string.Join("", grid[i]));
            }
        }

        private static char[][] Zoom(char[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var zoom = new char[2 * m][];
            for (int r = 0; r < 2*m; r++)
            {
                zoom[r] = new char[2*n];
                for (int c = 0; c < 2*n; c++)
                {
                    zoom[r][c] = 'I';
                }
            }
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r][c] == '.') continue;
                    zoom[2 * r][2 * c] = grid[r][c];
                    if ("|7F".Contains(grid[r][c])) // connecting north
                    {
                        zoom[2 * r + 1][2 * c] = '|';
                    }
                    if ("|JL".Contains(grid[r][c])) // connecting south
                    {
                        zoom[2 * r - 1][2 * c] = '|';
                    }
                    if ("-J7".Contains(grid[r][c])) // entering from west after first step
                    {
                        zoom[2 * r][2 * c - 1] = '-';
                    }
                    if ("-FL".Contains(grid[r][c])) // entering from east after first step
                    {
                        zoom[2 * r][2 * c + 1] = '-';
                    }

                }
            }
            return zoom;
        }

        private static void part1(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int step = 0;
            int m = inputs.Length, n = inputs[0].Length;
            var grid = new char[m + 2][];
            grid[0] = grid[m + 1] = new char[n + 2];
            int startR = 0, startC = 0;
            for (int j = 0; j < n + 2; j++) grid[0][j] = '.';
            for (int r = 1; r < m + 1; r++)
            {
                grid[r] = new char[n + 2];
                grid[r][0] = grid[r][n + 1] = '.';
                for (int c = 1; c < n + 1; c++)
                {
                    grid[r][c] = inputs[r - 1][c - 1];
                    if (grid[r][c] == 'S')
                    {
                        startR = r;
                        startC = c;
                    }
                }
            }
            var visited = new HashSet<(int r, int c)>();
            visited.Add((startR, startC));


            var q = new Queue<(int r, int c, int previous, int step)>();
            if ("|7F".Contains(grid[startR - 1][startC])) // connecting north
            {
                q.Enqueue((startR - 1, startC, 2, 1)); // entering from south after first step
            }
            if ("|JL".Contains(grid[startR + 1][startC])) // connecting south
            {
                q.Enqueue((startR + 1, startC, 0, 1)); // entering from north after first step
            }
            if ("-J7".Contains(grid[startR][startC + 1])) // entering from west after first step
            {
                q.Enqueue((startR, startC + 1, 3, 1));
            }
            if ("-FL".Contains(grid[startR][startC - 1])) // entering from east after first step
            {
                q.Enqueue((startR, startC - 1, 1, 1));
            }
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (visited.Contains((p.r, p.c))) continue;
                visited.Add((p.r, p.c));
                step = Math.Max(step, p.step);
                int next = pipes[grid[p.r][p.c]] - p.previous;
                int nextr = p.r + dr[next];
                int nextc = p.c + dc[next];
                q.Enqueue((nextr, nextc, (next + 2) % 4, p.step + 1));
            }
            Console.WriteLine($"1st part answer is {step}");
        }


    }

}