using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
                text.enabled = true;
            }
            else {
                text.enabled = false;
            }
        };
    }
}
