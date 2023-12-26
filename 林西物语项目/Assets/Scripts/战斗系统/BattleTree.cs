using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BattleTree : BattleBase
{
    public override void Dead()
    {
        base.Dead();
        Util.TryTrigger(0.7f, () =>
        {
            Instantiate(Resources.Load<GameObject>("大金币"), transform.position, Quaternion.identity);
        });
    }
}
