using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnEnvironmentTriggerInteract;
    public void EnvironmentTriggerInteract()
    {
        if(OnEnvironmentTriggerInteract != null)
        {

            OnEnvironmentTriggerInteract();
        }
    }

    public event Action OnLightAttackCommand;
    public void LightAttackCommand()
    {
        if(OnLightAttackCommand != null)
        {
            Debug.Log("Light Attack Event");
            OnLightAttackCommand();
        }
    }
    public event Action OnHeavyAttackCommand;
    public void HeavyAttackCommand()
    {
        if(OnHeavyAttackCommand != null)
        {
            Debug.Log("Heavy Attack Event");
            OnHeavyAttackCommand();
        }
    }
    public event Action OnEnemyLightAttackCommand;
    public void EnemyLightAttackCommand()
    {
        if(OnEnemyLightAttackCommand != null)
        {
            OnEnemyLightAttackCommand();
        }
    }
}
