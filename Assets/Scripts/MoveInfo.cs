using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInfo : MonoBehaviour
{
    private string moveName;
    private float damage;
    private float speed;
    private int knockback;
    private MoveType type;
    private RangeType rtype;
    private GameObject visual;
    public MoveInfo (string moveName, float damage, float speed, int knockback, MoveType type, RangeType rtype, GameObject visual)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.speed = speed;
        this.knockback = knockback;
        this.type = type;
        this.rtype = rtype;
        this.visual = visual;
    }
    public string GetMoveName()
    {
        return this.moveName;
    }

    public float GetDamage()
    {
        return this.damage;
    }

    public float GetSpeed()
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
    public GameObject GetVisual()
    {
        return this.visual;
    }
}
