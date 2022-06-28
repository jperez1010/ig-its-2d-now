using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class AttackGenerate : MonoBehaviour
{
    private GameObject Morph;
    public float spawn_distance = 0.4f;
    public Transform fireposition;
    [SerializeField]
    MorphComboTree tree;

    public void SpawnAttack(AttackInputType attackType)
    {
        Morph = GameObject.FindGameObjectWithTag("Player");
        Attacks AttackName = comboAttack(attackType);
        MoveInfo AttackInfo;
        MoveInfoList.MoveInfo.TryGetValue(AttackName, out AttackInfo);
        Vector3 Direction = GetDirection();

        GameObject AttackInstance = Instantiate((UnityEngine.GameObject)Resources.Load("Attack"), Direction, Quaternion.identity);
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

        AttackInstance.transform.position = Morph.transform.Find("Aim").position + Direction * spawn_distance;
    }

    public Vector3 GetDirection()
    {
        return GameObject.Find("Player").GetComponentInChildren<PlayerAim>().GetDirection().normalized;
    }
    private Attacks comboAttack(AttackInputType attackType)
    {
        Attacks AttackName = Morph.GetComponent<AttackPool>().lightAttack;
        if (attackType == AttackInputType.HEAVY)
        {
            AttackName = Morph.GetComponent<AttackPool>().heavyAttack;
        }
        int comboStage = Morph.GetComponent<ComboStage>().getComboStage();
        if (comboStage != 0)
        {
            foreach (List<ComboNode> c in tree.comboTree)
            {
                if (comboStage < c.Count)
                {
                    string temp = "";
                    for (int i = 0; i < comboStage; i++)
                    {
                        if (c[i].getType() == AttackInputType.LIGHT)
                        {
                            temp += "L";
                        }
                        else
                        {
                            temp += "H";
                        }
                    }
                    if (c[comboStage].getType() == attackType && temp == Morph.GetComponent<ComboStage>().currentCombo())
                    {
                        AttackName = c[comboStage].getAttack();
                        Debug.Log(comboStage);
                        Morph.GetComponent<ComboStage>().comboNext();
                        if (attackType == AttackInputType.LIGHT)
                        {
                            Morph.GetComponent<ComboStage>().addLight();
                        }
                        else
                        {
                            Morph.GetComponent<ComboStage>().addHeavy();
                        }
                        return AttackName;
                    }
                }
            }
        }
        Morph.GetComponent<ComboStage>().clear();
        Morph.GetComponent<ComboStage>().comboNext();
        if (attackType == AttackInputType.LIGHT)
        {
            Morph.GetComponent<ComboStage>().addLight();
        } else
        {
            Morph.GetComponent<ComboStage>().addHeavy();
        }
        return AttackName;
    }
}
