using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AOC2018
{
    class Day20
    {
        static void Main()
        {
            string className = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
            var lines = new List<string>();
            using (var sr = new StreamReader($"Resources/{className}.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine()!);
                }
            }
            var stopwatch = Stopwatch.StartNew();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        private static void part2(List<string> lines)
        {

        }
        private static int index = 0;
        private static int ComputeDoors(string l)
        {
            int maxDoors = 0;
            int r = 0, c = 0;
            index = 0;
            HashSet<(int r, int c)> doors = new();
            HashSet<(int r, int c)> rooms = new();
            index++;
            walk(0, 0);

            var q = new Queue<(int r, int c, int step)>();
            var visited = new Dictionary<(int r, int c), int>(); // just change an hashset here to a dictionary to do part2 from part1.
            int[] moves = new int[] { 0, 1, 0, -1, 0 };
            q.Enqueue((0, 0, 0));
            while(q.Count > 0)
            {
                var p = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    if (!doors.Contains((p.r + moves[i], p.c + moves[i + 1]))) continue; // pas de porte
                    if (!visited.TryAdd((p.r + 2*moves[i], p.c + 2*moves[i + 1]), p.step + 1)) continue; // déjà été là !
                    maxDoors = Math.Max(maxDoors, p.step + 1);
                    q.Enqueue((p.r + 2 * moves[i], p.c + 2 * moves[i+1], p.step + 1));
                }
            }
            Console.WriteLine($"{l} => furthest = {maxDoors}, over 1000 doors = {visited.Count(kvp => kvp.Value >= 1000)}");
            return maxDoors;

            void walk(int r, int c)
            {
                while (true)
                {
                    switch (l[index])
                    {
                        case '$': return;
                        case 'E':doors.Add((r, ++c));
                            rooms.Add((r, ++c)); index++; break;
                        case 'W': doors.Add((r, --c)); rooms.Add((r,--c));index++;break;
                        case 'N':doors.Add((--r, c));rooms.Add((--r, c));index++;break;
                        case 'S':doors.Add((++r, c));rooms.Add((++r, c));index++;break;
                        case '|':index++;return;
                        case '(':
                            index++;
                            while (l[index] != ')')
                            {
                                walk(r, c);
                            }
                            index++;
                            break;
                        case ')':return;
                    }
                }
            }


        }
        private static void part1(List<string> lines)
        {
            foreach (var l in lines)
            {
                Console.WriteLine($"part1: {l} => {ComputeDoors(l)}");
            }
        }

    }
}
