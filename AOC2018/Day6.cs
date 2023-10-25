using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2018
{
    public class Day6
    {

        public static void Main()
        {
            var input = @"355, 246
259, 215
166, 247
280, 341
54, 91
314, 209
256, 272
149, 313
217, 274
299, 144
355, 73
70, 101
266, 327
51, 228
274, 123
342, 232
97, 100
58, 157
130, 185
135, 322
306, 165
335, 84
268, 234
173, 255
316, 75
79, 196
152, 71
205, 261
275, 342
164, 95
343, 147
83, 268
74, 175
225, 130
354, 278
123, 206
166, 166
155, 176
282, 238
107, 295
82, 92
325, 299
87, 287
90, 246
159, 174
295, 298
260, 120
203, 160
72, 197
182, 296";
            int minx = int.MaxValue, miny = int.MaxValue, maxx = int.MinValue, maxy = int.MinValue;
            var points = new List<(int x, int y)>();
            foreach (var point in input.Split(new char[] { '\n' }))
            {
                var coordinate = point.Split(new char[] { '\r', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int x = int.Parse(coordinate[0]);
                int y = int.Parse(coordinate[1]);
                minx = Math.Min(x, minx);
                miny = Math.Min(y, miny);
                maxx = Math.Max(x, maxx);
                maxy = Math.Max(y, maxy);
                points.Add((x, y));
            }
            var grid = new int[maxy + 1][];
            int countLessThan1000 = 0;
            var areas = new List<int>();
            var borders = new HashSet<int>();
            for (int i = 0; i <= maxy; i++)
            {
                grid[i] = new int[maxx + 1];
                for (int j = 0; j <= maxx; j++)
                {
                    int totalDistance = 0;
                    int distance = int.MaxValue;
                    grid[i][j] = -1;
                    for (int k = 0; k < points.Count; k++)
                    {
                        var p = points[k];
                        int d = Math.Abs(p.x - j) + Math.Abs(p.y - i);
                        totalDistance += d;
                        if (d < distance)
                        {
                            distance = d;
                            grid[i][j] = k;
                        }
                        else if (d == distance)
                        {
                            grid[i][j] = -1;
                        }
                    }
                    if (totalDistance <= 10000)
                        countLessThan1000++;
                    if (grid[i][j] != -1)
                    {
                        if (i == 0 || j == 0 || i == maxx || j == maxy)
                        {
                            borders.Add(grid[i][j]);
                        }
                        areas.Add(grid[i][j]);
                    }
                }
            }
            Console.WriteLine(areas.Where(a => !borders.Contains(a)).GroupBy(a => a).OrderByDescending(gr => gr.Count()).First().Count());
            Console.WriteLine(countLessThan1000);
        }

    }
}
