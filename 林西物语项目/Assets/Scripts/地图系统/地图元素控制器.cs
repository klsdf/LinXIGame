using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 地图元素控制器 : MonoBehaviour
{

    public 地区级别 级别 = 地区级别.一级;

    TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();

        地图缩放.Instance.缩放图标 += (地区级别 当前缩放的级别) =>
        {
            if (级别 == 当前缩放的级别)
            {
                FadeIn();
               
            }
            else {
                FadeOut();
            }
        };
    }
    private void FadeOut()
    {
        text.DOFade(0f, 0.5f).OnComplete(() => text.enabled = false);
    }
    private void FadeIn()
    {
        text.DOFade(1f, 0.5f).OnComplete(() => text.enabled = true);
    }
}
