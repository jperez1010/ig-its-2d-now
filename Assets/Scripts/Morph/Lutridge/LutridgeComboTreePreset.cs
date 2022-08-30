using System.Collections.Generic;
using UnityEngine;

public class LutridgeComboTreePreset : ComboTreePreset
{
    public override ComboTree CreateTree()
    {
        ComboNode[] comboNodes = new ComboNode[1];

        Dictionary<ActionEnum, WaitTime> waitTimes_default = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.MOVEMENT, new WaitTime(0.15f, new MovementNodeData()) }
        };
        ComboNode node_0 = new ComboNode(waitTimes_default);
        comboNodes[0] = node_0;

        return new ComboTree(comboNodes);
    }
}
