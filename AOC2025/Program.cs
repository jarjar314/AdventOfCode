using System;

namespace AOC2025
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("AOC2025 — Running Days 1..12");

            var asm = typeof(Program).Assembly;
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"--- Day {i} ---");
                try
                {
                    var type = asm.GetType($"AOC2025.Day{i}");
                    if (type is null)
                    {
                        Console.WriteLine("Not implemented.");
                        continue;
                    }

                    var method = type.GetMethod("Run", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    if (method is null)
                    {
                        Console.WriteLine("No public static Run() found.");
                        continue;
                    }

                    method.Invoke(null, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}