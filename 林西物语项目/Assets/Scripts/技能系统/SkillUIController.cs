using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 作者：闫辰祥
/// 
/// 用于控制技能的UI图标
/// </summary>
public class SkillUIController : MonoBehaviour
{

    Image image;
    TMP_Text text;


    private void Awake()
    {
        //默认第一个子元素是图像，第二个是文字
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    void Start()
    {
        GameManager.Instance.OnPlayerMove += (playerCostTime) =>
        {

            SkillHolder skillHolder = GameManager.Instance.player.GetComponent<SkillHolder>();
           

            var p = 1 - skillHolder.nowCostTime / skillHolder.skill.cooldownTime;
            //如果p接近于1，则显示技能已经加载好
            if (Mathf.Abs(p - 1) < 0.01f)
            {
                image.fillAmount = 0;
                text.text = "";
                return;
            }
            else {

                image.fillAmount = p;
                text.text = (skillHolder.skill.cooldownTime - skillHolder.nowCostTime).ToString();
            }
            
    
        };
    }


    void Update()
    {
       

    }

 

}
