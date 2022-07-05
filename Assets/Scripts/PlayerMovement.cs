using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    public bool canMove;
    public Vector3 dir;
    public Rigidbody rb;
    WaitTimeHandler waitTimeHandler;

    /// <summary>
    /// TO FIX
    /// </summary>

    public Animator anim;

    private double movementThreshold = 0.2;

    private void Update()
    {
        Vector3 newDir = GetMovementInput();
        newDir = DetectObstacleCollisions(newDir);
        dir = newDir;
        if (IsMovementAllowed())
        {
            if (!dir.Equals(Vector3.zero))
            {
                FlipPlayer();
            }
            if (IsMovementAllowed() && canMove)
            {
                transform.position += dir.normalized * Time.deltaTime * speed;
            }
            anim.SetBool("Walking", dir.magnitude > movementThreshold);
        }
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
        Vector3 dirx = new Vector3(newDir.x, 0, 0);
        Vector3 dirz = new Vector3(0, 0, newDir.z);
        RaycastHit hitx;
        RaycastHit hitz;
        Physics.Raycast(new Ray(castPoint, dirx), out hitx, 0.5f, 1 << LayerMask.NameToLayer("Obstacle"));
        Physics.Raycast(new Ray(castPoint, dirz), out hitz, 0.5f, 1 << LayerMask.NameToLayer("Obstacle"));
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

    private bool IsMovementAllowed()
    {
        return false;//waitTimeHandler.GetNextNode(ActionEnum.MOVEMENT).Item1;
    }

}