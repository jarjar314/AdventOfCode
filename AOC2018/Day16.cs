using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2018
{
    public class Day16
    {
        static Regex before = new Regex(@"Before: \[(?<A>[0-9]+), (?<B>[0-9]+), (?<C>[0-9]+), (?<D>[0-9]+)\]");
        static Regex after = new Regex(@"After:  \[(?<A>[0-9]+), (?<B>[0-9]+), (?<C>[0-9]+), (?<D>[0-9]+)\]");
        private static int ReadInt(Match match, string key)
        {
            return int.Parse(match.Groups[key].Value);
        }

        public static void Main()
        {
            var firstPart = @"Before: [0, 3, 0, 3]
9 0 0 1
After:  [0, 0, 0, 3]

Before: [1, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [0, 0, 1, 2]
1 0 3 3
After:  [0, 0, 1, 0]

Before: [2, 1, 2, 1]
3 1 2 2
After:  [2, 1, 0, 1]

Before: [2, 1, 2, 0]
15 2 0 1
After:  [2, 1, 2, 0]

Before: [0, 3, 0, 3]
1 0 1 2
After:  [0, 3, 0, 3]

Before: [3, 1, 0, 3]
10 0 3 2
After:  [3, 1, 1, 3]

Before: [0, 1, 2, 3]
4 1 3 1
After:  [0, 0, 2, 3]

Before: [1, 1, 1, 2]
2 1 3 1
After:  [1, 0, 1, 2]

Before: [3, 1, 2, 1]
3 1 2 1
After:  [3, 0, 2, 1]

Before: [2, 1, 3, 2]
11 0 2 3
After:  [2, 1, 3, 1]

Before: [2, 0, 3, 3]
10 2 3 0
After:  [1, 0, 3, 3]

Before: [0, 1, 2, 1]
5 3 2 2
After:  [0, 1, 1, 1]

Before: [3, 0, 0, 3]
15 3 0 0
After:  [1, 0, 0, 3]

Before: [2, 1, 3, 0]
11 0 2 2
After:  [2, 1, 1, 0]

Before: [0, 0, 2, 0]
9 0 0 3
After:  [0, 0, 2, 0]

Before: [1, 1, 0, 3]
12 1 1 0
After:  [1, 1, 0, 3]

Before: [3, 1, 2, 0]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 3, 2, 1]
0 3 1 2
After:  [3, 3, 1, 1]

Before: [3, 2, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [1, 1, 3, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 3, 2, 3]
9 0 0 3
After:  [0, 3, 2, 0]

Before: [0, 0, 1, 1]
13 2 3 0
After:  [0, 0, 1, 1]

Before: [1, 2, 3, 1]
13 3 3 1
After:  [1, 0, 3, 1]

Before: [3, 0, 3, 3]
10 0 3 1
After:  [3, 1, 3, 3]

Before: [0, 2, 2, 3]
7 3 2 0
After:  [0, 2, 2, 3]

Before: [3, 0, 0, 3]
7 3 3 0
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [1, 3, 0, 2]
14 0 2 0
After:  [0, 3, 0, 2]

Before: [2, 1, 2, 0]
3 1 2 1
After:  [2, 0, 2, 0]

Before: [0, 1, 2, 1]
5 3 2 3
After:  [0, 1, 2, 1]

Before: [0, 3, 1, 2]
7 0 0 2
After:  [0, 3, 1, 2]

Before: [0, 1, 1, 2]
9 0 0 0
After:  [0, 1, 1, 2]

Before: [1, 3, 0, 2]
14 0 2 2
After:  [1, 3, 0, 2]

Before: [3, 1, 0, 2]
2 1 3 0
After:  [0, 1, 0, 2]

Before: [3, 1, 2, 3]
10 0 3 3
After:  [3, 1, 2, 1]

Before: [1, 2, 2, 1]
5 3 2 2
After:  [1, 2, 1, 1]

Before: [0, 3, 0, 1]
13 3 3 0
After:  [0, 3, 0, 1]

Before: [3, 1, 2, 2]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [0, 1, 2, 0]
3 1 2 2
After:  [0, 1, 0, 0]

Before: [2, 2, 3, 1]
11 0 2 2
After:  [2, 2, 1, 1]

Before: [3, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [2, 3, 3, 3]
11 0 2 1
After:  [2, 1, 3, 3]

Before: [1, 1, 2, 3]
3 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 3, 2, 3]
7 3 2 0
After:  [0, 3, 2, 3]

Before: [1, 0, 2, 3]
8 0 2 2
After:  [1, 0, 0, 3]

Before: [0, 1, 3, 2]
13 3 3 0
After:  [0, 1, 3, 2]

Before: [0, 0, 0, 1]
6 0 2 1
After:  [0, 0, 0, 1]

Before: [3, 3, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [0, 3, 0, 2]
6 0 2 3
After:  [0, 3, 0, 0]

Before: [0, 2, 0, 0]
9 0 0 3
After:  [0, 2, 0, 0]

Before: [1, 0, 2, 1]
8 0 2 1
After:  [1, 0, 2, 1]

Before: [3, 2, 0, 2]
11 2 0 2
After:  [3, 2, 1, 2]

Before: [3, 1, 2, 3]
3 1 2 2
After:  [3, 1, 0, 3]

Before: [3, 0, 2, 0]
7 2 2 0
After:  [1, 0, 2, 0]

Before: [0, 0, 3, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [0, 1, 0, 2]
1 0 3 1
After:  [0, 0, 0, 2]

Before: [1, 0, 2, 0]
8 0 2 3
After:  [1, 0, 2, 0]

Before: [2, 0, 3, 3]
11 0 2 2
After:  [2, 0, 1, 3]

Before: [3, 1, 3, 3]
10 0 3 0
After:  [1, 1, 3, 3]

Before: [1, 1, 1, 3]
7 3 3 0
After:  [1, 1, 1, 3]

Before: [2, 3, 3, 3]
10 2 3 1
After:  [2, 1, 3, 3]

Before: [3, 1, 3, 3]
10 0 3 1
After:  [3, 1, 3, 3]

Before: [1, 0, 1, 2]
13 3 3 3
After:  [1, 0, 1, 0]

Before: [0, 2, 1, 2]
7 0 0 1
After:  [0, 1, 1, 2]

Before: [3, 3, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 3, 1, 2]
1 0 1 2
After:  [0, 3, 0, 2]

Before: [0, 0, 3, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [2, 3, 2, 3]
15 2 0 2
After:  [2, 3, 1, 3]

Before: [3, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [3, 3, 2, 1]
5 3 2 2
After:  [3, 3, 1, 1]

Before: [2, 1, 2, 3]
3 1 2 2
After:  [2, 1, 0, 3]

Before: [1, 1, 0, 1]
12 1 1 0
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 3]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 0, 3, 3]
10 2 3 1
After:  [3, 1, 3, 3]

Before: [1, 1, 2, 2]
8 0 2 0
After:  [0, 1, 2, 2]

Before: [0, 0, 0, 2]
6 0 2 0
After:  [0, 0, 0, 2]

Before: [0, 1, 2, 2]
12 1 1 3
After:  [0, 1, 2, 1]

Before: [2, 1, 1, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 3, 2, 0]
15 2 0 3
After:  [2, 3, 2, 1]

Before: [2, 2, 1, 1]
13 3 3 0
After:  [0, 2, 1, 1]

Before: [2, 1, 3, 2]
2 1 3 3
After:  [2, 1, 3, 0]

Before: [1, 0, 3, 3]
10 2 3 0
After:  [1, 0, 3, 3]

Before: [0, 0, 0, 2]
6 0 1 2
After:  [0, 0, 0, 2]

Before: [1, 3, 3, 3]
10 2 3 3
After:  [1, 3, 3, 1]

Before: [2, 1, 3, 0]
12 1 1 3
After:  [2, 1, 3, 1]

Before: [3, 2, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [0, 1, 3, 1]
13 3 3 0
After:  [0, 1, 3, 1]

Before: [3, 1, 3, 1]
7 2 1 1
After:  [3, 0, 3, 1]

Before: [0, 1, 1, 2]
2 1 3 1
After:  [0, 0, 1, 2]

Before: [3, 0, 2, 3]
4 2 3 2
After:  [3, 0, 0, 3]

Before: [1, 1, 0, 2]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 1, 2, 3]
3 1 2 3
After:  [0, 1, 2, 0]

Before: [3, 1, 0, 1]
12 1 1 3
After:  [3, 1, 0, 1]

Before: [0, 1, 3, 0]
6 0 3 1
After:  [0, 0, 3, 0]

Before: [2, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [2, 1, 3, 3]
12 1 1 1
After:  [2, 1, 3, 3]

Before: [3, 0, 0, 3]
11 2 0 1
After:  [3, 1, 0, 3]

Before: [3, 1, 1, 3]
4 1 3 3
After:  [3, 1, 1, 0]

Before: [3, 2, 0, 1]
13 3 3 2
After:  [3, 2, 0, 1]

Before: [0, 3, 0, 0]
6 0 3 3
After:  [0, 3, 0, 0]

Before: [0, 2, 2, 1]
7 0 0 3
After:  [0, 2, 2, 1]

Before: [3, 3, 3, 1]
0 3 1 3
After:  [3, 3, 3, 1]

Before: [1, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [1, 0, 0, 3]
14 0 2 0
After:  [0, 0, 0, 3]

Before: [1, 1, 3, 3]
15 3 2 2
After:  [1, 1, 1, 3]

Before: [2, 1, 2, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 3, 1, 3]
4 2 3 0
After:  [0, 3, 1, 3]

Before: [0, 1, 1, 0]
6 0 3 2
After:  [0, 1, 0, 0]

Before: [1, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [0, 0, 2, 2]
6 0 1 1
After:  [0, 0, 2, 2]

Before: [1, 2, 2, 1]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 3, 2, 1]
5 3 2 3
After:  [3, 3, 2, 1]

Before: [1, 0, 0, 1]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [2, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [0, 3, 0, 1]
0 3 1 1
After:  [0, 1, 0, 1]

Before: [1, 1, 0, 0]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 0, 3, 1]
15 2 3 3
After:  [0, 0, 3, 0]

Before: [2, 2, 1, 1]
13 3 3 1
After:  [2, 0, 1, 1]

Before: [0, 0, 3, 3]
1 0 3 3
After:  [0, 0, 3, 0]

Before: [0, 1, 1, 1]
1 0 2 0
After:  [0, 1, 1, 1]

Before: [1, 1, 0, 3]
7 3 1 2
After:  [1, 1, 0, 3]

Before: [0, 1, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [2, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [3, 1, 3, 1]
15 2 3 3
After:  [3, 1, 3, 0]

Before: [0, 2, 0, 2]
9 0 0 0
After:  [0, 2, 0, 2]

Before: [0, 1, 2, 3]
3 1 2 2
After:  [0, 1, 0, 3]

Before: [0, 0, 0, 0]
6 0 3 3
After:  [0, 0, 0, 0]

Before: [0, 3, 2, 1]
1 0 2 0
After:  [0, 3, 2, 1]

Before: [3, 1, 3, 3]
10 2 3 2
After:  [3, 1, 1, 3]

Before: [3, 1, 3, 2]
12 1 1 3
After:  [3, 1, 3, 1]

Before: [2, 3, 2, 1]
5 3 2 3
After:  [2, 3, 2, 1]

Before: [0, 1, 1, 2]
2 1 3 3
After:  [0, 1, 1, 0]

Before: [0, 3, 1, 1]
0 3 1 3
After:  [0, 3, 1, 1]

Before: [0, 1, 0, 1]
6 0 2 0
After:  [0, 1, 0, 1]

Before: [1, 0, 0, 2]
13 3 3 3
After:  [1, 0, 0, 0]

Before: [1, 2, 2, 3]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 2, 0, 3]
10 0 3 2
After:  [3, 2, 1, 3]

Before: [1, 1, 2, 1]
5 3 2 2
After:  [1, 1, 1, 1]

Before: [2, 3, 3, 1]
15 2 3 3
After:  [2, 3, 3, 0]

Before: [0, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [3, 1, 3, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [2, 0, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [2, 3, 2, 1]
0 3 1 1
After:  [2, 1, 2, 1]

Before: [1, 3, 2, 2]
8 0 2 0
After:  [0, 3, 2, 2]

Before: [2, 3, 3, 3]
11 0 2 0
After:  [1, 3, 3, 3]

Before: [2, 2, 2, 1]
15 2 0 2
After:  [2, 2, 1, 1]

Before: [2, 3, 3, 1]
11 0 2 1
After:  [2, 1, 3, 1]

Before: [0, 1, 0, 0]
9 0 0 2
After:  [0, 1, 0, 0]

Before: [1, 0, 0, 1]
14 0 2 0
After:  [0, 0, 0, 1]

Before: [2, 1, 2, 3]
3 1 2 1
After:  [2, 0, 2, 3]

Before: [3, 0, 0, 2]
11 2 0 3
After:  [3, 0, 0, 1]

Before: [3, 3, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [3, 3, 0, 2]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [3, 2, 2, 3]
15 3 0 0
After:  [1, 2, 2, 3]

Before: [0, 0, 2, 1]
5 3 2 2
After:  [0, 0, 1, 1]

Before: [3, 1, 0, 3]
10 0 3 0
After:  [1, 1, 0, 3]

Before: [0, 2, 3, 3]
7 3 1 1
After:  [0, 0, 3, 3]

Before: [2, 1, 2, 3]
15 2 0 2
After:  [2, 1, 1, 3]

Before: [3, 1, 2, 3]
4 1 3 3
After:  [3, 1, 2, 0]

Before: [3, 0, 2, 1]
5 3 2 2
After:  [3, 0, 1, 1]

Before: [1, 3, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 2]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [0, 0, 3, 3]
10 2 3 2
After:  [0, 0, 1, 3]

Before: [0, 0, 2, 2]
1 0 3 3
After:  [0, 0, 2, 0]

Before: [0, 1, 3, 0]
12 1 1 0
After:  [1, 1, 3, 0]

Before: [0, 3, 3, 3]
15 3 2 3
After:  [0, 3, 3, 1]

Before: [3, 1, 0, 1]
11 2 0 0
After:  [1, 1, 0, 1]

Before: [1, 0, 0, 2]
14 0 2 0
After:  [0, 0, 0, 2]

Before: [2, 0, 2, 1]
10 0 2 1
After:  [2, 1, 2, 1]

Before: [2, 3, 3, 2]
13 3 3 3
After:  [2, 3, 3, 0]

Before: [0, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 1, 2, 0]
1 0 2 0
After:  [0, 1, 2, 0]

Before: [0, 0, 2, 0]
6 0 1 0
After:  [0, 0, 2, 0]

Before: [3, 1, 2, 0]
12 1 1 0
After:  [1, 1, 2, 0]

Before: [1, 1, 0, 3]
14 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 0, 3, 0]
6 0 3 2
After:  [0, 0, 0, 0]

Before: [2, 0, 2, 0]
10 0 2 1
After:  [2, 1, 2, 0]

Before: [1, 3, 3, 1]
0 3 1 3
After:  [1, 3, 3, 1]

Before: [3, 0, 0, 3]
10 0 3 3
After:  [3, 0, 0, 1]

Before: [3, 3, 1, 3]
7 3 3 3
After:  [3, 3, 1, 1]

Before: [3, 0, 3, 3]
15 3 0 2
After:  [3, 0, 1, 3]

Before: [0, 1, 2, 2]
3 1 2 2
After:  [0, 1, 0, 2]

Before: [1, 2, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [2, 2, 1, 1]
13 2 3 1
After:  [2, 0, 1, 1]

Before: [1, 0, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [3, 2, 0, 3]
11 2 0 2
After:  [3, 2, 1, 3]

Before: [0, 0, 3, 2]
6 0 1 2
After:  [0, 0, 0, 2]

Before: [1, 0, 2, 1]
8 0 2 3
After:  [1, 0, 2, 0]

Before: [2, 0, 3, 2]
11 0 2 2
After:  [2, 0, 1, 2]

Before: [1, 2, 0, 1]
13 3 3 3
After:  [1, 2, 0, 0]

Before: [2, 1, 3, 2]
2 1 3 1
After:  [2, 0, 3, 2]

Before: [2, 0, 2, 1]
5 3 2 3
After:  [2, 0, 2, 1]

Before: [1, 3, 3, 1]
13 3 3 3
After:  [1, 3, 3, 0]

Before: [1, 0, 2, 3]
8 0 2 0
After:  [0, 0, 2, 3]

Before: [3, 2, 2, 2]
7 2 2 0
After:  [1, 2, 2, 2]

Before: [1, 1, 2, 3]
8 0 2 2
After:  [1, 1, 0, 3]

Before: [3, 3, 1, 1]
0 3 1 2
After:  [3, 3, 1, 1]

Before: [3, 1, 1, 2]
12 1 1 1
After:  [3, 1, 1, 2]

Before: [0, 3, 3, 2]
13 3 3 1
After:  [0, 0, 3, 2]

Before: [3, 1, 0, 1]
12 1 1 0
After:  [1, 1, 0, 1]

Before: [0, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [1, 3, 0, 0]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [1, 2, 0, 3]
14 0 2 0
After:  [0, 2, 0, 3]

Before: [1, 3, 0, 2]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [0, 1, 0, 1]
6 0 2 2
After:  [0, 1, 0, 1]

Before: [2, 0, 2, 1]
10 0 2 3
After:  [2, 0, 2, 1]

Before: [0, 1, 3, 1]
15 2 3 2
After:  [0, 1, 0, 1]

Before: [1, 3, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [2, 1, 3, 3]
4 1 3 3
After:  [2, 1, 3, 0]

Before: [3, 3, 3, 3]
15 3 0 1
After:  [3, 1, 3, 3]

Before: [1, 3, 0, 0]
14 0 2 0
After:  [0, 3, 0, 0]

Before: [1, 1, 0, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 1, 2, 2]
2 1 3 3
After:  [0, 1, 2, 0]

Before: [3, 0, 0, 0]
11 2 0 3
After:  [3, 0, 0, 1]

Before: [2, 3, 0, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [1, 1, 2, 1]
3 1 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 3, 2]
12 1 1 2
After:  [3, 1, 1, 2]

Before: [0, 3, 1, 2]
1 0 1 3
After:  [0, 3, 1, 0]

Before: [0, 2, 1, 2]
13 3 3 2
After:  [0, 2, 0, 2]

Before: [3, 1, 3, 3]
15 3 2 0
After:  [1, 1, 3, 3]

Before: [3, 1, 0, 0]
11 2 0 1
After:  [3, 1, 0, 0]

Before: [3, 1, 2, 1]
13 3 3 1
After:  [3, 0, 2, 1]

Before: [1, 0, 2, 2]
8 0 2 2
After:  [1, 0, 0, 2]

Before: [0, 3, 0, 0]
1 0 1 2
After:  [0, 3, 0, 0]

Before: [1, 1, 3, 2]
2 1 3 1
After:  [1, 0, 3, 2]

Before: [0, 1, 3, 1]
1 0 2 2
After:  [0, 1, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [3, 3, 3, 3]
10 2 3 0
After:  [1, 3, 3, 3]

Before: [0, 0, 1, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [0, 1, 2, 3]
7 3 2 2
After:  [0, 1, 0, 3]

Before: [0, 0, 3, 3]
1 0 2 2
After:  [0, 0, 0, 3]

Before: [2, 1, 2, 0]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 1, 0, 2]
2 1 3 1
After:  [0, 0, 0, 2]

Before: [3, 0, 0, 3]
11 2 0 0
After:  [1, 0, 0, 3]

Before: [1, 3, 2, 1]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [2, 2, 2, 1]
5 3 2 0
After:  [1, 2, 2, 1]

Before: [2, 2, 2, 2]
15 2 1 3
After:  [2, 2, 2, 1]

Before: [0, 0, 3, 1]
6 0 1 1
After:  [0, 0, 3, 1]

Before: [0, 2, 0, 1]
6 0 2 2
After:  [0, 2, 0, 1]

Before: [3, 1, 0, 2]
2 1 3 1
After:  [3, 0, 0, 2]

Before: [1, 3, 0, 3]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [0, 2, 1, 0]
6 0 3 0
After:  [0, 2, 1, 0]

Before: [1, 3, 2, 1]
13 3 3 0
After:  [0, 3, 2, 1]

Before: [1, 2, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 3, 3, 2]
9 0 0 2
After:  [0, 3, 0, 2]

Before: [3, 3, 0, 0]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [2, 1, 2, 3]
12 1 1 2
After:  [2, 1, 1, 3]

Before: [0, 2, 0, 2]
6 0 2 3
After:  [0, 2, 0, 0]

Before: [0, 0, 3, 0]
1 0 2 2
After:  [0, 0, 0, 0]

Before: [2, 3, 3, 1]
0 3 1 3
After:  [2, 3, 3, 1]

Before: [0, 1, 0, 2]
2 1 3 3
After:  [0, 1, 0, 0]

Before: [1, 2, 3, 3]
7 3 3 3
After:  [1, 2, 3, 1]

Before: [3, 3, 1, 1]
0 3 1 3
After:  [3, 3, 1, 1]

Before: [3, 1, 0, 3]
11 2 0 2
After:  [3, 1, 1, 3]

Before: [1, 1, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [0, 3, 0, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [2, 1, 3, 1]
15 2 3 1
After:  [2, 0, 3, 1]

Before: [3, 0, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [3, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [2, 2, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 3, 2, 0]
10 0 2 1
After:  [2, 1, 2, 0]

Before: [0, 1, 1, 2]
1 0 3 0
After:  [0, 1, 1, 2]

Before: [3, 0, 3, 3]
7 3 3 3
After:  [3, 0, 3, 1]

Before: [0, 1, 0, 0]
12 1 1 0
After:  [1, 1, 0, 0]

Before: [0, 3, 2, 1]
13 3 3 0
After:  [0, 3, 2, 1]

Before: [2, 1, 2, 1]
13 3 3 2
After:  [2, 1, 0, 1]

Before: [0, 1, 1, 2]
12 1 1 3
After:  [0, 1, 1, 1]

Before: [1, 1, 0, 1]
12 1 1 1
After:  [1, 1, 0, 1]

Before: [0, 1, 3, 1]
12 1 1 3
After:  [0, 1, 3, 1]

Before: [1, 1, 0, 0]
12 1 1 2
After:  [1, 1, 1, 0]

Before: [1, 1, 1, 1]
13 2 3 1
After:  [1, 0, 1, 1]

Before: [0, 3, 3, 3]
1 0 1 0
After:  [0, 3, 3, 3]

Before: [3, 1, 0, 0]
11 2 0 2
After:  [3, 1, 1, 0]

Before: [1, 1, 2, 1]
3 1 2 0
After:  [0, 1, 2, 1]

Before: [0, 0, 0, 2]
6 0 1 3
After:  [0, 0, 0, 0]

Before: [1, 1, 0, 3]
4 1 3 0
After:  [0, 1, 0, 3]

Before: [0, 2, 0, 1]
13 3 3 3
After:  [0, 2, 0, 0]

Before: [0, 3, 0, 3]
6 0 2 1
After:  [0, 0, 0, 3]

Before: [0, 1, 0, 1]
9 0 0 2
After:  [0, 1, 0, 1]

Before: [1, 2, 3, 3]
7 3 3 1
After:  [1, 1, 3, 3]

Before: [3, 1, 1, 3]
10 0 3 2
After:  [3, 1, 1, 3]

Before: [1, 2, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 2, 0, 3]
9 0 0 0
After:  [0, 2, 0, 3]

Before: [2, 1, 2, 3]
4 1 3 1
After:  [2, 0, 2, 3]

Before: [1, 1, 0, 2]
2 1 3 3
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 3, 3, 1]
9 0 0 1
After:  [0, 0, 3, 1]

Before: [1, 1, 2, 3]
3 1 2 2
After:  [1, 1, 0, 3]

Before: [0, 0, 1, 2]
9 0 0 2
After:  [0, 0, 0, 2]

Before: [3, 3, 0, 1]
0 3 1 1
After:  [3, 1, 0, 1]

Before: [0, 1, 1, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [0, 0, 0, 0]
9 0 0 3
After:  [0, 0, 0, 0]

Before: [2, 2, 2, 1]
5 3 2 2
After:  [2, 2, 1, 1]

Before: [0, 1, 3, 3]
10 2 3 2
After:  [0, 1, 1, 3]

Before: [3, 0, 2, 2]
13 3 3 2
After:  [3, 0, 0, 2]

Before: [2, 1, 2, 2]
2 1 3 1
After:  [2, 0, 2, 2]

Before: [3, 1, 1, 3]
12 1 1 3
After:  [3, 1, 1, 1]

Before: [0, 1, 1, 1]
9 0 0 1
After:  [0, 0, 1, 1]

Before: [1, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [3, 2, 2, 1]
5 3 2 2
After:  [3, 2, 1, 1]

Before: [3, 0, 2, 1]
5 3 2 3
After:  [3, 0, 2, 1]

Before: [2, 3, 1, 1]
0 3 1 1
After:  [2, 1, 1, 1]

Before: [0, 3, 0, 1]
9 0 0 2
After:  [0, 3, 0, 1]

Before: [2, 1, 2, 3]
7 2 2 0
After:  [1, 1, 2, 3]

Before: [1, 1, 2, 0]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 2, 2]
3 1 2 1
After:  [3, 0, 2, 2]

Before: [1, 2, 2, 3]
8 0 2 2
After:  [1, 2, 0, 3]

Before: [2, 1, 1, 2]
2 1 3 1
After:  [2, 0, 1, 2]

Before: [0, 1, 2, 1]
3 1 2 3
After:  [0, 1, 2, 0]

Before: [1, 0, 0, 3]
14 0 2 2
After:  [1, 0, 0, 3]

Before: [1, 0, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [3, 1, 0, 1]
11 2 0 1
After:  [3, 1, 0, 1]

Before: [3, 3, 2, 3]
4 2 3 2
After:  [3, 3, 0, 3]

Before: [0, 1, 2, 1]
1 0 3 2
After:  [0, 1, 0, 1]

Before: [0, 2, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [3, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 1, 2, 0]
3 1 2 2
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 2]
7 2 2 3
After:  [1, 1, 2, 1]

Before: [1, 3, 2, 2]
7 2 2 0
After:  [1, 3, 2, 2]

Before: [0, 1, 2, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [0, 0, 2, 3]
6 0 1 3
After:  [0, 0, 2, 0]

Before: [0, 3, 3, 3]
7 0 0 2
After:  [0, 3, 1, 3]

Before: [0, 0, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 3, 0, 1]
14 0 2 0
After:  [0, 3, 0, 1]

Before: [3, 1, 0, 2]
12 1 1 1
After:  [3, 1, 0, 2]

Before: [2, 3, 1, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 0, 2, 0]
6 0 3 0
After:  [0, 0, 2, 0]

Before: [0, 2, 1, 3]
7 3 2 3
After:  [0, 2, 1, 0]

Before: [0, 1, 2, 3]
3 1 2 1
After:  [0, 0, 2, 3]

Before: [0, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [1, 1, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [3, 3, 3, 1]
0 3 1 1
After:  [3, 1, 3, 1]

Before: [1, 1, 1, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 3, 2, 1]
5 3 2 2
After:  [0, 3, 1, 1]

Before: [2, 1, 1, 0]
12 1 1 1
After:  [2, 1, 1, 0]

Before: [2, 3, 1, 3]
4 2 3 3
After:  [2, 3, 1, 0]

Before: [0, 1, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [2, 0, 2, 2]
10 0 2 0
After:  [1, 0, 2, 2]

Before: [1, 3, 2, 1]
0 3 1 3
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [2, 3, 2, 1]
10 0 2 0
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [1, 0, 2, 1]
5 3 2 3
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 2]
10 0 2 2
After:  [2, 1, 1, 2]

Before: [3, 1, 0, 3]
7 3 3 3
After:  [3, 1, 0, 1]

Before: [1, 3, 3, 1]
0 3 1 1
After:  [1, 1, 3, 1]

Before: [2, 3, 3, 3]
10 2 3 2
After:  [2, 3, 1, 3]

Before: [3, 2, 0, 1]
11 2 0 2
After:  [3, 2, 1, 1]

Before: [0, 0, 2, 1]
7 0 0 0
After:  [1, 0, 2, 1]

Before: [1, 2, 2, 0]
15 2 1 2
After:  [1, 2, 1, 0]

Before: [0, 2, 1, 1]
1 0 3 0
After:  [0, 2, 1, 1]

Before: [0, 1, 3, 1]
9 0 0 3
After:  [0, 1, 3, 0]

Before: [0, 0, 3, 1]
1 0 2 3
After:  [0, 0, 3, 0]

Before: [0, 3, 3, 0]
1 0 2 3
After:  [0, 3, 3, 0]

Before: [2, 2, 2, 0]
7 2 2 3
After:  [2, 2, 2, 1]

Before: [1, 2, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [1, 3, 2, 2]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [0, 2, 1, 1]
13 3 3 3
After:  [0, 2, 1, 0]

Before: [3, 0, 3, 1]
15 2 3 2
After:  [3, 0, 0, 1]

Before: [1, 3, 2, 1]
8 0 2 2
After:  [1, 3, 0, 1]

Before: [3, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [2, 1, 3, 3]
10 2 3 0
After:  [1, 1, 3, 3]

Before: [0, 3, 0, 2]
9 0 0 2
After:  [0, 3, 0, 2]

Before: [3, 1, 1, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [0, 0, 0, 0]
9 0 0 0
After:  [0, 0, 0, 0]

Before: [3, 3, 0, 0]
11 2 0 1
After:  [3, 1, 0, 0]

Before: [1, 2, 0, 3]
4 1 3 0
After:  [0, 2, 0, 3]

Before: [3, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [1, 1, 0, 3]
4 1 3 2
After:  [1, 1, 0, 3]

Before: [1, 2, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [0, 0, 3, 0]
6 0 1 0
After:  [0, 0, 3, 0]

Before: [0, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [0, 2, 0, 3]
7 3 1 0
After:  [0, 2, 0, 3]

Before: [2, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [1, 1, 0, 2]
14 0 2 2
After:  [1, 1, 0, 2]

Before: [1, 3, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 1, 0, 1]
6 0 2 3
After:  [0, 1, 0, 0]

Before: [1, 0, 1, 3]
4 2 3 3
After:  [1, 0, 1, 0]

Before: [2, 2, 2, 3]
7 3 2 3
After:  [2, 2, 2, 0]

Before: [0, 1, 1, 2]
13 3 3 1
After:  [0, 0, 1, 2]

Before: [0, 3, 1, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [0, 3, 1, 3]
4 2 3 3
After:  [0, 3, 1, 0]

Before: [3, 0, 2, 3]
10 0 3 0
After:  [1, 0, 2, 3]

Before: [2, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 3, 0, 0]
14 0 2 2
After:  [1, 3, 0, 0]

Before: [0, 0, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [1, 2, 0, 3]
14 0 2 2
After:  [1, 2, 0, 3]

Before: [1, 2, 2, 1]
8 0 2 0
After:  [0, 2, 2, 1]

Before: [2, 3, 2, 3]
4 2 3 1
After:  [2, 0, 2, 3]

Before: [1, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [3, 3, 2, 1]
13 3 3 3
After:  [3, 3, 2, 0]

Before: [0, 1, 1, 3]
9 0 0 2
After:  [0, 1, 0, 3]

Before: [0, 1, 3, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [2, 3, 0, 1]
0 3 1 1
After:  [2, 1, 0, 1]

Before: [3, 1, 2, 0]
7 2 2 3
After:  [3, 1, 2, 1]

Before: [1, 1, 2, 3]
12 1 1 0
After:  [1, 1, 2, 3]

Before: [1, 1, 2, 1]
3 1 2 2
After:  [1, 1, 0, 1]

Before: [0, 0, 3, 0]
6 0 3 1
After:  [0, 0, 3, 0]

Before: [2, 3, 2, 3]
7 3 3 0
After:  [1, 3, 2, 3]

Before: [2, 1, 0, 2]
13 3 3 3
After:  [2, 1, 0, 0]

Before: [2, 2, 0, 3]
7 3 3 2
After:  [2, 2, 1, 3]

Before: [0, 1, 2, 0]
7 2 2 2
After:  [0, 1, 1, 0]

Before: [3, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [2, 1, 3, 1]
11 0 2 2
After:  [2, 1, 1, 1]

Before: [0, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [0, 0, 0, 1]
6 0 2 2
After:  [0, 0, 0, 1]

Before: [2, 0, 3, 3]
11 0 2 0
After:  [1, 0, 3, 3]

Before: [1, 3, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [2, 0, 1, 3]
4 2 3 1
After:  [2, 0, 1, 3]

Before: [3, 1, 2, 0]
3 1 2 2
After:  [3, 1, 0, 0]

Before: [0, 1, 1, 3]
1 0 3 0
After:  [0, 1, 1, 3]

Before: [1, 2, 0, 1]
14 0 2 2
After:  [1, 2, 0, 1]

Before: [2, 1, 3, 3]
15 3 2 0
After:  [1, 1, 3, 3]

Before: [1, 2, 1, 3]
7 3 2 1
After:  [1, 0, 1, 3]

Before: [1, 1, 0, 0]
14 0 2 0
After:  [0, 1, 0, 0]

Before: [2, 2, 3, 3]
10 2 3 3
After:  [2, 2, 3, 1]

Before: [0, 3, 2, 0]
9 0 0 1
After:  [0, 0, 2, 0]

Before: [2, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [2, 3, 1, 1]
13 2 3 1
After:  [2, 0, 1, 1]

Before: [1, 0, 1, 3]
4 2 3 0
After:  [0, 0, 1, 3]

Before: [3, 2, 2, 1]
15 2 1 0
After:  [1, 2, 2, 1]

Before: [1, 3, 3, 3]
10 2 3 1
After:  [1, 1, 3, 3]

Before: [2, 3, 3, 3]
11 0 2 3
After:  [2, 3, 3, 1]

Before: [0, 3, 3, 3]
1 0 3 1
After:  [0, 0, 3, 3]

Before: [1, 1, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [3, 2, 2, 1]
5 3 2 3
After:  [3, 2, 2, 1]

Before: [1, 1, 0, 2]
14 0 2 0
After:  [0, 1, 0, 2]

Before: [0, 0, 1, 0]
6 0 3 0
After:  [0, 0, 1, 0]

Before: [3, 3, 1, 2]
13 3 3 0
After:  [0, 3, 1, 2]

Before: [1, 1, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [0, 1, 3, 3]
10 2 3 3
After:  [0, 1, 3, 1]

Before: [0, 2, 1, 3]
7 0 0 1
After:  [0, 1, 1, 3]

Before: [0, 2, 2, 1]
9 0 0 0
After:  [0, 2, 2, 1]

Before: [0, 2, 3, 1]
1 0 2 3
After:  [0, 2, 3, 0]

Before: [1, 2, 0, 3]
7 3 1 1
After:  [1, 0, 0, 3]

Before: [1, 0, 2, 0]
8 0 2 2
After:  [1, 0, 0, 0]

Before: [3, 3, 0, 3]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [0, 1, 0, 3]
4 1 3 2
After:  [0, 1, 0, 3]

Before: [3, 2, 0, 3]
15 3 0 1
After:  [3, 1, 0, 3]

Before: [2, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [0, 0, 0, 0]
6 0 1 1
After:  [0, 0, 0, 0]

Before: [3, 2, 2, 3]
15 3 0 2
After:  [3, 2, 1, 3]

Before: [0, 3, 0, 0]
9 0 0 0
After:  [0, 3, 0, 0]

Before: [0, 1, 2, 1]
12 1 1 2
After:  [0, 1, 1, 1]

Before: [3, 1, 2, 3]
4 1 3 0
After:  [0, 1, 2, 3]

Before: [2, 1, 3, 3]
12 1 1 3
After:  [2, 1, 3, 1]

Before: [1, 2, 3, 2]
13 3 3 3
After:  [1, 2, 3, 0]

Before: [2, 2, 2, 3]
4 1 3 1
After:  [2, 0, 2, 3]

Before: [3, 1, 1, 3]
4 1 3 2
After:  [3, 1, 0, 3]

Before: [3, 2, 0, 3]
11 2 0 3
After:  [3, 2, 0, 1]

Before: [2, 3, 3, 3]
11 0 2 2
After:  [2, 3, 1, 3]

Before: [3, 2, 2, 1]
5 3 2 0
After:  [1, 2, 2, 1]

Before: [3, 2, 0, 0]
11 2 0 2
After:  [3, 2, 1, 0]

Before: [0, 0, 1, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [1, 1, 2, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 0, 2, 2]
7 0 0 3
After:  [0, 0, 2, 1]

Before: [3, 1, 0, 3]
4 1 3 1
After:  [3, 0, 0, 3]

Before: [2, 1, 1, 0]
12 1 1 2
After:  [2, 1, 1, 0]

Before: [1, 1, 1, 3]
12 1 1 0
After:  [1, 1, 1, 3]

Before: [2, 1, 0, 3]
12 1 1 3
After:  [2, 1, 0, 1]

Before: [3, 1, 2, 2]
2 1 3 2
After:  [3, 1, 0, 2]

Before: [0, 0, 3, 2]
9 0 0 0
After:  [0, 0, 3, 2]

Before: [1, 1, 0, 1]
12 1 1 2
After:  [1, 1, 1, 1]

Before: [2, 1, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [1, 0, 2, 2]
13 3 3 3
After:  [1, 0, 2, 0]

Before: [1, 1, 3, 2]
13 3 3 1
After:  [1, 0, 3, 2]

Before: [3, 2, 0, 2]
11 2 0 1
After:  [3, 1, 0, 2]

Before: [3, 3, 0, 3]
10 0 3 1
After:  [3, 1, 0, 3]

Before: [0, 2, 2, 3]
7 3 3 2
After:  [0, 2, 1, 3]

Before: [1, 1, 2, 3]
7 3 2 2
After:  [1, 1, 0, 3]

Before: [0, 1, 2, 1]
3 1 2 2
After:  [0, 1, 0, 1]

Before: [0, 1, 2, 1]
3 1 2 1
After:  [0, 0, 2, 1]

Before: [0, 2, 2, 0]
15 2 1 1
After:  [0, 1, 2, 0]

Before: [1, 1, 3, 3]
10 2 3 0
After:  [1, 1, 3, 3]

Before: [2, 3, 2, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 0, 3, 0]
9 0 0 0
After:  [0, 0, 3, 0]

Before: [3, 1, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [3, 1, 2, 0]
12 1 1 2
After:  [3, 1, 1, 0]

Before: [1, 0, 3, 3]
15 3 2 2
After:  [1, 0, 1, 3]

Before: [3, 0, 1, 3]
4 2 3 2
After:  [3, 0, 0, 3]

Before: [1, 2, 0, 0]
14 0 2 0
After:  [0, 2, 0, 0]

Before: [3, 1, 2, 1]
5 3 2 3
After:  [3, 1, 2, 1]

Before: [2, 3, 2, 1]
15 2 0 3
After:  [2, 3, 2, 1]

Before: [3, 1, 3, 3]
4 1 3 3
After:  [3, 1, 3, 0]

Before: [1, 1, 2, 1]
5 3 2 3
After:  [1, 1, 2, 1]

Before: [0, 3, 0, 0]
6 0 3 2
After:  [0, 3, 0, 0]

Before: [0, 0, 3, 1]
1 0 2 0
After:  [0, 0, 3, 1]

Before: [0, 2, 0, 3]
4 1 3 1
After:  [0, 0, 0, 3]

Before: [3, 1, 0, 2]
11 2 0 1
After:  [3, 1, 0, 2]

Before: [0, 0, 2, 1]
5 3 2 3
After:  [0, 0, 2, 1]

Before: [1, 3, 2, 1]
8 0 2 0
After:  [0, 3, 2, 1]

Before: [0, 1, 2, 2]
2 1 3 1
After:  [0, 0, 2, 2]

Before: [1, 1, 2, 1]
12 1 1 2
After:  [1, 1, 1, 1]

Before: [0, 3, 0, 1]
6 0 2 3
After:  [0, 3, 0, 0]

Before: [1, 3, 3, 3]
10 2 3 2
After:  [1, 3, 1, 3]

Before: [3, 1, 3, 3]
15 3 0 0
After:  [1, 1, 3, 3]

Before: [2, 1, 2, 3]
4 1 3 2
After:  [2, 1, 0, 3]

Before: [0, 3, 2, 2]
13 3 3 3
After:  [0, 3, 2, 0]

Before: [1, 2, 2, 2]
8 0 2 2
After:  [1, 2, 0, 2]

Before: [1, 2, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [1, 3, 3, 2]
13 3 3 1
After:  [1, 0, 3, 2]

Before: [1, 1, 3, 2]
2 1 3 3
After:  [1, 1, 3, 0]

Before: [0, 3, 2, 1]
0 3 1 1
After:  [0, 1, 2, 1]

Before: [3, 3, 0, 1]
11 2 0 2
After:  [3, 3, 1, 1]

Before: [0, 1, 0, 3]
6 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 3, 3, 1]
15 2 3 1
After:  [0, 0, 3, 1]

Before: [0, 1, 3, 1]
13 3 3 2
After:  [0, 1, 0, 1]

Before: [1, 2, 2, 1]
5 3 2 3
After:  [1, 2, 2, 1]

Before: [2, 0, 2, 1]
13 3 3 1
After:  [2, 0, 2, 1]

Before: [1, 1, 3, 3]
15 3 2 3
After:  [1, 1, 3, 1]

Before: [3, 1, 2, 2]
3 1 2 2
After:  [3, 1, 0, 2]

Before: [2, 0, 2, 2]
10 0 2 3
After:  [2, 0, 2, 1]

Before: [0, 0, 2, 3]
9 0 0 2
After:  [0, 0, 0, 3]

Before: [0, 2, 2, 2]
9 0 0 3
After:  [0, 2, 2, 0]

Before: [0, 1, 2, 0]
9 0 0 3
After:  [0, 1, 2, 0]

Before: [1, 2, 2, 0]
8 0 2 0
After:  [0, 2, 2, 0]

Before: [2, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [0, 3, 2, 1]
0 3 1 3
After:  [0, 3, 2, 1]

Before: [0, 1, 1, 0]
1 0 2 2
After:  [0, 1, 0, 0]

Before: [1, 2, 2, 3]
4 1 3 1
After:  [1, 0, 2, 3]

Before: [0, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [0, 3, 0, 0]
9 0 0 1
After:  [0, 0, 0, 0]

Before: [3, 1, 1, 1]
13 3 3 2
After:  [3, 1, 0, 1]

Before: [1, 1, 2, 3]
3 1 2 1
After:  [1, 0, 2, 3]

Before: [2, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 0, 1, 1]
1 0 3 3
After:  [0, 0, 1, 0]

Before: [0, 3, 2, 2]
7 0 0 2
After:  [0, 3, 1, 2]

Before: [1, 1, 2, 0]
8 0 2 2
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 1]
8 0 2 0
After:  [0, 1, 2, 1]

Before: [0, 0, 3, 3]
6 0 1 3
After:  [0, 0, 3, 0]

Before: [2, 0, 2, 2]
15 2 0 2
After:  [2, 0, 1, 2]

Before: [2, 3, 3, 2]
13 3 3 2
After:  [2, 3, 0, 2]

Before: [2, 2, 2, 3]
4 2 3 1
After:  [2, 0, 2, 3]

Before: [1, 3, 0, 1]
0 3 1 3
After:  [1, 3, 0, 1]

Before: [0, 3, 1, 3]
1 0 1 0
After:  [0, 3, 1, 3]

Before: [2, 2, 2, 0]
10 0 2 3
After:  [2, 2, 2, 1]

Before: [0, 0, 1, 1]
9 0 0 0
After:  [0, 0, 1, 1]

Before: [0, 1, 0, 1]
6 0 2 1
After:  [0, 0, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 1, 2, 3]
9 0 0 0
After:  [0, 1, 2, 3]

Before: [3, 1, 2, 3]
15 3 0 0
After:  [1, 1, 2, 3]

Before: [0, 2, 0, 1]
1 0 1 3
After:  [0, 2, 0, 0]

Before: [1, 2, 0, 0]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [2, 1, 2, 3]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 2, 3, 0]
6 0 3 3
After:  [0, 2, 3, 0]

Before: [1, 2, 2, 0]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 1, 2, 3]
12 1 1 2
After:  [3, 1, 1, 3]

Before: [3, 0, 1, 2]
13 3 3 0
After:  [0, 0, 1, 2]

Before: [0, 2, 2, 1]
5 3 2 2
After:  [0, 2, 1, 1]

Before: [3, 1, 2, 1]
5 3 2 2
After:  [3, 1, 1, 1]

Before: [2, 3, 3, 1]
0 3 1 1
After:  [2, 1, 3, 1]

Before: [1, 3, 2, 3]
8 0 2 2
After:  [1, 3, 0, 3]

Before: [0, 2, 2, 0]
1 0 2 1
After:  [0, 0, 2, 0]

Before: [2, 3, 2, 1]
0 3 1 3
After:  [2, 3, 2, 1]

Before: [2, 1, 0, 2]
2 1 3 1
After:  [2, 0, 0, 2]

Before: [0, 0, 3, 3]
7 0 0 0
After:  [1, 0, 3, 3]

Before: [0, 0, 3, 1]
9 0 0 0
After:  [0, 0, 3, 1]

Before: [2, 2, 3, 2]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [2, 0, 1, 3]
7 3 2 1
After:  [2, 0, 1, 3]

Before: [3, 2, 2, 1]
15 2 1 1
After:  [3, 1, 2, 1]

Before: [0, 1, 3, 1]
9 0 0 1
After:  [0, 0, 3, 1]

Before: [0, 3, 3, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [0, 3, 2, 1]
9 0 0 3
After:  [0, 3, 2, 0]

Before: [3, 2, 0, 1]
13 3 3 1
After:  [3, 0, 0, 1]

Before: [1, 1, 0, 2]
2 1 3 1
After:  [1, 0, 0, 2]

Before: [0, 1, 0, 2]
12 1 1 3
After:  [0, 1, 0, 1]

Before: [3, 1, 3, 3]
15 3 0 1
After:  [3, 1, 3, 3]

Before: [0, 2, 1, 3]
9 0 0 0
After:  [0, 2, 1, 3]

Before: [0, 2, 1, 0]
6 0 3 1
After:  [0, 0, 1, 0]

Before: [1, 1, 2, 2]
3 1 2 1
After:  [1, 0, 2, 2]

Before: [3, 1, 0, 2]
11 2 0 3
After:  [3, 1, 0, 1]

Before: [3, 2, 2, 2]
13 3 3 0
After:  [0, 2, 2, 2]

Before: [2, 2, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [3, 3, 0, 2]
11 2 0 2
After:  [3, 3, 1, 2]

Before: [1, 3, 0, 1]
0 3 1 1
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 2]
2 1 3 1
After:  [3, 0, 2, 2]

Before: [3, 1, 2, 1]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 1, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 2, 0, 2]
1 0 1 2
After:  [0, 2, 0, 2]

Before: [2, 3, 2, 1]
7 2 2 1
After:  [2, 1, 2, 1]

Before: [1, 0, 0, 0]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [0, 3, 1, 1]
7 0 0 3
After:  [0, 3, 1, 1]

Before: [0, 2, 1, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [1, 2, 1, 3]
4 2 3 2
After:  [1, 2, 0, 3]

Before: [1, 3, 3, 1]
0 3 1 2
After:  [1, 3, 1, 1]

Before: [3, 2, 2, 2]
15 2 1 2
After:  [3, 2, 1, 2]

Before: [1, 3, 1, 1]
0 3 1 2
After:  [1, 3, 1, 1]

Before: [3, 2, 2, 3]
4 1 3 1
After:  [3, 0, 2, 3]

Before: [0, 2, 2, 2]
7 0 0 0
After:  [1, 2, 2, 2]

Before: [0, 2, 2, 3]
4 1 3 0
After:  [0, 2, 2, 3]

Before: [1, 1, 0, 0]
12 1 1 3
After:  [1, 1, 0, 1]

Before: [0, 2, 3, 1]
13 3 3 1
After:  [0, 0, 3, 1]

Before: [0, 2, 2, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [0, 2, 3, 2]
9 0 0 1
After:  [0, 0, 3, 2]

Before: [2, 1, 1, 2]
13 3 3 0
After:  [0, 1, 1, 2]

Before: [0, 1, 3, 2]
1 0 3 1
After:  [0, 0, 3, 2]

Before: [0, 0, 2, 0]
9 0 0 2
After:  [0, 0, 0, 0]

Before: [1, 3, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [0, 2, 2, 2]
15 2 1 1
After:  [0, 1, 2, 2]

Before: [1, 2, 1, 3]
4 2 3 3
After:  [1, 2, 1, 0]

Before: [1, 0, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 2, 2, 2]
15 2 1 0
After:  [1, 2, 2, 2]

Before: [2, 0, 3, 2]
13 3 3 3
After:  [2, 0, 3, 0]

Before: [2, 2, 2, 2]
10 0 2 0
After:  [1, 2, 2, 2]

Before: [1, 3, 2, 3]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [0, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [0, 0, 1, 3]
6 0 1 0
After:  [0, 0, 1, 3]

Before: [0, 2, 2, 0]
7 0 0 2
After:  [0, 2, 1, 0]

Before: [1, 1, 1, 3]
4 2 3 0
After:  [0, 1, 1, 3]

Before: [3, 2, 1, 1]
13 2 3 0
After:  [0, 2, 1, 1]

Before: [2, 1, 2, 0]
3 1 2 2
After:  [2, 1, 0, 0]

Before: [1, 3, 1, 3]
4 2 3 0
After:  [0, 3, 1, 3]

Before: [2, 0, 3, 0]
11 0 2 3
After:  [2, 0, 3, 1]

Before: [1, 1, 2, 1]
8 0 2 2
After:  [1, 1, 0, 1]

Before: [0, 0, 3, 1]
9 0 0 2
After:  [0, 0, 0, 1]

Before: [2, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [1, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [1, 3, 1, 1]
13 2 3 2
After:  [1, 3, 0, 1]

Before: [2, 1, 3, 1]
11 0 2 1
After:  [2, 1, 3, 1]

Before: [1, 1, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 0, 0, 1]
9 0 0 1
After:  [0, 0, 0, 1]

Before: [1, 1, 2, 3]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 0, 1]
11 2 0 2
After:  [3, 1, 1, 1]

Before: [2, 1, 2, 0]
10 0 2 3
After:  [2, 1, 2, 1]

Before: [3, 0, 1, 3]
10 0 3 1
After:  [3, 1, 1, 3]

Before: [0, 3, 1, 3]
1 0 3 2
After:  [0, 3, 0, 3]

Before: [1, 1, 2, 0]
8 0 2 0
After:  [0, 1, 2, 0]

Before: [1, 1, 2, 1]
8 0 2 1
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 2]
15 2 0 1
After:  [2, 1, 2, 2]

Before: [0, 0, 2, 0]
7 2 2 0
After:  [1, 0, 2, 0]

Before: [3, 3, 2, 3]
15 3 0 2
After:  [3, 3, 1, 3]

Before: [0, 2, 2, 3]
1 0 2 3
After:  [0, 2, 2, 0]

Before: [1, 2, 0, 3]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [3, 0, 3, 2]
13 3 3 1
After:  [3, 0, 3, 2]

Before: [0, 0, 2, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [2, 0, 3, 1]
11 0 2 2
After:  [2, 0, 1, 1]

Before: [1, 1, 0, 1]
14 0 2 0
After:  [0, 1, 0, 1]

Before: [2, 2, 3, 0]
11 0 2 1
After:  [2, 1, 3, 0]

Before: [3, 1, 0, 3]
7 3 1 2
After:  [3, 1, 0, 3]

Before: [0, 2, 1, 2]
1 0 2 0
After:  [0, 2, 1, 2]

Before: [0, 3, 1, 3]
4 2 3 1
After:  [0, 0, 1, 3]

Before: [1, 2, 0, 2]
14 0 2 2
After:  [1, 2, 0, 2]

Before: [1, 1, 2, 2]
2 1 3 3
After:  [1, 1, 2, 0]

Before: [3, 1, 2, 0]
3 1 2 1
After:  [3, 0, 2, 0]

Before: [0, 3, 3, 1]
7 0 0 0
After:  [1, 3, 3, 1]

Before: [0, 3, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [3, 3, 0, 1]
11 2 0 1
After:  [3, 1, 0, 1]

Before: [3, 2, 0, 3]
11 2 0 1
After:  [3, 1, 0, 3]

Before: [2, 1, 2, 2]
7 2 2 2
After:  [2, 1, 1, 2]

Before: [3, 3, 1, 1]
13 3 3 2
After:  [3, 3, 0, 1]

Before: [3, 1, 0, 2]
11 2 0 2
After:  [3, 1, 1, 2]

Before: [0, 3, 1, 0]
1 0 1 2
After:  [0, 3, 0, 0]

Before: [1, 1, 3, 1]
13 3 3 2
After:  [1, 1, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 2
After:  [2, 1, 0, 2]

Before: [0, 0, 1, 3]
9 0 0 3
After:  [0, 0, 1, 0]

Before: [3, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [1, 0, 0, 0]
14 0 2 2
After:  [1, 0, 0, 0]

Before: [0, 0, 0, 1]
6 0 2 0
After:  [0, 0, 0, 1]

Before: [2, 3, 3, 1]
11 0 2 2
After:  [2, 3, 1, 1]

Before: [3, 1, 3, 2]
2 1 3 1
After:  [3, 0, 3, 2]

Before: [1, 1, 2, 2]
13 3 3 1
After:  [1, 0, 2, 2]

Before: [3, 1, 0, 3]
10 0 3 1
After:  [3, 1, 0, 3]

Before: [1, 0, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [2, 3, 1, 2]
13 3 3 0
After:  [0, 3, 1, 2]

Before: [3, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [1, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [0, 3, 3, 3]
10 2 3 3
After:  [0, 3, 3, 1]

Before: [3, 3, 0, 1]
0 3 1 3
After:  [3, 3, 0, 1]

Before: [3, 1, 0, 2]
12 1 1 0
After:  [1, 1, 0, 2]

Before: [3, 2, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [0, 0, 1, 1]
6 0 1 0
After:  [0, 0, 1, 1]

Before: [1, 1, 0, 3]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 0, 3, 3]
6 0 1 0
After:  [0, 0, 3, 3]

Before: [3, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [0, 2, 3, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [3, 2, 0, 1]
11 2 0 3
After:  [3, 2, 0, 1]

Before: [0, 3, 2, 0]
1 0 1 3
After:  [0, 3, 2, 0]

Before: [1, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [1, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [2, 3, 3, 3]
10 2 3 3
After:  [2, 3, 3, 1]

Before: [3, 1, 1, 3]
4 1 3 1
After:  [3, 0, 1, 3]

Before: [2, 3, 3, 1]
11 0 2 0
After:  [1, 3, 3, 1]

Before: [0, 0, 0, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [2, 3, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [1, 2, 2, 3]
4 2 3 2
After:  [1, 2, 0, 3]

Before: [3, 1, 3, 3]
15 3 0 2
After:  [3, 1, 1, 3]

Before: [0, 2, 2, 2]
9 0 0 2
After:  [0, 2, 0, 2]

Before: [0, 0, 2, 1]
1 0 2 0
After:  [0, 0, 2, 1]

Before: [2, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [3, 1, 3, 2]
2 1 3 3
After:  [3, 1, 3, 0]

Before: [0, 1, 2, 2]
1 0 3 1
After:  [0, 0, 2, 2]

Before: [1, 0, 0, 0]
14 0 2 0
After:  [0, 0, 0, 0]

Before: [1, 3, 0, 3]
14 0 2 2
After:  [1, 3, 0, 3]

Before: [3, 1, 3, 1]
13 3 3 3
After:  [3, 1, 3, 0]

Before: [0, 0, 2, 1]
6 0 1 0
After:  [0, 0, 2, 1]

Before: [2, 2, 2, 3]
10 0 2 2
After:  [2, 2, 1, 3]

Before: [1, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [1, 0, 3, 1]
15 2 3 0
After:  [0, 0, 3, 1]

Before: [3, 0, 0, 3]
10 0 3 0
After:  [1, 0, 0, 3]

Before: [2, 2, 0, 3]
7 3 3 1
After:  [2, 1, 0, 3]

Before: [3, 1, 3, 2]
2 1 3 2
After:  [3, 1, 0, 2]

Before: [3, 1, 1, 3]
15 3 0 0
After:  [1, 1, 1, 3]

Before: [0, 1, 3, 3]
1 0 1 1
After:  [0, 0, 3, 3]

Before: [3, 0, 2, 3]
4 2 3 1
After:  [3, 0, 2, 3]

Before: [2, 1, 1, 2]
2 1 3 3
After:  [2, 1, 1, 0]

Before: [1, 1, 2, 1]
3 1 2 1
After:  [1, 0, 2, 1]

Before: [1, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [0, 3, 0, 2]
6 0 2 1
After:  [0, 0, 0, 2]

Before: [3, 1, 2, 2]
13 3 3 1
After:  [3, 0, 2, 2]

Before: [0, 3, 3, 1]
0 3 1 1
After:  [0, 1, 3, 1]

Before: [2, 2, 1, 3]
4 1 3 1
After:  [2, 0, 1, 3]

Before: [1, 2, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 2, 3, 0]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [0, 1, 3, 3]
4 1 3 2
After:  [0, 1, 0, 3]

Before: [2, 1, 3, 3]
15 3 2 2
After:  [2, 1, 1, 3]

Before: [3, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [0, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [3, 1, 0, 2]
2 1 3 3
After:  [3, 1, 0, 0]

Before: [0, 1, 0, 0]
12 1 1 1
After:  [0, 1, 0, 0]

Before: [0, 1, 0, 0]
6 0 2 0
After:  [0, 1, 0, 0]

Before: [0, 1, 1, 1]
12 1 1 0
After:  [1, 1, 1, 1]

Before: [2, 2, 0, 3]
4 1 3 0
After:  [0, 2, 0, 3]

Before: [0, 1, 3, 3]
7 2 1 2
After:  [0, 1, 0, 3]

Before: [2, 1, 0, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 1, 2, 3]
10 0 2 0
After:  [1, 1, 2, 3]

Before: [0, 0, 0, 2]
6 0 1 1
After:  [0, 0, 0, 2]

Before: [1, 1, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [2, 2, 2, 3]
7 3 3 3
After:  [2, 2, 2, 1]

Before: [2, 2, 2, 1]
15 2 1 1
After:  [2, 1, 2, 1]

Before: [2, 0, 2, 1]
5 3 2 2
After:  [2, 0, 1, 1]

Before: [0, 3, 1, 3]
1 0 3 3
After:  [0, 3, 1, 0]

Before: [2, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [0, 0, 0, 0]
6 0 2 3
After:  [0, 0, 0, 0]

Before: [0, 2, 2, 0]
9 0 0 0
After:  [0, 2, 2, 0]

Before: [1, 1, 2, 2]
2 1 3 1
After:  [1, 0, 2, 2]

Before: [2, 2, 3, 3]
11 0 2 2
After:  [2, 2, 1, 3]

Before: [1, 1, 0, 3]
14 0 2 2
After:  [1, 1, 0, 3]

Before: [2, 1, 1, 2]
12 1 1 3
After:  [2, 1, 1, 1]

Before: [3, 1, 2, 2]
2 1 3 3
After:  [3, 1, 2, 0]

Before: [1, 2, 2, 3]
4 1 3 3
After:  [1, 2, 2, 0]

Before: [0, 1, 2, 3]
1 0 3 2
After:  [0, 1, 0, 3]

Before: [3, 2, 2, 0]
7 2 2 3
After:  [3, 2, 2, 1]

Before: [1, 1, 2, 1]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [1, 1, 1, 2]
2 1 3 3
After:  [1, 1, 1, 0]

Before: [2, 1, 0, 2]
2 1 3 3
After:  [2, 1, 0, 0]

Before: [3, 3, 2, 1]
0 3 1 3
After:  [3, 3, 2, 1]

Before: [1, 1, 0, 2]
2 1 3 0
After:  [0, 1, 0, 2]

Before: [3, 3, 0, 0]
11 2 0 0
After:  [1, 3, 0, 0]

Before: [2, 1, 3, 3]
11 0 2 2
After:  [2, 1, 1, 3]

Before: [0, 2, 0, 2]
6 0 2 0
After:  [0, 2, 0, 2]

Before: [3, 3, 1, 1]
0 3 1 1
After:  [3, 1, 1, 1]

Before: [0, 3, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 0, 0, 1]
14 0 2 2
After:  [1, 0, 0, 1]

Before: [2, 1, 0, 1]
13 3 3 1
After:  [2, 0, 0, 1]

Before: [0, 1, 2, 2]
12 1 1 2
After:  [0, 1, 1, 2]

Before: [0, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [1, 2, 0, 3]
7 3 1 2
After:  [1, 2, 0, 3]

Before: [0, 1, 0, 2]
6 0 2 3
After:  [0, 1, 0, 0]

Before: [2, 0, 2, 3]
15 2 0 1
After:  [2, 1, 2, 3]

Before: [1, 1, 0, 1]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [0, 1, 2, 1]
1 0 2 2
After:  [0, 1, 0, 1]

Before: [3, 0, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [3, 3, 0, 3]
15 3 0 1
After:  [3, 1, 0, 3]

Before: [0, 3, 2, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [1, 0, 2, 0]
7 2 2 1
After:  [1, 1, 2, 0]

Before: [1, 3, 0, 1]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [2, 3, 3, 2]
11 0 2 3
After:  [2, 3, 3, 1]

Before: [0, 1, 3, 2]
12 1 1 0
After:  [1, 1, 3, 2]

Before: [3, 3, 0, 1]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [0, 0, 0, 3]
7 3 3 1
After:  [0, 1, 0, 3]

Before: [1, 1, 0, 0]
14 0 2 2
After:  [1, 1, 0, 0]

Before: [2, 1, 3, 1]
13 3 3 3
After:  [2, 1, 3, 0]

Before: [1, 3, 2, 1]
5 3 2 3
After:  [1, 3, 2, 1]

Before: [3, 1, 2, 1]
3 1 2 2
After:  [3, 1, 0, 1]

Before: [0, 1, 2, 3]
4 1 3 3
After:  [0, 1, 2, 0]

Before: [0, 3, 3, 0]
1 0 2 0
After:  [0, 3, 3, 0]

Before: [3, 1, 2, 1]
12 1 1 0
After:  [1, 1, 2, 1]

Before: [1, 0, 3, 3]
10 2 3 2
After:  [1, 0, 1, 3]

Before: [1, 0, 3, 1]
13 3 3 3
After:  [1, 0, 3, 0]

Before: [3, 2, 2, 3]
4 2 3 2
After:  [3, 2, 0, 3]

Before: [2, 1, 2, 2]
10 0 2 1
After:  [2, 1, 2, 2]

Before: [0, 3, 1, 2]
1 0 2 0
After:  [0, 3, 1, 2]

Before: [3, 1, 3, 0]
7 2 1 1
After:  [3, 0, 3, 0]

Before: [0, 1, 0, 3]
4 1 3 0
After:  [0, 1, 0, 3]

Before: [2, 3, 0, 1]
0 3 1 3
After:  [2, 3, 0, 1]

Before: [1, 3, 0, 3]
14 0 2 0
After:  [0, 3, 0, 3]

Before: [1, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [2, 1, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 0, 3, 1]
11 0 2 3
After:  [2, 0, 3, 1]

Before: [2, 2, 3, 1]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [1, 3, 1, 1]
13 3 3 3
After:  [1, 3, 1, 0]

Before: [0, 2, 1, 1]
9 0 0 1
After:  [0, 0, 1, 1]

Before: [1, 2, 3, 3]
4 1 3 3
After:  [1, 2, 3, 0]

Before: [0, 0, 2, 1]
1 0 3 1
After:  [0, 0, 2, 1]

Before: [0, 1, 0, 0]
9 0 0 1
After:  [0, 0, 0, 0]

Before: [3, 0, 1, 3]
10 0 3 0
After:  [1, 0, 1, 3]

Before: [3, 2, 0, 0]
11 2 0 0
After:  [1, 2, 0, 0]

Before: [2, 3, 2, 2]
15 2 0 1
After:  [2, 1, 2, 2]

Before: [3, 1, 0, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [1, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [2, 3, 3, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 2, 2, 1]
5 3 2 3
After:  [0, 2, 2, 1]

Before: [2, 1, 1, 1]
13 2 3 3
After:  [2, 1, 1, 0]

Before: [1, 0, 0, 3]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [2, 2, 3, 1]
13 3 3 3
After:  [2, 2, 3, 0]

Before: [3, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [3, 0, 3, 1]
15 2 3 3
After:  [3, 0, 3, 0]

Before: [2, 0, 2, 3]
10 0 2 0
After:  [1, 0, 2, 3]

Before: [3, 2, 3, 3]
15 3 2 3
After:  [3, 2, 3, 1]

Before: [0, 1, 1, 3]
4 2 3 3
After:  [0, 1, 1, 0]

Before: [1, 3, 2, 1]
0 3 1 2
After:  [1, 3, 1, 1]

";
            var secondPart = @"8 2 0 0
8 1 2 3
8 3 2 2
1 3 2 2
1 2 3 2
6 1 2 1
5 1 0 0
8 3 1 1
8 0 0 2
1 3 2 3
1 3 3 3
6 0 3 0
5 0 1 1
8 2 2 2
8 1 0 3
1 0 0 0
9 0 1 0
5 0 2 3
1 3 1 3
6 3 1 1
5 1 2 2
8 3 3 3
8 0 2 0
8 2 1 1
8 1 3 3
1 3 2 3
6 3 2 2
5 2 3 0
8 3 2 2
8 0 2 3
12 1 2 3
1 3 2 3
6 3 0 0
5 0 3 1
1 0 0 0
9 0 2 0
8 2 2 3
12 0 2 2
1 2 2 2
6 2 1 1
5 1 1 2
8 0 0 1
8 1 3 3
13 0 3 1
1 1 3 1
1 1 1 1
6 1 2 2
5 2 3 0
1 3 0 3
9 3 3 3
8 2 3 1
8 0 2 2
3 3 2 3
1 3 1 3
6 3 0 0
8 0 2 3
1 1 0 2
9 2 2 2
1 0 0 1
9 1 0 1
4 3 2 1
1 1 1 1
1 1 3 1
6 1 0 0
8 1 2 1
8 3 2 2
7 3 2 2
1 2 3 2
1 2 2 2
6 2 0 0
5 0 1 2
8 1 2 0
8 3 1 1
8 3 0 0
1 0 1 0
6 0 2 2
5 2 2 0
8 2 0 2
4 3 2 3
1 3 3 3
6 0 3 0
5 0 1 2
1 1 0 3
9 3 1 3
8 1 2 0
6 3 3 1
1 1 2 1
6 2 1 2
8 2 0 3
1 0 0 0
9 0 2 0
1 3 0 1
9 1 1 1
10 0 3 0
1 0 3 0
6 2 0 2
8 2 3 0
8 3 0 1
2 1 0 0
1 0 2 0
6 0 2 2
5 2 0 0
8 3 0 2
8 0 3 3
8 2 3 1
7 3 2 1
1 1 2 1
6 1 0 0
5 0 2 3
8 0 0 2
8 3 0 0
8 0 0 1
8 2 0 2
1 2 1 2
1 2 1 2
6 3 2 3
5 3 2 1
8 0 3 3
8 1 2 2
1 1 0 0
9 0 2 0
0 0 3 0
1 0 3 0
1 0 3 0
6 1 0 1
5 1 2 3
8 1 1 0
8 2 0 2
8 0 2 1
5 0 2 1
1 1 1 1
6 1 3 3
5 3 2 1
8 3 1 2
1 2 0 3
9 3 1 3
8 2 0 2
1 2 2 2
1 2 1 2
6 1 2 1
5 1 2 3
8 3 2 0
8 0 1 1
8 0 3 2
11 2 0 0
1 0 2 0
1 0 2 0
6 0 3 3
5 3 3 0
8 1 1 1
8 3 3 3
1 1 2 3
1 3 3 3
1 3 2 3
6 0 3 0
5 0 1 1
8 2 0 3
8 3 2 2
8 2 1 0
0 0 3 0
1 0 2 0
6 0 1 1
8 3 3 0
8 2 0 2
1 0 0 3
9 3 0 3
15 2 0 3
1 3 2 3
6 1 3 1
8 1 2 0
8 0 3 3
8 0 2 2
6 0 0 3
1 3 3 3
6 1 3 1
5 1 0 2
1 3 0 3
9 3 0 3
8 1 3 1
8 3 0 3
1 3 2 3
6 2 3 2
5 2 2 1
8 1 1 3
8 2 2 2
6 0 3 3
1 3 3 3
6 3 1 1
8 2 1 0
8 2 1 3
10 0 3 3
1 3 2 3
6 3 1 1
5 1 0 2
1 2 0 1
9 1 1 1
8 2 1 3
14 1 0 1
1 1 3 1
6 2 1 2
5 2 3 1
8 2 3 2
1 2 0 0
9 0 1 0
5 0 2 2
1 2 2 2
6 2 1 1
5 1 3 0
8 3 2 1
8 1 1 3
8 0 1 2
3 1 2 2
1 2 1 2
6 0 2 0
5 0 3 3
8 2 0 0
8 3 1 2
12 0 2 2
1 2 2 2
6 3 2 3
5 3 3 1
8 2 1 2
8 0 0 3
8 0 2 0
4 3 2 0
1 0 2 0
1 0 3 0
6 1 0 1
5 1 0 0
8 2 2 1
4 3 2 1
1 1 3 1
6 0 1 0
5 0 1 3
1 1 0 0
9 0 2 0
8 1 3 1
8 1 3 2
14 1 0 2
1 2 1 2
6 3 2 3
5 3 2 2
8 2 3 3
8 0 3 1
8 3 3 0
8 1 3 1
1 1 2 1
1 1 2 1
6 1 2 2
5 2 0 1
8 1 0 3
8 0 0 2
11 2 0 2
1 2 2 2
6 2 1 1
5 1 2 0
8 0 1 1
1 1 0 2
9 2 3 2
8 3 1 3
8 1 2 1
1 1 2 1
1 1 1 1
6 0 1 0
5 0 1 2
8 2 3 3
8 3 2 1
8 2 2 0
0 0 3 0
1 0 1 0
6 2 0 2
5 2 1 0
1 2 0 2
9 2 2 2
8 2 0 1
8 0 3 3
4 3 2 2
1 2 1 2
6 2 0 0
8 3 1 1
1 2 0 2
9 2 2 2
15 2 1 3
1 3 3 3
1 3 2 3
6 0 3 0
5 0 3 1
8 2 2 3
8 1 0 0
14 0 3 0
1 0 3 0
6 1 0 1
5 1 2 2
8 3 3 1
8 1 3 0
14 0 3 1
1 1 3 1
6 2 1 2
5 2 0 3
8 2 0 2
8 1 2 1
5 0 2 0
1 0 1 0
1 0 2 0
6 0 3 3
5 3 0 1
8 1 1 3
8 2 1 0
6 3 3 0
1 0 1 0
6 0 1 1
8 3 1 3
8 3 1 0
12 2 0 3
1 3 2 3
1 3 3 3
6 3 1 1
5 1 0 2
1 2 0 3
9 3 2 3
8 1 1 1
2 0 3 1
1 1 2 1
6 1 2 2
5 2 1 1
8 3 3 2
1 0 0 3
9 3 3 3
8 2 2 0
11 0 2 3
1 3 1 3
6 3 1 1
8 1 1 3
8 0 1 2
1 3 2 0
1 0 2 0
6 0 1 1
5 1 3 0
8 2 0 1
8 3 3 3
8 3 1 2
12 1 2 1
1 1 1 1
1 1 1 1
6 0 1 0
5 0 2 1
8 1 3 3
8 0 3 2
8 0 2 0
6 3 3 0
1 0 3 0
6 0 1 1
5 1 3 0
8 3 2 3
8 0 2 1
1 1 0 2
9 2 3 2
3 3 2 1
1 1 3 1
6 0 1 0
8 0 1 3
8 3 3 1
8 2 3 2
4 3 2 1
1 1 2 1
1 1 2 1
6 1 0 0
1 2 0 1
9 1 1 1
1 3 0 3
9 3 2 3
0 2 3 1
1 1 1 1
6 1 0 0
5 0 0 3
8 3 2 2
8 1 3 1
8 1 1 0
6 1 0 1
1 1 1 1
6 1 3 3
5 3 1 0
1 0 0 1
9 1 2 1
8 2 1 3
8 1 2 2
0 1 3 1
1 1 2 1
6 1 0 0
5 0 0 2
8 3 2 3
8 3 2 1
8 2 1 0
2 3 0 3
1 3 2 3
6 3 2 2
5 2 3 3
8 0 0 0
8 3 1 2
8 2 2 1
12 1 2 0
1 0 1 0
1 0 3 0
6 3 0 3
5 3 2 2
8 2 1 0
1 3 0 3
9 3 2 3
10 0 3 1
1 1 2 1
6 2 1 2
8 3 2 3
8 1 2 1
14 1 0 1
1 1 2 1
6 1 2 2
5 2 3 0
8 3 1 1
8 2 3 2
15 2 1 1
1 1 1 1
1 1 1 1
6 1 0 0
5 0 0 3
8 3 1 2
8 3 3 1
8 2 0 0
11 0 2 1
1 1 2 1
6 1 3 3
8 1 2 0
1 3 0 1
9 1 1 1
1 0 2 1
1 1 3 1
1 1 2 1
6 3 1 3
8 2 0 0
8 1 3 1
14 1 0 1
1 1 3 1
6 3 1 3
5 3 1 1
8 1 2 0
8 2 1 2
8 3 3 3
5 0 2 3
1 3 1 3
6 3 1 1
8 1 2 3
8 2 0 0
8 3 0 2
11 0 2 2
1 2 1 2
6 2 1 1
5 1 0 0
8 3 3 1
8 0 0 3
8 3 1 2
7 3 2 2
1 2 2 2
6 2 0 0
5 0 3 3
8 1 3 1
8 1 1 0
8 2 0 2
5 0 2 2
1 2 3 2
6 2 3 3
5 3 3 1
8 3 1 2
1 0 0 3
9 3 0 3
8 2 0 0
7 3 2 2
1 2 3 2
1 2 1 2
6 2 1 1
8 2 3 3
1 1 0 2
9 2 0 2
10 0 3 3
1 3 2 3
6 1 3 1
1 0 0 2
9 2 1 2
8 2 2 3
10 0 3 3
1 3 1 3
6 3 1 1
8 0 0 3
8 1 1 0
8 3 3 2
7 3 2 3
1 3 3 3
6 1 3 1
5 1 1 2
1 0 0 3
9 3 1 3
1 0 0 0
9 0 0 0
8 1 2 1
6 3 3 3
1 3 3 3
6 2 3 2
5 2 2 1
1 2 0 0
9 0 1 0
8 2 2 3
8 0 0 2
14 0 3 0
1 0 3 0
6 0 1 1
5 1 2 2
8 1 0 3
8 0 3 0
1 1 0 1
9 1 0 1
9 3 1 0
1 0 3 0
1 0 3 0
6 0 2 2
5 2 1 0
1 1 0 1
9 1 3 1
8 3 0 3
8 0 3 2
3 1 2 3
1 3 3 3
6 3 0 0
5 0 3 2
1 3 0 1
9 1 2 1
8 1 2 0
1 1 0 3
9 3 2 3
14 0 3 1
1 1 3 1
6 1 2 2
5 2 2 3
8 3 0 1
1 3 0 2
9 2 2 2
8 2 1 0
2 1 0 1
1 1 2 1
1 1 3 1
6 3 1 3
5 3 0 0
8 0 2 3
8 3 0 2
8 2 0 1
7 3 2 2
1 2 2 2
6 0 2 0
8 2 0 3
8 0 0 2
1 2 0 1
9 1 0 1
7 2 3 3
1 3 3 3
6 0 3 0
5 0 3 3
8 1 1 0
8 2 2 1
1 0 2 1
1 1 1 1
1 1 1 1
6 1 3 3
8 2 1 1
8 3 0 2
12 1 2 1
1 1 3 1
6 3 1 3
5 3 1 0
8 2 3 2
8 1 2 1
8 0 3 3
4 3 2 1
1 1 2 1
6 1 0 0
5 0 2 3
8 3 3 2
1 2 0 1
9 1 3 1
8 2 1 0
2 1 0 2
1 2 1 2
1 2 2 2
6 3 2 3
5 3 2 0
8 3 3 2
8 1 1 1
8 3 0 3
1 1 2 1
1 1 1 1
1 1 1 1
6 1 0 0
5 0 3 3
8 2 3 1
8 3 0 0
1 2 0 2
9 2 2 2
12 1 0 0
1 0 2 0
6 0 3 3
5 3 2 2
8 2 1 0
8 2 1 3
1 1 0 1
9 1 0 1
10 0 3 1
1 1 1 1
1 1 1 1
6 1 2 2
5 2 1 1
8 3 2 2
10 0 3 2
1 2 2 2
1 2 2 2
6 2 1 1
5 1 2 2
1 2 0 3
9 3 0 3
8 0 2 1
0 0 3 0
1 0 3 0
6 0 2 2
8 0 0 0
1 2 0 1
9 1 1 1
1 2 0 3
9 3 1 3
6 1 3 3
1 3 2 3
1 3 1 3
6 2 3 2
5 2 1 0
8 3 1 3
8 3 1 2
3 3 2 1
1 1 2 1
1 1 3 1
6 1 0 0
5 0 3 2
8 1 3 0
8 0 3 1
9 0 1 0
1 0 1 0
6 0 2 2
5 2 0 1
1 2 0 3
9 3 1 3
8 0 1 2
1 0 0 0
9 0 1 0
6 3 3 3
1 3 2 3
6 3 1 1
5 1 2 3
8 0 1 1
8 3 2 2
1 0 2 1
1 1 1 1
1 1 2 1
6 1 3 3
5 3 2 0
8 3 0 1
8 0 1 2
8 1 0 3
8 2 1 2
1 2 1 2
1 2 3 2
6 0 2 0
5 0 2 2
8 2 3 0
8 2 3 3
8 1 0 1
10 0 3 3
1 3 1 3
6 3 2 2
5 2 3 1
8 0 0 2
8 1 3 3
13 0 3 3
1 3 2 3
6 1 3 1
1 2 0 2
9 2 2 2
8 0 2 3
4 3 2 2
1 2 1 2
6 2 1 1
5 1 2 3
8 2 3 1
8 2 0 2
8 1 3 0
5 0 2 1
1 1 1 1
6 1 3 3
5 3 3 0
8 2 1 3
8 3 0 2
8 1 1 1
14 1 3 2
1 2 3 2
6 2 0 0
5 0 2 3
8 2 3 2
1 3 0 0
9 0 1 0
8 2 2 1
5 0 2 0
1 0 1 0
1 0 1 0
6 0 3 3
8 3 0 1
1 1 0 2
9 2 3 2
8 2 2 0
15 0 1 1
1 1 2 1
1 1 1 1
6 1 3 3
5 3 1 0
8 0 3 1
8 0 3 2
1 2 0 3
9 3 0 3
8 2 3 1
1 1 1 1
6 1 0 0
8 2 3 2
8 1 1 1
4 3 2 2
1 2 1 2
6 2 0 0
5 0 0 1
8 0 3 2
8 1 0 3
8 2 3 0
14 3 0 2
1 2 1 2
6 1 2 1
5 1 3 0
8 0 3 2
8 3 0 3
8 3 3 1
3 3 2 3
1 3 3 3
6 3 0 0
5 0 3 2
8 3 0 3
8 2 2 1
8 3 3 0
2 0 1 3
1 3 2 3
1 3 1 3
6 3 2 2
5 2 3 1
8 2 3 3
1 0 0 2
9 2 3 2
8 2 0 0
10 0 3 3
1 3 3 3
6 1 3 1
5 1 3 3
8 1 1 1
14 1 0 2
1 2 2 2
1 2 2 2
6 2 3 3
5 3 1 2
1 2 0 3
9 3 2 3
8 3 1 1
10 0 3 1
1 1 1 1
6 1 2 2
5 2 2 0
8 2 2 1
8 3 0 2
1 0 0 3
9 3 3 3
12 1 2 2
1 2 2 2
6 0 2 0
5 0 0 1
8 2 0 0
8 3 1 2
2 3 0 0
1 0 3 0
6 1 0 1
5 1 1 3
8 2 0 2
8 3 0 1
8 2 0 0
15 2 1 0
1 0 2 0
6 3 0 3
5 3 2 0
8 2 3 1
8 3 0 2
8 3 1 3
12 1 2 3
1 3 3 3
6 3 0 0
5 0 1 1
8 1 1 0
8 2 1 2
8 0 1 3
5 0 2 0
1 0 1 0
1 0 3 0
6 1 0 1
5 1 2 2
8 3 2 1
8 2 1 3
1 1 0 0
9 0 1 0
9 0 1 0
1 0 3 0
6 0 2 2
5 2 0 0
8 1 2 1
8 0 0 2
8 1 3 3
1 1 2 1
1 1 1 1
6 0 1 0
5 0 3 1
8 2 2 3
1 3 0 0
9 0 1 0
8 2 0 2
5 0 2 3
1 3 1 3
1 3 3 3
6 1 3 1
5 1 1 2
8 0 2 3
8 2 0 0
8 3 3 1
0 0 3 3
1 3 1 3
1 3 2 3
6 2 3 2
5 2 3 3
8 2 0 1
8 3 3 2
8 1 3 0
1 0 2 0
1 0 2 0
1 0 3 0
6 0 3 3
8 0 2 0
8 3 0 1
8 1 0 2
3 1 2 1
1 1 3 1
1 1 2 1
6 1 3 3
8 1 1 0
1 0 0 1
9 1 3 1
1 3 0 2
9 2 0 2
9 0 1 2
1 2 2 2
1 2 2 2
6 2 3 3
5 3 2 2
8 2 2 0
1 3 0 3
9 3 1 3
14 3 0 3
1 3 2 3
1 3 3 3
6 2 3 2
5 2 2 1
8 1 2 2
8 3 0 3
3 3 2 0
1 0 1 0
6 0 1 1
8 0 3 2
8 2 2 3
1 2 0 0
9 0 3 0
11 2 0 3
1 3 1 3
1 3 2 3
6 1 3 1
5 1 0 3
8 1 3 0
8 1 0 1
8 2 2 2
5 0 2 1
1 1 2 1
1 1 2 1
6 1 3 3
1 3 0 1
9 1 2 1
8 3 1 0
8 3 3 2
12 1 0 2
1 2 1 2
6 2 3 3
5 3 2 1
8 1 0 2
1 0 0 0
9 0 2 0
8 2 0 3
10 0 3 0
1 0 3 0
1 0 3 0
6 1 0 1
8 3 3 0
8 0 3 2
8 0 0 3
11 2 0 0
1 0 2 0
6 0 1 1
8 1 3 3
8 3 2 2
8 1 1 0
6 3 3 3
1 3 1 3
1 3 2 3
6 3 1 1
5 1 3 0
8 3 3 1
1 2 0 3
9 3 0 3
7 3 2 3
1 3 1 3
1 3 2 3
6 0 3 0
5 0 2 2
1 2 0 1
9 1 2 1
1 1 0 3
9 3 2 3
8 2 3 0
10 0 3 3
1 3 3 3
1 3 3 3
6 2 3 2
5 2 2 1
8 2 1 3
8 3 1 0
8 3 2 2
2 0 3 3
1 3 1 3
6 1 3 1
1 1 0 2
9 2 2 2
8 3 1 3
1 0 0 0
9 0 1 0
5 0 2 0
1 0 1 0
6 1 0 1
5 1 3 0
8 2 2 3
8 2 3 1
0 2 3 2
1 2 1 2
6 0 2 0
5 0 3 3
8 3 2 1
8 0 2 0
8 3 0 2
3 1 2 1
1 1 2 1
6 1 3 3
8 0 0 1
8 0 1 2
8 1 2 0
9 0 1 0
1 0 3 0
6 3 0 3
5 3 0 2
8 2 3 1
1 3 0 0
9 0 3 0
8 0 0 3
12 1 0 1
1 1 3 1
1 1 3 1
6 1 2 2
5 2 3 1
8 2 0 0
8 3 3 2
7 3 2 0
1 0 3 0
6 1 0 1
5 1 3 2
8 2 3 1
8 1 2 0
8 1 1 3
6 0 0 1
1 1 2 1
1 1 3 1
6 2 1 2
8 0 0 1
8 3 1 3
9 0 1 3
1 3 1 3
6 2 3 2
5 2 3 0
8 3 1 1
8 2 2 2
8 3 0 3
15 2 1 2
1 2 2 2
6 2 0 0
5 0 3 3
1 1 0 2
9 2 0 2
8 1 0 0
3 1 2 0
1 0 1 0
6 0 3 3
5 3 1 0
8 2 1 3
8 2 3 2
15 2 1 1
1 1 1 1
6 1 0 0
5 0 3 1
1 0 0 2
9 2 0 2
1 3 0 0
9 0 2 0
7 2 3 3
1 3 1 3
6 3 1 1
5 1 3 0
8 0 1 1
8 3 2 3
3 3 2 3
1 3 3 3
6 3 0 0
5 0 1 1
8 2 3 3
8 1 0 0
1 1 0 2
9 2 3 2
1 0 2 3
1 3 3 3
6 3 1 1
5 1 1 2
8 1 1 3
8 1 1 1
1 3 0 0
9 0 2 0
13 0 3 3
1 3 1 3
6 2 3 2
5 2 1 1
8 3 1 0
8 0 0 2
8 1 3 3
11 2 0 3
1 3 1 3
6 1 3 1
5 1 0 3
8 3 0 1
1 2 0 2
9 2 1 2
8 1 2 0
3 1 2 2
1 2 2 2
6 2 3 3
5 3 0 1
8 2 1 2
1 3 0 3
9 3 1 3
8 2 2 0
13 0 3 0
1 0 3 0
6 1 0 1
8 1 1 0
1 0 0 3
9 3 0 3
4 3 2 0
1 0 3 0
6 1 0 1
5 1 2 3
8 0 0 2
8 0 1 1
1 1 0 0
9 0 3 0
11 2 0 2
1 2 1 2
6 3 2 3
5 3 3 0
8 1 1 3
1 3 0 2
9 2 3 2
8 1 3 1
1 3 2 2
1 2 2 2
6 0 2 0
5 0 3 3
1 2 0 1
9 1 0 1
8 2 2 2
8 3 2 0
15 2 0 2
1 2 2 2
1 2 2 2
6 3 2 3
5 3 3 0";
            var registers = new int[4];
            var firsts = firstPart.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var seconds = secondPart.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var operators = new List<Action<int, int, int>>();
            operators.Add(addr);
            operators.Add(addi);
            operators.Add(muli);
            operators.Add(mulr);
            operators.Add(banr);
            operators.Add(bani);
            operators.Add(borr);
            operators.Add(bori);
            operators.Add(setr);
            operators.Add(seti);
            operators.Add(gtir);
            operators.Add(gtri);
            operators.Add(gtrr);
            operators.Add(eqir);
            operators.Add(eqri);
            operators.Add(eqrr);
            var findOperator = new Dictionary<int, HashSet<Action<int, int, int>>>();
            for (int i = 0; i < 16; i++)
            {
                findOperator[i] = new HashSet<Action<int, int, int>>(operators);
            }
            int index = 0;
            int total = 0;
            while (index < firsts.Length)
            {
                var matchb = before.Match(firsts[index]);
                var beforeArray = new int[] { ReadInt(matchb, "A"), ReadInt(matchb, "B"), ReadInt(matchb, "C"), ReadInt(matchb, "D") };
                var matcha = after.Match(firsts[index + 2]);
                var afterArray = new int[] { ReadInt(matcha, "A"), ReadInt(matcha, "B"), ReadInt(matcha, "C"), ReadInt(matcha, "D") };
                var action = firsts[index + 1].Split().Select(int.Parse).ToArray();
                var elem = 0;
                for (int i = 0; i < 16; i++)
                {
                    registers = (int[])beforeArray.Clone();
                    operators[i](action[1], action[2], action[3]);
                    if (registers.SequenceEqual(afterArray))
                        elem++;
                    else
                    {
                        // Set invalid for action[0] for this operator...
                        findOperator[action[0]].Remove(operators[i]);
                    }
                }
                if (elem >= 3)
                    total++;
                index += 3;
            }
            Console.WriteLine(total);

            // now clean the findOperator
            CleanOperators(findOperator);
            registers = new int[4];
            foreach (var line in seconds)
            {
                var code = line.Split().Select(int.Parse).ToArray();
                findOperator[code[0]].First()(code[1], code[2], code[3]);
            }
            Console.WriteLine(registers[0]);

            void addr(int A, int B, int C)
            {
                registers[C] = registers[A] + registers[B];
            }
            void addi(int A, int B, int C)
            {
                registers[C] = registers[A] + B;
            }
            void mulr(int A, int B, int C)
            {
                registers[C] = registers[A] * registers[B];
            }
            void muli(int A, int B, int C)
            {
                registers[C] = registers[A] * B;
            }
            void banr(int A, int B, int C)
            {
                registers[C] = registers[A] & registers[B];
            }
            void bani(int A, int B, int C)
            {
                registers[C] = registers[A] & B;
            }
            void borr(int A, int B, int C)
            {
                registers[C] = registers[A] | registers[B];
            }
            void bori(int A, int B, int C)
            {
                registers[C] = registers[A] | B;
            }
            void setr(int A, int B, int C)
            {
                registers[C] = registers[A];
            }
            void seti(int A, int B, int C)
            {
                registers[C] = A;
            }
            void gtir(int A, int B, int C)
            {
                registers[C] = A > registers[B] ? 1 : 0;
            }
            void gtri(int A, int B, int C)
            {
                registers[C] = registers[A] > B ? 1 : 0;
            }
            void gtrr(int A, int B, int C)
            {
                registers[C] = registers[A] > registers[B] ? 1 : 0;
            }
            void eqir(int A, int B, int C)
            {
                registers[C] = A == registers[B] ? 1 : 0;
            }
            void eqri(int A, int B, int C)
            {
                registers[C] = registers[A] == B ? 1 : 0;
            }
            void eqrr(int A, int B, int C)
            {
                registers[C] = registers[A] == registers[B] ? 1 : 0;
            }

        }

        private static void CleanOperators(Dictionary<int, HashSet<Action<int, int, int>>> findOperator)
        {
            bool found = true;
            while (found)
            {
                found = false;
                for (int i = 0; i < 16; i++)
                {
                    if (findOperator[i].Count == 1)
                    {
                        var oneOp = findOperator[i].First();
                        for (int j = 0; j < 16; j++)
                        {
                            if (i == j) continue;
                            findOperator[j].Remove(oneOp);
                        }
                    }
                    else
                        found = true;
                }
            }
        }
    }

}
