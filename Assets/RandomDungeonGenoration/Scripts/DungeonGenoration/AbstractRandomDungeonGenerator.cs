using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRandomDungeonGenerator : MonoBehaviour
{
    [Header("Base Parameters")]

    [SerializeField]
    protected TilemapBuilder builder = null;

    [SerializeField]
    protected Vector2Int startPos;

    [SerializeField]
    protected RandomDungeonGeneratorObject randomDungeonGenorationParameters;

    [Header("Color")]

    [SerializeField]
    protected bool genorateWithRandomColor;

    [SerializeField]
    [Range(0, 1)]
    protected float saturation;

    [SerializeField]
    [Range(0, 1)]
    protected float value;

    public void GenorateDungeon()
    {
        builder.Clear();
        builder.ColorTilemap(Color.white);
        RunGenoration();
    }

    public void Clear()
    {
        builder.Clear();
        builder.ColorTilemap(Color.white);
    }

    protected abstract void RunGenoration();
}
