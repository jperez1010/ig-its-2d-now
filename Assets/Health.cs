using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    float health, maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        //--health;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        lerpSpeed = 3f * Time.deltaTime;
        HealthBar();
        ColorChanger();
    }
    void HealthBar()
    {
        float hp = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
        healthBar.fillAmount = hp;
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }
    public void Damage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
        }
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {
            health += healingPoints;
        }
    }
}
