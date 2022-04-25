using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilAI : MonoBehaviour
{
    public GameObject target;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        Vector3 targetPosition = target.transform.position;
        this.transform.position = this.transform.position - movementSpeed * Vector3.Normalize(position - targetPosition);
        if (Vector3.Magnitude(targetPosition - position) >= 5)
        {
        //    this.transform.position = this.transform.position + movementSpeed * Vector3.Normalize(position - targetPosition);
        }
    }
}
