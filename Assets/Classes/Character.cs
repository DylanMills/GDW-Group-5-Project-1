using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int level = 0;
    public bool magicClass;
    public bool targetAlly;
    public bool isAggroed;
    public float attackUp = 1;
    public float defenseUp = 1;
    public float HP;
    public float maxHP;
    public float ATK;
    public float MAG;
    public float DEF;
    public float AGL;
    public float LUK;
    public float attackMult;
    public int gHP;
    public int gATK;
    public int gMAG;
    public int gDEF;
    public int gAGL;
    public int gLUK;

    public void TakeDamage(Character enemy, float multiplier, float attackmult)
    {
        if (Random.Range(1, 100) > AGL)
        {
            if (Random.Range(1, 100) < enemy.LUK)
            {
                if (!enemy.magicClass)
                {
                    HP = HP - (enemy.ATK * multiplier * attackmult * 1.5f / 100 / (DEF*defenseUp));
                }
                else
                {
                    HP = HP - (enemy.MAG * multiplier * attackmult * 1.5f / 100 / (MAG*defenseUp));
                }
            }
            else
            {
                if (!enemy.magicClass)
                {
                    HP = HP - (enemy.ATK * multiplier * attackmult / 100 / (DEF * defenseUp));
                }
                else
                {
                    HP = HP - (enemy.MAG * multiplier * attackmult / 100 / (MAG * defenseUp));
                }
            }
        }
        else
        {
            Debug.Log("The attack missed!");
        }
    }

    public void LevelUp()
    {
        SetStat(maxHP, gHP);
        if (HP + gHP < maxHP)
        {
            HP += gHP;
        }
        else
        {
            HP = maxHP;
        }
        SetStat(ATK, gATK);
        SetStat(MAG, gMAG);
        SetStat(DEF, gDEF);
        SetStat(AGL, gAGL);
        SetStat(LUK, gLUK);
        level += 1;
    }

    public void CreateStats(int targetLevel)
    {
        while (level < targetLevel)
        {
            LevelUp();
        }
    }
    
    public virtual void Attack(Character target)
    {
        target.TakeDamage(this, attackMult, attackUp);
    }

    public virtual void Ability (Character target)
    {

    }

    void SetStat(float stat, int growth)
    {
        if (Random.Range(1, 100) < LUK && growth!=0)
        {
            stat += Random.Range(1, growth);
        }
        else
        {
            stat += Random.Range(0, growth);
        }
    }
}
