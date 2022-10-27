using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figther : Character
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 25;
        maxHP = 25;
        ATK = 4;
        DEF = 3;
        MAG = 0;
        gHP = 4;
        gATK = 4;
        gMAG = 0;
        gDEF = 3;
        AGL = 40;
        LUK = 40;
        magicClass = false;
        attackMult = 100;
        targetAlly = true;
    }

    public override void Ability(Character target)
    {
        target.attackUp += 0.5f;
    }

    public override void NameOfAbility(string name)
    {
        name = " ";
    }
}
