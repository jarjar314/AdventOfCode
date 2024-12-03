using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day18
    {
        static string sample4 = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]";
        static string sample5 = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]";
        static string input1 = @"[[[[1,1],[2,2]],[3,3]],[4,4]]";
        static string input2 = @"[[[[1,1],[2,2]],[3,3]],[4,4]]";
        static string sample2 = @"[[[[4,3],4],4],[7,[[8,4],9]]]
[1,1]";
        static string sample3 = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";
        static string sample = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";
        static string input = @"[[[3,[8,6]],[6,1]],[[[1,1],2],[[1,0],0]]]
[[[1,[7,3]],1],9]
[[[2,6],[[3,1],[0,9]]],[[7,[4,8]],[[2,7],3]]]
[[[3,[0,4]],[[8,4],[1,9]]],[7,[2,[5,7]]]]
[[[4,5],[[0,7],1]],[9,[0,4]]]
[[5,[[1,5],[3,6]]],8]
[[3,[[9,3],9]],9]
[2,[[[2,1],[0,5]],[9,9]]]
[[2,[6,9]],[[[4,1],0],[3,4]]]
[[[[6,8],0],[[8,8],9]],[[[4,2],3],[3,[7,3]]]]
[[3,7],9]
[[[[2,5],8],[2,5]],[[0,[5,7]],[[2,5],4]]]
[[[8,[6,6]],0],[4,[[5,6],[8,4]]]]
[[[1,[8,2]],[[0,4],[2,6]]],[[3,4],0]]
[[1,[[9,2],[6,0]]],[[[0,9],5],[[8,0],[1,5]]]]
[[2,[[2,3],[1,8]]],[3,[[7,2],[0,7]]]]
[[5,4],5]
[[[[4,2],[4,8]],[7,3]],[0,[[8,9],6]]]
[[[6,7],0],5]
[[2,[[9,0],[8,4]]],[[[7,4],[3,4]],0]]
[[[9,[8,9]],1],[[5,[6,7]],3]]
[[2,[0,0]],[3,[[2,5],[1,4]]]]
[[0,1],[0,[[8,8],[8,3]]]]
[[[0,2],[2,8]],[1,[[7,0],0]]]
[[[[5,4],3],[[7,5],[2,6]]],[[5,8],[0,1]]]
[0,[0,0]]
[[5,[[5,6],0]],[[[2,7],9],[7,9]]]
[[[[0,8],2],[[2,5],[7,6]]],[[9,7],[[8,7],[9,2]]]]
[[[0,[4,6]],[[6,3],[4,4]]],[8,[[4,8],[4,8]]]]
[[[[8,9],[3,8]],8],[[[7,9],6],[9,[2,7]]]]
[[[[8,9],[1,6]],0],[[[8,7],4],[9,[1,4]]]]
[5,7]
[[[[1,5],[3,6]],[[5,5],4]],[[3,3],[4,[4,0]]]]
[[[0,6],[5,[5,3]]],[[4,[0,0]],8]]
[7,[6,8]]
[[[[8,5],9],[[3,2],7]],[[[6,6],5],2]]
[[[[4,4],[0,4]],9],0]
[[0,[3,[9,3]]],[9,[[8,0],[0,9]]]]
[[[[4,0],0],[1,[1,7]]],[[3,[3,0]],[[1,3],6]]]
[[9,4],[3,[[7,1],6]]]
[[[[3,7],7],1],[[4,3],[[6,9],[6,9]]]]
[[[8,[2,5]],[[8,4],4]],[[[3,4],[6,7]],[5,[8,5]]]]
[2,[4,[[3,2],7]]]
[[[[3,1],[5,6]],[[2,7],7]],[4,[8,[7,4]]]]
[[7,8],[[[3,9],7],2]]
[[[[8,8],[5,8]],[[1,0],[6,0]]],[[[1,2],6],[[4,2],[5,5]]]]
[[1,[0,9]],[[[2,1],1],1]]
[[6,[8,1]],[4,[[7,8],5]]]
[[[1,[1,6]],[1,[5,7]]],[[[2,8],6],0]]
[9,1]
[[[0,[6,5]],[[8,5],2]],[[[2,4],[7,3]],[[1,5],[9,2]]]]
[[[2,7],[0,[3,6]]],[[[1,0],[9,6]],[1,[0,4]]]]
[6,[[[5,9],8],[0,2]]]
[7,[[[9,4],[8,6]],[[1,1],1]]]
[[[2,1],0],8]
[1,[[6,[1,4]],[[0,0],[1,9]]]]
[[[1,[7,9]],2],8]
[[[[0,9],2],[[8,4],9]],[0,[[7,7],[4,8]]]]
[[1,[2,[1,8]]],[[[3,6],[2,1]],[3,[5,0]]]]
[[3,3],[3,5]]
[[[[9,3],[4,3]],[5,[8,1]]],[[6,[5,0]],9]]
[0,[[9,[3,5]],3]]
[[[9,1],0],[[[5,9],[8,0]],[7,[4,8]]]]
[[[[7,7],8],3],[[[6,6],[6,5]],[6,4]]]
[[[[3,7],1],[9,[4,2]]],[[9,[2,5]],[[9,0],5]]]
[5,[[0,2],6]]
[[[[2,7],[5,3]],[1,8]],2]
[[[8,[7,7]],[9,[0,0]]],4]
[[[4,[1,4]],0],[[[8,7],8],[[4,1],7]]]
[[[[0,6],0],[[3,2],[9,8]]],[[9,[4,5]],[[7,7],[0,8]]]]
[[[[6,3],3],[[1,5],7]],[[0,1],[7,7]]]
[[[[2,0],2],[3,[3,5]]],[[[0,8],[8,2]],[[0,6],5]]]
[[[6,[5,3]],[[5,5],9]],[[5,9],[[8,7],[3,7]]]]
[[[[1,7],[3,4]],[9,2]],1]
[[[[8,2],6],1],[[5,[2,7]],[3,9]]]
[5,[5,7]]
[[[[9,8],[3,4]],[[2,5],[5,6]]],[[[2,7],7],[9,[8,7]]]]
[[[1,4],[[6,1],[1,3]]],[1,[7,[1,7]]]]
[[[[1,4],8],[[5,1],8]],[[[1,3],[6,9]],[6,[3,3]]]]
[[[[4,0],[0,7]],[4,5]],[4,2]]
[3,8]
[7,[[[7,6],5],[[6,6],5]]]
[[[5,[0,5]],[4,4]],[3,[[4,2],[7,0]]]]
[[[[7,9],8],[9,6]],[5,0]]
[[[[3,0],[5,2]],1],[[[6,9],[5,3]],[[2,5],[6,3]]]]
[7,[[[7,7],[4,5]],[9,2]]]
[[7,[[4,2],[9,3]]],[7,[6,1]]]
[7,9]
[[[8,[8,1]],[[7,3],1]],[[9,8],[2,[8,3]]]]
[[[9,3],3],3]
[[[8,[5,7]],[[2,1],[1,3]]],[[[3,5],2],0]]
[[[8,8],0],[[1,4],[[8,6],9]]]
[[9,[3,[3,0]]],[1,7]]
[1,[[[8,8],1],[2,[0,5]]]]
[[0,[1,5]],[9,[0,[9,0]]]]
[1,[[[1,1],[8,3]],[1,8]]]
[[5,[[7,7],[3,3]]],[[[6,6],[7,8]],[1,[0,0]]]]
[[[[6,7],1],[0,2]],[[[4,2],[7,6]],[[8,4],[4,9]]]]
[[6,[[3,3],[9,0]]],[1,[[4,5],4]]]
[[[[3,4],7],[9,0]],[[[4,5],1],[[5,1],[9,3]]]]";
        public static void Main()
        {
            //testMagnitude();
            //part1(sample2);
            //part1(sample4);
            //part1(sample5);
            part1(sample3);
            part1(sample);
            part1(input);
            part2(sample);
            part2(input);
        }

        private static void testMagnitude()
        {
            var d = new Dictionary<string, long>();
            d.Add("[[1,2],[[3,4],5]]", 143);
            d.Add("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384);
            d.Add("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445);
            d.Add("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791);
            d.Add("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137);
            d.Add("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488);
            foreach (var kvp in d)
            {
                var s = Read(kvp.Key);
                Console.WriteLine($"Magnitude is {s.Magnitude()} and should be {kvp.Value}");
            }
        }

        public static void part2(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long count = 0;
            int m = inputs.Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    count = Math.Max(count, Math.Max(Compute(inputs[i], inputs[j]), Compute(inputs[j], inputs[i])));

                }
            }

            Console.WriteLine($"2nd star is {count}");
        }
        public static long Compute(string i1, string i2)
        {
            var s1 = Read(i1);
            var s2 = Read(i2);
            var head = new SnailFish() { left = s1, right = s2 };
            var start = new SnailFish() { isNumber = true, value = 0 };
            var last = start;
            var end = FillPreviousNext(head, last);
            end.next = new SnailFish() { isNumber = true, value = 0, previous = end };
            bool processed = true;
            while (processed)
            {
                processed = Explode(head, 0) || Split(head);
            }
            //Console.WriteLine(head);
            return head.Magnitude();
        }

        public static void part1(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long count = 0;
            int m = inputs.Length;
            var head = Read(inputs[0]);
            for (int i = 1; i < m; i++)
            {
                var current = Read(inputs[i]);
                head = new SnailFish() { left = head, right = current};
                var start = new SnailFish() { isNumber = true, value = 0 };
                var last = start;
                var end = FillPreviousNext(head, last);
                end.next = new SnailFish() { isNumber = true, value = 0, previous = end };
                bool processed = true;
                while (processed)
                {
                    processed = Explode(head, 0) || Split(head);
                }
                //Console.WriteLine(head);
            }

            count = head.Magnitude();
            Console.WriteLine($"1st star is {count}");

        }
        public static SnailFish FillPreviousNext(SnailFish current, SnailFish previous)
        {
            if (current.isNumber)
            {
                current.previous = previous;
                previous.next = current;
                return current;
            }
            previous = FillPreviousNext(current.left, previous);
            previous = FillPreviousNext(current.right, previous);
            return previous;
        }

        public static bool Explode(SnailFish node, int level)
        {
            if (node.isNumber) return false;
            if (node.left.isNumber && node.right.isNumber) 
            {
                if (level >= 4)
                {
                    node.left.previous.value += node.left.value;
                    node.right.next.value += node.right.value;
                    node.isNumber = true;
                    node.value = 0;
                    node.left.previous.next = node;
                    node.right.next.previous = node;
                    node.previous = node.left.previous;
                    node.next = node.right.next;
                    node.left = null;
                    node.right = null;
                    return true;
                }
            }
            return Explode(node.left, level + 1) || Explode(node.right, level + 1);
        }
        public static bool Split(SnailFish node)
        {
            if (node.isNumber)
            {
                if (node.value >= 10) // split !!
                {
                    node.isNumber = false;
                    node.left = new SnailFish() { isNumber = true, value = node.value / 2, parent = node };
                    node.right = new SnailFish() { isNumber = true, value = node.value - node.left.value, parent = node };
                    node.previous.next = node.left;
                    node.left.previous = node.previous;
                    node.next.previous = node.right;
                    node.right.next = node.next;
                    node.left.next = node.right;
                    node.right.previous = node.left;
                    node.value = 0;
                    return true;
                }
                return false;
            }
            return Split(node.left) || Split(node.right);
        }

        public static SnailFish Read(string input)
        {
            int index = 0;
            return Read(ref index, input);
        }
        public static SnailFish Read(ref int index, string input)
        {
            var c = input[index];
            if (char.IsDigit(c))
            {
                index++;
                return new SnailFish() { value = c - '0', isNumber = true };
            }
            var res = new SnailFish(); // Not a number
            if (c == '[')
            {
                index++;
                res.left = Read(ref index, input);
            }
            c = input[index];
            if (c != ',') throw new Exception("que s'est-il passé là ? pourquoi je n'ai pas une ,...");
            index++;
            res.right = Read(ref index, input);
            c = input[index];
            if (c != ']') throw new Exception("mais ici, à droite, il faudrait avancer...");
            index++;
            res.right.parent = res;
            res.left.parent = res;
            return res;
        }
    }

    public class SnailFish
    {
        public bool isNumber = false;
        public int value;
        public SnailFish left, right, parent, previous, next;
        public override string ToString()
        {
            if (isNumber)
                return value.ToString();
            return $"[{left},{right}]";
        }
        public long Magnitude()
        {
            if (isNumber)
                return value;
            return 3*left.Magnitude() + 2* right.Magnitude();
        }
    }
}
