using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MythomorphStats mythomorphStats;
    public bool canMove;
    public Vector3 dir;
    public Rigidbody rb;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    public WaitTimeHandler waitTimeHandler;
    private RotateEntity rotateEntity;

    /// <summary>
    /// TO FIX
    /// </summary>

    public Animator anim;
    private double movementThreshold = 0.2;

    private void Start()
    {
        rotateEntity = GetComponent<RotateEntity>();
    }

    private void Update()
    {
        Vector3 newDir = GetMovementInput();
        newDir = DetectObstacleCollisions(newDir);
        dir = newDir;
        if (dir.magnitude > movementThreshold && IsMovementAllowed())
        {
            if (Mathf.Abs(dir.x) > Mathf.Epsilon)
            {
                FlipPlayer(IsMovingRight());
            }
        }
        if (canMove)
        {
            transform.position += mythomorphStats.movementSpeed * Time.deltaTime * GetAngledDirection(dir.normalized);
        }
        anim.SetBool("Walking", dir.magnitude > movementThreshold);
    }

    private Vector3 GetAngledDirection(Vector3 dir)
    {
        float alpha = rotateEntity.angle * Mathf.PI / 180;
        Vector3 A = dir.x * new Vector3(Mathf.Cos(alpha), 0, -Mathf.Sin(alpha));
        Vector3 B = dir.z * new Vector3(Mathf.Sin(alpha), 0, Mathf.Cos(alpha));
        return A + B;
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

    public void FlipPlayer(bool facingRight)
    {
        spriteRenderer.flipX = facingRight;
    }

    public bool IsMovingRight()
    {
        return (dir.x > 0);
    }

    private bool IsMovementAllowed()
    {
        return waitTimeHandler.GetNextNodeData(ActionEnum.MOVEMENT) != null;
    }

}