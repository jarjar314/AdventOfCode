using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day18
    {
        public static void Main()
        {
            int size = 400000;
            var input = @"^..^^.^^^..^^.^...^^^^^....^.^..^^^.^.^.^^...^.^.^.^.^^.....^.^^.^.^.^.^.^.^^..^^^^^...^.....^....^.";
            var room = new char[size][];
            var l = input.Length + 2;
            room[0] = new char[l];
            room[0][0] = '.';
            room[0][l - 1] = '.';
            // Add two extras col to mark walls.
            for (int col = 1; col < l - 1; col++)
            {
                room[0][col] = input[col - 1];
            }
            for (int i = 1; i < size; i++)
            {
                room[i] = new char[l];
                room[i][0] = '.';
                room[i][l - 1] = '.';
                for (int col = 1; col < l - 1; col++)
                {
                    if (room[i - 1][col - 1] != room[i - 1][col + 1])
                        room[i][col] = '^';
                    else
                        room[i][col] = '.';
                }
            }
            Console.WriteLine(room.Select(x => x.Count(c => c == '.')).Sum() - 2 * size);
        }

    }

}
