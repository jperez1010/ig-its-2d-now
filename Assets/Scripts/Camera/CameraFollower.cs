using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public CurrentPlayer currentPlayer;
    public GameObject player;
    public Vector3 defaultOffset = new Vector3(-2.5f, 4, -2.5f);
    public Vector3 offset;
    public float lerpAmount = 0.5f;
    private CameraRotation rotation;

    void Start()
    {
        rotation = GetComponent<CameraRotation>();
        offset = Vector3.Scale(defaultOffset, new Vector3(Mathf.Sin(rotation.angle), 1, Mathf.Cos(rotation.angle)));
        currentPlayer.OnCurrentMorphAltered += SwapMorph_OnCurrentMorphAltered;
        rotation.OnAngleAltered += ChangeAngle_OnAngleAltered;
    }

    void SwapMorph_OnCurrentMorphAltered(object s, System.EventArgs e)
    {
        player = currentPlayer.GetCurrentMorph();
    }

    void ChangeAngle_OnAngleAltered(object s, System.EventArgs e)
    {
        float angle = (float) s * Mathf.PI/180f;
        offset = Vector3.Scale(defaultOffset, new Vector3(Mathf.Sin(angle), 1, Mathf.Cos(angle)));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = (Vector3.Lerp(this.transform.position, player.transform.position + offset, lerpAmount
            ));
    }
}
