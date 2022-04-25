using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxFollower : MonoBehaviour
{
    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.transform.position;
    }
}
