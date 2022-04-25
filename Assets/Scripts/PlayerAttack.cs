using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public InputHandler inputHandler;
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
        if (inputHandler.controller)
        {
            float horizontalInput = Input.GetAxis("HorizontalTurn");
            float verticalInput = Input.GetAxis("VerticalTurn");
            Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
            if (direction.magnitude <= 0.05)
            {
                return this.GetComponent<PlayerMovement>().dir.normalized;
            }
            else
            {
                return direction.normalized;
            }
        }
        else
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            worldPosition.y = 0;
            Debug.Log(worldPosition - this.transform.position);
            return (worldPosition - this.transform.position).normalized;
        }
        
    }
}
