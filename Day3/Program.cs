using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main()
        {
            string[] inputLines = File.ReadAllLines("input.txt");

            // Part A

            int sum = 0;

            for(int i = 0; i < inputLines.Length; i++)
            {
                string comp1 = inputLines[i].Substring(0, (inputLines[i].Length / 2));
                string comp2 = inputLines[i].Substring((inputLines[i].Length / 2), (inputLines[i].Length / 2));

                char[] chars1 = comp1.ToCharArray();
                char[] chars2 = comp2.ToCharArray();

                for (int j = 0; j < chars1.Length; j++)
                {
                    for (int k = 0; k < chars2.Length; k++)
                    {
                        if (chars1[j] == chars2[k])
                        {
                            int error = Convert.ToInt32(chars1[j]);

                            if (error > 95)
                                error -= 96;
                            else
                                error -= 38;

                            sum += error;

                            goto NextLine;
                        }
                    }
                }

            NextLine:;

            }

            Console.WriteLine("Sum of values of error letters: " + sum);

            // Part B

            sum = 0;

            for (int i = 0; i < inputLines.Length; i += 3)
            {
                char[] chars1 = inputLines[i].ToCharArray();
                char[] chars2 = inputLines[(i+1)].ToCharArray();
                char[] chars3 = inputLines[(i+2)].ToCharArray();

                for (int j = 0; j < chars1.Length; j++)
                {
                    for (int k = 0; k < chars2.Length; k++)
                    {
                        for (int l = 0; l < chars3.Length; l++)
                        {
                            if (chars1[j] == chars2[k] && chars1[j] == chars3[l])
                            {
                                int error = Convert.ToInt32(chars1[j]);

                                if (error > 95)
                                    error -= 96;
                                else
                                    error -= 38;

                                sum += error;

                                goto NextLine;
                            }
                        }
                    }
                }

            NextLine:;

            }

            Console.WriteLine("Sum of values of badge letters: " + sum);
            Console.ReadKey();
        }
    }
}
