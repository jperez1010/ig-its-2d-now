using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MythoGemUI : MonoBehaviour
{
    public CurrentPlayer currentPlayer;
    public GameObject[] MorphImages;

    void Start()
    {
        currentPlayer.OnCurrentMorphAltered += SwapMorph_OnCurrentMorphAltered;
    }

    void SwapMorph_OnCurrentMorphAltered(object sender, System.EventArgs _)
    {
        int i = (int) sender;
        for (int k = 0; k < 4; k++)
        {
            SetImageActive(k, true);
        }
        SetImageActive(i, false);
    }

    public void SetImageActive(int i, bool value)
    {
        if (MorphImages[i] != null)
        {
            MorphImages[i].transform.GetChild(0).gameObject.SetActive(value);
        }
    }
}
