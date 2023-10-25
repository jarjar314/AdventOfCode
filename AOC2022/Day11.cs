using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace AOC2022
{
    public class Day11
    {

        public static void Main()
        {
            #region change input

            /*  input = @"addx 15
  addx -11
  addx 6
  addx -3
  addx 5
  addx -1
  addx -8
  addx 13
  addx 4
  noop
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx 5
  addx -1
  addx -35
  addx 1
  addx 24
  addx -19
  addx 1
  addx 16
  addx -11
  noop
  noop
  addx 21
  addx -15
  noop
  noop
  addx -3
  addx 9
  addx 1
  addx -3
  addx 8
  addx 1
  addx 5
  noop
  noop
  noop
  noop
  noop
  addx -36
  noop
  addx 1
  addx 7
  noop
  noop
  noop
  addx 2
  addx 6
  noop
  noop
  noop
  noop
  noop
  addx 1
  noop
  noop
  addx 7
  addx 1
  noop
  addx -13
  addx 13
  addx 7
  noop
  addx 1
  addx -33
  noop
  noop
  noop
  addx 2
  noop
  noop
  noop
  addx 8
  noop
  addx -1
  addx 2
  addx 1
  noop
  addx 17
  addx -9
  addx 1
  addx 1
  addx -3
  addx 11
  noop
  noop
  addx 1
  noop
  addx 1
  noop
  noop
  addx -13
  addx -19
  addx 1
  addx 3
  addx 26
  addx -30
  addx 12
  addx -1
  addx 3
  addx 1
  noop
  noop
  noop
  addx -9
  addx 18
  addx 1
  addx 2
  noop
  noop
  addx 9
  noop
  noop
  noop
  addx -1
  addx 2
  addx -37
  addx 1
  addx 3
  noop
  addx 15
  addx -21
  addx 22
  addx -6
  addx 1
  noop
  addx 2
  addx 1
  noop
  addx -10
  noop
  noop
  addx 20
  addx 1
  addx 2
  addx 2
  addx -6
  addx -11
  noop
  noop
  noop";/* */
            #endregion

            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = inputs.Length;
            Process(3, 20);
            Process(1, 10000);
        }

        private static void Process(int relief, int rounds)
        {
            List<Monkey> monkeys = Init(relief);

            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < monkeys.Count; j++)
                {
                    var item = monkeys[j].Analyze();
                    foreach (var it in item)
                    {
                        monkeys[it.monkey].Add(it.item);
                    }
                }
            }
            var l = monkeys.Select(m => m.AnalysisCount).OrderByDescending(c => c).Take(2).ToArray();
            Console.WriteLine(l[0] * l[1]);
            for (int i = 0; i < monkeys.Count; i++)
            {
                Monkey m = monkeys[i];
                Console.WriteLine($"Monkey {i} inspected items {m.AnalysisCount} times.");
            }
        }

        private static List<Monkey> Init(int relief)
        {
            var monkeys = new List<Monkey>(8);
            monkeys.Add(new Monkey(x => x * 17, new[] { 85, 79, 63, 72 }) { MonkeyFalse = 6, MonkeyTrue = 2, Test = 2, Relief = relief });
            monkeys.Add(new Monkey(x => x * x, new[] { 53, 94, 65, 81, 93, 73, 57, 92 }) { MonkeyFalse = 2, MonkeyTrue = 0, Test = 7, Relief = relief });
            monkeys.Add(new Monkey(x => x + 7, new[] { 62, 63 }) { MonkeyFalse = 6, MonkeyTrue = 7, Test = 13, Relief = relief });
            monkeys.Add(new Monkey(x => x + 4, new[] { 57, 92, 56 }) { MonkeyFalse = 5, MonkeyTrue = 4, Test = 5, Relief = relief });
            monkeys.Add(new Monkey(x => x + 5, new[] { 67 }) { MonkeyFalse = 5, MonkeyTrue = 1, Test = 3, Relief = relief });
            monkeys.Add(new Monkey(x => x + 6, new[] { 85, 56, 66, 72, 57, 99 }) { MonkeyFalse = 0, MonkeyTrue = 1, Test = 19, Relief = relief });
            monkeys.Add(new Monkey(x => x * 13, new[] { 86, 65, 98, 97, 69 }) { MonkeyFalse = 7, MonkeyTrue = 3, Test = 11, Relief = relief });
            monkeys.Add(new Monkey(x => x + 2, new[] { 87, 68, 92, 66, 91, 50, 68 }) { MonkeyFalse = 3, MonkeyTrue = 4, Test = 17, Relief = relief });
            return monkeys;
        }

        static string input = @"Monkey 0:
  Starting items: 85, 79, 63, 72
  Operation: new = old * 17
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 6

Monkey 1:
  Starting items: 53, 94, 65, 81, 93, 73, 57, 92
  Operation: new = old * old
  Test: divisible by 7
    If true: throw to monkey 0
    If false: throw to monkey 2

Monkey 2:
  Starting items: 62, 63
  Operation: new = old + 7
  Test: divisible by 13
    If true: throw to monkey 7
    If false: throw to monkey 6

Monkey 3:
  Starting items: 57, 92, 56
  Operation: new = old + 4
  Test: divisible by 5
    If true: throw to monkey 4
    If false: throw to monkey 5

Monkey 4:
  Starting items: 67
  Operation: new = old + 5
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 5

Monkey 5:
  Starting items: 85, 56, 66, 72, 57, 99
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 1
    If false: throw to monkey 0

Monkey 6:
  Starting items: 86, 65, 98, 97, 69
  Operation: new = old * 13
  Test: divisible by 11
    If true: throw to monkey 3
    If false: throw to monkey 7

Monkey 7:
  Starting items: 87, 68, 92, 66, 91, 50, 68
  Operation: new = old + 2
  Test: divisible by 17
    If true: throw to monkey 4
    If false: throw to monkey 3";

    }

    public class Monkey
    {
        public long modulo = 2L * 3 * 5 * 7 * 11 * 13 * 17 * 19;
        public long Relief { get; set; }
        public Func<long, long> Operation;
        public Queue<long> Items;
        public int Test { get; set; }
        public int MonkeyTrue { get; set; }
        public int MonkeyFalse { get; set; }
        public void Add(long item)
        {
            Items.Enqueue(item);
        }
        public Monkey(Func<long, long> operation, int[] items)
        {
            Operation = operation;
            Items = new Queue<long>();
            foreach (var it in items) Items.Enqueue(it);
        }
        public long AnalysisCount { get; set; }
        public IList<(long item, int monkey)> Analyze()
        {
            var res = new List<(long item, int monkey)>();
            while (Items.Any())
            {
                AnalysisCount++;
                var p = Items.Dequeue();
                p = Operation(p) / Relief % modulo;
                if (p % Test == 0)
                    res.Add((p, MonkeyTrue));
                else
                    res.Add((p, MonkeyFalse));
            }
            return res;
        }
    }



}
