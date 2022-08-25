using UnityEngine;

public class AttackGenerate : MonoBehaviour
{
    public float spawn_distance = 0.4f;
    public Transform fireposition;

    [SerializeField]
    public WaitTimeHandler waitTimeHandler;
    public Animator anim;

    public void SpawnAttack(ActionEnum actionEnum)
    {
        AttackNodeData data =  (AttackNodeData) waitTimeHandler.GetNextNodeData(actionEnum);
        if (data != null)
        {
            anim.SetTrigger("Cast");
            Vector3 aimDirection = GetDirection();
            ChangeDirection(aimDirection);
            if (data.attack)
            {
                GameObject attack = Instantiate(data.attack);
                attack.transform.position = this.transform.position + aimDirection * spawn_distance;
                attack.GetComponent<HarmEnemy>().direction = aimDirection;
            }
        }
    }

    public Vector3 GetDirection()
    {
        return GetComponent<PlayerAim>().GetDirection().normalized;
    }

    public void ChangeDirection(Vector3 aimDirection)
    {
        GetComponent<PlayerMovement>().FlipPlayer(aimDirection.x > 0);
    }
}
