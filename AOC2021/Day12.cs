using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2021
{
    public class Day12
    {

        public static void Main()
        {
            var input = @"lg-GW
pt-start
pt-uq
nx-lg
ve-GW
start-nx
GW-start
GW-nx
pt-SM
sx-GW
lg-end
nx-SM
lg-SM
pt-nx
end-ve
ve-SM
TG-uq
end-SM
SM-uq";
//            input = @"start-A
//start-b
//A-c
//A-b
//b-d
//A-end
//b-end";
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var n = inputs.Length;
            var graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var tokens = inputs[i].Split('-').ToArray();
                var cave1 = tokens[0];
                var cave2 = tokens[1];
                Connect(cave1, cave2);
                Connect(cave2, cave1);
            }
            int path = 0;
            HashSet<string> smallVisited = new HashSet<string>() { "start" };
            List<string> pathCave = new List<string>() { "start" };
            Visit("start", "end", true);
            Console.WriteLine(path);
            path = 0;
            smallVisited.Clear();
            pathCave.Clear();
            smallVisited.Add("start");
            pathCave.Add("start");
            Visit("start", "end", false);

            Console.WriteLine(path);

            void Visit(string start, string end, bool smallTwice)
            {
                if (start == end)
                {
                    path++;
                    Console.WriteLine(string.Join(" ", pathCave));
                    return;
                }
                var next = graph[start];
                foreach (var neighboor in next)
                {
                    if (neighboor == "start") continue;
                    if (smallVisited.Contains(neighboor) && smallTwice) continue;
                    pathCave.Add(neighboor);
                    if (neighboor.ToLower() == neighboor)
                    {
                        if (smallVisited.Contains(neighboor))
                        {
                            Visit(neighboor, end, true);
                        }
                        else
                        {
                            smallVisited.Add(neighboor);
                            Visit(neighboor, end, smallTwice);
                            smallVisited.Remove(neighboor);
                        }
                    }
                    else
                    {
                        Visit(neighboor, end, smallTwice);
                    }
                    pathCave.RemoveAt(pathCave.Count - 1);
                }
            }

            void Connect(string c1, string c2)
            {
                if (!graph.TryGetValue(c1, out var list))
                {
                    list = new List<string>();
                    graph[c1] = list;
                }
                list.Add(c2);
            }
        }
    }
}
