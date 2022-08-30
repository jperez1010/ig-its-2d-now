using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private CameraFollower follower;
    public CameraRotator[] rotators;
    public Vector3 angle;
    public event EventHandler OnAngleAltered;

    private void Start()
    {
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

    void SetAngle(Vector3 angle)
    {
        transform.eulerAngles = angle;
        OnAngleAltered?.Invoke(angle, EventArgs.Empty);
    }
}
