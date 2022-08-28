using System.Collections.Generic;
using UnityEngine;

public class ComboNode
{
    Dictionary<ActionEnum, WaitTime> waitTimes;

    public ComboNode(Dictionary<ActionEnum, WaitTime> waitTimes)
    {
        this.waitTimes = waitTimes;
    }

    public WaitTime GetWaitTime(ActionEnum actionEnum)
    {
        return waitTimes[actionEnum];
    }

    public void ResetTimer()
    {
        foreach (ActionEnum actionEnum in waitTimes.Keys)
        {
            waitTimes[actionEnum].ResetTimer();
        }
    }

    public bool DecreaseTimer()
    {
        foreach (ActionEnum actionEnum in waitTimes.Keys)
        {
            waitTimes[actionEnum].DecreaseTimer();
            if (actionEnum.Equals(ActionEnum.DELAY) && waitTimes[actionEnum].currentValue == 0f)
            {
                return true;
            }
        }
        return false;
    }

}