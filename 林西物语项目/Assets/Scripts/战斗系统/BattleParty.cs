using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>

public enum BattleParty
{
    Player,//玩家阵营
    Neutral,//完全中立
    CapturedPlayer,//被抓的玩家阵营
    NeutralEnemy,//中立野怪，被攻击后会变成敌人
    Enemy//敌方阵营
}
