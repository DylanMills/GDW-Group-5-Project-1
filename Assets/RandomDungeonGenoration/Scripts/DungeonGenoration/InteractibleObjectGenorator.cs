using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class InteractibleObjectGenorator : MonoBehaviour
{
    [SerializeField]
    private InteractableObject[] interactableObjects;

    [SerializeField]
    private Transform interactableObjectPartent;

    public void GenorateDungeonObjects(HashSet<Vector2Int> dungeonFloor)
    {
        Clear();

        foreach (InteractableObject obj in interactableObjects)
        {
            if (!obj.genorateSetAmount)
            {
                HashSet<Vector2Int> createdObjectPos = new HashSet<Vector2Int>();

                int createObjectCount = Mathf.RoundToInt(dungeonFloor.Count * obj.objectToRoomPercent);
                List<Vector2Int> createObjects = dungeonFloor.OrderBy(x => Guid.NewGuid()).Take(createObjectCount).ToList();

                foreach (Vector2Int pos in createObjects)
                {
                    bool spaceOcupied = false;

                    //Check if object neigbors a preexisting instance of object
                    foreach (Vector2Int dir in Direction2D.dirList)
                    {
                        if (createdObjectPos.Contains(pos + dir))
                            spaceOcupied = true;

                        if (dir == Vector2Int.up || dir == Vector2Int.down)
                        {
                            if (createdObjectPos.Contains(pos + dir + Vector2Int.right))
                                spaceOcupied = true;
                            if (createdObjectPos.Contains(pos + dir + Vector2Int.left))
                                spaceOcupied = true;
                        }
                        else
                        {
                            if (createdObjectPos.Contains(pos + dir + Vector2Int.up))
                                spaceOcupied = true;
                            if (createdObjectPos.Contains(pos + dir + Vector2Int.down))
                                spaceOcupied = true;
                        }
                    }

                    if (!spaceOcupied)
                    {
                        Instantiate(obj.prefab, new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), Quaternion.identity, interactableObjectPartent);
                        createdObjectPos.Add(pos);
                    }
                }
            }
            else
            {
                int createObjectCount = Mathf.RoundToInt(dungeonFloor.Count * obj.objectToRoomPercent);
                List<Vector2Int> createObjects = dungeonFloor.OrderBy(x => Guid.NewGuid()).Take(obj.genorateAmount).ToList();

                foreach (Vector2Int pos in createObjects)
                {
                    Instantiate(obj.prefab, new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), Quaternion.identity, interactableObjectPartent);
                }
            }
        }
    }

    public void Clear()
    {
        foreach (Transform obj in interactableObjectPartent.transform)
        {
            DestroyImmediate(obj.gameObject);
        }

        if (interactableObjectPartent.transform.childCount > 0)
        {
            Clear();
        }
    }
}
