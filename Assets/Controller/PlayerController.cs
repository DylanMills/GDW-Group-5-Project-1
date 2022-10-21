using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Transform t;
    private Rigidbody2D rb;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private bool menuActive = false;
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
    void ToggleMenu()
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
        if (playerControls.Ground.MenuToggle.triggered)
        {
            print("hello");
            ToggleMenu();
        }
      
        
    }
}
