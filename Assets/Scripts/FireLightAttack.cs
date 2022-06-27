using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireLightAttack : MonoBehaviour
{
    private float timer = 0;
    private float elapsedTime;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) &&  timer == 0)
        {
            EventManager.current.LightAttackCommand();
            timer = Time.time;
        }
        if (timer != 0)
        {
            elapsedTime = Time.time - timer;
        }
        if (elapsedTime > 0.5f)
        {
            timer = 0;
        }
    }
}
