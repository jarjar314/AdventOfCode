using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AOC2018
{
    class Day17
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
            var vertical = new List<(int x, int y1, int y2)>();
            var horizontal = new List<(int y, int x1, int x2)>();
            int ymin = int.MaxValue, ymax = -1, xmin = int.MaxValue, xmax = int.MinValue;
            foreach (var line in lines)
            {
                var l = line.Split(new char[] { '=', ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (l[0] == "y")
                {
                    int y = int.Parse(l[1]), x1 = int.Parse(l[3]), x2 = int.Parse(l[4]);
                    horizontal.Add((y, x1, x2));
                    ymin = Math.Min(ymin, y);
                    ymax = Math.Max(ymax, y);
                    xmin = Math.Min(xmin, Math.Min(x1, x2));
                    xmax = Math.Max(xmax, Math.Max(x1, x2));
                }
                else
                {
                    int x = int.Parse(l[1]), y1 = int.Parse(l[3]), y2 = int.Parse(l[4]);
                    vertical.Add((x, y1, y2));
                    xmin = Math.Min(xmin, x);
                    xmax = Math.Max(xmax, x);
                    ymin = Math.Min(ymin, Math.Min(y1, y2));
                    ymax = Math.Max(ymax, Math.Max(y1, y2));
                }
            }

            xmax += 2;
            var grid = new char[ymax + 1][];
            for (int i = 0; i <= ymax; i++)
            {
                grid[i] = new char[xmax];
                for (int j = 0; j < xmax; j++)
                    grid[i][j] = '.';
            }
            foreach (var h in horizontal)
                for (int x = h.x1; x <= h.x2; x++)
                    grid[h.y][x] = '#';

            foreach (var v in vertical)
                for (int y = v.y1; y <= v.y2; y++)
                    grid[y][v.x] = '#';

            print();

            var st = new Stack<(int y, int x)>();
            st.Push((0, 500));
            grid[0][500] = '+';
            while (st.Count > 0)
            {
                var w = st.Peek();
                if (w.y == ymax) // tombe dans le vide
                {
                    grid[w.y][w.x] = '|';
                    st.Pop();
                    continue;
                }

                // on tombe en dessous
                if (grid[w.y + 1][w.x] == '.')
                {
                    grid[w.y][w.x] = '|';
                    st.Push((w.y + 1, w.x));
                    continue;
                }

                // on a déjà goutté en dessous
                if (grid[w.y + 1][w.x] == '|')
                {
                    grid[w.y][w.x] = '|';
                    st.Pop();
                    continue;
                }

                // donc on a du concret en dessous, eau stagnante ou mur et on va ruisseler sur les côtés
                int xl = w.x, xr = w.x;
                bool falling = false, alreadyFalling = false;
                while (xl >= 0)
                {
                    if (grid[w.y + 1][xl] == '.')
                    {
                        falling = true;
                        st.Push((w.y, xl));
                        st.Push((w.y + 1, xl));
                        break;
                    }

                    if (grid[w.y + 1][xl] == '|')
                    {
                        // ça coule déjà en dessous
                        alreadyFalling = true;
                        break;
                    }
                    if (grid[w.y][xl] == '#') break; // hit a wall
                    xl--;
                }
                while (xr < xmax) // dernière colonne pleine de .
                {
                    if (grid[w.y + 1][xr] == '.')
                    {
                        falling = true;
                        st.Push((w.y, xr));
                        st.Push((w.y + 1, xr));
                        break;
                    }

                    if (grid[w.y + 1][xr] == '|')
                    {
                        // ça coule déjà en dessous
                        alreadyFalling = true;
                        break;
                    }
                    if (grid[w.y][xr] == '#') break; // hit a wall
                    xr++;
                }

                if (falling)
                {
                    for (int x = xl; x <= xr; x++)
                        if (grid[w.y][x] != '#')
                            grid[w.y][x] = '|';
                    continue;
                }

                if (alreadyFalling)
                {
                    for (int x = xl; x <= xr; x++)
                        if (grid[w.y][x] != '#')
                            grid[w.y][x] = '|';
                    st.Pop();
                    continue;
                }

                // ici on a des murs de chaque côté, donc on va mettre des ~, sauf si on touche le bord 0 ou xmax
                char c = '~';
                if (xl < 0 || xr == xmax) c = '|';
                for (int x = xl + 1; x < xr; x++)
                    grid[w.y][x] = c;
                st.Pop();
            }

            print();
            Console.WriteLine($"part2:{Count2(grid, ymin, ymax)}");


            void print() => Console.WriteLine(string.Join("\n", grid.Select(row => string.Join("", row.Skip(xmin - 1)))));
        }

        private static void part1(List<string> lines)
        {
            var vertical = new List<(int x, int y1, int y2)>();
            var horizontal = new List<(int y, int x1, int x2)>();
            int ymin = int.MaxValue, ymax = -1, xmin = int.MaxValue, xmax = int.MinValue;
            foreach (var line in lines)
            {
                var l = line.Split(new char[] { '=', ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (l[0] == "y")
                {
                    int y = int.Parse(l[1]), x1 = int.Parse(l[3]), x2 = int.Parse(l[4]);
                    horizontal.Add((y, x1, x2));
                    ymin = Math.Min(ymin, y);
                    ymax = Math.Max(ymax, y);
                    xmin = Math.Min(xmin, Math.Min(x1, x2));
                    xmax = Math.Max(xmax, Math.Max(x1, x2));
                }
                else
                {
                    int x = int.Parse(l[1]), y1 = int.Parse(l[3]), y2 = int.Parse(l[4]);
                    vertical.Add((x, y1, y2));
                    xmin = Math.Min(xmin, x);
                    xmax = Math.Max(xmax, x);
                    ymin = Math.Min(ymin, Math.Min(y1, y2));
                    ymax = Math.Max(ymax, Math.Max(y1, y2));
                }
            }

            xmax += 2;
            var grid = new char[ymax + 1][];
            for (int i = 0; i <= ymax; i++)
            {
                grid[i] = new char[xmax];
                for (int j = 0; j < xmax; j++)
                    grid[i][j] = '.';
            }
            foreach (var h in horizontal)
                for (int x = h.x1; x <= h.x2; x++)
                    grid[h.y][x] = '#';

            foreach (var v in vertical)
                for (int y = v.y1; y <= v.y2; y++)
                    grid[y][v.x] = '#';

            print();

            var st = new Stack<(int y, int x)>();
            st.Push((0, 500));
            grid[0][500] = '+';
            while (st.Count > 0)
            {
                var w = st.Peek();
                if (w.y == ymax) // tombe dans le vide
                {
                    grid[w.y][w.x] = '|';
                    st.Pop();
                    continue;
                }

                // on tombe en dessous
                if (grid[w.y + 1][w.x] == '.')
                {
                    grid[w.y][w.x] = '|';
                    st.Push((w.y+1, w.x));
                    continue;
                }

                // on a déjà goutté en dessous
                if (grid[w.y + 1][w.x] == '|')
                {
                    grid[w.y][w.x] = '|';
                    st.Pop();
                    continue;
                }

                // donc on a du concret en dessous, eau stagnante ou mur et on va ruisseler sur les côtés
                int xl = w.x, xr = w.x;
                bool falling = false, alreadyFalling = false;
                while (xl >= 0)
                {
                    if (grid[w.y + 1][xl] == '.')
                    {
                        falling = true;
                        st.Push((w.y, xl));
                        st.Push((w.y + 1, xl));
                        break;
                    }

                    if (grid[w.y + 1][xl] == '|')
                    {
                        // ça coule déjà en dessous
                        alreadyFalling = true;
                        break;
                    }
                    if (grid[w.y][xl] == '#') break; // hit a wall
                    xl--;
                }
                while (xr < xmax) // dernière colonne pleine de .
                {
                    if (grid[w.y + 1][xr] == '.')
                    {
                        falling = true;
                        st.Push((w.y, xr));
                        st.Push((w.y + 1, xr));
                        break;
                    }

                    if (grid[w.y + 1][xr] == '|')
                    {
                        // ça coule déjà en dessous
                        alreadyFalling = true;
                        break;
                    }
                    if (grid[w.y][xr] == '#') break; // hit a wall
                    xr++;
                }

                if (falling)
                {
                    for (int x = xl; x <= xr; x++)
                        if (grid[w.y][x] != '#')
                            grid[w.y][x] = '|';
                    continue;
                }

                if (alreadyFalling)
                {
                    for (int x = xl; x <= xr; x++)
                        if (grid[w.y][x] != '#')
                            grid[w.y][x] = '|';
                    st.Pop();
                    continue;
                }

                // ici on a des murs de chaque côté, donc on va mettre des ~, sauf si on touche le bord 0 ou xmax
                char c = '~';
                if (xl < 0 || xr == xmax) c = '|';
                for (int x = xl + 1; x < xr; x++)
                    grid[w.y][x] = c;
                st.Pop();
            }

            print();
            Console.WriteLine($"part1:{Count(grid, ymin, ymax)}");


            void print() => Console.WriteLine(string.Join("\n", grid.Select(row => string.Join("", row.Skip(xmin - 1)))));
        }
        private static int Count2(char[][] grid, int y1, int y2)
        {
            int count = 0;
            for (int y = y1; y <= y2; y++)
                for (int x = 0; x < grid[0].Length; x++)
                    if (grid[y][x] == '~') count++;
            return count;
        }
        private static int Count(char[][] grid, int y1, int y2)
        {
            int count = 0;
            for (int y = y1; y <= y2; y++)
                for (int x = 0; x < grid[0].Length; x++)
                    if (grid[y][x] == '|' || grid[y][x] == '~') count++;
            return count;
        }
    }
}
