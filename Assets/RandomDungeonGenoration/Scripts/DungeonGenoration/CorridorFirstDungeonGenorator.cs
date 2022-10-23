using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CorridorFirstDungeonGenorator : RandomDungeonGenerator
{
    [Header("Corridor Parameters")]

    [SerializeField]
    private int corridorLength = 14;

    [SerializeField]
    int corridorCount = 5;

    [SerializeField]
    [Range(0f, 1f)]
    private float roomPercent = 0.8f;

    protected override void RunGenoration()
    {
        StartDungeonGenoration();
    }

    private void StartDungeonGenoration()
    {
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPos = new HashSet<Vector2Int>();

        CreateCorridors(floorPos, potentialRoomPos);

        floorPos.UnionWith(CreateRooms(FindAllDeadEnds(floorPos)));

        floorPos.UnionWith(CreateRooms(potentialRoomPos));

        floorPos.UnionWith(RandomDungeonGenerationAlgorithm.GenorateWalls(floorPos));

        builder.PaintFloorTiles(floorPos);

        if (genorateWithRandomColor)
        {
            float hue = Random.Range(0.0f, 1.0f);
           // print(hue);
            builder.ColorTilemap(Color.HSVToRGB(hue, saturation, value));
        }
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPos)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();

        foreach (Vector2Int pos in floorPos)
        {
            int neighboursCount = 0;

            foreach (Vector2Int dir in Direction2D.dirList)
            {
                if (floorPos.Contains(pos + dir))
                {
                    neighboursCount++;
                }
            }

            if (neighboursCount == 1)
            {
                deadEnds.Add(pos);
            }
        }

        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPos)
    {
        HashSet<Vector2Int> rooms = new HashSet<Vector2Int>();

        int roomCreateCount = Mathf.RoundToInt(potentialRoomPos.Count * roomPercent);

        List<Vector2Int> createRooms = potentialRoomPos.OrderBy(x => Guid.NewGuid()).Take(roomCreateCount).ToList();

        foreach (Vector2Int pos in createRooms)
        {
            HashSet<Vector2Int> roomFloor = StartDungeonGenoration(randomDungeonGenorationParameters, pos);
            rooms.UnionWith(roomFloor);
        }

        return rooms;
    }

    private HashSet<Vector2Int> CreateRooms(List<Vector2Int> roomPos)
    {
        HashSet<Vector2Int> rooms = new HashSet<Vector2Int>();

        foreach (Vector2Int pos in roomPos)
        {
            HashSet<Vector2Int> roomFloor = StartDungeonGenoration(randomDungeonGenorationParameters, pos);
            rooms.UnionWith(roomFloor);
        }

        return rooms;
    }

    private void CreateCorridors(HashSet<Vector2Int> dungeonTiles, HashSet<Vector2Int> potentialRoomPos)
    {
        Vector2Int currentPos = startPos;
        potentialRoomPos.Add(currentPos);

        for (int i = 0; i < corridorCount; i++)
        {
            List<Vector2Int> corridor = RandomDungeonGenerationAlgorithm.GenorateCorridors(currentPos, corridorLength);
            currentPos = corridor[corridor.Count - 1];
            potentialRoomPos.Add(currentPos);

            dungeonTiles.UnionWith(corridor);
        }
    }
}
