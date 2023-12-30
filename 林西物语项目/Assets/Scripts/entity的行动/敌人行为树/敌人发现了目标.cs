using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 敌人发现了目标 : Conditional
{

    public float 侦测范围 = 10.0f;

    public SharedTransform targetTransform; //第一个敌人

    override public TaskStatus OnUpdate()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 侦测范围);

        foreach (var hitCollider in hitColliders)
        {
            
            BattleBase battleBase = hitCollider.GetComponent<BattleBase>();
            if (battleBase != null)
            {
                if (hitCollider.GetComponent<BattleBase>().party == BattleParty.Player)
                {
              
                    targetTransform.Value = hitCollider.transform;
                    //EnemyAttack(hitCollider.gameObject);
                    //nowCostTime -= battleBase.costTime;
                    return TaskStatus.Success;
                }
            }
        }

        return TaskStatus.Failure;
    }

    ////用gizom绘制侦测范围
    //override public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, 侦测范围);
    //}


}
