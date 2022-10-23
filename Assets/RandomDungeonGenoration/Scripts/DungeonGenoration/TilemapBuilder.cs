using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapBuilder : MonoBehaviour
{
    [SerializeField]
    private Tilemap dungeonTileMap;

    [SerializeField]
    private TileBase tileBase;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPos)
    {
        PaintTiles(floorPos, dungeonTileMap, tileBase);
    }

    public void ColorTilemap(Color32 color)
    {
        dungeonTileMap.color = color;
        print(color);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tileMap, TileBase tile)
    {
        foreach (var pos in positions)
        {
            PaintSingleTile(tileMap, tile, pos);
        }
    }

    private void PaintSingleTile(Tilemap tileMap, TileBase tile, Vector2Int pos)
    {
        var tilePos = tileMap.WorldToCell((Vector3Int)pos);
        tileMap.SetTile(tilePos, tile);
    }

    public void Clear()
    {
        dungeonTileMap.ClearAllTiles();
    }
}
