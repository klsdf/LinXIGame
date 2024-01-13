using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

public enum DamageType
{
    普通,
    暴击,
    格挡
}


public class 伤害跳字 : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, duration);
        
    }
    public float duration = 3f;
    public float moveDistance = 3f;
    private TMP_Text damageText;




    public void Init(float damage, DamageType damageType)
    {
        damageText = GetComponentInChildren<TMP_Text>();
        damageText.alpha = 1;

        switch (damageType)
        {
            case DamageType.普通:
                damageText.text = "-" + damage.ToString();
                break;
            case DamageType.暴击:
                damageText.text = "Crit!  -" + damage.ToString();
                damageText.fontSize += 50;
                break;
            case DamageType.格挡:
                damageText.text = "Blcok! 0";
                break;
        }

        

        // 向上移动
        transform.DOMoveY(transform.position.y + moveDistance, duration);
        // 透明度变低
        damageText.DOFade(0, duration);
    }
    private void Update()
    {
        
    }
}
