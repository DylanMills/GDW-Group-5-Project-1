using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    float _currentHealth = 2;
    public bool Destroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
           FindObjectOfType<TurnHandler>().SetDestroyedEnemy(true);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

    }


}
