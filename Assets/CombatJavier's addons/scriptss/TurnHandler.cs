using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TurnHandler : MonoBehaviour
{

    //Menu Stuff
    public bool SelectionMenuSelected;
    public bool AbilityMenuSelected;
    bool RunSelected;
    bool menuReseted;

    public GameObject SelectionMenu;
    public GameObject AbilityMenu;



    //TurnStuff
    bool EnemyTurn;
    public bool PlayerTurn;

    bool abilityMade;
    bool damageAbility;
    bool healingAbility;
    bool deadEnemy;
    bool deadPartner;

    int counterTurn;
    int counter2 = 0;
    int counter;
    int i = 0;
    int j = 0;
    int _totalGoodGuys;
    int _totalBadGuys;

    GameObject MenuHandler;

    public List<GameObject> PlayerTeamT = new List<GameObject>();
    public List<GameObject> EnemyTeamT = new List<GameObject>();
 


    public GameObject _arrowPrefab;
    GameObject _arrowCopy;

    public GameObject _currentCharacter;

    public InputAction inputSelection;
    public InputAction move;
    Vector2 input = Vector2.zero;



    // Start is called before the first frame update
    void Awake()
    {
        //Menu Stuff
        SelectionMenuSelected = true;

        move.performed += _ctx => {

            if ( PlayerTurn == true )
            {
                input.x = _ctx.ReadValue<float>() * 1;
            }

        };
        move.canceled += _ctx => {
            input.x = 0;

        };


        //Turn
        _totalBadGuys = EnemyTeamT.Count;
        _totalGoodGuys = PlayerTeamT.Count;

        EnemyTurn = false;
        PlayerTurn = true;
        _currentCharacter = PlayerTeamT[i];
        SelectionArrow();

        move.performed += _ctx => {

            if ( PlayerTurn == true )
            {
                input.y = _ctx.ReadValue<float>() * 1;
            }

        };
        move.canceled += _ctx => {
            input.y = 0;
            counter = 0;

        };

        inputSelection.started += _ctx => {

            if (abilityMade == true)
            {
                if (PlayerTurn == true)
                {
                    Character partner = PlayerTeamT[i].GetComponent<Character>();
                    Enemy enemy = EnemyTeamT[j].GetComponent<Enemy>();

                    if (damageAbility == true)
                    {
                        enemy.Attack(partner);
                    }
                    else if (healingAbility == true)
                    {
                        partner.Ability(partner);
                    }
                }

                ChangingTurns();
                healingAbility = false;
                damageAbility = false;
                MenuReset();
                abilityMade = false;
                counter2 = 0;
            }



        };

    }

    // Update is called once per frame
    void Update()
    {
        //Menu Stuff
        if (SelectionMenuSelected == true)
        {
            AbilityMenu.SetActive(false);
            SelectionMenu.SetActive(true);
            

        }

        if (AbilityMenuSelected == true)
        {

            SelectionMenu.SetActive(false);
            AbilityMenu.SetActive(true);

        }

        if (RunSelected == true)
        {
            AbilityMenu.SetActive(false);
        }


        //Turn Stuff

        if (deadEnemy == true)
        {

            EnemyTeamT.Remove(EnemyTeamT[j]);
            _totalBadGuys--;
            deadEnemy = false;
        }

        if (deadPartner == true)
        {

            PlayerTeamT.Remove(PlayerTeamT[j]);
            _totalBadGuys--;
            deadPartner = false;
        }


        if (_totalGoodGuys == 0)
        {
            Debug.Log("loose");
        }
        if (_totalBadGuys == 0)
        {
            Debug.Log("win");
        }

        Turns();
        if (damageAbility == true)
        {

            if (counter2 == 0)
            {
                j = 0;
                counter = 0;
                _currentCharacter = EnemyTeamT[j];
                counter2++;
            }
            else
            {
                SelectingEnemyMember();
            }

        }
        if (healingAbility == true)
        {

            if (counter2 == 0)
            {

                j = 0;
                counter = 0;
                _currentCharacter = PlayerTeamT[j];
                counter2++;
            }


            SelectingPartyMember();



        }


        if (EnemyTurn == true)
        {
          //  MenuHandler.SetActive(false);
            TurnOfEnemy();
        }
    }

    void TurnOfEnemy()
    {
        int objective = Random.Range(0, _totalGoodGuys);

        if (objective > 0 && objective < _totalGoodGuys)
        {
            Enemy enemy = EnemyTeamT[j].GetComponent<Enemy>();
            Character partner = PlayerTeamT[objective].GetComponent<Character>();
            partner.Attack(enemy);
        }

    }

    void Turns()
    {

        // FindObjectOfType<EnemyLogic>().SetEnemyTurn(true);


    }

    private void OnEnable()
    {
        move.Enable();
        inputSelection.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        inputSelection.Disable();
    }

    void SelectingPartyMember()
    {


        if (input.y == -1 && j < _totalGoodGuys - 1 && counter == 0)
        {

            j++;
            counter++;

        }
        if (input.y == 1 && j > 0 && counter == 0)
        {
            j--;
            counter--;

        }

        _currentCharacter = PlayerTeamT[j];




        SelectionArrow();
    }

    void SelectingEnemyMember()
    {


        if (input.y == -1 && j < _totalBadGuys - 1 && counter == 0)
        {
            j++;
            counter++;

        }
        if (input.y == 1 && j > 0 && counter == 0)
        {
            j--;
            counter--;

        }

        _currentCharacter = EnemyTeamT[j];



        SelectionArrow();
    }

    void ChangingTurns()
    {
        counterTurn++;
        i++;

        if (counterTurn == _totalGoodGuys + _totalBadGuys)
        {
            counterTurn = 0;
            i = 0;
        }

        if (counterTurn == _totalGoodGuys)
        {
            i = 0;
            _currentCharacter = EnemyTeamT[i];
        }

        if (counterTurn < _totalGoodGuys)
        {
            _currentCharacter = PlayerTeamT[i];
            EnemyTurn = false;
            PlayerTurn = true;
        }

        if (counterTurn > _totalGoodGuys && counterTurn < _totalGoodGuys + _totalBadGuys)
        {
            _currentCharacter = EnemyTeamT[i];
            PlayerTurn = false;
            EnemyTurn = true;
        }

        SelectionArrow();

    }

    

    void SelectionArrow()
    {
        Destroy(_arrowCopy);
        _arrowCopy = Instantiate(_arrowPrefab, _currentCharacter.transform.position + new Vector3(-2f, 0f, 0f), _currentCharacter.transform.rotation);

    }


    public void SetDestroyedEnemy(bool destroyedEnemy)
    {
        deadEnemy = destroyedEnemy;
    }

    public void SetDestroyedPartner(bool destroyedPartner)
    {
        deadPartner = destroyedPartner;
    }




    //Menu Stuff

    public void AttackPhase()
    {
        AbilityMenuSelected = true;


    }


    public void RunPhase()
    {
        RunSelected = false;
    }


    public void Ability(int number)
    {
      
       
        if (number == 1)
        {
            damageAbility = true;
        }

        if (number == 2)
        {
            healingAbility = true;
        }

        abilityMade = true;

    }

    void MenuReset()
    {
        SelectionMenuSelected = true;
        RunSelected = false;
        AbilityMenuSelected = false;
        // SelectionMenuSelected = false;
    }
}