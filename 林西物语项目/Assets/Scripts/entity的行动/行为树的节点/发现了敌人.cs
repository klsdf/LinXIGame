using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 发现了敌人 : Conditional
{


    private float 侦测范围 = 10.0f;

    public SharedTransform targetTransform; //第一个敌人

    private BattleBase battleBase;

    public override void OnStart()
    {
        battleBase = GetComponent<BattleBase>();
        侦测范围 = battleBase.reconnaissanceRange;
    }


    override public TaskStatus OnUpdate()
    {

        float closestDistance = 999999;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 侦测范围);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject == gameObject)
            {
                continue;
            }
            
            BattleBase otherBattleBase = hitCollider.GetComponent<BattleBase>();

            if (otherBattleBase != null)
            {    
                if (Util.isEnemy(battleBase,otherBattleBase))
                {
                    float distanceToEnemy = Vector2.Distance(transform.position, hitCollider.transform.position);

                    if (distanceToEnemy < closestDistance)
                    {
                        closestDistance = distanceToEnemy;
                        targetTransform.Value = hitCollider.transform;
                    }
                }
            }
        }
        if (closestDistance == 999999)
        {
            return TaskStatus.Failure;
        }
        else {
            return TaskStatus.Success;
        }
       
    }

    ////用gizom绘制侦测范围
    //override public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, 侦测范围);
    //}


  
}
