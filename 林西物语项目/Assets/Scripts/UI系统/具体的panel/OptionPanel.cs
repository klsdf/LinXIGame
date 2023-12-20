using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class OptionPanel : BasePanel
{
    public Slider masterSlider;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    public Toggle toggle;

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

        //选项

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        toggle.onValueChanged.AddListener(ToggleFullScreen);
    }

    public override void OnClose()
    {
        SaveSystem.Instance.SaveSetting();
    }
    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
 
        // Set the resolution to the selected one
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
