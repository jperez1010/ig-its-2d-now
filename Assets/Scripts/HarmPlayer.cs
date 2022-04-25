using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("MythomorphP"))
        {
            collision.gameObject.GetComponent<HealthHandler>().Damage(damage);
        }
    }
}
