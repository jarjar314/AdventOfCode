using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day14
    {
        public static void Main()
        {
            var input = "ngcjuoqr";
            //input = "abc";
            Console.WriteLine(FindElement(input, 1));
            Console.WriteLine(FindElement(input, 2017));
        }

        private static long FindElement(string input, int loop)
        {
            long i = 0;
            char[] map = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            var keys3 = new Dictionary<char, List<long>>();
            foreach (var m in map) keys3.Add(m, new List<long>());
            var keysIndex = new SortedSet<long>();
            using (var md5 = MD5.Create())
            {
                while (true)
                {
                    string basis = input + i;
                    var s = new StringBuilder();
                    for (int j = 0; j < loop; j++)
                    {
                        byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(basis));
                        s.Clear();
                        foreach (var b in data)
                        {
                            s.Append(b.ToString("x2"));
                        }
                        basis = s.ToString();
                    }
                    var has5 = Has(s, 5);
                    bool added = false;
                    if (has5 != ' ')
                    {
                        foreach (var index in keys3[has5])
                        {
                            if (i - index <= 1000)
                            {
                                added = true;
                                keysIndex.Add(index);
                            }
                        }
                        keys3[has5].Add(i);
                    }
                    var has3 = Has(s, 3);
                    if (has3 != ' ')
                    {
                        keys3[has3].Add(i);
                        if (added && keysIndex.Count >= 64)
                        {
                            if (keysIndex.Skip(63).First() + 1000 < i)
                                break;
                        }
                    }
                    i++;
                }
            }
            return keysIndex.Skip(63).First();
        }

        private static char Has(StringBuilder s, int v)
        {
            var res = ' ';
            for (int i = 0; i < s.Length - v + 1; i++)
            {
                var c = s[i];
                bool match = true;
                for (int j = 1; j < v; j++)
                {
                    if (c != s[i + j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return c;
            }

            return res;
        }
    }

}
