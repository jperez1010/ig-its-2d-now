using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 0.1f;
    public bool canMove;
    public Vector3 dir;
    
    /// <summary>
    /// TO FIX
    /// </summary>
    
    public Animator anim;

    private double movementThreshold = 0.2;

    void Update()
    {
        Vector3 newDir = GetMovementInput();
        newDir = DetectObstacleCollisions(newDir);
        dir = newDir;
    }

    private void FixedUpdate()
    {
        if (!dir.Equals(Vector3.zero))
        {
            FlipPlayer();
        }
        if (canMove)
        {
            this.transform.position = this.transform.position + Vector3.Normalize(dir) * speed;
        }
        anim.SetBool("Walking", dir.magnitude > movementThreshold);
    }

    private Vector3 GetMovementInput()
    {
        Vector3 newDir = Vector3.zero;
        if (Input.GetJoystickNames().Length == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                newDir.z += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                newDir.z -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                newDir.x += 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                newDir.x -= 1;
            }
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            newDir.x = horizontalInput;
            newDir.z = verticalInput;
        }
        return newDir;
    }

    private Vector3 DetectObstacleCollisions(Vector3 newDir)
    {
        Vector3 castPoint = this.gameObject.transform.position;
        Vector3 dirx = new(newDir.x, 0, 0);
        Vector3 dirz = new(0, 0, newDir.z);
        RaycastHit hitx;
        RaycastHit hitz;
        Physics.Raycast(new Ray(castPoint, dirx), out hitx, 1f, 1 << LayerMask.NameToLayer("Obstacle"));
        Physics.Raycast(new Ray(castPoint, dirz), out hitz, 1f, 1 << LayerMask.NameToLayer("Obstacle"));
        if (hitx.collider)
        {
            newDir.x = 0;
        }
        if (hitz.collider)
        {
            newDir.z = 0;
        }
        return newDir;
    }

    private void FlipPlayer()
    {
        if (dir.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(-120, 0, 180);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(60, 0, 0);
        }
    }

}