using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    bool EnemyCurrentTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCurrentTurn == true)
        {
            Debug.Log("llll");
        }
    }


    public void SetEnemyTurn( bool enemy)
    {
        EnemyCurrentTurn = enemy;
    }
}
