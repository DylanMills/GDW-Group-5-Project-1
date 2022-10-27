using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        ATK = 1;
        DEF = 1;
        MAG = 6;
        gHP = 3;
        gATK = 1;
        gMAG = 6;
        gDEF = 1;
        AGL = 50;
        LUK = 15;
        magicClass = true;
        attackMult = 60;
        targetAlly = true;
    }



    public override void Ability(Character target)
    {
        target.defenseUp += 0.5f;
    }

    public override void NameOfAbility(string name)
    {
        name = " ";
    }
}
