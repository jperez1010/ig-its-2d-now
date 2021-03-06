using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmEnemy : MonoBehaviour
{
    public Vector3 direction;
    public int damage = 1;
    public float speed = 0.1f;
    public int timer;
    public float push = 10.0f;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        this.transform.position = this.transform.position + speed * direction;
        if (timer >= 60 * 2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MythomorphE")
        {
            Debug.Log(direction * push);
            other.gameObject.GetComponent<HealthHandler>().Damage(damage);
            float weight = other.gameObject.GetComponent<MythomorphStats>().weight;
            other.gameObject.transform.Translate(direction * push / weight);
            Destroy(gameObject);
        }
    }
}
