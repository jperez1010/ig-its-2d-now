using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireLightAttack : MonoBehaviour
{
    DateTime timer;
    private TimeSpan threshold = new TimeSpan(0, 0, 1);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = DateTime.Now;
        }
        if (Input.GetKeyUp(KeyCode.Space) && (DateTime.Now - timer) < threshold)
        {
            EventManager.current.LightAttackCommand();
        }
    }
}
