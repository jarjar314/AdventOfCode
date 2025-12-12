using System;
using Microsoft.Z3;

namespace AOC2025
{
    internal static class Day10
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day10
            Console.WriteLine("AOC2025 Day10 placeholder");
            Process("Day10/Day10-small.txt");
            Process("Day10/Day10.txt");
            Process2("Day10/Day10-small.txt");
            Process2("Day10/Day10.txt");
        }

        public static void Process(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<string[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!.Split());
            }
            count = l.Select(Fewest).Sum();


            Console.WriteLine($"Part 1 : {fileName} : {count}");
        }

        public static int ReadTarget(string s)
        {
            int res = 0;
            for (int i = s.Length - 2; i > 0; i--)
            {
                res = 2 * res + (s[i] == '#' ? 1 : 0);
            }
            return res;
        }

        public static long Fewest(string[] g)
        {
            int target = ReadTarget(g[0]);
            var buttons = g.Skip(1).Take(g.Length - 2).Select(ReadButtons).ToArray();
            var possible = new Dictionary<int, int>() { { 0, 0 } };
            foreach (var b in buttons)
            {
                var next = new Dictionary<int, int>(possible);
                foreach (var p in possible)
                {
                    int np = p.Key ^ b;
                    int nc = p.Value + 1;
                    if (!next.ContainsKey(np) || next[np] > nc)
                    {
                        next[np] = nc;
                    }
                }
                possible = next;
            }
            return possible[target];
        }
        public static int ReadButtons(string s)
        {
            var pressed = s.Split(new[] { ',', ')', '(' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int res = 0;
            foreach (var p in pressed)
            {
                res |= (1 << p);
            }
            return res;
        }
        public static void Process2(string fileName)
        {
            long count = 0;
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var l = new List<string[]>();
            while (!reader.EndOfStream)
            {
                l.Add(reader.ReadLine()!.Split());
            }
            count = l.Select(solve_Z3).Sum();
            Console.WriteLine($"Part 2 : {fileName} : {count}");
        }

        public static long solve_Z3(string[] g)
        {
            int[] target = g[^1][1..^1].Split([',']).Select(int.Parse).ToArray();
            int m = target.Length;
            var buttons = g.Skip(1).Take(g.Length - 2).Select(c => c.Split(new[] { ',', ')', '(' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToArray();
            var cols = new List<int[]>();
            foreach (var b in buttons)
            {
                var col = new int[m];
                foreach (var p in b)
                {
                    col[p] = 1;
                }
                cols.Add(col);
            }
            int n = cols.Count;
            // transposer la matrice pour faire A*X = V
            var A = new int[m][];
            for (int r = 0; r < m; r++)
            {
                A[r] = new int[n];
                for (int c = 0; c < n; c++)
                {
                    A[r][c] = cols[c][r];
                }
            }

            using var solver = new Context();
            var opt = solver.MkOptimize(); // on veut une optimisation
            var xs = new IntExpr[n]; // notre vecteur X à résoudre
            for (int j = 0; j < n; j++)
            {
                xs[j] = (IntExpr)solver.MkConst($"x{j}", solver.IntSort);
                // chaque xj est positif
                opt.Add(solver.MkGe(xs[j], solver.MkInt(0)));
            }
            // Contraintes A*X = V
            for (int r = 0; r < m; r++)
            {
                var terms = new List<ArithExpr>();
                for (int j = 0; j < n; j++)
                {
                    if (A[r][j] == 0) continue;
                    if (A[r][j] == 1)
                    {
                        terms.Add(xs[j]);
                    }
                    else
                        terms.Add(solver.MkMul(solver.MkInt(A[r][j]), xs[j]));
                }

                ArithExpr left;
                if (terms.Count == 0)left = solver.MkInt(0);
                else if (terms.Count == 1)
                    left = terms[0];
                else
                    left = solver.MkAdd(terms.ToArray());
                opt.Add(solver.MkEq(left, solver.MkInt(target[r])));
            }

            // fonction objectif : minimiser la somme des xj
            ArithExpr objective = solver.MkAdd(xs.Cast<ArithExpr>().ToArray());
            opt.MkMinimize(objective);

            var status = opt.Check();
            if (status != Status.SATISFIABLE && status != Status.UNKNOWN)
            {
                // pas de solution mais on ne devrait pas se trouver là par définition.
                return -1;
            }

            var model = opt.Model;
            // Récupérer et afficher les valeurs de x0..x{n-1} en cas de debug
            var xsValues = new long[n];
            for (int j = 0; j < n; j++)
            {
                var v = model.Evaluate(xs[j], true);
                if (v is IntNum num)
                {
                    xsValues[j] = num.Int64;
                }
                else
                {
                    // tentative de parsing depuis la représentation textuelle
                    if (!long.TryParse(v.ToString(), out long parsed))
                        parsed = 0;
                    xsValues[j] = parsed;
                }
            }
            // récupérer la valeur de l'objectif dans le modèle
            var eval = model.Evaluate(objective, true);
            if (eval is IntNum inum)
            {
                try
                {
                    return inum.Int64;
                }
                catch
                {
                    // si trop grand pour Int64, renvoyer la valeur via ToString
                    if (long.TryParse(inum.ToString(), out long val))
                        return val;
                    return -1;
                }
            }

            return -1;
        }
    }
}