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
        (bool, GameObject) result = waitTimeHandler.GetNextNode(actionEnum);
        if (result.Item1)
        {
            Debug.Log(actionEnum);
            anim.SetTrigger("Cast");
            if (result.Item2)
            {
                GameObject attack = Instantiate(result.Item2);
                attack.transform.position = this.transform.position + GetDirection() * spawn_distance;
                attack.GetComponent<HarmEnemy>().direction = GetDirection();
            }
        }
    }

    public Vector3 GetDirection()
    {
        return GameObject.Find("Player").GetComponentInChildren<PlayerAim>().GetDirection().normalized;
    }   
}
