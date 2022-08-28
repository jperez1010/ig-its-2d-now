using System;
using UnityEngine;

public class WaitTime
{

    public float maxValue;
    public float currentValue;
    public NodeData nodeData;

    public WaitTime(float maxValue, NodeData nodeData)
    {
        this.maxValue = maxValue;
        this.nodeData = nodeData;
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

    public bool IsWaitTimeOver()
    {
        return currentValue == 0f;
    }

    public NodeData GetNodeData()
    {
        return nodeData;
    }
}

public abstract class NodeData
{
    protected int nextNode;

    public int GetNextNode()
    {
        return nextNode;
    }
}

public class AttackNodeData : NodeData
{
    public GameObject attack;
    
    public AttackNodeData(GameObject attack) : this(attack, 0) { }
    
    public AttackNodeData(GameObject attack, int nextNode)
    {
        this.attack = attack;
        this.nextNode = nextNode;
    }
}

public class MovementNodeData : NodeData
{
    public MovementNodeData() : this(0) { }
    
    public MovementNodeData(int nextNode)
    {
        this.nextNode = nextNode;
    }
}

public class DelayNodeData : NodeData
{
    public DelayNodeData() : this(0) { }

    public DelayNodeData(int nextNode)
    {
        this.nextNode = nextNode;
    }

}
