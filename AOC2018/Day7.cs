using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2018
{
    public class Day7
    {

        public static void Main()
        {
            var input = @"Step B must be finished before step X can begin.
Step H must be finished before step P can begin.
Step Y must be finished before step J can begin.
Step Z must be finished before step I can begin.
Step T must be finished before step U can begin.
Step R must be finished before step C can begin.
Step S must be finished before step J can begin.
Step W must be finished before step J can begin.
Step C must be finished before step L can begin.
Step L must be finished before step F can begin.
Step E must be finished before step G can begin.
Step A must be finished before step G can begin.
Step V must be finished before step X can begin.
Step U must be finished before step O can begin.
Step P must be finished before step F can begin.
Step O must be finished before step I can begin.
Step I must be finished before step F can begin.
Step K must be finished before step F can begin.
Step J must be finished before step F can begin.
Step G must be finished before step X can begin.
Step M must be finished before step X can begin.
Step F must be finished before step Q can begin.
Step Q must be finished before step N can begin.
Step D must be finished before step N can begin.
Step X must be finished before step N can begin.
Step I must be finished before step Q can begin.
Step U must be finished before step I can begin.
Step D must be finished before step X can begin.
Step B must be finished before step W can begin.
Step L must be finished before step N can begin.
Step U must be finished before step X can begin.
Step U must be finished before step J can begin.
Step C must be finished before step V can begin.
Step G must be finished before step N can begin.
Step S must be finished before step K can begin.
Step Q must be finished before step D can begin.
Step J must be finished before step X can begin.
Step V must be finished before step K can begin.
Step Z must be finished before step A can begin.
Step L must be finished before step M can begin.
Step H must be finished before step D can begin.
Step V must be finished before step Q can begin.
Step L must be finished before step V can begin.
Step S must be finished before step D can begin.
Step C must be finished before step Q can begin.
Step S must be finished before step L can begin.
Step E must be finished before step V can begin.
Step E must be finished before step P can begin.
Step C must be finished before step I can begin.
Step O must be finished before step K can begin.
Step H must be finished before step V can begin.
Step M must be finished before step F can begin.
Step K must be finished before step N can begin.
Step C must be finished before step X can begin.
Step G must be finished before step D can begin.
Step E must be finished before step U can begin.
Step R must be finished before step L can begin.
Step K must be finished before step G can begin.
Step W must be finished before step C can begin.
Step B must be finished before step L can begin.
Step L must be finished before step J can begin.
Step U must be finished before step D can begin.
Step I must be finished before step G can begin.
Step Q must be finished before step X can begin.
Step B must be finished before step M can begin.
Step T must be finished before step P can begin.
Step G must be finished before step Q can begin.
Step Y must be finished before step U can begin.
Step M must be finished before step D can begin.
Step P must be finished before step I can begin.
Step I must be finished before step K can begin.
Step O must be finished before step M can begin.
Step H must be finished before step Z can begin.
Step V must be finished before step M can begin.
Step P must be finished before step J can begin.
Step B must be finished before step U can begin.
Step E must be finished before step X can begin.
Step M must be finished before step Q can begin.
Step W must be finished before step L can begin.
Step O must be finished before step J can begin.
Step I must be finished before step X can begin.
Step J must be finished before step N can begin.
Step Y must be finished before step S can begin.
Step E must be finished before step D can begin.
Step M must be finished before step N can begin.
Step E must be finished before step O can begin.
Step I must be finished before step D can begin.
Step V must be finished before step N can begin.
Step R must be finished before step X can begin.
Step Z must be finished before step O can begin.
Step O must be finished before step X can begin.
Step I must be finished before step J can begin.
Step S must be finished before step E can begin.
Step E must be finished before step Q can begin.
Step J must be finished before step Q can begin.
Step H must be finished before step Y can begin.
Step T must be finished before step G can begin.
Step S must be finished before step A can begin.
Step P must be finished before step K can begin.
Step A must be finished before step D can begin.
Step B must be finished before step P can begin.";
            var allsteps = new HashSet<Step>();
            var aftersteps = new HashSet<Step>();
            foreach (var precedence in input.Split(new char[] { '\n' }))
            {
                var tokens = precedence.Split(' ').ToArray();
                var before = StepFactory.GetStep(tokens[1]);
                var after = StepFactory.GetStep(tokens[7]);
                before.After.Add(after);
                after.Before.Add(before);
                after.Ready++;
                allsteps.Add(before);
                allsteps.Add(after);
                aftersteps.Add(after);
            }
            allsteps.ExceptWith(aftersteps);
            var all = StepFactory.AllSteps();
            var sorted = new SortedSet<(string name, Step step)>();
            for (int i = 0; i < all.Count; i++)
            {
                var step = all[i];
                step.Validate();
                if (step.IsReady)
                {
                    sorted.Add((step.Name, step));
                }
            }
            var sb = new StringBuilder();
            while (sorted.Count > 0)
            {
                var step = sorted.First();
                sorted.Remove(step);
                sb.Append(step.name);
                for (int i = 0; i < step.step.After.Count; i++)
                {
                    var next = step.step.After[i];
                    next.Ready--;
                    next.Validate();
                    if (next.IsReady)
                        sorted.Add((next.Name, next));
                }
            }
            Console.WriteLine(sb.ToString());
            var sorted2 = new SortedSet<(int time, string name, Step step)>();
            for (int i = 0; i < all.Count; i++)
            {
                all[i].Reset();
                all[i].Validate();
                if (all[i].IsReady)
                    sorted2.Add((0, all[i].Name, all[i]));
            }
            // Handle 5 elves...
            var workers = new SortedSet<(int time, string name)>();
            workers.Add((0, "w1"));
            workers.Add((0, "w2"));
            workers.Add((0, "w3"));
            workers.Add((0, "w4"));
            workers.Add((0, "w5"));
            sb.Clear();
            while (sorted2.Count > 0)
            {
                var step = sorted2.First();
                sorted2.Remove(step);
                var worker = workers.First();
                workers.Remove(worker);
                int startTime = Math.Max(worker.time, step.time);
                var endTime = startTime + 60 + step.name[0] - 'A' + 1;
                workers.Add((endTime, worker.name));
                sb.Append(step.name);
                for (int i = 0; i < step.step.After.Count; i++)
                {
                    var next = step.step.After[i];
                    next.Ready--;
                    next.Validate();
                    if (next.IsReady)
                        sorted2.Add((endTime, next.Name, next));
                }

            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(workers.Select(c => c.time).Max());
        }
    }

    internal class StepFactory
    {
        static Dictionary<string, Step> steps = new Dictionary<string, Step>();
        public static Step GetStep(string step)
        {
            if (!steps.TryGetValue(step, out var s))
            {
                s = new Step() { Name = step };
                steps[step] = s;
            }
            return s;
        }
        public static List<Step> AllSteps()
        {
            return steps.Values.ToList();
        }
    }

    internal class Step
    {
        public void Reset()
        {
            IsReady = false;
            Ready = Before.Count;

        }
        public string Name { get; set; }
        public List<Step> Before = new List<Step>();
        public List<Step> After = new List<Step>();
        public int Ready { get; set; }
        public Step()
        {
            Reset();
        }
        public bool IsReady { get; set; }
        public void Validate()
        {
            IsReady = Ready == 0;
        }
    }
}
