using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackGenerate : MonoBehaviour
{
    private GameObject Morph;
    private float spawn_distance = 0.4f;
    private void Start()
    {
        EventManager.current.OnHeavyAttackCommand += SpawnAttack;
    }

    private void SpawnAttack()
    {
        Morph = GameObject.Find("Player");
        Attacks AttackName = Morph.GetComponent<AttackPool>().heavyAttack;
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
        visual.transform.parent = this.transform;

        AttackBehaviour Behaviour;
        MoveInfoList.Behaviour.TryGetValue(AttackInfo.GetRangeType(), out Behaviour);
        AttackBehaviour BehaviourComponent = AttackInstance.GetComponent(Behaviour.GetType()) as AttackBehaviour;
        BehaviourComponent.enabled = !BehaviourComponent.enabled;
        BehaviourComponent.SetSpeed(AttackInfo.GetSpeed());
        BehaviourComponent.SetDirection(Direction);

        AttackInstance.transform.position = Morph.transform.position + Direction * spawn_distance;
    }

    public Vector3 GetDirection()
    {
        return GameObject.Find("Player").GetComponentInChildren<PlayerAim>().GetDirection().normalized;
    }
}
