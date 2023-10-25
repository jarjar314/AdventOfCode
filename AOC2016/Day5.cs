using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day5
    {
        public static void Main()
        {
            var input = "ffykfhsq";
            //input = "abc";
            var sb = new StringBuilder();
            var sb2 = new char[8];
            long i = 0;
            char[] map = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            using (var md5 = MD5.Create())
            {
                while (true)
                {
                    byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input + i));
                    if (data[0] == 0 && data[1] == 0 && data[2] < 16)
                    {
                        if (sb.Length < 8)
                            sb.Append(map[data[2]]);
                        if (data[2] < 8 && sb2[data[2]] == '\0')
                            sb2[data[2]] = map[data[3] / 16];

                        if (sb.Length == 8 && sb2.All(c => c != '\0'))
                            break;
                    }
                    i++;
                }
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(new string(sb2));
        }
    }
}
