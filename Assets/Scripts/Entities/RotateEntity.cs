using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEntity : MonoBehaviour
{
    public Camera cam;
    public float angle;
    public EventHandler OnAngleAltered;

    // Start is called before the first frame update
    void Start()
    {
        CameraRotation rotation = cam.GetComponent<CameraRotation>();
        rotation.OnAngleAltered += ChangeAngle_OnAngleAltered;
    }

    void ChangeAngle_OnAngleAltered(object s, System.EventArgs e)
    {
        angle = (float) s;
        transform.eulerAngles = new Vector3(60, angle, 0);
    }
}
