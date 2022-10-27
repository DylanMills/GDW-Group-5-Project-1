using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Button))]

public class ButtonLogic : MonoBehaviour
{
    public TurnHandler T;



    Button _currentButton;
    public Color _unselectedTint = Color.grey;
    public Color _selectedTint = Color.white;

    public List<Button> buttons = new List<Button>();
    public List<Button> buttons2 = new List<Button>();


    public InputAction inputSelection;
    public InputAction move;

    int i;
    int j;
    int counter;
    int counter2;

    public GameObject canvas;
    public GameObject _boxPrefab;
    GameObject _copyBox;

    Vector2 input = Vector2.zero;
    // Start is called before the first frame update
    void Awake()
    {
        move.performed += _ctx => {

            if (T.PlayerTurn == true)
            {

                input.x = _ctx.ReadValue<float>() * 1;
            }

        };
        move.canceled += _ctx => {
            input.x = 0;


        };

        inputSelection.started += _ctx => {

            _currentButton.onClick.Invoke();



        };
    }

    // Update is called once per frame
    void Update()
    {
            SelectingButton();
    }

    void SelectingButton()
    {
        if (T.SelectionMenuSelected == true)
        {
            if (input.x == -1 && j < buttons.Count - 1 && counter == 0)
            {
                j++;
                counter++;

            }
            if (input.x == 1 && j > 0 && counter == 0)
            {
                j--;
                counter--;

            }
            _currentButton = buttons[j];
        }

        if (T.AbilityMenuSelected == true)
        {
            if (input.x == -1 && i < buttons.Count - 1 && counter == 0)
            {
                i++;
                counter2++;

            }
            if (input.x == 1 && i > 0 && counter == 0)
            {
                i--;
                counter2--;

            }
            _currentButton = buttons[i];
        }


        SelectionBox();
    }

    void SelectionBox()
    {
        Destroy(_copyBox);
         _copyBox = Instantiate(_boxPrefab) as GameObject;
        _copyBox.transform.SetParent(canvas.transform, false);

    }
}
