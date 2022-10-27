using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer : Character
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        ATK = 3;
        DEF = 6;
        MAG = 2;
        gHP = 6;
        gATK = 3;
        gMAG = 2;
        gDEF = 6;
        AGL = 20;
        LUK = 20;
        magicClass = false;
        attackMult = 60;
        targetAlly = false;
    }

    public override void Ability(Character target)
    {
        target.isAggroed = true;
    }

    public override void NameOfAbility(string name)
    {
         name = " ";
    }
}
