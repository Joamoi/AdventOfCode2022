using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public TextAsset inputFile;
    public Transform rootDir;
    public GameObject emptyObject;

    // Start is called before the first frame update
    void Start()
    {
        // Creating directories and files

        string input = inputFile.text;
        string[] inputLines = input.Split(new char[] { '\n' });

        Transform currentDir = gameObject.transform;
        List<Transform> dirs = new List<Transform>();

        for(int i = 0; i < inputLines.Length; i++)
        {
            string line = inputLines[i];
            string[] lineParts = line.Split(new char[] { ' ' });

            if (lineParts[0].ToString() == "$")
            {
                if (lineParts[1].ToString() == "cd")
                {
                    if (line[5] == '/')
                        currentDir = rootDir;

                    else if (line[5] == '.')
                        currentDir = currentDir.parent;

                    else
                        currentDir = currentDir.Find(lineParts[2]);
                }

                else
                    continue;
            }

            else if((line[0].ToString() == "d"))
            {
                GameObject newDir = Instantiate(emptyObject, currentDir);
                newDir.name = lineParts[1];
                newDir.AddComponent<ObjectInfo>().type = 1;
                dirs.Add(newDir.transform);
            }

            else
            {
                GameObject newFile = Instantiate(emptyObject, currentDir);
                newFile.name = lineParts[1];
                newFile.AddComponent<ObjectInfo>().size = int.Parse(lineParts[0]);
            }
        }

        // Part A
        Debug.Log("Part A");

        int sum = 0;
        int size = 0;

        for (int i = 0; i < dirs.Count; i++)
        {
            size = 0;

            foreach (Transform a in dirs[i].GetComponentsInChildren<Transform>())
            {
                size += a.gameObject.GetComponent<ObjectInfo>().size;

                if (size > 100000)
                    break;
            }

            if (size > 100000)
                continue;

            sum += size;
            Debug.Log("dir " + dirs[i].name + " size: " + size);
        }

        Debug.Log("Sum: " + sum);

        // Part B
        Debug.Log("Part B");

        size = 0;

        foreach (Transform a in rootDir.GetComponentsInChildren<Transform>())
        {
            size += a.gameObject.GetComponent<ObjectInfo>().size;
        }

        int freeSpace = 70000000 - size;
        int neededSpace = 30000000 - freeSpace;

        Debug.Log("/ size: " + size);
        Debug.Log("free space: " + freeSpace);
        Debug.Log("needed space: " + neededSpace);

        List<int> largeDirs = new List<int>();

        for (int i = 0; i < dirs.Count; i++)
        {
            size = 0;

            foreach (Transform a in dirs[i].GetComponentsInChildren<Transform>())
            {
                size += a.gameObject.GetComponent<ObjectInfo>().size;
            }

            if (size < neededSpace)
                continue;

            Debug.Log("dir " + dirs[i].name + " size: " + size);
            largeDirs.Add(size);
        }

        largeDirs.Sort();

        Debug.Log("smallest of the large enough dirs: " + largeDirs[0]);
    }
}
