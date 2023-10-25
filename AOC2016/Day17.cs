using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day17
    {
        public static void Main()
        {
            var input = "hhhxzeay";
            //input = "ihgpwlah";
            //input = "kglvqrro";

            var allpaths = FindPath(input);
            Console.WriteLine(allpaths.First());
            Console.WriteLine(allpaths.Select(x => x.Length).Max() - input.Length);
        }

        private static List<string> FindPath(string input)
        {
            var res = new List<string>();
            using (var md5 = MD5.Create())
            {

                var q = new Queue<(int row, int col, string path)>();
                q.Enqueue((0, 0, input));
                while (q.Count > 0)
                {
                    var p = q.Dequeue();
                    byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(p.path));
                    var key = data[0].ToString("x2") + data[1].ToString("x2");
                    var up = IsOpen(key[0]);
                    var down = IsOpen(key[1]);
                    var left = IsOpen(key[2]);
                    var right = IsOpen(key[3]);
                    int row = p.row;
                    int col = p.col;
                    if (up && row != 0)
                    {
                        q.Enqueue((row - 1, col, p.path + "U"));
                    }
                    if (down && row != 3)
                    {
                        if (row == 2 && col == 3)
                        {
                            res.Add(p.path + "D");
                        }
                        else
                            q.Enqueue((row + 1, col, p.path + "D"));
                    }
                    if (left && col != 0)
                    {
                        q.Enqueue((row, col - 1, p.path + "L"));
                    }
                    if (right && col != 3)
                    {
                        if (row == 3 && col == 2)
                        {
                            res.Add(p.path + "R");
                        }
                        else
                            q.Enqueue((row, col + 1, p.path + "R"));
                    }

                }
            }
            return res;
        }

        private static bool IsOpen(char v)
        {
            return "bcdef".Contains(v);
        }
    }

}
