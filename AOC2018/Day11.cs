using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day11
    {
        // Size of given matrix
        static int N;

        public static void Main()
        {
            N = 300;
            var input = @"9306";
            int serial = int.Parse(input);
            int n = 300;
            var grid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                grid[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = Fill(j + 1, i + 1, serial);
                }
            }
            (int, int) coordinate = (0, 0);
            int maximal = int.MinValue;
            for (int x = 0; x < n - 2; x++)
            {
                for (int y = 0; y < n - 2; y++)
                {
                    int total = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            total += grid[y + i][x + j];
                        }
                    }
                    if (maximal < total)
                    {
                        maximal = total;
                        coordinate = (x + 1, y + 1);
                    }
                }
            }
            Console.WriteLine($"{coordinate.Item1},{coordinate.Item2} = {maximal}");

            int maxi = int.MinValue;
            int X = -1, Y = -1, size = -1;
            for (int k = 1; k < 301; k++)
            {
                (int x, int y, int power) = printMaxSumSub(grid, k);
                if (power > maxi)
                {
                    maxi = power;
                    size = k;
                    X = x + 1;
                    Y = y + 1;
                }
            }
            Console.WriteLine($"{X},{Y},{size}");
        }

        private static int Fill(int X, int Y, int serial)
        {
            int rackId = X + 10;
            int powerLevel = rackId * Y;
            powerLevel += serial;
            powerLevel *= rackId;
            return powerLevel / 100 % 10 - 5;

        }

        // A O(n^2) function to the maximum sum sub-
        // squares of size k x k in a given square
        // matrix of size n x n
        public static (int x, int y, int power) printMaxSumSub(int[][] mat, int k)
        {

            // k must be smaller than or equal to n
            if (k > N)
                return (-1, -1, -1);

            // 1: PREPROCESSING
            // To store sums of all strips of size k x 1
            int[,] stripSum = new int[N, N];

            // Go column by column
            for (int j = 0; j < N; j++)
            {

                // Calculate sum of first k x 1 rectangle
                // in this column
                int sum = 0;
                for (int i = 0; i < k; i++)
                    sum += mat[i][j];
                stripSum[0, j] = sum;

                // Calculate sum of remaining rectangles
                for (int i = 1; i < N - k + 1; i++)
                {
                    sum += mat[i + k - 1][j] -
                            mat[i - 1][j];
                    stripSum[i, j] = sum;
                }
            }

            // max_sum stores maximum sum and its
            // position in matrix
            int max_sum = int.MinValue;
            Position pos = new Position(-1, -1);

            // 2: CALCULATE SUM of Sub-Squares using stripSum[,]
            for (int i = 0; i < N - k + 1; i++)
            {

                // Calculate and print sum of first subsquare
                // in this row
                int sum = 0;
                for (int j = 0; j < k; j++)
                    sum += stripSum[i, j];

                // Update max_sum and position of result
                if (sum > max_sum)
                {
                    max_sum = sum;
                    pos.updatePosition(i, 0);
                }

                // Calculate sum of remaining squares in
                // current row by removing the leftmost
                // strip of previous sub-square and adding
                // a new strip
                for (int j = 1; j < N - k + 1; j++)
                {
                    sum += stripSum[i, j + k - 1] -
                            stripSum[i, j - 1];

                    // Update max_sum and position of result
                    if (sum > max_sum)
                    {
                        max_sum = sum;
                        pos.updatePosition(i, j);
                    }
                }
            }

            // Print the result matrix
            //for (int i = 0; i < k; i++)
            //{
            //    for (int j = 0; j < k; j++)
            //    {
            //        Console.Write(mat[i + pos.getXPosition()][
            //                          j + pos.getYPosition()] + " ");
            //    }
            //    Console.WriteLine();
            //}
            return (pos.getYPosition(), pos.getXPosition(), max_sum);
        }

    }
    class Position
    {
        int x;
        int y;

        // Constructor
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Updates the position if new maximum sum
        // is found
        public void updatePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // returns the current value of X
        public int getXPosition()
        {
            return x;
        }

        // returns the current value of y
        public int getYPosition()
        {
            return y;
        }
    }

    //class GFG
    //{

    //    // Driver Code
    //    public public static void Main()
    //    {
    //        N = 5;
    //        int[,] mat = {{ 1, 1, 1, 1, 1 },
    //                  { 2, 2, 2, 2, 2 },
    //                    { 3, 8, 6, 7, 3 },
    //                  { 4, 4, 4, 4, 4 },
    //                  { 5, 5, 5, 5, 5 }};
    //        int k = 3;

    //        Console.WriteLine("Maximum sum 3 x 3 matrix is");
    //        printMaxSumSub(mat, k);
    //    }
    //}
}
