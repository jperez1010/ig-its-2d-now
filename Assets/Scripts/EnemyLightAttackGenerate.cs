using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightAttackGenerate : MonoBehaviour
{
    [SerializeField]
    GameObject Morph;
    public float SpawnDistance = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.OnEnemyLightAttackCommand += EnemySpawnAttack;
    }

    // Update is called once per frame
    private void EnemySpawnAttack()
    {
        Attacks AttackName = Morph.GetComponent<AttackPool>().lightAttack;
        MoveInfo AttackInfo;
        MoveInfoList.MoveInfo.TryGetValue(AttackName, out AttackInfo);
        Vector3 Direction = GetDirection();

        GameObject AttackInstance = GameObject.Instantiate((UnityEngine.GameObject)Resources.Load("Attack"), Direction, Quaternion.identity);
        AttackInstance.GetComponent<AttackStats>().name = AttackInfo.GetMoveName();
        AttackInstance.GetComponent<AttackStats>().damage = AttackInfo.GetDamage();
        AttackInstance.GetComponent<AttackStats>().speed = AttackInfo.GetSpeed();
        AttackInstance.GetComponent<AttackStats>().knockback = AttackInfo.GetKnockback();
        AttackInstance.GetComponent<AttackStats>().type = AttackInfo.GetMoveType();
        AttackInstance.GetComponent<AttackStats>().direction = Direction;
        GameObject visual = Instantiate(AttackInfo.GetVisual());
        visual.transform.parent = AttackInstance.transform;

        AttackBehaviour Behaviour;
        MoveInfoList.Behaviour.TryGetValue(AttackInfo.GetRangeType(), out Behaviour);
        AttackBehaviour BehaviourComponent = AttackInstance.GetComponent(Behaviour.GetType()) as AttackBehaviour;
        BehaviourComponent.enabled = !BehaviourComponent.enabled;
        BehaviourComponent.SetSpeed(AttackInfo.GetSpeed());
        BehaviourComponent.SetDirection(Direction);

        AttackInstance.transform.position = Morph.transform.position + Direction * SpawnDistance;
    }
    public Vector3 GetDirection()
    {
        return Morph.GetComponent<EnemyAI>().GetDirection();
    }
}
