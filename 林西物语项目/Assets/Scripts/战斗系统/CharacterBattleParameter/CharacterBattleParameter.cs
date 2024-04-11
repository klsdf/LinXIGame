using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Stats")]
public class CharacterBattleParameter : ScriptableObject
{
    [Header("最大生命")]
    public float maxHp;

    [Header("攻击")]
    public float atk;

    [Header("防御")]
    public float def;

    [Header("远程攻击")]
    public float rangeAtk;

    [Header("远程防御")]
    public float rangeDef;

    [Header("暴击率")]
    public float crit;

    [Header("暴击伤害")]
    public float critDamage;

    [Header("格挡率")]
    public float block;

    [Header("攻击距离")]
    public float attackRange = 3.0f;

    [Header("侦察距离")]
    public float reconnaissanceRange = 10.0f;

    [Header("移动耗时")]
    public float costTime = 1;//每进行一次行动的耗时

    public void Init(CharacterBattleParameter baseParamter)
    {
        maxHp = baseParamter.maxHp;
        atk = baseParamter.atk;
        def = baseParamter.def;
        rangeAtk = baseParamter.rangeAtk;
        rangeDef = baseParamter.rangeDef;
        crit = baseParamter.crit;
        critDamage = baseParamter.critDamage;
        block = baseParamter.block;
        attackRange = baseParamter.attackRange;
        reconnaissanceRange = baseParamter.reconnaissanceRange;
        costTime = baseParamter.costTime;
    }
}
