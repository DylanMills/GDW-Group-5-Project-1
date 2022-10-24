using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private Transform player;

    [SerializeField]
    private bool activateTorchWithPlayer;

    [SerializeField]
    private float torchActivateInRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if ((player.position - transform.position).magnitude <= torchActivateInRange && activateTorchWithPlayer)
        {
            anim.SetBool("TorchActive", true);
        }

        spriteRenderer.sortingOrder = player.position.y - transform.position.y > 0 ? 2 : 0;
    }

    public void Active(bool active)
    {
        anim.SetBool("TorchActive", active);
    }
}
