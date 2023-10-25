using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2021
{
    public class Day14
    {

        public static void Main()
        {
            var input = @"BVBNBVPOKVFHBVCSHCFO

SO -> V
PB -> P
HV -> N
VF -> O
KS -> F
BB -> C
SH -> H
SB -> C
FS -> F
PV -> F
BC -> K
SF -> S
NO -> O
SK -> C
PO -> N
VK -> F
FC -> C
VV -> S
SV -> S
HH -> K
FH -> K
HN -> O
NP -> F
PK -> N
VO -> K
NC -> C
KP -> B
CS -> C
KO -> F
BK -> N
OO -> N
CF -> H
KN -> C
BV -> S
OK -> O
CN -> F
OP -> O
VP -> N
OC -> P
NH -> C
VN -> S
VC -> B
NF -> H
FO -> H
CC -> B
KB -> N
CP -> N
HK -> N
FB -> H
BH -> V
BN -> N
KC -> F
CV -> K
SP -> V
VS -> P
KF -> S
CH -> V
NS -> N
HS -> O
CK -> K
NB -> O
OF -> K
VB -> N
PS -> B
KH -> P
BS -> C
VH -> C
KK -> F
FN -> F
BP -> B
HF -> O
HB -> V
OV -> H
NV -> N
HO -> S
OS -> H
SS -> K
BO -> V
OB -> K
HP -> P
CO -> B
PP -> K
HC -> N
BF -> S
NK -> S
ON -> P
PH -> C
FV -> H
CB -> H
PC -> K
FF -> P
PN -> P
NN -> O
PF -> F
SC -> C
FK -> K
SN -> K
KV -> P
FP -> B
OH -> F";

            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var n = inputs.Length;
            var polymer = inputs[0];
            var mapping = new Dictionary<(char, char), char>();
            for (int i = 1; i < n; i++)
            {
                var l = inputs[i];
                mapping[(l[0], l[1])] = l[^1];
            }
            int steps = 10;
            for (int i = 0; i < 10; i++)
            {
                polymer = Insert();
            }

            Console.WriteLine(string.Join(" ", polymer.GroupBy(c => c).OrderBy(gr => gr.Count()).Select(x => x.Count())));

            long[] counting = new long[26];
            polymer = inputs[0];
            var cache = new Dictionary<(char, char, int), long[]>();
            for (int i = 1; i < polymer.Length; i++)
            {
                var elem = Compute(polymer[i - 1], polymer[i], 10);
                for (int j = 0; j < 26; j++)
                    counting[j] += elem[j];
            }
            counting[polymer[^1] - 'A']++;
            Console.WriteLine(string.Join(" ", counting.OrderBy(c => c)));
            Console.WriteLine(counting.Max() - counting.Where(c => c > 0).Min());

            counting = new long[26];
            polymer = inputs[0];
            for (int i = 1; i < polymer.Length; i++)
            {
                var elem = Compute(polymer[i - 1], polymer[i], 40);
                for (int j = 0; j < 26; j++)
                    counting[j] += elem[j];
            }
            counting[polymer[^1] - 'A']++;
            Console.WriteLine(string.Join(" ", counting.OrderBy(c => c)));
            Console.WriteLine(counting.Max() - counting.Where(c => c > 0).Min());


            long[] Compute(char a, char b, int step)
            {
                long[] res;
                if (cache.TryGetValue((a, b, step), out res))
                {
                    return res;
                }
                res = new long[26];
                if (step == 0)
                {
                    res[a - 'A']++;
                    cache[(a, b, step)] = res;
                    return res;
                }
                var left = Compute(a, mapping[(a, b)], step - 1);
                var right = Compute(mapping[(a, b)], b, step - 1);
                for (int j = 0; j < 26; j++)
                {
                    res[j] = left[j] + right[j];
                }
                cache[(a, b, step)] = res;
                return res;
            }

            string Insert()
            {
                var sb = new StringBuilder();
                sb.Append(polymer[0]);
                int l = polymer.Length;
                for (int i = 1; i < l; i++)
                {
                    sb.Append(mapping[(polymer[i - 1], polymer[i])]);
                    sb.Append(polymer[i]);
                }
                return sb.ToString();
            }
        }
    }
}
