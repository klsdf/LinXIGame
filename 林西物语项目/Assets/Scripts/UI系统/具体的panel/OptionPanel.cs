using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class OptionPanel : BasePanel
{
    public Slider masterSlider;

    public void Close()
    {
        UIController.Instance.PopPanel(gameObject);
    }

    

  



    public override void OnOpen()
    {
        masterSlider.onValueChanged.AddListener(MusicController.Instance.SetMasterVolume);
    }

    public override void OnClose()
    {
        print("关闭");
    }


}
