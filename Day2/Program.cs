using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main()
        {
            string[] inputString = File.ReadAllLines("input.txt");

            Console.WriteLine("Number of games: " + inputString.Length);

            int[] opp = new int[inputString.Length];
            int[] own = new int[inputString.Length];

            // convert letters to numbers 1, 2 and 3 for easier calculation
            for(int i = 0; i < inputString.Length; i++)
            {
                string[] line = inputString[i].Split(' ');
                opp[i] = char.Parse(line[0]) - 64;
                own[i] = char.Parse(line[1]) - 87;
            }

            // Part A

            int total = 0;

            for (int i = 0; i < own.Length; i++)
            {
                total += own[i];

                if (opp[i] == own[i])
                    total += 3;
                else if ((opp[i] + 1) == own[i] || (opp[i] - 2) == own[i])
                    total += 6;
            }

            Console.WriteLine("Total score in Part A: " + total);

            // Part B

            total = 0;

            for (int i = 0; i < own.Length; i++)
            {
                if (own[i] == 3)
                {
                    if (opp[i] == 3)
                        total += 7;
                    else
                        total += opp[i] + 7;
                }

                else if (own[i] == 1)
                {
                    if (opp[i] == 1)
                        total += 3;
                    else
                        total += opp[i] - 1;
                }

                else
                    total += opp[i] + 3;
            }

            Console.WriteLine("\nTotal score in Part B: " + total);
            Console.ReadKey();
        }
    }
}
