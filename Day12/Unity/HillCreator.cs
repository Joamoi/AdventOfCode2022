using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class HillCreator : EditorWindow
{
    SerializedProperty inputProp;
    SerializedProperty grassParentProp;
    SerializedProperty cliffParentProp;

    public TextAsset inputFile;
    public GameObject grassParent;
    public GameObject cliffParent;

    // creates ob creator tool to window menu

    [MenuItem("Window/Hill Creator")]
    static void Init()
    {
        HillCreator hillCreator = (HillCreator)EditorWindow.GetWindow(typeof(HillCreator));
        hillCreator.Show();
    }

    private void OnGUI()
    {
        SerializedObject serializedObject = new UnityEditor.SerializedObject(this);

        inputProp = serializedObject.FindProperty("inputFile");
        grassParentProp = serializedObject.FindProperty("grassParent");
        cliffParentProp = serializedObject.FindProperty("cliffParent");

        GUILayout.Label("");
        GUILayout.Label("Creates hills from cubes based on the input.");
        GUILayout.Label("");

        EditorGUILayout.PropertyField(inputProp, new GUIContent("Hill input txt file"));
        EditorGUILayout.PropertyField(grassParentProp, new GUIContent("Grass parent object"));
        EditorGUILayout.PropertyField(cliffParentProp, new GUIContent("Cliff parent object"));

        if (GUILayout.Button("Create hills"))
            CreateHills();

        serializedObject.ApplyModifiedProperties();
    }

    // creates collider cubes between ob markers

    public void CreateHills()
    {
        string input = inputFile.text;
        string[] inputLines = input.Split(new char[] { '\n' });

        for(int x = 0; x < inputLines.Length; x++)
        {
            string line = inputLines[x];

            for (int z = 0; z < line.Length; z++)
            {
                int y = Convert.ToInt32(line[z]) - 96;

                GameObject grass = GameObject.CreatePrimitive(PrimitiveType.Cube);
                grass.transform.position = new Vector3(x, y, z);
                grass.transform.parent = grassParent.transform;
                grass.name = line[z].ToString();

                for (int i = 1; i < y; i++)
                {
                    GameObject cliff = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cliff.transform.position = new Vector3(x, i, z);
                    cliff.transform.parent = cliffParent.transform;
                    cliff.name = "cliff";
                }
            }
        }
    }
}
