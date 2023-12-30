using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 攻击 : Action
{
    public SharedTransform target;

    private BattleBase battleBase;


    public override void OnStart()
    {
        battleBase = GetComponent<BattleBase>();
    }

    public override TaskStatus OnUpdate()
    {
        
        target.Value.GetComponent<BattleBase>().ProcessAttack(battleBase);
        return TaskStatus.Success;

    }
}
