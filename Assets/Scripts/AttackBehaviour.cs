using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AttackBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    protected DateTime timer;
    protected abstract void Start();
    protected abstract void Update();
    public abstract void SetSpeed(int speed);
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
