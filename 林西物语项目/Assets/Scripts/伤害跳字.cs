using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 伤害跳字 : MonoBehaviour
{

    void Start()
    {
  
        
    }
    public float duration = 3f;
    public float moveDistance = 3f;
    public TMP_Text damageText;

    public void Init(float damage)
    {
        damageText.text = "-"+damage.ToString();

        // 向上移动
        transform.DOMoveY(transform.position.y + moveDistance, duration);

        // 透明度变低
        damageText.DOFade(0, duration).OnComplete(() => Destroy(gameObject));
    }

}
