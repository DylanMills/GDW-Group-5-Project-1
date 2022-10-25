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

        transform.rotation = Random.Range(0, 2) == 1 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        if ((transform.position - player.position).magnitude <= ratRange)
        {
            rb.AddForce((transform.position - player.position).normalized * ratAcceleration, ForceMode2D.Force);
        }

        transform.rotation = rb.velocity.x > 0 ? Quaternion.Euler(0, 180, 0): Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
