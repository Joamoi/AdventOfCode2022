using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main()
        {
            string[] inputLines = File.ReadAllLines("input.txt");

            int addx1;

            int x = 1;
            int x2 = 1;
            int c = 1;
            int pos;
            List<int> ss = new List<int>();
            List<string> pixels = new List<string>();

            for (int i = 1; i < (inputLines.Length + 1); i++)
            {
                if (c == 20 || c == 60 || c == 100 || c == 140 || c == 180 || c == 220)
                {
                    ss.Add((c * x));
                    Console.WriteLine("Cycle " + c + ", signal strength " + x);
                }

                if (c == 41 || c == 81 || c == 121 || c == 161 || c == 201)
                {
                    x2 += 40;
                }

                pos = c - 1;

                if (Math.Abs(x2 - pos) <= 1)
                    pixels.Add("#");
                else
                    pixels.Add(".");

                Console.WriteLine("pos " + pos + ", x " + x2 + ", pixel " + pixels.Last());

                string line = inputLines[(i - 1)];

                if (line != "noop")
                {
                    string[] linePart = line.Split(new char[] { ' ' });
                    addx1 = int.Parse(linePart[1]);
                    c++;

                    if (c == 41 || c == 81 || c == 121 || c == 161 || c == 201)
                    {
                        x2 += 40;
                    }

                    pos = c - 1;

                    if (Math.Abs(x2 - pos) <= 1)
                        pixels.Add("#");
                    else
                        pixels.Add(".");

                    Console.WriteLine("pos " + pos + ", x " + x2 + ", pixel " + pixels.Last());
                }

                else
                    addx1 = 0;

                if (c == 20 || c == 60 || c == 100 || c == 140 || c == 180 || c == 220)
                {
                    ss.Add((c * x));
                    Console.WriteLine("Cycle " + c + ", signal strength " + x);
                }

                x += addx1;
                x2 += addx1;

                c++;
            }

            Console.WriteLine("\nSum of signal strengths: " + ss.Sum());
            Console.WriteLine("\nAmount of pixels: " + pixels.Count);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Console.Write(pixels[(i*40 + j)]);
                }

                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}