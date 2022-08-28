using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysics : MonoBehaviour
{
    public double upperBound = 0.5;
    public double lowerBound = 0.5;
    public float downwardVelocity = 0;
    public float acceleration = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //int layerMask = 0;
        //layerMask = ~layerMask;
        
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        //
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        //
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.blue);
            print("There is something " + hit.distance + " away!");
            if (hit.distance > upperBound)
            {
                downwardVelocity = Mathf.Min(downwardVelocity + (acceleration * Time.deltaTime), 20);
            } 
            else
            {
                downwardVelocity = 0;
            }
        }
        this.transform.Translate(downwardVelocity * Vector3.down);
    }
}
