using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BehaviorDesigner.Runtime;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 移动到玩家控制点 : Action
{
    private NPCController entityController;
    public SharedVector3 点击的位置;
    public SharedBool 是否被玩家控制;

    public override void OnStart()
    {
        entityController = GetComponent<NPCController>();
    }


    public SharedTransform targetTrtansform;
    public override TaskStatus OnUpdate()
    {

            //集群力，默认以玩家为中心点
            Vector3 direction = (点击的位置.Value - entityController.targetPosition).normalized;
        entityController.targetPosition = entityController.targetPosition + direction;

            if (Vector2.Distance(点击的位置.Value, transform.position) < 1.0f)
            {
            entityController.isPlayerControl = false;
                //是否被玩家控制 = false;
            }
        return TaskStatus.Success;
    }
}
