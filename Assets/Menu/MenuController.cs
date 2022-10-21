using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject _activeMenu;

  //  public AudioSource _backgroundAudio;
    public List<KeyCode> _increaseVert;//up
    public List<KeyCode> _decreaseVert;//down
    public List<KeyCode> _increaseHoriz;//right
    public List<KeyCode> _decreaseHoriz;//left
    public List<KeyCode> _confirmButtons;
    public InputActionReference _actionRef;
    public InputAction _action;
    private MenuDefinition _activeMenuDefinition;
    private int _activeButton = 0;

    public PlayerController playerController;

    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private bool menuActive = false;

    private void Awake()
    {
       
        playerInput = GetComponent<PlayerInput>();
        playerControls = new PlayerControls();  
        _action = _actionRef.ToInputAction();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateActiveMenuDefinition();
    

    }

    public void SetActiveMenu(GameObject activeMenu)
    {
        _activeMenu = activeMenu;

        UpdateActiveMenuDefinition();
    }

    // Update is called once per frame
    public void Update()
    {
        switch (_activeMenuDefinition.GetMenuType())
        {
            case MenuType.HORIZONTAL:
                MenuInput(_increaseHoriz, _decreaseHoriz);
;                break;

            case MenuType.VERTICAL:
                MenuInput(_increaseVert, _decreaseVert);
                break;
        }
    }
    private void MenuInput(List<KeyCode> increase, List<KeyCode> decrease)
    {
        int newActive = _activeButton;
        for (int i=0; i<increase.Count; i++)
        {
            if (Input.GetKeyDown(increase[i]))
            {
                newActive = SwitchCurrentButton(1);
            }
        }
        for (int i = 0; i < decrease.Count; i++)
        {
            if (Input.GetKeyDown(decrease[i]))
            {
                newActive = SwitchCurrentButton(-1);
            }
        }
        for (int i = 0; i < _confirmButtons.Count; i++)
        {
            if (Input.GetKeyDown(_confirmButtons[i]))
            {
                ClickCurrentButton();
            }
        }
        _activeButton = newActive;
    }
    private void ClickCurrentButton()
    {        //remove menu when selecting
        //this is temporary
        playerController.ToggleMenu();

      //  if (!_activeMenuDefinition.GetButtonDefinitions()[_activeButton].GetDisableControls())
        {
       //     StartCoroutine(_activeMenuDefinition.GetButtonDefinitions()[_activeButton].ClickButton());
        }

    }
    private int SwitchCurrentButton(int increment)
    {
        if (!_activeMenuDefinition.GetButtonDefinitions()[_activeButton].GetDisableControls())
        {
            int newActive = Utility.WrapAround(_activeMenuDefinition.GetButtonCount(), _activeButton, increment);
            _activeMenuDefinition.GetButtonDefinitions()[_activeButton].SwappedOff();
            _activeMenuDefinition.GetButtonDefinitions()[newActive].SwappedTo();
            return newActive;
        }

        return _activeButton;
    }

    public void UpdateActiveMenuDefinition()
    {
        _activeMenuDefinition = _activeMenu.GetComponent<MenuDefinition>();
    }
}
