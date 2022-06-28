using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboNode : MonoBehaviour
{
    private Attacks attack;
    private ComboNode lightAttack;
    private ComboNode heavyAttack;
    private AttackInputType type;
    private int comboLevel;

    public ComboNode(Attacks attack, ComboNode lightAttack, ComboNode heavyAttack, AttackInputType type, int comboLevel)
    {
        this.attack = attack;
        this.lightAttack = lightAttack;
        this.heavyAttack = heavyAttack;
        this.comboLevel = comboLevel;
        this.type = type;
    }
    public Attacks getAttack()
    {
        return this.attack;
    }
    public ComboNode getLightAttack()
    {
        return this.lightAttack;
    }
    public ComboNode getHeavyAttack()
    {
        return this.heavyAttack;
    }
    public void setAttack(Attacks attack)
    {
        this.attack = attack;
    }
    public void setLightAttack(ComboNode node)
    {
        this.lightAttack = node;
    }
    public void setHeavyAttack(ComboNode node)
    {
        this.heavyAttack = node;
    }
    public int getLevel()
    {
        return this.comboLevel;
    }
    public void setLevel(int lvl)
    {
        this.comboLevel = lvl;
    }
    public AttackInputType getType()
    {
        return this.type;
    }
    public void setType(AttackInputType type)
    {
        this.type = type;
    }
}
