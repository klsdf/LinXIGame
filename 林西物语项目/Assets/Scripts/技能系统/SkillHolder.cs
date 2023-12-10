using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class SkillHolder : MonoBehaviour
{
    //public Skill skill;
    public float nowCostTime = 0;
  


    public Skill skill;

    private void Start()
    {

        switch (skill.skillType) 
        {
            case SkillType.闪现:
                skill = new SkillFlash(SkillType.闪现,skill.cooldownTime, skill.activeTime);
                break;
        }
    
        GameManager.Instance.OnPlayerMove += (playerCostTime )=>
        {
            //如果技能是准备状态，或者是执行状态，那么就不进行刷新
            if (skill.skillState == SkillState.ready || skill.skillState== SkillState.active)
            {
                return;
            }
            nowCostTime += playerCostTime;
            if (nowCostTime >= skill.cooldownTime)
            {
                nowCostTime -= skill.cooldownTime;
                skill.skillState = SkillState.ready;
                
            }
        };
    }


    void Update()
    {
        
    }


    public void CastSkill()
    {
        
        if (skill.skillState==SkillState.ready)
        {
            skill.Active(gameObject);
            skill.skillState = SkillState.cooldown;

        }
    }




}
