using System.Collections.Generic;
using UnityEngine;

public class VergicComboTreePreset : ComboTreePreset
{
    public GameObject manaBall;

    public override ComboTree CreateTree()
    {
        ComboNode[] comboNodes = new ComboNode[2];

        Dictionary<ActionEnum, WaitTime> waitTimes_0 = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.MOVEMENT, new WaitTime(0.1f) },
            { ActionEnum.LIGHT, new WaitTime(1.5f, 1) },
            { ActionEnum.HEAVY, new WaitTime(3f, 0, manaBall) }
        };
        ComboNode node_0 = new ComboNode(waitTimes_0);
        comboNodes[0] = node_0;

        Dictionary<ActionEnum, WaitTime> waitTimes_1 = new Dictionary<ActionEnum, WaitTime>()
        {
            { ActionEnum.DELAY, new WaitTime(1f) },
            { ActionEnum.MOVEMENT, new WaitTime(0.5f) },
            { ActionEnum.LIGHT, new WaitTime(0.2f) },
            { ActionEnum.HEAVY, new WaitTime(3f) }  
        };
        ComboNode node_1 = new ComboNode(waitTimes_1);
        comboNodes[1] = node_1;

        return new ComboTree(comboNodes);
    }
}
