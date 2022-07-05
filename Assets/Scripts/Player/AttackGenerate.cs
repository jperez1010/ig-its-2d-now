using UnityEngine;

public class AttackGenerate : MonoBehaviour
{
    public float spawn_distance = 0.4f;
    public Transform fireposition;

    [SerializeField]
    public WaitTimeHandler waitTimeHandler;

    public void SpawnAttack(ActionEnum actionEnum)
    {
        (bool, GameObject) result = waitTimeHandler.GetNextNode(actionEnum);
        if (result.Item1)
        {
            Debug.Log(actionEnum);
        }
    }

    public Vector3 GetDirection()
    {
        return GameObject.Find("Player").GetComponentInChildren<PlayerAim>().GetDirection().normalized;
    }   
}
