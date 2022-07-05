using UnityEngine;

public class InputHandlerAttack: MonoBehaviour
{
    void Update()
    {
        if (FireLightInputPressed())
        {
            this.gameObject.GetComponent<AttackGenerate>().SpawnAttack(ActionEnum.LIGHT);
        }
        if (FireHeavyInputPressed())
        {
            this.gameObject.GetComponent<AttackGenerate>().SpawnAttack(ActionEnum.HEAVY);
        }
    }
    private bool FireLightInputPressed()
    {
       return Input.GetKeyDown(KeyCode.Mouse0);
    }

    private bool FireHeavyInputPressed()
    {
        return Input.GetKeyDown(KeyCode.Mouse1);
    }
}
