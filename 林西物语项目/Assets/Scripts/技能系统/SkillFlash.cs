using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

//[CreateAssetMenu(fileName = "Data", menuName = "自定义脚本/MyScriptableObject", order = 1)]
public class SkillFlash : Skill
{
    public override void Active(GameObject playerObj)
    {
     
        Debug.Log("闪现"+ playerObj.name);
        //让玩家瞬移到鼠标点击的位置
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 10;
        //Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        //playerObj.transform.position = targetPos;



    }

    public SkillFlash(SkillType skillType, float cooldownTime, float activeTime)
        : base(skillType, cooldownTime, activeTime)
    {
    }

}
