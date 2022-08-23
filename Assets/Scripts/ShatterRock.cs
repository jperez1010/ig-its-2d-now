using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterRock : MonoBehaviour
{
    public GameObject shattered;
    public int explosiveForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            Instantiate(shattered, transform.position, transform.rotation);
            GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, 5);
            Destroy(gameObject);
        }
    }
}
