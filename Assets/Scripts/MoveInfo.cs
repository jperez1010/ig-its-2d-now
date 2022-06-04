using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInfo : MonoBehaviour
{
    private string name;
    private int damage;
    private int speed;
    private int knockback;
    private MoveType type;
    private RangeType rtype;
    private Sprite sprite;
    public MoveInfo (string name, int damage, int speed, int knockback, MoveType type, RangeType rtype, Sprite sprite)
    {
        this.name = name;
        this.damage = damage;
        this.speed = speed;
        this.knockback = knockback;
        this.type = type;
        this.rtype = rtype;
        this.sprite = sprite;
    }
    public string GetName()
    {
        return this.name;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public int GetSpeed()
    {
        return this.speed;
    }
    public int GetKnockback()
    {
        return this.knockback;
    }
    public MoveType GetMoveType()
    {
        return this.type;
    }
    public RangeType GetRangeType()
    {
        return this.rtype;
    }
    public Sprite GetSprite()
    {
        return this.sprite;
    }
}
