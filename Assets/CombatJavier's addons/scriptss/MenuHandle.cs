using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHandle : MonoBehaviour
{
    bool SelectionMenuSelected;
    bool AbilityMenuSelected;
    bool RunSelected;
    bool menuReseted;

    public GameObject SelectionMenu;
    public GameObject AbilityMenu;

    public TurnHandler TH;



    // Start is called before the first frame update
    void Start()
    {
        SelectionMenuSelected = true;

    }

    // Update is called once per frame
    void Update()
    {

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

    }

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

          

        }

        if (number == 2)
        {
         
        }


    }

    public void SetMenuReset(bool made)
    {
        SelectionMenuSelected = made;
        RunSelected = false;
        AbilityMenuSelected = false;
       // SelectionMenuSelected = false;
    }

    
}
