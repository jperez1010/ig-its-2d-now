using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicRanged: AttackBehaviour
{
    private TimeSpan lifespan = new TimeSpan(0,0,2);
    private float speed;
    protected override void Start()
    {
        timer = DateTime.Now;
    }
    // Update is called once per frame
    protected override void Update()
    {
        TimeSpan elapsedTime = DateTime.Now - timer;
        transform.Translate(speed * direction);
        if (elapsedTime >= lifespan)
        {
            Destroy(this.gameObject);
        }
    }
    public override void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
