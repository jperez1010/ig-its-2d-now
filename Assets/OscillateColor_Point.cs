using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class OscillateColor_Point : MonoBehaviour
{
    public float amp = 6;
    public float freq = 2f;

    public Light lightSource;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        lightSource.intensity = Mathf.Abs(amp * Mathf.Sin(freq * Mathf.PerlinNoise(Time.realtimeSinceStartup / 100f, 0.0f) * Time.realtimeSinceStartup));
    }
}
