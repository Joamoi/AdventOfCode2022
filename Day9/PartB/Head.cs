using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public GameObject tailObject;
    public TextAsset inputFile;
    public static float interval = 0f;

    string input;
    string[] inputLines;
    string[] dir;
    int[] dist;
    int[] headX;
    int[] headY;

    // Start is called before the first frame update
    void Start()
    {
        input = inputFile.text;
        inputLines = input.Split(new char[] { '\n' });

        dir = new string[(inputLines.Length + 1)];
        dist = new int[(inputLines.Length + 1)];

        headX = new int[(inputLines.Length + 1)];
        headY = new int[(inputLines.Length + 1)];

        headX[0] = 0;
        headY[0] = 0;

        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        for (int i = 1; i < (inputLines.Length + 1); i++)
        {
            string[] linePart = inputLines[(i - 1)].Split(new char[] { ' ' });
            dir[i] = linePart[0];
            dist[i] = int.Parse(linePart[1]);

            headX[i] = headX[(i - 1)];
            headY[i] = headY[(i - 1)];

            if (dir[i] == "L")
            {
                int goalX = headX[i] - dist[i];

                do
                {
                    yield return new WaitForSeconds(interval);
                    headX[i]--;
                    transform.position = new Vector2(headX[i], headY[i]);

                } while (headX[i] != goalX);
            }

            else if (dir[i] == "R")
            {
                int goalX = headX[i] + dist[i];

                do
                {
                    yield return new WaitForSeconds(interval);
                    headX[i]++;
                    transform.position = new Vector2(headX[i], headY[i]);

                } while (headX[i] != goalX);
            }

            else if (dir[i] == "U")
            {
                int goalY = headY[i] + dist[i];

                do
                {
                    yield return new WaitForSeconds(interval);
                    headY[i]++;
                    transform.position = new Vector2(headX[i], headY[i]);

                } while (headY[i] != goalY);
            }

            else if (dir[i] == "D")
            {
                int goalY = headY[i] - dist[i];

                do
                {
                    yield return new WaitForSeconds(interval);
                    headY[i]--;
                    transform.position = new Vector2(headX[i], headY[i]);

                } while (headY[i] != goalY);
            }
        }

        yield return new WaitForSeconds(1f);

        Tail tail = tailObject.GetComponent<Tail>();
        tail.ShowResults();
    }
}
