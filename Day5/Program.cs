using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main()
        {
            string[] moves = File.ReadAllLines("moves.txt");

            int[] amount = new int[moves.Length];
            int[] from = new int[moves.Length];
            int[] to = new int[moves.Length];

            for (int i = 0; i < moves.Length; i++)
            {
                string[] line = moves[i].Split(new char[] { ' ' });

                amount[i] = int.Parse(line[1]);
                from[i] = int.Parse(line[3]);
                to[i] = int.Parse(line[5]);
            }

            // Part A

            string[] stacks = File.ReadAllLines("stacks.txt");

            for (int i = 0; i < moves.Length; i++)
            {
                for (int j = 0; j < amount[i]; j++)
                {
                    char movable = stacks[(from[i] - 1)].Last();
                    stacks[(from[i] - 1)] = stacks[(from[i] - 1)].Remove((stacks[(from[i] - 1)].Length - 1));
                    stacks[(to[i] - 1)] += movable;
                }
            }

            string answer = "";

            for (int i = 0; i < stacks.Length; i++)
            {
                answer += stacks[i].Last();
            }

            Console.WriteLine("Crates at the top of each stack with single lifts: " + answer);

            // Part B

            stacks = File.ReadAllLines("stacks.txt");

            for (int i = 0; i < moves.Length; i++)
            {
                string movable = stacks[(from[i] - 1)].Remove(0, (stacks[(from[i] - 1)].Length - amount[i]));
                stacks[(from[i] - 1)] = stacks[(from[i] - 1)].Remove((stacks[(from[i] - 1)].Length - amount[i]));
                stacks[(to[i] - 1)] += movable;
            }

            answer = "";

            for (int i = 0; i < stacks.Length; i++)
            {
                answer += stacks[i].Last();
            }

            Console.WriteLine("Crates at the top of each stack with multilifts: " + answer);
            Console.ReadKey();
        }
    }
}
