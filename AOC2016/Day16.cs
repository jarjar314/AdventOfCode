using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day16
    {
        public static void Main()
        {
            var input = "11011110011011101";
            //input = "abc";
            int diskSize = 272;

            Console.WriteLine(CheckSum(Generate(input, 272).Substring(0, 272)));
            Console.WriteLine(CheckSum(Generate(input, 35651584).Substring(0, 35651584)));
        }

        private static string Generate(string input, int diskSize)
        {
            int n = input.Length;
            while (n <= diskSize)
            {
                input = DragonCurve(input);
                n = input.Length;
            }
            return input;
        }

        private static string CheckSum(string v)
        {
            while (v.Length % 2 == 0)
            {
                int n = v.Length;
                var sb = new StringBuilder(n / 2);
                for (int i = 0; i < n; i += 2)
                {
                    if (v[i] == v[i + 1])
                        sb.Append('1');
                    else
                        sb.Append('0');
                }
                v = sb.ToString();
            }
            return v;
        }

        private static string DragonCurve(string input)
        {
            int s01 = '0' + '1';
            int n = input.Length;
            var sb = new StringBuilder(input);
            sb.Append('0');
            for (int i = n - 1; i >= 0; i--)
            {
                sb.Append((char)(s01 - input[i]));
            }
            return sb.ToString();
        }
    }

}
