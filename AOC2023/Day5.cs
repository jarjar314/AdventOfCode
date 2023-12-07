using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AOC2022
{
    public class Day5
    {

        public static void Main()
        {
            var input = @"seeds: 364807853 408612163 302918330 20208251 1499552892 200291842 3284226943 16030044 2593569946 345762334 3692780593 17215731 1207118682 189983080 2231594291 72205975 3817565407 443061598 2313976854 203929368

seed-to-soil map:
2069473506 3732587455 1483883
3235691256 2348990120 6550341
3547561069 1392195671 747406227
3264251584 3734071338 283309485
391285622 257757572 195552540
1645243555 3166958320 377191689
335002083 512210869 56283539
3242241597 897735089 22009987
77244511 0 257757572
989159646 4172023334 122943962
605476380 3544150009 188437446
0 568494408 18343754
2700122696 4050276683 121746651
2022435244 2139601898 47038262
2227672101 919745076 95840269
1112103608 2633818373 533139947
826809686 2186640160 162349960
3100147259 762191092 135543997
18343754 453310112 58900757
2323512370 1015585345 282396986
2605909356 1297982331 94213340
2821869347 2355540461 278277912
793913826 4017380823 32895860
2070957389 605476380 156714712

soil-to-fertilizer map:
2700214958 2743391193 363795571
1484584575 1440072796 24660284
927520818 435059068 191969051
1588488926 1434420334 5652462
1423277199 141187887 5443857
1594141388 1350997453 83422881
1986188257 3933008893 120750463
1509244859 146631744 79093544
3712482038 4220862006 74105290
3948206286 1986188257 277570873
291046304 281588807 153470261
1119489869 918224946 303787330
1677564269 1321192605 29804848
2309878676 2336743687 390336282
3079951473 3306332300 449116691
444516565 1222012276 99180329
543696894 1464733080 383823924
3895169406 3771389935 53036880
3529068164 4053759356 167102650
0 627178642 291046304
3696170814 2727079969 16311224
3855550220 3824426815 39619186
2106938720 3107186764 199145536
1428721056 225725288 55863519
1707369117 0 64378064
1771747181 64378064 76809823
3064010529 3755448991 15940944
2306084256 2332949267 3794420
4225777159 2263759130 69190137
3786587328 3864046001 68962892
1588338403 627028119 150523

fertilizer-to-water map:
2299879115 39069388 7889905
514481680 504392888 101474410
3448524168 0 25428313
13641075 1832356728 472401611
0 25428313 13641075
1842445520 108629584 395763304
486042686 3445513487 28438994
2307769020 2304758339 1140755148
2238208824 46959293 61670291
615956090 605867298 1226489430

water-to-light map:
1318826171 2010420436 223477535
2278894745 2233897971 671603259
988189854 447584401 27746374
2132052210 300741866 146842535
0 1279660741 97125596
3531244480 3147213622 507810286
257581844 3816963790 101424269
1298609589 3918388059 20216582
3317726838 1072550929 21856732
3065323607 1254863909 4121973
97125596 1094407661 160456248
359006113 1057194484 15356445
374362558 1636971609 104335413
4039054766 475330775 9209679
1038424317 1376786337 260185272
878530050 3938604641 109659804
1784016098 3738041092 78922698
3152462764 0 165264074
1862938796 1741307022 269113414
497536930 676201364 380993120
3069445580 3655023908 83017184
2950498004 165264074 114825603
1015936228 1258985882 1835900
478697971 1260821782 18838959
1017772128 280089677 20652189
1542303706 2905501230 241712392
3339583570 484540454 191660910

light-to-temperature map:
2827696039 489007811 183207687
1480301347 3744628626 306791400
695239418 130668965 358338846
1297125534 2232912413 183175813
3979319170 1917264287 315648126
3010903726 948848843 968415444
130668965 2663473525 564570453
1053578264 4051420026 243547270
2303677395 672215498 276633345
1787092747 3228043978 516584648
2580310740 2416088226 247385299

temperature-to-humidity map:
4161466647 3871737509 133500649
2423686895 2864370860 72123408
1983529997 0 320533964
3184295196 2695571092 41928210
0 822932241 605870242
3557076981 3267347843 604389666
3226223406 2936494268 330853575
2495810303 2737499302 126871558
1108268519 1428802483 491674128
605870242 320533964 502398277
2622681861 2423686895 271884197
2894566058 4005238158 289729138
1599942647 1920476611 383587350

humidity-to-location map:
2945628300 1864953738 334378942
3467273713 3579654586 715312710
975015905 1356290883 508662855
1483678760 2498980024 1080674562
3443998409 2199332680 23275304
3280007242 2222607984 163991167
4182586423 2386599151 112380873
2564353322 975015905 381274978";
            var sample = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";
            part1(sample);
            part2(sample);
            part1(input);
            part2(input);

        }

        private static void part2(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var m = inputs.Length;
            var seedToSoil = new SortedDictionary<(long start, long end), (long start, long end)>();
            var soilToFertilizer = new SortedDictionary<(long start, long end), (long start, long end)>();
            var fertilizerToWater = new SortedDictionary<(long start, long end), (long start, long end)>();
            var waterToLight = new SortedDictionary<(long start, long end), (long start, long end)>();
            var lightToTemperature = new SortedDictionary<(long start, long end), (long start, long end)>();
            var temperatureToHumidity = new SortedDictionary<(long start, long end), (long start, long end)>();
            var humidityToLocation = new SortedDictionary<(long start, long end), (long start, long end)>();
            SortedDictionary<(long start, long end), (long start, long end)>? current = null;
            var seeds = new SortedSet<(long start, long end)>();
            for (int i = 0; i < m; i++)
            {
                if (string.IsNullOrEmpty(inputs[i])) continue;
                if (inputs[i].StartsWith("seeds"))
                {
                    var arr = inputs[i].Split().Skip(1).Select(long.Parse).ToArray();
                    for (int j = 0; j < arr.Length; j += 2)
                    {
                        seeds.Add((arr[j], arr[j] + arr[j + 1]));
                    }
                    continue;
                }
                if (inputs[i] == "seed-to-soil map:")
                {
                    current = seedToSoil;
                    continue;
                }
                if (inputs[i] == "soil-to-fertilizer map:")
                {
                    current = soilToFertilizer;
                    continue;
                }
                if (inputs[i] == "fertilizer-to-water map:")
                {
                    current = fertilizerToWater;
                    continue;
                }
                if (inputs[i] == "water-to-light map:")
                {
                    current = waterToLight;
                    continue;
                }
                if (inputs[i] == "light-to-temperature map:")
                {
                    current = lightToTemperature;
                    continue;
                }
                if (inputs[i] == "temperature-to-humidity map:")
                {
                    current = temperatureToHumidity;
                    continue;
                }
                if (inputs[i] == "humidity-to-location map:")
                {
                    current = humidityToLocation;
                    continue;
                }
                var line = inputs[i].Split().Select(long.Parse).ToArray();
                current!.Add((line[1], line[1] + line[2] - 1), (line[0], line[0] + line[2] - 1));
            }
            var path = new[] { seedToSoil, soilToFertilizer, fertilizerToWater, waterToLight, lightToTemperature, temperatureToHumidity, humidityToLocation };
            Console.WriteLine("Let's the fun begin");
            var curr = seeds;
            foreach (var map in path)
            {
                curr = transform2(map, curr);
            }
            Console.WriteLine($"réponse à 2 est {curr.First().start}");

        }

        private static SortedSet<(long start, long end)> transform2(SortedDictionary<(long start, long end), (long start, long end)> map, SortedSet<(long start, long end)> intervals)
        {
            var res = new SortedSet<(long start, long end)>();
            foreach (var interval in intervals)
            {
                long start = interval.start, end = interval.end;
                foreach (var m in map)
                {
                    long sourceStart = m.Key.start, sourceEnd = m.Key.end;
                    long destinationStart = m.Value.start, destinationEnd = m.Value.end;
                    long diff = destinationStart - sourceStart;
                    if (end < sourceStart) break; // all other intervals will be after current.
                    if (sourceEnd < start) continue; // no intersection
                    if (sourceStart <= start && end <= sourceEnd) // interval fully within the new one.
                    {
                        res.Add((start + destinationStart - sourceStart, end + destinationStart - sourceStart));
                        start = end + 1; // nothing else to fill
                        break;
                    }
                    if (start < sourceStart) // source start étant plus petit que end, ça veut dire que sourcestart est entre start et end inclus
                    {
                        res.Add((start, sourceStart - 1));
                        start = sourceStart;
                    }
                    // maintenant on a sourcestart qui est avant start (inclus), end inclus => start va décaler jusqu'à end ou sourceend de diff et on continuera avec start à ce point + 1;
                    res.Add((start + diff, Math.Min(end, sourceEnd) + diff));
                    start = Math.Min(end, sourceEnd) + 1;

                    if (start > end) break; // all points have been mapped
                }
                if (start <= end)
                    res.Add((start, end)); // add the remaining interval if any
            }

            return res;
        }

        private static void part1(string input)
        {
            var inputs = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var m = inputs.Length;
            var seedToSoil = new Dictionary<(long, long), long>();
            var soilToFertilizer = new Dictionary<(long, long), long>();
            var fertilizerToWater = new Dictionary<(long, long), long>();
            var waterToLight = new Dictionary<(long, long), long>();
            var lightToTemperature = new Dictionary<(long, long), long>();
            var temperatureToHumidity = new Dictionary<(long, long), long>();
            var humidityToLocation = new Dictionary<(long, long), long>();
            Dictionary<(long, long), long> current = null;
            var seeds = new List<long>();
            for (int i = 0; i < m; i++)
            {
                if (string.IsNullOrEmpty(inputs[i])) continue;
                if (inputs[i].StartsWith("seeds"))
                {
                    seeds.AddRange(inputs[i].Split().Skip(1).Select(long.Parse));
                    continue;
                }
                if (inputs[i] == "seed-to-soil map:")
                {
                    current = seedToSoil;
                    continue;
                }
                if (inputs[i] == "soil-to-fertilizer map:")
                {
                    current = soilToFertilizer;
                    continue;
                }
                if (inputs[i] == "fertilizer-to-water map:")
                {
                    current = fertilizerToWater;
                    continue;
                }
                if (inputs[i] == "water-to-light map:")
                {
                    current = waterToLight;
                    continue;
                }
                if (inputs[i] == "light-to-temperature map:")
                {
                    current = lightToTemperature;
                    continue;
                }
                if (inputs[i] == "temperature-to-humidity map:")
                {
                    current = temperatureToHumidity;
                    continue;
                }
                if (inputs[i] == "humidity-to-location map:")
                {
                    current = humidityToLocation;
                    continue;
                }
                var line = inputs[i].Split().Select(long.Parse).ToArray();
                current!.Add((line[1], line[2]), line[0]);

            }
            var path = new[] { seedToSoil, soilToFertilizer, fertilizerToWater, waterToLight, lightToTemperature, temperatureToHumidity, humidityToLocation };
            Console.WriteLine("Let's the fun begin");
            Console.WriteLine($"réponse à 1 est {seeds.Select(transform).Min()}");

            long transform(long a)
            {
                foreach (var map in path)
                {
                    foreach (var kvp in map)
                    {
                        if (kvp.Key.Item1 <= a && a <= kvp.Key.Item1 + kvp.Key.Item2)
                        {
                            a += kvp.Value - kvp.Key.Item1;
                            break;
                        }
                    }
                }
                return a;
            }
        }
    }
}
