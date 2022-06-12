using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicRanged : AttackBehaviour
{
    private TimeSpan lifespan = new TimeSpan(0, 0, 2);
    private float speed;
    protected override void Start()
    {
        timer = DateTime.Now;
    }
    // Update is called once per frame
    protected override void FixedUpdate()
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MythomorphE")
        {
            Debug.Log("Collision");
            other.gameObject.GetComponent<HealthHandler>().Damage(this.GetComponent<AttackStats>().damage);
            float weight = other.gameObject.GetComponent<MythomorphStats>().weight;
            other.gameObject.transform.Translate(direction * this.GetComponent<AttackStats>().knockback / weight);
            Destroy(gameObject);
        }
    }
}