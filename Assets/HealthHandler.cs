using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public HealthbarBehavior healthBar;
    public bool immune;
    int immuneCounter = 0;
    public int IFrames = 100;
    public SpriteRenderer sprite;

    void Start()
    {
        health = maxHealth;
        immune = false;
        healthBar.SetHealth(health, maxHealth);
    }

    private void Update()
    {
        if (immune)
        {
            immuneCounter += 1;
            if (immuneCounter >= IFrames)
            {
                IFramesDeactivate();
            }
        }
    }

    public void Damage(int damage)
    {
        if (!immune)
        {
            health -= damage;
            healthBar.SetHealth(health, maxHealth);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            IFramesActivate();
        }
    }
    private void IFramesActivate()
    {
        immune = true;
        sprite.color = Color.red;
    }

    private void IFramesDeactivate()
    {
        immuneCounter = 0;
        immune = false;
        sprite.color = Color.white;
    }
}
