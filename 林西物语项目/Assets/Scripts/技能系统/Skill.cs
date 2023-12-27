using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// 
/// 技能的数据类
/// </summary>
/// 


public enum SkillState
{
    ready,
    active,
    cooldown
}

[Serializable]
public class Skill 
{

    public SkillType skillType;
    [SerializeField]
    public float cooldownTime;//冷却时间
    [SerializeField]
    public float activeTime;//持续时间

    SkillState _skillState;//默认初始值为冷却状态

    public SkillState skillState
    {
        get
        {
            return _skillState;
        }
        set
        {
            _skillState = value;
        }
    }

  

    public virtual void Active(GameObject obj)
    {  
    }


     public  Skill(SkillType skillType, float cooldownTime, float activeTime) 
    {
        this.skillType = skillType;
        this.cooldownTime = cooldownTime;
        this.activeTime = activeTime;
        skillState = SkillState.cooldown;
    }
}
