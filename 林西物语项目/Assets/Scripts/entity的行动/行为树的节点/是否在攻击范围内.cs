using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using UnityEngine.UIElements;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 是否在攻击范围内 : Conditional
{
    public SharedTransform enemy;

    public float attackRange;

    private BattleBase  battleBase;

    public override void OnStart()
    {
        battleBase = GetComponent<BattleBase>();
        attackRange = battleBase.attackRange;
    }

    public override TaskStatus OnUpdate()
    {

        Vector2 dir = enemy.Value.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, attackRange, LayerMask.GetMask("Obstacle"));

        if (Vector2.Distance(enemy.Value.position, transform.position) <= attackRange)
        {

            return TaskStatus.Success;
        }

        return TaskStatus.Failure;


    }
}
