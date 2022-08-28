using UnityEngine;

public class ComboTree
{
    ComboNode[] comboNodes;
    private int currentNode;

    public ComboTree(ComboNode[] comboNodes)
    {
        this.comboNodes = comboNodes;
        currentNode = 0;
    }

    public void DecreaseTimer()
    {
        if (comboNodes[currentNode].DecreaseTimer())
        {
            TraverseNextNode(ActionEnum.DELAY);
        }
    }

    public NodeData TraverseNextNode(ActionEnum actionEnum)
    {
        WaitTime waitTime = comboNodes[currentNode].GetWaitTime(actionEnum);
        if (waitTime.IsWaitTimeOver())
        {
            NodeData data = waitTime.GetNodeData();
            currentNode = data.GetNextNode();
            comboNodes[currentNode].ResetTimer();
            return data;
        }
        return null;
    }

    public ComboNode GetCurrentNode()
    {
        return comboNodes[currentNode];
    }
}