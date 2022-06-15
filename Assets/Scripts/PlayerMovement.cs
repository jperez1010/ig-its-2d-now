using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.1f;
    public bool canMove;
    public Vector3 dir;
    public Animator anim;
    bool horizontalContact;
    bool verticalContact;

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
        Debug.Log(newDir);
        Vector3 dirx = new Vector3(newDir.x * 0.1f, 0, 0);
        Vector3 dirz = new Vector3(0, 0, newDir.z * 0.1f);
        RaycastHit hitx;
        RaycastHit hitz;
        horizontalContact = Physics.Raycast(new Ray(castPoint, dirx), out hitx, 1f, 1 << LayerMask.NameToLayer("Obstacle"));
        verticalContact = Physics.Raycast(new Ray(castPoint, dirz), out hitz, 1f, 1 << LayerMask.NameToLayer("Obstacle"));
        if (hitx.collider != null)
        {
            newDir.x = 0;
        }
        if (hitz.collider != null)
        {
            newDir.z = 0;
        }
        dir = newDir;
    }
    private void FixedUpdate()
    {
        if (!dir.Equals(Vector3.zero))
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
        if (canMove)
        {
            this.transform.position = this.transform.position + Vector3.Normalize(dir) * speed;
        }
        anim.SetBool("Walking", dir.magnitude > 0.5);
    }
}
