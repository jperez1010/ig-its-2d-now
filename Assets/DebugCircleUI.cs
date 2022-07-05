using UnityEngine;
using UnityEngine.UI;

public class DebugCircleUI : MonoBehaviour
{
    public WaitTimeHandler waitTimeHandler;
    public ActionEnum actionEnum;

    public void Start()
    {
        waitTimeHandler.OnWaitTimesAltered += PlayerInputWait_OnWaitTimesAltered;
    }

    private void PlayerInputWait_OnWaitTimesAltered(object sender, System.EventArgs e)
    {
        ComboNode comboNode = (ComboNode) sender;
        UpdateCircle(comboNode.GetWaitTime(actionEnum));
    }

    public void UpdateCircle(WaitTime waitTime)
    {
        float maximumAmount = waitTime.maxValue;
        float currentAmount = waitTime.currentValue;
        GetComponent<Image>().fillAmount = currentAmount / maximumAmount;
    }
}