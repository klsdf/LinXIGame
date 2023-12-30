using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 被玩家操控中 : Conditional
{

    NPCController npc;

    public SharedBool 是否被玩家控制;
    

    public override void OnStart()
    {
        npc = GetComponent<NPCController>();
    }


    public override TaskStatus OnUpdate()
    {
        bool isPlayerControl = npc.isPlayerControl;

        if (isPlayerControl == true)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }

        
    }

}
