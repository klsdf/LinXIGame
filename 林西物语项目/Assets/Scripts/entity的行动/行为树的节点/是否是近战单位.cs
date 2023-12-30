using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 是否是近战单位 : Conditional
{



    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }
}
