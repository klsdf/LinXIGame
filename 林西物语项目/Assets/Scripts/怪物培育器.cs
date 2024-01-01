using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 怪物培育器 : EntityActionBase
{



    protected override void Action(float playerCostTime)
    {

        nowCostTime += playerCostTime;

        while (nowCostTime >= battleBase.costTime)
        {
            //创建敌人对象

            GameObject bullet = Resources.Load<GameObject>("Entity/敌人战士");

            GameObject bulletObj = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);



            nowCostTime -= battleBase.costTime;
        }
    }
}
