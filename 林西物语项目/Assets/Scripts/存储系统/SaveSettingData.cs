using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// 用于存储游戏的设置数据
/// </summary>
/// 

[System.Serializable]
public class SaveSettingData 
{
    public int masterVolume;
    public int bgmVolume;
    public int effectVolume;


    //默认的参数
    public SaveSettingData()
    {
        masterVolume = 0;
        bgmVolume = 0;
        effectVolume = 0;
    }

}
