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
        dir = new Vector3(0, 0, 1);
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
        Vector3 castPoint = this.gameObject.transform.position;
        Vector3 dirx = new Vector3(newDir.x, 0, 0);
        Vector3 dirz = new Vector3(0, 0, newDir.y);
        RaycastHit hitx;
        RaycastHit hitz;
        bool horizontalContact = Physics.Raycast(new Ray(castPoint, dirx), out hitx, 1f, 1 << LayerMask.NameToLayer("Map") | 1 << LayerMask.NameToLayer("Obstacle"));
        bool verticalContact = Physics.Raycast(new Ray(castPoint, dirz), out hitz, 1f, 1 << LayerMask.NameToLayer("Map") | 1 << LayerMask.NameToLayer("Obstacle"));
        if (horizontalContact)
        {
            newDir.x = 0;
        }
        if (verticalContact)
        {
            newDir.y = 0;
        }
        if (canMove)
        {
            this.transform.position = this.transform.position + Vector3.Normalize(newDir) * speed;
        }
        anim.SetBool("Walking", newDir.magnitude > 0.5);
        

        

        //if (!newDir.Equals(Vector3.zero)) {
            //dir = newDir;
            //if (newDir.x > 0)
            //{
                //this.transform.rotation = Quaternion.Euler(-120, 0, 180);
            //}
            //else
            //{
                //this.transform.rotation = Quaternion.Euler(60, 0, 0);
            //}
        //}
    }
}
