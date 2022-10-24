using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<Transform>().position = transform.position;
    }
}
