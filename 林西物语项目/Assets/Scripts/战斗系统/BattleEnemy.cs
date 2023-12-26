using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BattleEnemy : BattleBase
{
    public int reward = 10;
   
    public override void Dead()
    {
        base.Dead();
        

        GameManager.Instance.GetMojing(reward);
        bool hasBlood = Util.TryTrigger(0.5f, () =>
        {
            Instantiate(Resources.Load<GameObject>("HP球"), transform.position, Quaternion.identity);
        });
        if (!hasBlood)
        {
            Util.TryTrigger(0.5f, () =>
            {
                Instantiate(Resources.Load<GameObject>("金币"), transform.position, Quaternion.identity);
            });

        }

    }
}
