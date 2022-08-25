using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public int currentMorph;
    public GameObject[] morphObjects;
    public event EventHandler OnCurrentMorphAltered;

    void Update()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapMorph(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapMorph(1);
        }
    }

    void SwapMorph(int i)
    {
        if (currentMorph == i)
        {
            return;
        }
        int previous = currentMorph;
        currentMorph = i;
        ActivateCurrentMythomorph(previous);
        OnCurrentMorphAltered?.Invoke(i, EventArgs.Empty);
    }

    public void ActivateCurrentMythomorph(int previous)
    {
        for (int k = 0; k < 4; k++)
        {
            if (morphObjects[k])
            {
                morphObjects[k].SetActive(false);
            }
        }
        Vector3 previousPos = morphObjects[previous].transform.position;
        morphObjects[currentMorph].transform.position = previousPos;
        morphObjects[currentMorph].SetActive(true);
    }

    public GameObject GetCurrentMorph()
    {
        return morphObjects[currentMorph];
    }
}
