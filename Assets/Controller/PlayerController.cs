using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Transform t;
    private Rigidbody2D rb;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private bool menuActive = false;
    
    public bool isMoving;
    public bool movingUp;
    public bool movingDown;
    public bool movingLeft;
    public bool movingRight;

    [SerializeField]private GameObject menu;
    [SerializeField] private float speed=5;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        menu.SetActive(false);
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        
    }
    public void ToggleMenu()
    {
        if (menuActive)
        {
            menu.SetActive(false);
            menuActive = false;
        }
        else
        {
            menu.SetActive(true);
            menuActive = true;
        }
    }
    private void Update()
    {
        Vector2 move = playerControls.Ground.Move.ReadValue<Vector2>();
        rb.velocity = move*speed;
        DirectionCheck(move);
        if (playerControls.Ground.MenuToggle.triggered)
        {
            ToggleMenu();
        }
      
        
    }

    private void DirectionCheck(Vector2 move)
    {
        if (move != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        if (move == new Vector2(0.0f, 1.0f))
        {
            movingUp = true;
        }
        else
        {
            movingUp = false;
        }
        
        if (move == new Vector2(0.0f, -1.0f))
        {
            movingDown = true;
        }
        else
        {
            movingDown = false;
        }

        if (move == new Vector2(1.0f, 0.0f))
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        if (move == new Vector2(-1.0f, 0.0f))
        { 
            movingLeft = true;
        }
        else
        {
            movingLeft = false;
        }
    }
}
