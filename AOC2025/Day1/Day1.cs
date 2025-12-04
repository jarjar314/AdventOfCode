using System;

namespace AOC2025
{
    internal static class Day1
    {
        public static void Run()
        {
            // TODO: implémenter l'exercice Day01
            Console.WriteLine("AOC2025 Day01 placeholder");
            Process("Day1/Day1-small.txt");
            Process("Day1/Day1.txt");
        }

        public static void Process(string fileName)
        {
            Console.WriteLine($"Processing {fileName}...");
            using var reader = new System.IO.StreamReader(fileName);
            var instructions = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line is not null)
                {
                    instructions.Add(line);
                }
            }
            Process1(instructions);
            Process2(instructions);
        }
        private static void Process2(List<string> instructions)
        {
            // Implémentation de la partie 2
            int dial = 50, password = 0;
            foreach (var instruction in instructions)
            {
                int count = int.Parse(instruction[1..]);
                password += (count / 100); // chaque tour complet ajoute 1 au mot de passe
                count %= 100;
                if (count == 0) continue;
                if (instruction[0] == 'L')
                {
                    if (dial != 0 && count >= dial) password++; // si on passe par 0, on ajoute 1 au mot de passe
                    dial = (dial - count + 100) % 100;
                }
                else if (instruction[0] == 'R')
                {
                    if (dial + count >= 100) password++; // si on passe par 0, on ajoute 1 au mot de passe
                    dial = (dial + count) % 100;
                }
                else
                {
                    Console.WriteLine($"Unknown instruction: {instruction}");
                }
            }
            Console.WriteLine($"Part2 : {password}");
        }
        private static void Process1(List<string> instructions)
        {
            int dial = 50, password = 0;
            foreach (var instruction in instructions)
            {
                int count = int.Parse(instruction[1..]);
                if (instruction[0] == 'L')
                {
                    dial = (dial - count + 100) % 100;
                }
                else if (instruction[0] == 'R')
                {
                    dial = (dial + count) % 100;
                }
                else
                {
                    Console.WriteLine($"Unknown instruction: {instruction}");
                }
                if (dial == 0)
                    password++;
            }
            Console.WriteLine(password);
        }
    }
}
