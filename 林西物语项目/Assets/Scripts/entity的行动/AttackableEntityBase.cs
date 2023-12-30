using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public abstract class AttackableEntityBase : EntityActionBase
{
    public NPCType profession;//职业
    protected EnvCheck envCheck;

    protected override void Start()
    {
        base.Start();
        envCheck = GetComponentInChildren<EnvCheck>();
    }
    protected override abstract void Action(float playerCostTime);

}
