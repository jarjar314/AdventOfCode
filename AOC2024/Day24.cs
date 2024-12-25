using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day24
    {
        static Dictionary<string, Node> nodes = new Dictionary<string, Node>();
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
            var elem = ReadCircuit(lines);
            part1(elem);
            part2();
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        private static void part2()
        {
            //TODO : the generic solution, not the one I did in excel reinterpreting the machine :D
        }

        private static void part1(List<Node> elem)
        {
            var q = new Queue<Node>(elem);
            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (p == null) continue;
                if (p.valueSet)
                {
                    foreach (var next in p.child)
                    q.Enqueue(next);
                }
                else
                {
                    if (p.left.valueSet && p.right.valueSet)
                    {
                        p.Process();
                        foreach (var next in p.child)
                            q.Enqueue(next);
                    }
                }
            }
            long res = 0;
            foreach (var kvp in nodes)
            {
                if (kvp.Key[0] == 'z')
                {
                    var shift = int.Parse(kvp.Key[1..]);
                    res += (long)(kvp.Value.Val) << shift;
                }
            }
            Console.WriteLine(res);
        }

        private static Node GetNode(string n)
        {
            if (nodes.TryGetValue(n, out var node)) return node;
            return nodes[n] = new Node(n);
        }
        private static List<Node> ReadCircuit(List<string> lines)
        {
            int index = 0;
            var inputs = new List<Node>();
            while (!string.IsNullOrEmpty(lines[index]))
            {
                var arr = lines[index++].Split(": ");
                var n = GetNode(arr[0]);
                n.Val = int.Parse(arr[1]);
                inputs.Add(n);
            }

            index++;
            while (index < lines.Count)
            {
                var arr = lines[index++].Split();
                var left = GetNode(arr[0]);
                var right = GetNode(arr[2]);
                var target = GetNode(arr[4]);
                target.left = left;
                target.right = right;
                left.child.Add(target);
                right.child.Add(target);
                target.op = arr[1];
            }
            return inputs;
        }
    }
    public class Node
    {
        public string id;
        public List<Node> child = new List<Node>();
        public Node left, right;
        public string op;
        public bool valueSet;
        private int val;
        public Node(string id) { this.id = id; }

        public int Val { get => val; 
            set { valueSet = true; val = value; }
            }

        public void Process()
        {
            if (left.valueSet && right.valueSet)
            {
                valueSet = true;
                switch (op)
                {
                    case "AND":val = left.Val & right.Val;break;
                    case "OR":val = left.Val | right.Val;break;
                    case "XOR": val = left.Val ^ right.Val;break;
                }
            }
        }
    }
}
