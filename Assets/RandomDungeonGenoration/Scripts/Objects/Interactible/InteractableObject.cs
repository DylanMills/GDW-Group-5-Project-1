using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractibleObjectParameters", menuName = "PCG/InteractibleGenorationData")]

public class InteractableObject : ScriptableObject
{
    public GameObject prefab;

    [Range(0f, 0.1f)]
    public float objectToRoomPercent = 0f;
}
