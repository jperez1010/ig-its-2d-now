using System;
using UnityEngine;

public class WaitTimeHandler : MonoBehaviour
{
    public event EventHandler OnWaitTimesAltered;
    public ComboTree comboTree;
    public ComboTreePreset comboTreePreset;

    void Start()
    {
        comboTree = comboTreePreset.CreateTree();
    }

    void Update()
    {
        DecreaseTimer();
    }

    public (bool, GameObject) GetNextNode(ActionEnum actionEnum)
    {
        return comboTree.GetNextNode(actionEnum);
    }

    private void DecreaseTimer()
    {
        comboTree.DecreaseTimer();
        OnWaitTimesAltered?.Invoke(this.comboTree.GetCurrentNode(), EventArgs.Empty);
    }
}