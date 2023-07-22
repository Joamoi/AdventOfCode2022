using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main()
        {
            string input = File.ReadAllText("input.txt");

            char[] inputChars = input.ToCharArray();

            // Part A
            Console.WriteLine("Part A:\n");

            for(int i = 0; i < (inputChars.Length - 3); i++)
            {
                if (inputChars[i] == inputChars [(i+1)] || inputChars[i] == inputChars[(i + 2)] || inputChars[i] == inputChars[(i + 3)])
                {
                    continue;
                }

                else if(inputChars[(i + 1)] == inputChars[(i + 2)] || inputChars[(i + 1)] == inputChars[(i + 3)])
                {
                    continue;
                }

                else if(inputChars[(i + 2)] == inputChars[(i + 3)])
                {
                    continue;
                }

                else
                {
                    Console.WriteLine("First marker after character: " + (i + 4));
                    Console.WriteLine("First marker: " + inputChars[i] + inputChars[(i + 1)] + inputChars[(i + 2)] + inputChars[(i + 3)]);
                    break;
                }
            }

            // Part B
            Console.WriteLine("\nPart B:\n");

            for (int i = 0; i < (inputChars.Length - 13); i++)
            {
                int counter = 0;

                for (int j = 0; j < 13; j++)
                {
                    for (int k = 1; k < 14; k++)
                    {
                        if (inputChars[(i+j)] != inputChars[(i + k)])
                        {
                            counter++;
                        }
                    }
                }

                if(counter == 157)
                {
                    Console.WriteLine("First marker after character: " + (i + 14));
                    Console.Write("First marker: ");

                    for (int l = 0; l < 14; l++)
                    {
                        Console.Write(inputChars[i+l]);
                    }

                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
