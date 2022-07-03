using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterRock : MonoBehaviour
{
    public GameObject shattered;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("it worked");
        Instantiate(shattered, transform.position, transform.rotation);
        GetComponent<Rigidbody>().AddExplosionForce(200, transform.position, 5);
        Destroy(gameObject);
    }
}
