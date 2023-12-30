using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class Util 
{



    /// <summary>
    /// 百分之probability的概率触发callback
    /// </summary>
    /// <param name="probability">概率</param>
    /// <param name="callback">回调方法</param>
    /// <returns>触发成功返回true，否则false</returns>
    public static bool TryTrigger(float probability, Action callback)
    {

        float roll = UnityEngine.Random.Range(0f, 1f);
        if (roll <= probability)
        {
            callback();
            return true;
        }

        return false;
    }

    public static bool TryTrigger(float probability)
    {

        float roll = UnityEngine.Random.Range(0f, 1f);
        if (roll <= probability)
        {
            return true;
        }

        return false;
    }


    public static bool isEnemy(BattleBase battleBase1 ,BattleBase battleBase2)
    {
        if (battleBase1.party == BattleParty.Player && battleBase2.party == BattleParty.Enemy)
            return true;
        if (battleBase1.party == BattleParty.Enemy && battleBase2.party == BattleParty.Player)
            return true;
        return false;
    }


}
