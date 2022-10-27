using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Character
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        ATK = 0;
        DEF = 1;
        MAG = 4;
        gHP = 3;
        gATK = 0;
        gMAG = 4;
        gDEF = 1;
        AGL = 60;
        LUK = 60;
        magicClass = true;
        attackMult = 60;
        targetAlly = true;
    }

    public override void Attack(Character target)
    {
        target.TakeDamage(this, attackMult, attackUp);
        HP = HP + ((MAG * attackMult * attackUp * 1.5f / 100 / (target.MAG * target.defenseUp)) / 2);
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }

    public override void Ability(Character target)
    {
        if (target.HP + MAG < target.maxHP)
        {
            target.HP += MAG;
        }
        else
        {
            target.HP = target.maxHP;
        }
    }

    public override void NameOfAbility(string name)
    {
        name = " ";
    }
}

