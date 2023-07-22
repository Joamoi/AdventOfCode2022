using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    static int startX = 20;
    static int startZ = 0;
    static int goalX = 20;
    static int goalZ = 40;
    static int infValue = 999;

    static string[] inputLines;
    static int[,] tileHeights;
    static int[,] distanceToTile;
    static List<string> tilesToCheck = new List<string>();
    static List<string> nextTilesToCheck = new List<string>();
    static int currentX;
    static int currentZ;

    static void Main()
    {
        Start();
    }

    static void Start()
    {
        inputLines = File.ReadAllLines("input_modified.txt");

        tileHeights = new int[inputLines.Length, inputLines[0].Length];
        distanceToTile = new int[inputLines.Length, inputLines[0].Length];

        for (int x = 0; x < inputLines.Length; x++)
        {
            string line = inputLines[x];

            for (int z = 0; z < line.Length; z++)
            {
                tileHeights[x, z] = Convert.ToInt32(line[z]) - 96;
                distanceToTile[x, z] = infValue;
            }
        }

        currentX = startX;
        currentZ = startZ;
        distanceToTile[startX, startZ] = 0;
        tilesToCheck.Add(startX + "," + startZ);

        while (tilesToCheck.Count != 0)
        {
            foreach (string tile in tilesToCheck)
            {
                string[] coords = tile.Split(new char[] { ',' });
                currentX = int.Parse(coords[0]);
                currentZ = int.Parse(coords[1]);

                // Part B Rule
                if (tileHeights[currentX, currentZ] == 1)
                {
                    distanceToTile[currentX, currentZ] = 0;
                }

                Console.WriteLine("current: " + currentX + "," + currentZ + "\tdistance " + distanceToTile[currentX, currentZ]);

                AdjacentTiles();
            }

            if (distanceToTile[goalX, goalZ] != infValue)
            {
                Console.Write("Goal reached in " + distanceToTile[goalX, goalZ] + " steps");
                break;
            }

            tilesToCheck.Clear();

            foreach (string tile in nextTilesToCheck)
            {
                tilesToCheck.Add(tile);
            }

            nextTilesToCheck.Clear();

        }

        for (int x = 0; x < inputLines.Length; x++)
        {
            string line = inputLines[x];
            Console.Write("\n");

            for (int z = 0; z < line.Length; z++)
            {
                if(distanceToTile[x, z] > 99)
                    Console.Write(distanceToTile[x, z] + " ");
                else if (distanceToTile[x, z] > 9)
                    Console.Write(distanceToTile[x, z] + "  ");
                else
                    Console.Write(distanceToTile[x, z] + "   ");
            }
        }

        Console.ReadKey();
    }

    static void AdjacentTiles()
    {
        if (currentX != 0)
        {
            int diffL = tileHeights[(currentX - 1), currentZ] - tileHeights[(currentX), currentZ];
            if (diffL <= 1)
            {
                int distL = distanceToTile[currentX, currentZ] + 1;

                if (distL < distanceToTile[(currentX - 1), currentZ])
                {
                    distanceToTile[(currentX - 1), currentZ] = distL;
                    nextTilesToCheck.Add((currentX - 1) + "," + currentZ);

                    Console.WriteLine("left: " + (currentX - 1) + "," + currentZ + "\tdistance " + distL);
                }
            }
        }

        if (currentX != (inputLines.Length - 1))
        {
            int diffR = tileHeights[(currentX + 1), currentZ] - tileHeights[(currentX), currentZ];
            if (diffR <= 1)
            {
                int distR = distanceToTile[currentX, currentZ] + 1;

                if (distR < distanceToTile[(currentX + 1), currentZ])
                {
                    distanceToTile[(currentX + 1), currentZ] = distR;
                    nextTilesToCheck.Add((currentX + 1) + "," + currentZ);

                    Console.WriteLine("right: " + (currentX + 1) + "," + currentZ + "\tdistance " + distR);
                }
            }
        }

        if (currentZ != (inputLines[0].Length - 1))
        {
            int diffU = tileHeights[currentX, (currentZ + 1)] - tileHeights[(currentX), currentZ];
            if (diffU <= 1)
            {
                int distU = distanceToTile[currentX, currentZ] + 1;

                if (distU < distanceToTile[currentX, (currentZ + 1)])
                {
                    distanceToTile[currentX, (currentZ + 1)] = distU;
                    nextTilesToCheck.Add(currentX + "," + (currentZ + 1));

                    Console.WriteLine("up: " + currentX + "," + (currentZ + 1) + "\tdistance " + distU);
                }
            }
        }

        if (currentZ != 0)
        {
            int diffD = tileHeights[currentX, (currentZ - 1)] - tileHeights[(currentX), currentZ];
            if (diffD <= 1)
            {
                int distD = distanceToTile[currentX, currentZ] + 1;

                if (distD < distanceToTile[currentX, (currentZ - 1)])
                {
                    distanceToTile[currentX, (currentZ - 1)] = distD;
                    nextTilesToCheck.Add(currentX + "," + (currentZ - 1));

                    Console.WriteLine("down: " + currentX + "," + (currentZ - 1) + "\tdistance " + distD);
                }
            }
        }
    }
}
