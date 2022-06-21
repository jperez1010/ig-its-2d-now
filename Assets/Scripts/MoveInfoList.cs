using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInfoList : MonoBehaviour
{
    public static Dictionary<Attacks, MoveInfo> MoveInfo = new Dictionary<Attacks, MoveInfo>()
    {
        { Attacks.MAGIC_SHOT, new MoveInfo("Magic Shot", 1, 0.25f, 1, MoveType.MAGIC, RangeType.BASIC_RANGED, Resources.Load<GameObject>("Prefabs/Entities/ManaBall")) },
        { Attacks.HAT_TRICK, new MoveInfo("Hat Trick", 1, 0.25f, 1, MoveType.MAGIC, RangeType.BASIC_RANGED, Resources.Load<GameObject>("Prefabs/Entities/Mana Ball"))}
    };

    public static Dictionary<RangeType, AttackBehaviour> Behaviour = new Dictionary<RangeType, AttackBehaviour>()
    {
        { RangeType.BASIC_RANGED, new BasicRanged() },
        { RangeType.BASIC_MELEE, new BasicMelee() }
    };
}
