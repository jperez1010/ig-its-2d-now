using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private CameraFollower follower;
    public CameraRotator[] rotators;
    public float angle = 0f;
    public event EventHandler OnAngleAltered;

    private void Start()
    {
        angle = 0f;
        follower = GetComponent<CameraFollower>();
    }

    void Update()
    {
        Vector3 position = follower.currentPlayer.GetCurrentMorph().transform.position;
        foreach (CameraRotator rotator in rotators)
        {
            if (rotator.PlayerWithin(position))
            {
                SetAngle(rotator.GetLerp(position));
            }
        }
    }

    void SetAngle(float angle)
    {
        this.angle = angle;
        transform.eulerAngles = new Vector3(60, angle, 0);
        OnAngleAltered?.Invoke(angle, EventArgs.Empty);
    }
}
