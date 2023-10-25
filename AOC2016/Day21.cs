using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AOC2016
{
    public class Day21
    {
        static Regex swapPosition = new Regex(@"^swap position (?<X>[0-9]) with position (?<Y>[0-9])");
        static Regex swapLetter = new Regex(@"^swap letter (?<X>[a-z]) with letter (?<Y>[a-z])");
        static Regex rotate = new Regex(@"^rotate (?<direction>[a-z]+) (?<X>[0-9]) step[s]*");
        static Regex rotatePosition = new Regex(@"^rotate based on position of letter (?<X>[a-z])");
        static Regex reversePosition = new Regex(@"^reverse positions (?<X>[0-9]) through (?<Y>[0-9])");
        static Regex movePosition = new Regex(@"^move position (?<X>[0-9]) to position (?<Y>[0-9])");

        public static void Main()
        {
            var input = @"reverse positions 1 through 6
rotate based on position of letter a
swap position 4 with position 1
reverse positions 1 through 5
move position 5 to position 7
swap position 4 with position 0
swap position 4 with position 6
rotate based on position of letter a
swap position 0 with position 2
move position 5 to position 2
move position 7 to position 1
swap letter d with letter c
swap position 5 with position 3
reverse positions 3 through 7
rotate based on position of letter d
swap position 7 with position 5
rotate based on position of letter f
swap position 4 with position 1
swap position 3 with position 6
reverse positions 4 through 7
rotate based on position of letter c
move position 0 to position 5
swap position 7 with position 4
rotate based on position of letter f
reverse positions 1 through 3
move position 5 to position 3
rotate based on position of letter g
reverse positions 2 through 5
rotate right 0 steps
rotate left 0 steps
swap letter f with letter b
rotate based on position of letter h
move position 1 to position 3
reverse positions 3 through 6
rotate based on position of letter h
swap position 4 with position 3
swap letter b with letter h
swap letter a with letter h
reverse positions 1 through 6
swap position 3 with position 6
swap letter e with letter d
swap letter e with letter h
swap position 1 with position 5
rotate based on position of letter a
reverse positions 4 through 5
swap position 0 with position 4
reverse positions 0 through 3
move position 7 to position 2
swap letter e with letter c
swap position 3 with position 4
rotate left 3 steps
rotate left 7 steps
rotate based on position of letter e
reverse positions 5 through 6
move position 1 to position 5
move position 1 to position 2
rotate left 1 step
move position 7 to position 6
rotate left 0 steps
reverse positions 5 through 6
reverse positions 3 through 7
swap letter d with letter e
rotate right 3 steps
swap position 2 with position 1
swap position 5 with position 7
swap letter h with letter d
swap letter c with letter d
rotate based on position of letter d
swap letter d with letter g
reverse positions 0 through 1
rotate right 0 steps
swap position 2 with position 3
rotate left 4 steps
rotate left 5 steps
move position 7 to position 0
rotate right 1 step
swap letter g with letter f
rotate based on position of letter a
rotate based on position of letter b
swap letter g with letter e
rotate right 4 steps
rotate based on position of letter h
reverse positions 3 through 5
swap letter h with letter e
swap letter g with letter a
rotate based on position of letter c
reverse positions 0 through 4
rotate based on position of letter e
reverse positions 4 through 7
rotate left 4 steps
swap position 0 with position 6
reverse positions 1 through 6
rotate left 2 steps
swap position 5 with position 3
swap letter b with letter d
swap letter b with letter d
rotate based on position of letter d
rotate based on position of letter c
rotate based on position of letter h
move position 4 to position 7";
            var password = "abcdefgh".ToCharArray();
            Scramble(input, password);
            Console.WriteLine(new string(password));
            var target = "fbgdceah";
            var source = "abcdefgh".ToCharArray();
            int possible = 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1;
            for (int i = 0; i < possible; i++)
            {
                var temp = (char[])source.Clone();
                Scramble(input, temp);
                if (new string(temp) == target)
                {
                    Console.WriteLine(new string(source));
                }
                NextPermutation(source);
            }

            //Unscramble(input, scrambledPassword);
            //Console.WriteLine(new string(scrambledPassword));
        }

        private static void Unscramble(string input, char[] password)
        {
            Match match;
            foreach (var instruction in input.Split("\n").Reverse())
            {
                match = swapPosition.Match(instruction);
                if (match.Success)
                {
                    Swap(password, ReadInt(match, "X"), ReadInt(match, "Y"));
                    continue;
                }
                match = swapLetter.Match(instruction);
                if (match.Success)
                {
                    Swap(password, FindInt(match, password, "X"), FindInt(match, password, "Y"));
                    continue;
                }
                match = rotate.Match(instruction);
                if (match.Success)
                {
                    Rotate(password, ReadString(match, "direction") != "right", ReadInt(match, "X"));
                    continue;
                }
                match = rotatePosition.Match(instruction);
                if (match.Success)
                {
                    // Will need to find which one of the password is the previous step.
                    var target = new string(password);
                    for (int i = 0; i < target.Length; i++)
                    {
                        var temp = target.ToCharArray();
                        Rotate(temp, true, i);
                        if (new string(temp) == target)
                        {
                            password = temp;
                            break;
                        }
                    }
                    continue;
                }
                match = reversePosition.Match(instruction);
                if (match.Success)
                {
                    Reverse(password, ReadInt(match, "Y"), ReadInt(match, "X"));
                    continue;
                }
                match = movePosition.Match(instruction);
                if (match.Success)
                {
                    Move(password, ReadInt(match, "X"), ReadInt(match, "Y"));
                    continue;
                }
                throw new NotImplementedException($"{instruction} got no match.");
            }
        }

        private static void RotatePosition(char[] password, Match match)
        {
            int step = FindInt(match, password, "X");
            step += step >= 4 ? 2 : 1;
            Rotate(password, true, step);
        }

        private static void Scramble(string input, char[] password)
        {
            Match match;
            foreach (var instruction in input.Split("\n"))
            {
                match = swapPosition.Match(instruction);
                if (match.Success)
                {
                    Swap(password, ReadInt(match, "X"), ReadInt(match, "Y"));
                    continue;
                }
                match = swapLetter.Match(instruction);
                if (match.Success)
                {
                    Swap(password, FindInt(match, password, "X"), FindInt(match, password, "Y"));
                    continue;
                }
                match = rotate.Match(instruction);
                if (match.Success)
                {
                    Rotate(password, ReadString(match, "direction") == "right", ReadInt(match, "X"));
                    continue;
                }
                match = rotatePosition.Match(instruction);
                if (match.Success)
                {
                    RotatePosition(password, match);
                    continue;
                }
                match = reversePosition.Match(instruction);
                if (match.Success)
                {
                    Reverse(password, ReadInt(match, "X"), ReadInt(match, "Y"));
                    continue;
                }
                match = movePosition.Match(instruction);
                if (match.Success)
                {
                    Move(password, ReadInt(match, "X"), ReadInt(match, "Y"));
                    continue;
                }
                throw new NotImplementedException($"{instruction} got no match.");
            }
        }

        private static void Move(char[] password, int x, int y)
        {
            char xc = password[x];
            for (int i = x; i < password.Length - 1; i++)
            {
                password[i] = password[i + 1];
            }
            for (int i = password.Length - 1; i > y; i--)
            {
                password[i] = password[i - 1];
            }
            password[y] = xc;
        }

        private static void Reverse(char[] password, int v1, int v2)
        {
            Array.Reverse(password, Math.Min(v1, v2), Math.Abs(v2 - v1) + 1);
        }

        private static void Rotate(char[] password, bool right, int shift)
        {
            int n = password.Length;
            if (!right)
                shift = ((n - shift) % n + n) % n;

            int g = Gcd(n, shift);
            for (int i = 0; i < g; i++)
            {
                var c = password[i];
                int loop = n / g;
                int prev;
                int next = ((i - shift) % n + n) % n;
                for (int j = 0; j < loop - 1; j++)
                {
                    prev = ((i - j * shift) % n + n) % n;
                    next = ((i - (j + 1) * shift) % n + n) % n;
                    password[prev] = password[next];
                }
                password[next] = c;
            }
        }

        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        private static int FindInt(Match match, char[] password, string key)
        {
            return Array.IndexOf(password, ReadChar(match, key));
        }
        private static char ReadChar(Match match, string key)
        {
            return match.Groups[key].Value[0];
        }
        private static string ReadString(Match match, string key)
        {
            return match.Groups[key].Value;
        }

        private static void Swap(char[] password, int v1, int v2)
        {
            var t = password[v1];
            password[v1] = password[v2];
            password[v2] = t;
        }

        private static int ReadInt(Match match, string key)
        {
            return int.Parse(match.Groups[key].Value);
        }

        public static void NextPermutation(char[] nums)
        {
            var count = nums.Length;
            var done = true;
            for (var i = count - 1; i > 0; i--)
            {
                var curr = nums[i];
                if (curr <= nums[i - 1])
                    continue;
                done = false;
                var prev = nums[i - 1];
                var currIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    var tmp = nums[j];
                    if (tmp <= curr && tmp > prev)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }
                nums[currIndex] = prev;
                nums[i - 1] = curr;
                // Reverse the end
                for (int j = count - 1; j > i; j--, i++)
                {
                    var tmp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tmp;
                }
                break;
            }

            if (done) // higher order, just swap to get the smaller one.
            {
                int i = count - 1, j = 0;
                for (; j < i; j++, i--)
                {
                    var tmp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tmp;
                }
            }
        }


    }

}
