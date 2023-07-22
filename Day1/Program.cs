using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day1
{
    class Program
    {
        static void Main()
        {
            string[] inputString = File.ReadAllLines("input.txt");
            List<int> totals = new List<int>();

            totals.Add(0);
            int j = 0;

            for(int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] != "")
                {
                    totals[j] += int.Parse(inputString[i]);
                }

                else
                {
                    totals.Add(0);
                    j++;
                }
            }

            totals.Sort();

            for (int i = 0; i < totals.Count; i++)
            {
                Console.WriteLine(totals[i]);
            }

            Console.WriteLine("\nNumber of elves: " + totals.Count);
            Console.WriteLine("Biggest food amount: " + totals[totals.Count - 1]);

            int top3 = totals[totals.Count - 1] + totals[totals.Count - 2] + totals[totals.Count - 3];

            Console.WriteLine("Food amount of top 3: " + top3);

            // Linq version

            Console.WriteLine("\nLinq version:\n");

            Console.WriteLine("Biggest food amount: " + File.ReadAllText("input.txt").Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Select(y => int.Parse(y)).Sum()).Max());

            Console.WriteLine("Food amount of top 3: " + File.ReadAllText("input.txt").Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Select(y => int.Parse(y)).OrderByDescending(y => y).Take(3).Sum()));

            Console.ReadKey();
        }
    }
}
