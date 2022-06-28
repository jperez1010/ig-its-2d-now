using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireAttack : MonoBehaviour
{
    void Update()
    {
        if (fireLightInputPressed())
        {
            this.gameObject.GetComponent<AttackGenerate>().SpawnAttack(AttackInputType.LIGHT);
        }
        if (fireHeavyInputPressed())
        {
            this.gameObject.GetComponent<AttackGenerate>().SpawnAttack(AttackInputType.HEAVY);
        }
    }
    private bool fireLightInputPressed()
    {
       return Input.GetKeyDown(KeyCode.Mouse0);
    }
    private bool fireHeavyInputPressed()
    {
        return Input.GetKeyDown(KeyCode.Mouse1);
    }
}
