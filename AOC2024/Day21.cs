using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Text;

namespace AOC2024
{
    internal class Day21
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
            init();
            part1(lines);
            part2(lines);
            stopwatch.Stop();
            Console.WriteLine($"time={stopwatch.ElapsedMilliseconds}ms.");
        }

        private const string directions = "<>v^A";
        static Dictionary<char, (int r, int c)> directional = new Dictionary<char, (int r, int c)>()
        {
            { '^', (0,1) },
            { 'A', (0,2) },
            { '<', (1,0) },
            { 'v', (1,1) },
            { '>', (1,2) }
        };

        static Dictionary<int, (int r, int c)> positions = new Dictionary<int, (int r, int c)>(){
            {7,(0,0) },
            {8,(0,1) },
            {9,(0,2) },
            {4,(1,0) },
            {5,(1,1) },
            {6,(1,2) },
            {1,(2,0) },
            {2,(2,1) },
            {3,(2,2) },
            {0,(3,1) },
            {10,(3,2) },
        };
        static Dictionary<(int from, int to), string> mapsPositions = new Dictionary<(int from, int to), string>();
        static Dictionary<(int from, int to), string> mapsDirections = new Dictionary<(int from, int to), string>();
        static void init()
        {
            #region position keyboard
            var sb = new StringBuilder();
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == j)
                    {
                        mapsPositions.Add((i, j), "A");
                        continue;
                    }
                    sb.Clear();
                    int dr = positions[j].r - positions[i].r, dc = positions[j].c - positions[i].c;
                    if (dr == 0)
                    {
                        mapsPositions.Add((i, j), moveCol(dc) + "A");
                        continue;
                    }
                    if (dc == 0)
                    {
                        mapsPositions.Add((i, j), moveRow(dr) + "A");
                        continue;
                    }
                    if (positions[j].r == 3 && positions[i].c == 0) // on ne peut pas passer par le gap donc on monte d'abord, et on décale latéralement ensuite
                    {
                        mapsPositions.Add((i, j), moveCol(dc) + moveRow(dr) + "A");
                        continue;
                    }
                    if (positions[i].r == 3 && positions[j].c == 0)
                    {
                        mapsPositions.Add((i, j), moveRow(dr) + moveCol(dc) + "A");
                        continue;
                    }
                    // maintenant, on doit prioriser des éléments pour la version de deuxième niveau
                    if (dr > 0 && dc > 0)
                    {
                        mapsPositions.Add((i, j), moveRow(dr) + moveCol(dc) + "A");
                    }
                    else if (dr > 0 && dc < 0)
                    {
                        mapsPositions.Add((i, j), moveCol(dc) + moveRow(dr) + "A");
                    }
                    else if (dr < 0 && dc > 0)
                    {
                        mapsPositions.Add((i, j), moveRow(dr) + moveCol(dc) + "A");
                    }
                    else if (dr < 0 && dc < 0)
                    {
                        mapsPositions.Add((i, j), moveCol(dc) + moveRow(dr) + "A");
                    }
                }
            }
            #endregion
            #region direction keyboard
            foreach (var from in directions)
            {
                foreach (var to in directions)
                {
                    if (from == to)
                    {
                        mapsDirections.Add((from, to), "A"); // le bras est déjà en position
                        continue;
                    }
                    sb.Clear();
                    int dr = directional[to].r - directional[from].r, dc = directional[to].c - directional[from].c;
                    if (dr == 0)
                    {
                        mapsDirections.Add((from, to), moveCol(dc) + "A");
                        continue;
                    }
                    if (dc == 0)
                    {
                        mapsDirections.Add((from, to), moveRow(dr) + "A");
                        continue;
                    }
                    if (directional[to].r == 0 && directional[from].c == 0)
                    {
                        mapsDirections.Add((from, to), moveCol(dc) + moveRow(dr) + "A");
                        continue;
                    }
                    if (directional[from].r == 0 && directional[to].c == 0)
                    {
                        mapsDirections.Add((from, to), moveRow(dr) + moveCol(dc) + "A");
                            continue;
                    }
                    // maintenant, on doit prioriser des éléments pour la version de deuxième niveau
                    if (dr > 0 && dc > 0)
                    {
                        mapsDirections.Add((from, to), moveRow(dr) + moveCol(dc) + "A");
                    }
                    else if (dr > 0 && dc < 0)
                    {
                        mapsDirections.Add((from, to), moveCol(dc) + moveRow(dr) + "A");
                    }
                    else if (dr < 0 && dc > 0)
                    {
                        mapsDirections.Add((from, to), moveRow(dr) + moveCol(dc) + "A");
                    }
                    else if (dr < 0 && dc < 0)
                    {
                        mapsDirections.Add((from, to), moveCol(dc) + moveRow(dr) + "A");
                    }
                }
            }
            #endregion
        }
        static string moveRow(int d) => GetString(d, 'v', '^');
        static string moveCol(int d) => GetString(d, '>', '<');
        static string GetString(int d, char pos, char neg)
        {
            var c = d > 0 ? pos : neg;
            d = Math.Abs(d);
            return new string(c, d);
        }

        /*
         * 
         * 
        789
        456
        123
         0A

         ^A
        <v>

         * 
         */

        private static Dictionary<string, long> initDictionary()
        {
            var dico = new Dictionary<string, long>();
            foreach (var a in directions)
                foreach (var b in directions)
                    dico.Add($"{a}{b}", 0);
            return dico;
        }
        private static long Complexities(string line)
        {
            var last = 'A';
            var first = GetPositions(line);
            var dico = initDictionary();
            long nbA = 0;
            for (int i = 0; i < first.Length; i++)
            {
                if (last == 'A' && first[i] == 'A')
                    nbA++;
                else
                    dico[$"{last}{first[i]}"]++;
                last = first[i];
            }
            for(int i = 0; i < 25; i++)
            {
                var temp = initDictionary();
                foreach (var kvp in dico)
                {
                    var l = mapsDirections[(kvp.Key[0], kvp.Key[1])];
                    last = 'A';
                    foreach (var c in l)
                    {
                        if (last == 'A' && c == 'A')
                        {
                            nbA += kvp.Value;
                        }
                        else
                            temp[$"{last}{c}"] += kvp.Value;
                        last = c;
                    }
                }
                dico = temp;
            }
            return dico.Values.Sum() + nbA;
        }
        private static void part2(List<string> lines)
        {
            long total = 0;
            foreach (var line in lines)
            {
                var comp = Complexities(line);
                total += long.Parse(line[0..^1]) * comp;
            }
            Console.WriteLine($"part2: {total}");
        }

        private static string GetPositions(string line)
        {
            var sb = new StringBuilder();
            int last = 10; // bouton en A
            foreach (var c in line)
            {
                int curr = (c == 'A' ? 10 : c - '0');
                sb.Append(mapsPositions[(last, curr)]);
                last = curr;
            }
            return sb.ToString();
        }
        private static string GetDirections(string line)
        {
            var sb = new StringBuilder();
            char last = 'A'; // bouton en A
            foreach (var c in line)
            {
                sb.Append(mapsDirections[(last, c)]);
                last = c;
            }
            return sb.ToString();
        }
        private static void part1(List<string> lines)
        {
            long force = 0;
            foreach (var line in lines)
            {
                var firstRobot = GetPositions(line);
                Console.WriteLine($"{line}=> {firstRobot.Length} moves : {firstRobot}");
                var secondRobot = GetDirections(firstRobot);
                Console.WriteLine($"{line}=> {secondRobot.Length} moves : {secondRobot}");
                var thirdRobot = GetDirections(secondRobot);
                Console.WriteLine($"{line}=> {thirdRobot.Length} moves : {thirdRobot}");
                Console.WriteLine($"{line} => {long.Parse(line[0..^1]) * thirdRobot.Length}");
                force += long.Parse(line[0..^1]) * thirdRobot.Length;
            }

            Console.WriteLine($"part1: {force}");
        }
    }
}
