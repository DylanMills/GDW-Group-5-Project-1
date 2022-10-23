using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomDungeonGenorationParameters", menuName = "PCG/RandomDungeonGenorationData")]

public class RandomDungeonGeneratorObject : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;
}
