using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public bool controller;
    public KeyCode lightAttack;

    void Start()
    {
        if (false && Input.GetJoystickNames().Length > 0)
        {
            controller = true;
            SetupController();
        } else
        {
            controller = false;
        }

    }

    public void SetupKeyboard()
    {
        lightAttack = KeyCode.Space;
    }
    public void SetupController()
    {
 //       lightAttack = KeyCode;
    }
}
