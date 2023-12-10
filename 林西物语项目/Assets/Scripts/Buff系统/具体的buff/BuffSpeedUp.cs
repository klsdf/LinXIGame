using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BuffSpeedUp : BuffBase
{
    public BuffSpeedUp(string bufflName, float activeTime)
      : base(bufflName, activeTime)
    {
    }

    public override void Active(GameObject obj)
    {
        base.Active(obj);
        GameManager.Instance.player.GetComponent<BattleBase>().costTime = 0.5f;


    }

    public override void Stop(GameObject obj)
    {
        base.Stop(obj);
        GameManager.Instance.player.GetComponent<BattleBase>().costTime = 1f;
    }
}
