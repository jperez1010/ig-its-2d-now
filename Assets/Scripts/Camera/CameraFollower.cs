using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public CurrentPlayer currentPlayer;
    public GameObject player;
    public Vector3 offset = new Vector3(0,2,-2);

    void Start()
    {
        currentPlayer.OnCurrentMorphAltered += SwapMorph_OnCurrentMorphAltered;
    }

    void SwapMorph_OnCurrentMorphAltered(object s, System.EventArgs e)
    {
        player = currentPlayer.GetCurrentMorph();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
