using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main()
        {
            string[] inputLines = File.ReadAllLines("input.txt");

            string[] dir = new string[inputLines.Length];
            int[] dist = new int[inputLines.Length];

            int[] headX= new int[(inputLines.Length + 1)];
            int[] headY = new int[(inputLines.Length + 1)];
            int[] tailX = new int[(inputLines.Length + 1)];
            int[] tailY = new int[(inputLines.Length + 1)];

            headX[0] = 0;
            headY[0] = 0;
            tailX[0] = 0;
            tailY[0] = 0;

            Console.WriteLine("Part A\n");

            // head

            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] linePart = inputLines[i].Split(new char[] { ' ' });
                dir[i] = linePart[0];
                dist[i] = int.Parse(linePart[1]);

                if(dir[i] == "L")
                {
                    headX[(i + 1)] = headX[i] - dist[i];
                    headY[(i + 1)] = headY[i];
                }

                else if (dir[i] == "R")
                {
                    headX[(i + 1)] = headX[i] + dist[i];
                    headY[(i + 1)] = headY[i];
                }

                else if (dir[i] == "U")
                {
                    headY[(i + 1)] = headY[i] + dist[i];
                    headX[(i + 1)] = headX[i];
                }

                else if (dir[i] == "D")
                {
                    headY[(i + 1)] = headY[i] - dist[i];
                    headX[(i + 1)] = headX[i];
                }
            }

            List<string> tailCoord = new List<string>();
            tailCoord.Add("0,0");

            // tail

            for (int i = 1; i < headX.Length; i++)
            {
                tailX[i] = tailX[(i - 1)];
                tailY[i] = tailY[(i - 1)];

                if (Math.Abs(headX[i] - tailX[i]) >= 2 && Math.Abs(headY[i] - tailY[i]) == 1)
                {
                    int goalX = tailX[i] + Math.Sign(headX[i] - tailX[i]) * (Math.Abs(headX[i] - tailX[i]) - 1);
                    tailY[i] = headY[i];

                    do
                    {
                        tailX[i] += Math.Sign(headX[i] - tailX[i]) * 1;
                        tailCoord.Add(tailX[i] + "," + tailY[i]);

                    } while (tailX[i] != goalX);
                }

                else if (Math.Abs(headX[i] - tailX[i]) == 1 && Math.Abs(headY[i] - tailY[i]) >= 2)
                {
                    tailX[i] = headX[i];
                    int goalY = tailY[i] + Math.Sign(headY[i] - tailY[i]) * (Math.Abs(headY[i] - tailY[i]) - 1);

                    do
                    {
                        tailY[i] += Math.Sign(headY[i] - tailY[i]) * 1;
                        tailCoord.Add(tailX[i] + "," + tailY[i]);

                    } while (tailY[i] != goalY);
                }

                else if (Math.Abs(headX[i] - tailX[i]) >= 2)
                {
                    int goalX = tailX[i] + Math.Sign(headX[i] - tailX[i]) * (Math.Abs(headX[i] - tailX[i]) - 1);

                    do
                    {
                        tailX[i] += Math.Sign(headX[i] - tailX[i]) * 1;
                        tailCoord.Add(tailX[i] + "," + tailY[i]);

                    } while (tailX[i] != goalX);
                    
                }

                else if (Math.Abs(headY[i] - tailY[i]) >= 2)
                {
                    int goalY = tailY[i] + Math.Sign(headY[i] - tailY[i]) * (Math.Abs(headY[i] - tailY[i]) - 1);

                    do
                    {
                        tailY[i] += Math.Sign(headY[i] - tailY[i]) * 1;
                        tailCoord.Add(tailX[i] + "," + tailY[i]);

                    } while (tailY[i] != goalY);
                }
            }

            Console.WriteLine("amount of tail positions: " + tailCoord.Count);

            string[] uniqueTailCoord = tailCoord.Distinct().ToArray();

            Console.WriteLine("\namount of unique tail positions: " + uniqueTailCoord.Length);

            // Part B done in Unity

            Console.ReadKey();
        }
    }
}
