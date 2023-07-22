using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main()
        {
            string[] inputLines = File.ReadAllLines("input.txt");

            int counterA = 0;
            int counterB = 0;

            for(int i = 0; i < inputLines.Length; i++)
            {
                string[] line = inputLines[i].Split(new char[] { ',' });
                string[] pair1 = line[0].Split(new char[] { '-' });
                string[] pair2 = line[1].Split(new char[] { '-' });
                int pair1Min = int.Parse(pair1[0]);
                int pair1Max = int.Parse(pair1[1]);
                int pair2Min = int.Parse(pair2[0]);
                int pair2Max = int.Parse(pair2[1]);

                if ((pair1Min <= pair2Min && pair1Max >= pair2Max) || (pair2Min <= pair1Min && pair2Max >= pair1Max))
                {
                    counterA++;
                }

                if((pair1Max >= pair2Min && pair1Max <= pair2Max) || (pair1Min >= pair2Min && pair1Min <= pair2Max) || (pair2Max >= pair1Min && pair2Max <= pair1Max) || (pair2Min >= pair1Min && pair2Min <= pair1Max))
                {
                    counterB++;
                }
            }

            Console.WriteLine("Full overlaps in pairs in total: " + counterA);
            Console.WriteLine("Partial overlaps in pairs in total: " + counterB);
            Console.ReadKey();
        }
    }
}
