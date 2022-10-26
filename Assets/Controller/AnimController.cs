using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator anim;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (playerController.movingUp)
        {
            anim.SetBool("movingUp", true);
        }
        else
        {
            anim.SetBool("movingUp", false);
        }

        if (playerController.movingDown)
        {
            anim.SetBool("movingDown", true);
        }
        else
        {
            anim.SetBool("movingDown", false);
        }

        if (playerController.movingLeft)
        {
            anim.SetBool("movingLeft", true);
        }
        else
        {
            anim.SetBool("movingLeft", false);
        }
        
        if (playerController.movingRight)
        {
            anim.SetBool("movingRight", true);
        }
        else
        {
            anim.SetBool("movingRight", false);
        }

    }
}
