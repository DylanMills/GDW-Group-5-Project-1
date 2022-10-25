using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAT : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;

    [SerializeField]
    float ratRange;
    
    [SerializeField]
    float ratAcceleration;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((transform.position - player.position).magnitude <= ratRange)
        {
            rb.AddForce((transform.position - player.position).normalized * ratAcceleration, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
