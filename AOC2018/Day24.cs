using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
namespace AOC2018
{
    public enum BacteryType
    {
        ImmuneSystem,
        Infection
    }
    public class Army : ICloneable
    {
        public static Regex regex = new(@"^(?<units>\d+) units each with (?<hit>\d+) hit points(?<immunity>.*) with an attack that does (?<damage>\d+) (?<attackType>\w+) damage at initiative (?<initiative>\d+)$");
        public BacteryType bacteryType;
        public HashSet<string> immunities = new HashSet<string>();
        public HashSet<string> weaknesses = new HashSet<string>();
        public string attackType, input;
        public int initiative, hitPoints, units, damage;
        public string IW()
        {
            if (immunities.Count == 0 && weaknesses.Count == 0) return string.Empty;
            if (immunities.Count > 0 && weaknesses.Count > 0) return $"(immune to {string.Join(", ", immunities)}; weak to {string.Join(", ", weaknesses)}) ";
            if (immunities.Count > 0) return $"(immune to {string.Join(", ", immunities)}) ";
            return $"(weak to {string.Join(", ", weaknesses)}) ";
        }
        public override string ToString()
        {
            return $"{units} units each with {hitPoints} hit points {IW()}with an attack that does {damage} {attackType} damage at initiative {initiative}";
        }
        public Army(string input, BacteryType bacteryType)
        {
            this.input = input;
            var match = regex.Match(input);
            if (match.Success)
            {
                attackType = match.Groups["attackType"].Value;
                initiative = int.Parse(match.Groups["initiative"].Value);
                hitPoints = int.Parse(match.Groups["hit"].Value);
                units = int.Parse(match.Groups["units"].Value);
                damage = int.Parse(match.Groups["damage"].Value);
                var immunity = match.Groups["immunity"].Value;
                if (!string.IsNullOrEmpty(immunity))
                {
                    var split = immunity.Replace(" to ", ",").Replace("(", "").Replace(")", "")
                        .Replace("; ", ",").Replace(" ", "").Split(',').ToArray();
                    var current = immunities;
                    foreach (var n in split)
                    {
                        if (n == "immune") current = immunities;
                        else if (n == "weak") current = weaknesses;
                        else current.Add(n);
                    }
                }
            }

            this.bacteryType = bacteryType;
        }

        public int Attack(Army defendant)
        {
            if (defendant.immunities.Contains(attackType)) return 0;
            int attack = units * damage;
            if (defendant.weaknesses.Contains(attackType)) return 2 * attack;
            return attack;
        }

        public void Defend(int damages)
        {
            int killed = damages / hitPoints;
            units = Math.Max(0, units - killed);
        }

        internal int EffectivePower()
        {
            return units * damage;
        }

        public object Clone()
        {
            return new Army(input, this.bacteryType);
        }
    }

    public class Day24
    {
        private static int Abs(int a) => Math.Abs(a);
        private static bool Simulate(List<Army> immunes, List<Army> infections, int boost)
        {
            var immune = immunes.Select(i => (Army)i.Clone()).ToList();
            var infection = infections.Select(i => (Army)i.Clone()).ToList();
            for (int i = 0; i < immune.Count; i++)
            {
                immune[i].damage += boost;
            }
            Fight(immune, infection);
            return infection.Sum(arm => arm.units) == 0;
        }

        private static void part2(List<Army> immunes, List<Army> infections)
        {
            int boost = 1;
            while (!Simulate(immunes, infections, boost))
            {
                boost++;
            }
            var immune = immunes.Select(i => (Army)i.Clone()).ToList();
            var infection = infections.Select(i => (Army)i.Clone()).ToList();
            for (int i = 0; i < immune.Count; i++)
            {
                immune[i].damage += boost;
            }
            Fight(immune, infection);
            Console.WriteLine(immune.Sum(arm => arm.units));

        }
        private static void part1(List<Army> immunes, List<Army> infections)
        {
            var immune = immunes.Select(i => (Army)i.Clone()).ToList();
            var infection = infections.Select(i => (Army)i.Clone()).ToList();
            Fight(immune, infection);
            Console.WriteLine(immune.Sum(arm => arm.units) + infection.Sum(arm => arm.units));
        }

        private static void Fight(List<Army> immune, List<Army> infection)
        {
            int last = int.MaxValue;
            while (immune.Sum(arm => arm.units) > 0 && infection.Sum(arm => arm.units) > 0)
            {
                var targetting = new SortedSet<(int effectivePower, int initiative, int damagesDone, int defenseEffectivePower, int defenseInitiative, Army att, Army def)>();
                foreach (var im in immune)
                {
                    if (im.units == 0) continue;
                    foreach (var inf in infection)
                    {
                        if (inf.units == 0) continue;
                        targetting.Add((-1 * im.EffectivePower(), -1 * im.initiative, -1 * im.Attack(inf), -1 * inf.EffectivePower(), -1 * inf.initiative, im, inf));
                        targetting.Add((-1 * inf.EffectivePower(), -1 * inf.initiative, -1 * inf.Attack(im), -1 * im.EffectivePower(), -1 * im.initiative, inf, im));
                    }
                }
                var attaquant = new HashSet<Army>();
                var defenseur = new HashSet<Army>();
                var attacks = new SortedSet<(int initiative, Army att, Army def)>();
                foreach (var target in targetting)
                {
                    if (target.damagesDone == 0) continue;
                    if (attaquant.Contains(target.att)) continue;
                    if (defenseur.Contains(target.def)) continue;
                    attaquant.Add(target.att);
                    defenseur.Add(target.def);
                    attacks.Add((-1 * target.att.initiative, target.att, target.def));
                }
                // ATTACKING PHASE
                foreach (var strike in attacks)
                {
                    var damages = strike.att.Attack(strike.def);
                    strike.def.Defend(damages);
                }
                var remaining = immune.Sum(arm => arm.units) + infection.Sum(arm => arm.units);
                if (remaining == last) break; // stalemate
                last = remaining;
            }
        }

        public static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new HashSet<(int x, int y, int z, int t)>();
            var immune = new List<Army>();
            var infection = new List<Army>();
            List<Army> current = null;
            BacteryType bt = BacteryType.ImmuneSystem;
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var l = sr.ReadLine()!;
                    if (l == "Immune System:")
                    {
                        bt = BacteryType.ImmuneSystem;
                        current = immune;
                    }
                    else if (l == "Infection:")
                    {
                        bt = BacteryType.Infection;
                        current = infection;
                    }
                    else if (!string.IsNullOrEmpty(l))
                        current!.Add(new Army(l, bt));
                }
            }
            Console.WriteLine("Immune System:");
            Console.WriteLine(string.Join("\n", immune));
            Console.WriteLine("Infection:");
            Console.WriteLine(string.Join("\n", infection));
            var stopwatch = Stopwatch.StartNew();
            part1(immune, infection);
            part2(immune, infection);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }
    }
}
