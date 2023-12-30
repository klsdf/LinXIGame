using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 是否在攻击范围内 : Conditional
{
    public SharedTransform enemy;

    public float attackRange = 3.0f;

    void Start()
    {
        
    }

    public override TaskStatus OnUpdate()
    {

        if (Vector2.Distance(enemy.Value.position, transform.position) <= attackRange)
        {

            return TaskStatus.Success;
        }

        return TaskStatus.Failure;


    }
}
