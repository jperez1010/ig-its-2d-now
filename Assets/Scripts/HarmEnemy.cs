using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmEnemy : MonoBehaviour
{
    public Vector3 direction;
    public int damage = 1;
    public float speed = 0.1f;
    public float timer;
    public float push = 10.0f;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 0.28f)
        {
            return;
        }
        this.transform.position = this.transform.position + speed * direction;
        if (timer >= 5)
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
            float weight = 1f;//other.gameObject.GetComponent<MythomorphStats>().weight;
            other.gameObject.transform.Translate(direction * push / weight);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
