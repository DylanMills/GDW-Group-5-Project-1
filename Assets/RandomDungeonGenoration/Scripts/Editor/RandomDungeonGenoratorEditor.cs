using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractRandomDungeonGenerator), true)]

public class RandomDungeonGenoratorEditor : Editor
{
    AbstractRandomDungeonGenerator generator;

    private void Awake()
    {
        generator = (AbstractRandomDungeonGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Create Dungeon"))
        {
            generator.GenorateDungeon();
        }

        if (GUILayout.Button("Clear"))
        {
            generator.Clear();
        }
    }
}
