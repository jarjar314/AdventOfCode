using System.Diagnostics;
using System.Reflection;

namespace AOC2024
{
    internal class Day15
    {
        private static void part1(List<string> lines)
        {
            var instructions = new List<char[]>();
            var grid = new List<char[]>();
            var current = grid;
            foreach (var l in lines)
            {
                if (string.IsNullOrEmpty(l))
                {
                    current = instructions;
                    continue;
                }
                current.Add(l.ToCharArray());
            }
            int rR = 0, cR = 0;
            int m = grid.Count, n = grid[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        rR = i; cR = j;
                        break;
                    }
                }
            }
            var moves = new Dictionary<char, (int dr, int dc)>() { { '^', (-1, 0) }, { 'v', (1, 0) }, { '<', (0, -1) }, { '>', (0, 1) } };
            foreach (var l in instructions)
            {
                foreach (var c in l)
                {
                    var move = moves[c];
                    int nr = rR + move.dr, nc = cR + move.dc;
                    while (grid[nr][nc] == 'O') // tant qu'on peut pousser un objet
                    {
                        nr += move.dr;
                        nc += move.dc;
                    }
                    if (grid[nr][nc] == '#') // un mur, on ne peut pas pousser en fait !
                        continue;
                    if (grid[nr][nc] == '.') // normalement, ça ne peut pas être un autre caractère
                    {
                        grid[nr][nc] = grid[rR + move.dr][cR + move.dc]; // si on a un O, on met le 0 à la fin, et on met le @ du robot sur la case courante
                        grid[rR + move.dr][cR + move.dc] = '@'; // on bouge le robot
                        grid[rR][cR] = '.';
                        rR += move.dr;
                        cR += move.dc;
                    }
                }
            }

            long total = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (grid[i][j] == 'O')
                        total += 100 * i + j;
            print(grid);
            Console.WriteLine(total);
        }

        private static void print(List<char[]> grid)
        {
            Console.WriteLine(string.Join("\n", grid.Select(r => string.Join("", r))));
        }

        private static void part2(List<string> lines)
        {
            var instructions = new List<char[]>();
            var grid = new List<char[]>();
            var current = grid;
            foreach (var l in lines)
            {
                if (string.IsNullOrEmpty(l))
                {
                    current = instructions;
                    continue;
                }
                current.Add(l.ToCharArray());
            }
            int rR = 0, cR = 0;
            int m = grid.Count, n = grid[0].Length;
            var grid2 = new List<char[]>();
            for (int i = 0; i < m; i++)
            {
                grid2.Add(new char[2 * n]);
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        rR = i; 
                        cR = 2*j;
                        grid2[i][2 * j] = '@';
                        grid2[i][2 * j + 1] = '.';
                    }
                    else if (grid[i][j] == 'O')
                    {
                        grid2[i][2 * j] = '[';
                        grid2[i][2 * j + 1] = ']';
                    }
                    else
                    {
                        grid2[i][2 * j] = grid2[i][2 * j + 1] = grid[i][j];
                    }
                }
            }
            foreach (var l in instructions)
            {
                foreach (var c in l)
                {
                    if (c == '>')moveHorizontal( 1);
                    if (c == '<')moveHorizontal(-1);
                    if (c == '^') moveVertical(-1);
                    if (c == 'v') moveVertical(1);
                }
            }

            long total = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < 2*n; j++)
                    if (grid2[i][j] == '[')
                        total += 100 * i + j;
            Console.WriteLine("part2");
            Console.WriteLine(string.Join("\n", grid2.Select(r => string.Join("", r))));
            Console.WriteLine(total);

            void moveHorizontal(int dc)
            {
                int nr = rR , nc = cR + dc;
                while (grid2[nr][nc] != '.' && grid2[nr][nc] != '#') // nos cas d'arrêts
                {
                    nc += dc;
                }
                if (grid2[nr][nc] == '#') return; // no move possible, boxes are stuck
                // so we have a . we need to shift one all the char from nr nc to rR cR
                while (nc != cR)
                {
                    grid2[nr][nc] = grid2[nr][nc - dc];
                    nc -= dc;
                }
                grid2[rR][cR] = '.'; // le robot vient de bouger, donc on met la case vide
                // on indique le déplacement du robot dans la grille
                cR += dc;
            }
            void moveVertical(int dr)
            {
                int level = 0;
                var hs = new HashSet<int>() { cR};
                int nr = rR;
                var mustMove = new SortedSet<(int level, int r, int c)>();
                while (hs.Count > 0) // quand on a une rangée de . qui aura accueilli le mouvement, ce sera bon.
                {
                    nr += dr;
                    var nexths = new HashSet<int>();
                    bool stop = false;
                    foreach (var col in hs)
                    {
                        if (grid2[nr][col] == '#')// bloc
                        {
                            return; // no move !!!
                        }
                        mustMove.Add((level, nr, col)); // va accueillir la ligne précédente
                        if (grid2[nr][col] == '.') // pas d'impact
                            continue;
                        if (grid2[nr][col] == '[') // on rajoute col et col + 1
                        {
                            nexths.Add(col);
                            nexths.Add(col + 1);
                            mustMove.Add((level, nr, col+1));
                        }
                        if (grid2[nr][col] == ']') // on rajoute col et col-1
                        {
                            nexths.Add(col);
                            nexths.Add(col - 1);
                            mustMove.Add((level, nr, col-1));
                        }
                    }
                    level--;
                    hs = nexths;
                }

                foreach (var m in mustMove)
                {
                    // je remplace par un point si je n'ai pas la case en dessous dans la liste
                    if (mustMove.Contains((m.level + 1, m.r - dr, m.c)))
                    {
                        grid2[m.r][m.c] = grid2[m.r - dr][m.c];
                    }
                    else
                        grid2[m.r][m.c] = '.';
                }
                grid2[rR][cR] = '.'; // robot vacate !
                rR += dr;
                //grid2[rR][cR] = '@';
            }
        }

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

    }
}
