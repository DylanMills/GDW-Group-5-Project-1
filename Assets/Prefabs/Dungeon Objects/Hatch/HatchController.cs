using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchController : MonoBehaviour
{
    CorridorFirstDungeonGenorator genorator;
    Transform player;

    [SerializeField]
    float range = 2;

    private void Awake()
    {
        genorator = FindObjectOfType<CorridorFirstDungeonGenorator>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && (player.position - transform.position).magnitude <= range)
        {
            genorator.StartDungeonGenoration();
        }
    }
}
