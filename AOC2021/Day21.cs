using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

namespace AOC2021
{
    public class Day21
    {
        public static void Main()
        {
            var input = @"Player 1 starting position: 4
Player 2 starting position: 6";
            int player1 = 4;
            int player2 = 6;
            Play(4, 8, 1000);
            Play(player1, player2, 1000);
            PlayDirac(4, 8, 21);
            PlayDirac(player1, player2, 21);

        }

        private static void PlayDirac(int player1, int player2, int target)
        {
            #region initialize dirac possible results
            // {1,2,3} x {1,2,3} x {1,2,3} => {2:1, 3:2, 4:3, 5:2, 6:1} x {1,2,3}
            // => {3:1,4:3,5:6,6:7,7:6,8:3,9:1}
            var diracRolls = new Dictionary<int, int>();
            diracRolls.Add(3, 1);
            diracRolls.Add(4, 3);
            diracRolls.Add(5, 6);
            diracRolls.Add(6, 7);
            diracRolls.Add(7, 6);
            diracRolls.Add(8, 3);
            diracRolls.Add(9, 1);
            //diracRolls.Add(1, 1);
            //diracRolls.Add(2, 1);
            //diracRolls.Add(3, 1);
            #endregion

            long winner1 = 0;
            long winner2 = 0;

            int position1 = player1 - 1, position2 = player2 - 1;
            int score1 = 0, score2 = 0, s12 = 0, s1 = 0, s2 = 0, p1 = 0, p2 = 0;
            bool first = true, currentPlayerFirst;
            var games = new SortedDictionary<(int s12, int p1, int p2, int s1, int s2, bool first), long>();
            Add(1);
            while (games.Count > 0)
            {
                var f = games.First();
                games.Remove(f.Key);
                (_, p1, p2, s1, s2, currentPlayerFirst) = f.Key;
                first = !currentPlayerFirst; // it will be the other player to save...
                position1 = p1;
                position2 = p2;
                score1 = s1;
                score2 = s2;
                // initialize, and we will override what we need in the loop
                foreach (var kvp in diracRolls)
                {
                    // As I already flipped first, if true, we are with second
                    if (currentPlayerFirst)
                    {
                        position1 = (p1 + kvp.Key) % 10;
                        score1 = s1 + position1 + 1;
                        if (score1 >= target)
                        {
                            winner1 += f.Value * kvp.Value;
                        }
                        else
                            Add(f.Value * kvp.Value);
                    }
                    else
                    {
                        position2 = (p2 + kvp.Key) % 10;
                        score2 = s2 + position2 + 1;
                        if (score2 >= target)
                        {
                            winner2 += f.Value * kvp.Value;
                        }
                        else
                            Add(f.Value * kvp.Value);
                    }
                }
            }

            Console.WriteLine($"player1 wins {winner1}\nplayer2 wins {winner2}");

            void Add(long total)
            {
                var key = (score1 + score2, position1, position2, score1, score2, first);
                if (games.TryGetValue(key, out var count))
                {
                    games[key] = count + total;
                    return;
                }
                games[key] = total;
            }
        }


        private static void Play(int player1, int player2, long target)
        {
            int position1 = player1 - 1;
            int position2 = player2 - 1;
            long turn = 0;
            long score1 = 0, score2 = 0;
            int dice = 1;
            int diceMax = 100;
            bool first = true;
            while (score1 < target && score2 < target)
            {
                turn += 3;
                var run = RollDice() + RollDice() + RollDice();
                if (first)
                {
                    position1 = (position1 + run) % 10;
                    score1 += position1 + 1;
                }
                else
                {
                    position2 = (position2 + run) % 10;
                    score2 += position2 + 1;
                }
                first = !first;
            }
            Console.WriteLine(turn * Math.Min(score1, score2));

            int RollDice()
            {
                var d = dice;
                dice++;
                if (dice > 100) dice -= 100;
                return d;
            }
        }
    }
}
