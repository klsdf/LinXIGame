using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class SpecialActionCreateMoney : SpecialAction
{    //当前所耗费的时间
    protected float nowCostTime;

    //冷却时间
    protected float cooltime = 5;
    public override void DoAction(float playerCostime)
    {
        nowCostTime += playerCostime;
        while (nowCostTime >= cooltime)
        {
                nowCostTime -= cooltime;
            CreateMoney();       
        }
    }

    private void CreateMoney()
    {
        GameManager.Instance.GetMojing(1);
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
