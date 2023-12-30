using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BehaviorDesigner.Runtime;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 追击 : Action
{
    public SharedTransform targetTrtansform;

    private EntityActionBase entityController;


    Vector3 targetPosition;
    public override void OnStart()
    {
        entityController = GetComponent<EntityActionBase>();
        base.OnStart();
        targetPosition = entityController.targetPosition;
    }

    public override TaskStatus OnUpdate()
    {
        Transform enemy = targetTrtansform.Value;
        if (enemy != null)
        {
            Vector3 actionTargetPosition = enemy.position;
            //playerTargetPosition = GameManager.Instance.player.GetComponent<CharacterController>().targetPosition;
            Vector3 directionToPlayer = (actionTargetPosition - targetPosition).normalized;
            entityController.targetPosition = targetPosition + directionToPlayer;
        }
        
        return TaskStatus.Success;


    }

}
