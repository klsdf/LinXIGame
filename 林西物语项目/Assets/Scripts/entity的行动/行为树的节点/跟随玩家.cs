using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 跟随玩家 : Action
{
    private EntityActionBase entityController;

    private GameObject player;


    public override void OnStart()
    {
        player = GameManager.Instance.player;
        entityController = GetComponent<EntityActionBase>();
    }


    public override TaskStatus OnUpdate()
    {

        //Vector3 playerTempPosition = player.transform.position + new Vector3(Random.Range(-NPCMoveSize, NPCMoveSize), Random.Range(-NPCMoveSize, NPCMoveSize), 0);
        Vector3 playerTempPosition = player.transform.position;
        //集群力，默认以玩家为中心点
        Vector3 directionToPlayer = (playerTempPosition - entityController.targetPosition).normalized;
        entityController.targetPosition = entityController.targetPosition + directionToPlayer;
        return TaskStatus.Success;
    }
}
