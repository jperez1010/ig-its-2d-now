using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject manaBall;
    public float reloadPeriod = 40f;
    public int canShootCounter;
    public bool canShoot;

    private float spawn_distance = 0.4f;

    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnManaBall();
            canShoot = false;
            canShootCounter = 0;
        }
        else
        {
            if (!canShoot)
            {
                canShootCounter++;
            }
            if (canShootCounter >= reloadPeriod)
            {
                canShoot = true;
            }
        }
    }

    public void SpawnManaBall()
    {
        GameObject manaBallInstance = Instantiate(manaBall);
        Vector3 direction = GetDirection();
        manaBallInstance.GetComponent<HarmEnemy>().direction = direction;
        manaBallInstance.transform.position = this.transform.position + direction * spawn_distance;
    }

    public Vector3 GetDirection()
    {
        return this.GetComponent<PlayerMovement>().dir.normalized;
    }
}
