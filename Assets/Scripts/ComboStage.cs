using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboStage : MonoBehaviour
{
    private int comboStage = 0;
    private float timer = 0;
    private float elapsedTime;
    void Update()
    {
        if (comboStage != 0)
        {
            elapsedTime = Time.time - timer;
        }
        if (elapsedTime > 0.5)
        {
            comboStage = 0;
        }
    }
    public void comboNext()
    {
        comboStage++;
        timer = Time.time;
    }
    public int getComboStage()
    {
        return comboStage;
    }
}
