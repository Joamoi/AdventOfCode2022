using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Route : MonoBehaviour
{
    public TextAsset inputFile;
    public int startX = 20;
    public int startZ = 0;
    public int goalX = 20;
    public int goalZ = 40;
    public int infValue = 9999;

    string input;
    string[] inputLines;
    int[,] tileHeights;
    int[,] distanceToTile;
    List<string> tilesToCheck = new List<string>();
    List<string> nextTilesToCheck = new List<string>();
    int currentX;
    int currentZ;

    public GameObject player;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        input = inputFile.text;
        inputLines = input.Split(new char[] { '\n' });

        tileHeights = new int[inputLines.Length,inputLines[0].Length];
        distanceToTile = new int[inputLines.Length, inputLines[0].Length];

        for (int x = 0; x < inputLines.Length; x++)
        {
            string line = inputLines[x];

            for (int z = 0; z < line.Length; z++)
            {
                tileHeights[x,z] = Convert.ToInt32(line[z]) - 96;
                distanceToTile[x, z] = infValue;
            }
        }

        currentX = startX;
        currentZ = startZ;
        distanceToTile[startX, startZ] = 0;
        tilesToCheck.Add(startX + "," + startZ);

        StartCoroutine("Loop");
    }

    IEnumerator Loop()
    {
        while (tilesToCheck.Count != 0)
        {
            foreach (string tile in tilesToCheck)
            {
                string[] coords = tile.Split(new char[] { ',' });
                currentX = int.Parse(coords[0]);
                currentZ = int.Parse(coords[1]);

                // visualization
                yield return new WaitForSeconds(interval);
                player.transform.position = new Vector3(currentX, (tileHeights[currentX, currentZ] + 1.5f), currentZ);

                // Part B Rule
                //if (tileHeights[currentX, currentZ] == 1)
                //{
                //    distanceToTile[currentX, currentZ] = 0;
                //}

                Debug.Log("current: " + currentX + "," + currentZ + "\tdistance " + distanceToTile[currentX, currentZ]);

                AdjacentTiles();
            }

            if (distanceToTile[goalX, goalZ] != infValue)
            {
                Debug.Log("Goal reached in " + distanceToTile[goalX, goalZ] + " steps");
                break;
            }

            tilesToCheck.Clear();

            foreach (string tile in nextTilesToCheck)
            {
                tilesToCheck.Add(tile);
            }

            nextTilesToCheck.Clear();
        }
    }

    void AdjacentTiles()
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

                    Debug.Log("left: " + (currentX - 1) + "," + currentZ + "\tdistance " + distL);
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

                    Debug.Log("right: " + (currentX + 1) + "," + currentZ + "\tdistance " + distR);
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

                    Debug.Log("up: " + currentX + "," + (currentZ + 1) + "\tdistance " + distU);
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

                    Debug.Log("down: " + currentX + "," + (currentZ - 1) + "\tdistance " + distD);
                }
            }
        }
    }
}
