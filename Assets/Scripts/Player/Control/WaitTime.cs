using UnityEngine;

public class WaitTime
{
    public float maxValue;
    public float currentValue;
    public int nextNode;
    public GameObject attack;

    public WaitTime(float maxValue) : this(maxValue, 0)
    {

    }
    public WaitTime(float maxValue, int nextNode) : this(maxValue, nextNode, null)
    {
    
    }

    public WaitTime(float maxValue, int nextNode, GameObject attack)
    {
        this.maxValue = maxValue;
        this.nextNode = nextNode;
        this.attack = attack;
        ResetTimer();
    }

    public void ResetTimer()
    {
        currentValue = maxValue;
    }

    public float DecreaseTimer()
    {
        if (currentValue != 0f)
        {
            currentValue = Mathf.Max(0f, currentValue - (1f * Time.deltaTime));
        }
        return currentValue;
    }

    public (int, GameObject) GetNextNode()
    {
        if (currentValue == 0)
        {
            return (nextNode, attack);
        }
        return (-1, null);
    }

    public void SetNextNode(int nextNode)
    {
        this.nextNode = nextNode;
    }
}
