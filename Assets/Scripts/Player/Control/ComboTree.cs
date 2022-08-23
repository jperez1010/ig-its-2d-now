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
            GetNextNode(ActionEnum.DELAY);
        }
    }

    public (bool, GameObject) GetNextNode(ActionEnum actionEnum)
    {
        (int, GameObject) result = comboNodes[currentNode].GetNextNode(actionEnum);
        int index = result.Item1;
        GameObject attack = result.Item2;
        if (index == -1)
        {
            return (false, null);
        }
        currentNode = index;
        comboNodes[currentNode].ResetTimer();
        return (true, attack);
    }

    public ComboNode GetCurrentNode()
    {
        return comboNodes[currentNode];
    }
}