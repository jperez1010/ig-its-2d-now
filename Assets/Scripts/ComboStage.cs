using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboStage : MonoBehaviour
{
    private int comboStage = 0;
    private float timer = 0;
    private float elapsedTime;
    private string combo = "";
    void Update()
    {
        if (comboStage != 0)
        {
            elapsedTime = Time.time - timer;
        }
        if (elapsedTime > 0.5f)
        {
            clear();
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
    public void addLight()
    {
        this.combo += "L";
    }
    public void addHeavy()
    {
        this.combo += "H";
    }
    public string currentCombo()
    {
        return this.combo;
    }
    public void clear()
    {
        this.comboStage = 0;
        this.combo = "";
    }
}
