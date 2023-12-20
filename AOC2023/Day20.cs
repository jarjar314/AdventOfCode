using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace AOC2023
{
    public class Day20
    {

        public static void Main()
        {
            var input = @"%db -> cq
%rj -> gp, nd
%ff -> bk
%rc -> gp
%bk -> tv
%xz -> tf, bn
%gs -> bn
%ps -> rs, gp
%jr -> gp, cg
&pm -> vf
%pn -> pp, rt
%nv -> jr
%rs -> nv
%kz -> mj
%nd -> rc, gp
%nm -> rt, db
%dg -> rt, xl
%vg -> gn
%hc -> vr
%ft -> lf, bn
%mj -> hc, cz
%vb -> ft
%qd -> cz, sz
%pp -> rt
%cq -> rt, vg
%sr -> vb
%lf -> vx, bn
%lh -> pn, rt
%ls -> sl, cz
%tv -> gp, rj
%tf -> sr, bn
&mk -> vf
%bs -> rt, lh
%vx -> bn, gs
&bn -> fs, bv, vb, mk, sr, bz, cf
%rr -> ls
%bv -> xz
%hp -> bs, rt
&pk -> vf
%cg -> rq
%gn -> rt, dg
&cz -> hc, kz, rr, hf, sh
%sl -> cz, kz
broadcaster -> sh, nm, ps, fs
%cf -> bv
&vf -> rx
&rt -> pk, xl, nm, vg, db
%xl -> hp
%sh -> rr, cz
%bz -> cf
%fz -> dn, cz
&gp -> rs, nv, pm, cg, ff, bk, ps
%fs -> bz, bn
&hf -> vf
%vr -> cz, qd
%rq -> gp, ff
%sz -> cz, fz
%dn -> cz";
            var sample = @"broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a";
            var sample2 = @"broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output";

            part1(sample, 1000);
            part1(sample2, 1000);
            part1(input, 1000);
            part2(input);
        }
        private static Dictionary<string, Module> modules = new Dictionary<string, Module>();
        private static long low, high;
        private static void part1(string input, int pushes)
        {
            modules.Clear();
            low = 0;
            high = 0;
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long count = 0;
            int m = inputs.Length;
            for (int i = 0; i < m; i++)
            {
                var line = inputs[i].Split(new char[] { '-', ',', ' ', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var name = char.IsLetter(line[0][0]) ? line[0] : line[0][1..];
                var mod = GetModule(name);
                mod.flipflop = line[0][0] == '%';
                mod.conjunction = line[0][0] == '&';
                foreach (var output in line.Skip(1))
                {
                    mod.targets.Add(output);
                    GetModule(output).entries.Add(name, false);
                }
            }
            for (int i = 0; i < pushes; i++)
            {
                PushButton();
            }
            count = high * low;
            Console.WriteLine($"1st star is {count}");
        }
        private static void PushButton()
        {
            low++;
            var q = new Queue<(string name, string parent, bool high)>();
            q.Enqueue(("broadcaster", "button", false)); // send a low on broadcaster
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                var module = GetModule(p.name);
                var signal = p.high;
                if (module.flipflop)
                {
                    if (signal) continue;
                    module.on = !module.on;
                    if (module.on) high += module.targets.Count;
                    else low += module.targets.Count;
                    module.lastSignal = module.on;
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, module.on));
                    }
                    continue;
                }
                else if (module.conjunction)
                {
                    module.entries[p.parent] = signal;
                    signal = !module.entries.Values.All(c => c); // if all high, then low
                    if (signal) high += module.targets.Count;
                    else low += module.targets.Count;
                    module.lastSignal = signal;
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, signal));
                    }
                }
                else
                {
                    if (signal) high += module.targets.Count;
                    else low += module.targets.Count;
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, signal));
                    }
                }
            }
        }

        private static Module GetModule(string name)
        {
            return modules.TryGetValue(name, out var val) ? val : modules[name] = new Module() { name = name };
        }
        private static long cycle;
        private static void part2(string input)
        {
            modules.Clear();
            low = 0;
            high = 0;
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long count = 0;
            int m = inputs.Length;
            for (int i = 0; i < m; i++)
            {
                var line = inputs[i].Split(new char[] { '-', ',', ' ', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var name = char.IsLetter(line[0][0]) ? line[0] : line[0][1..];
                var mod = GetModule(name);
                mod.flipflop = line[0][0] == '%';
                mod.conjunction = line[0][0] == '&';
                foreach (var output in line.Skip(1))
                {
                    mod.targets.Add(output);
                    GetModule(output).entries.Add(name, false);
                }
            }

            string target = "vf"; // because rx is after vf who is a multi-conjunction
            cycle = 0;
            var entries = GetModule(target).entries.ToDictionary(c => c.Key, c => 0L);

            while (true)
            {
                cycle++;
                PushButton2(entries);
                if (entries.All(c => c.Value != 0)) break;
            }
            count = 1;
            foreach (var kvp in entries)
            {
                var g = Gcd(count, kvp.Value);
                count = count / g * kvp.Value;
            }

            Console.WriteLine($"2nd star is {count}");
        }
        public static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long c = a % b;
                a = b;
                b = c;
            }
            return a;
        }

        private static void PushButton2(Dictionary<string, long> sources)
        {
            low++;
            var q = new Queue<(string name, string parent, bool high)>();
            q.Enqueue(("broadcaster", "button", false)); // send a low on broadcaster
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                var module = GetModule(p.name);
                var signal = p.high;
                if (module.flipflop)
                {
                    if (signal) continue;
                    module.on = !module.on;
                    if (module.on) high += module.targets.Count;
                    else low += module.targets.Count;
                    module.lastSignal = module.on;
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, module.on));
                    }
                    continue;
                }
                else if (module.conjunction)
                {
                    module.entries[p.parent] = signal;
                    signal = !module.entries.Values.All(c => c); // if all high, then low
                    if (signal) high += module.targets.Count;
                    else low += module.targets.Count;
                    module.lastSignal = signal;
                    if (module.lastSignal && sources.ContainsKey(module.name))
                    {
                        if (sources[module.name] == 0)
                            sources[module.name] = cycle;
                        Console.WriteLine($"{cycle}: {module.name} is High");
                    }
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, signal));
                    }
                }
                else
                {
                    if (signal) high += module.targets.Count;
                    else low += module.targets.Count;
                    foreach (var next in module.targets)
                    {
                        q.Enqueue((next, module.name, signal));
                    }
                }
            }
        }

    }

    public class Module
    {
        public bool lastSignal = false;
        public bool flipflop;
        public bool on;
        public bool conjunction;
        public string name;
        public List<string> targets = new List<string>();
        public Dictionary<string, bool> entries = new();

    }
}