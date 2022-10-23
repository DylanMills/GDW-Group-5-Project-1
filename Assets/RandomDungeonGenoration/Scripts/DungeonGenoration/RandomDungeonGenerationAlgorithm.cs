using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public static class RandomDungeonGenerationAlgorithm
{
    public static HashSet<Vector2Int> GenorateFloor(Vector2Int startPos, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var previouspos = startPos;

        for (int i = 0; i < walkLength; i++)
        {
            var newPos = previouspos + Direction2D.GetRandomDirection();
            path.Add(newPos);
            previouspos = newPos;
        }

        return path;
    }

    public static HashSet<Vector2Int> GenorateWalls(HashSet<Vector2Int> floorPos)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();

        foreach (Vector2Int pos in floorPos)
        {
            foreach (Vector2Int dir in Direction2D.dirList)
            {
                Vector2Int neighborPos = pos + dir;

                if (!floorPos.Contains(neighborPos))
                {
                    wallPos.Add(neighborPos);

                    if (dir == Vector2Int.up || dir == Vector2Int.down)
                    {
                        wallPos.Add(neighborPos + Vector2Int.right);
                        wallPos.Add(neighborPos + Vector2Int.left);
                    }
                    else // dir == left or right
                    {
                        wallPos.Add(neighborPos + Vector2Int.up);
                        wallPos.Add(neighborPos + Vector2Int.down);
                    }
                }
            }
        }

        return wallPos;
    }

    public static List<Vector2Int> GenorateCorridors(Vector2Int startPos, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        Vector2Int dir = Direction2D.GetRandomDirection();
        Vector2Int currentPos = startPos;

        corridor.Add(currentPos);

        for (int i = 0; i < corridorLength; i++)
        {
            currentPos += dir;
            corridor.Add(currentPos);
        }

        return corridor;
    }
}

public static class Direction2D
{
    //direction list stores the four cardinal directions
    public static List<Vector2Int> dirList = new List<Vector2Int>
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public static Vector2Int GetRandomDirection()
    {
        //Retern a random direction from the direction list 
        return dirList[Random.Range(0, dirList.Count)];
    }
}
