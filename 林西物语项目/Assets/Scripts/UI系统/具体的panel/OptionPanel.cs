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

        SaveSystem.Instance.LoadSetting();
        masterSlider.onValueChanged.AddListener(MusicController.Instance.SetMasterVolume);
        masterSlider.value = SaveSystem.Instance.settingData.masterVolume;
        MusicController.Instance.SetMasterVolume(SaveSystem.Instance.settingData.masterVolume);
    }

    public override void OnClose()
    {
        SaveSystem.Instance.SaveSetting();
    }


}
