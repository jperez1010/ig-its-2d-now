using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public RotationAngle angleA;
    public RotationAngle angleB;

    public float theta;
    public float phidel = (Mathf.PI/ 180) * 5;


    private void Start()
    {
        theta = GetAngle(angleA.transform.position, angleB.transform.position);
    }

    public Vector3 GetLerp(Vector3 position)
    {
        float phi1 = GetAngle(angleA.transform.position, position);
        float t = phi1 / theta;
        return Vector3.Lerp(angleA.rotationAngle, angleB.rotationAngle, Mathf.Clamp(t, 0,1));   
    }

    public bool PlayerWithin(Vector3 position)
    {
        float phi1 = GetAngle(angleA.transform.position, position);
        float phi2 = GetAngle(angleB.transform.position, position);
        return phi1 + phi2 - phidel < theta;
    }

    public float GetAngle(Vector3 a, Vector3 b)
    {
        a -= transform.position;
        b -= transform.position;
        a.y = 0;
        b.y = 0;
        return Mathf.Acos(Vector3.Dot(a.normalized, b.normalized));
    }
}
