using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private bool hit = false;
    private void Start()
    {
        EventManager.current.OnEnvironmentTriggerInteract += OnEnvironmentInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            hit = true;
        }
    }

    private void OnEnvironmentInteract()
    {
        if (hit)
        {
            Destroy(this.gameObject);
        }
    }
}
