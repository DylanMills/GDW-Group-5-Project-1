using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomDungeonGenerator : AbstractRandomDungeonGenerator
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            RunGenoration();
        }
    }

    protected override void RunGenoration()
    {
        HashSet<Vector2Int> dungeonTiles = StartDungeonGenoration(randomDungeonGenorationParameters, startPos);
        builder.Clear();
        builder.PaintFloorTiles(dungeonTiles);
    }

    protected HashSet<Vector2Int> StartDungeonGenoration(RandomDungeonGeneratorObject parameters, Vector2Int pos)
    {
        var currentPos = pos;
        HashSet<Vector2Int> dungeonTiles = new HashSet<Vector2Int>();

        for (int i = 0; i < parameters.iterations; i++)
        {
            HashSet<Vector2Int> path = RandomDungeonGenerationAlgorithm.GenorateFloor(currentPos, parameters.walkLength);
            dungeonTiles.UnionWith(path);

            if (parameters.startRandomlyEachIteration)
            {
                currentPos = dungeonTiles.ElementAt(Random.Range(0, dungeonTiles.Count));
            }
        }

        interactibleObjectGenorator.GenorateDungeonObjects(dungeonTiles);

        dungeonTiles.UnionWith(RandomDungeonGenerationAlgorithm.GenorateWalls(dungeonTiles));

        if (genorateWithRandomColor)
        {
            float hue = Random.Range(0.0f, 1.0f);
            builder.ColorTilemap(Color.HSVToRGB(hue, saturation, value));
        }

        return dungeonTiles;
    }
}
