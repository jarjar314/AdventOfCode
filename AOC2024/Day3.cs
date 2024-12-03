using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AOC2024
{
    internal class Day3
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                var program = new List<string>();
                while (!sr.EndOfStream)
                {
                    program.Add(sr.ReadLine());
                }
                part1(program);
                part2(program);
            }
        }

        static void part2(List<string> lines)
        {
            string regex = @"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)|do\(\)|don\'t\(\)";
            var regexp = new Regex(regex);
            long sum = 0;
            bool mulEnabled = true;
            foreach (var line in lines)
            {
                var match = regexp.Matches(line);
                foreach (Match m in match)
                {
                    if (m.Value == @"do()")
                    {
                        mulEnabled = true;
                        continue;
                    }
                    if (m.Value == @"don't()")
                    {
                        mulEnabled = false;
                        continue;
                    }
                    if (mulEnabled)
                    {
                        var p = m.Value.Split([',', '(', ')']);
                        sum += int.Parse(m.Groups["first"].Value) * int.Parse(m.Groups["second"].Value);
                    }
                }
            }
            Console.WriteLine(sum);
        }
        static void part1(List<string> lines)
        {
            string regex = @"mul\((?<first>\d{1,3}),(?<second>\d{1,3})\)";
            var regexp = new Regex(regex);
            long sum = lines.Sum(line => regexp.Matches(line).Sum(m => int.Parse(m.Groups["first"].Value) * int.Parse(m.Groups["second"].Value)));
            Console.WriteLine(sum);
        }
    }
}
