using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.03f;
    public bool canMove;
    public Vector3 dir;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        if (canMove)
        {
            this.transform.position = this.transform.position + Vector3.Normalize(newDir) * speed;
        }
        anim.SetBool("Walking", newDir.magnitude > 0.5);
        

        

        if (!newDir.Equals(Vector3.zero)) {
            dir = newDir;
            if (newDir.x > 0)
            {
                this.transform.rotation = Quaternion.Euler(-120, 0, 180);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(60, 0, 0);
            }
        }
    }
}
