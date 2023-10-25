using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019
{
    public class Day2
    {
        public static void Main()
        {
            // check if this is working
            var input = @"1,9,10,3,2,3,11,0,99,30,40,50";
            var intCode = new Intcode(input);
            intCode.Run();
            Console.WriteLine(intCode.Get(0));

            // Let's process the big game
            intCode = new Intcode(@"1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,5,19,23,1,13,23,27,1,6,27,31,2,31,13,35,1,9,35,39,2,39,13,43,1,43,10,47,1,47,13,51,2,13,51,55,1,55,9,59,1,59,5,63,1,6,63,67,1,13,67,71,2,71,10,75,1,6,75,79,1,79,10,83,1,5,83,87,2,10,87,91,1,6,91,95,1,9,95,99,1,99,9,103,2,103,10,107,1,5,107,111,1,9,111,115,2,13,115,119,1,119,10,123,1,123,10,127,2,127,10,131,1,5,131,135,1,10,135,139,1,139,2,143,1,6,143,0,99,2,14,0,0");
            intCode.Set(1, 1, 12);
            intCode.Set(1, 2, 2);
            intCode.Run();
            Console.WriteLine(intCode.Get(0));

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb =  0; verb < 100; verb++)
                {
                    intCode.Reset();
                    intCode.Set(1, 1, noun);
                    intCode.Set(1, 2, verb);
                    intCode.Run();
                    if (intCode.Get(0) == 19690720)
                        Console.WriteLine(100 * noun + verb);
                }
            }
        }

        public static void Process(string input)
        {
        }
    }
}
