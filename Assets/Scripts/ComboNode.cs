using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboNode : MonoBehaviour
{
    private Attacks attack;
    private ComboNode lightAttack;
    private ComboNode heavyAttack;
    private ComboNode predecessor;
    private int comboLevel;

    public ComboNode(Attacks attack, ComboNode lightAttack, ComboNode heavyAttack, ComboNode predecessor, int comboLevel)
    {
        this.attack = attack;
        this.lightAttack = lightAttack;
        this.heavyAttack = heavyAttack;
        this.comboLevel = comboLevel;
        this.predecessor = predecessor;
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
    public ComboNode getPredecessor()
    {
        return this.predecessor;
    }
    public void setPredecessor(ComboNode node)
    {
        this.predecessor = node;
    }
}
