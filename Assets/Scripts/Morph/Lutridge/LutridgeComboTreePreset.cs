using System.Collections.Generic;
using UnityEngine;

public class LutridgeComboTreePreset : ComboTreePreset
{
    public GameObject manaBall;

    public override ComboTree CreateTree()
    {
        ComboNode[] comboNodes = new ComboNode[3];

        Dictionary<ActionEnum, WaitTime> waitTimes_default = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.MOVEMENT, new WaitTime(0.15f, new MovementNodeData()) },
            { ActionEnum.LIGHT, new WaitTime(0.8f, new AttackNodeData(null, 1)) },
            { ActionEnum.HEAVY, new WaitTime(1.6f, new AttackNodeData(manaBall)) }
        };
        ComboNode node_0 = new ComboNode(waitTimes_default);
        comboNodes[0] = node_0;

        Dictionary<ActionEnum, WaitTime> waitTimes_L = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.DELAY, new WaitTime(1.7f, new DelayNodeData()) },
            { ActionEnum.MOVEMENT, new WaitTime(1.3f, new MovementNodeData()) },
            { ActionEnum.LIGHT, new WaitTime(0.75f, new AttackNodeData(null, 2)) },
            { ActionEnum.HEAVY, new WaitTime(2f, new AttackNodeData(manaBall)) }  
        };
        ComboNode node_1 = new ComboNode(waitTimes_L);
        comboNodes[1] = node_1;

        Dictionary<ActionEnum, WaitTime> waitTimes_LL = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.DELAY, new WaitTime(1.5f, new DelayNodeData()) },
            { ActionEnum.MOVEMENT, new WaitTime(1.25f, new MovementNodeData()) },
            { ActionEnum.LIGHT, new WaitTime(2f, new AttackNodeData(null)) },
            { ActionEnum.HEAVY, new WaitTime(0.75f, new AttackNodeData(manaBall)) }
        };
        ComboNode node_2 = new ComboNode(waitTimes_LL);
        comboNodes[2] = node_2;

        return new ComboTree(comboNodes);
    }
}
