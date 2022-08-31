using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public int currentMorph = 0;
    public GameObject spawnLocation;
    public GameObject[] morphObjects;
    public event EventHandler OnCurrentMorphAltered;

    private void Start()
    {
        SpawnMorph(0, spawnLocation.transform.position);
    }

    void Update()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapMorph(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapMorph(2);
        }
    }

    void SwapMorph(int i)
    {
        int previous = currentMorph;
        currentMorph = i;
        if (previous == i)
        {
            currentMorph = 0;
        }
        ActivateCurrentMythomorph(previous);
    }

    public void ActivateCurrentMythomorph(int previous)
    {
        for (int k = 0; k < 5; k++)
        {
            if (morphObjects[k])
            {
                morphObjects[k].GetComponent<RotateEntity>().angle = morphObjects[previous].GetComponent<RotateEntity>().angle;
                morphObjects[k].SetActive(false);
            }
        }
        SpawnMorph(currentMorph, morphObjects[previous].transform.position);
    }

    public void SpawnMorph(int index, Vector3 position)
    {
        morphObjects[index].transform.position = position;
        morphObjects[index].SetActive(true);
        OnCurrentMorphAltered?.Invoke(index, EventArgs.Empty);
    }

    public GameObject GetCurrentMorph()
    {
        return morphObjects[currentMorph];
    }
}
