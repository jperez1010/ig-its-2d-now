using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDebris : MonoBehaviour
{
    private float currentTime;
    private float finalTime = 3f;
    [SerializeField]



    // Update is called once per frame
    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= finalTime)
        {
            KillObject();
        }
        foreach (Transform child in transform)
        {
            Color color = child.GetComponent<Renderer>().material.color;
            color.a = Mathf.Clamp(1 - currentTime / finalTime, 0, 1);
            child.GetComponent<Renderer>().material.color = color;
        }
    }

    void KillObject()
    {
        Destroy(gameObject);
}
}
