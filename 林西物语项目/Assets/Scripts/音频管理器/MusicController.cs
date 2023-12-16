using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.UI;

/// <summary>
/// 作者：闫辰祥
/// </summary>

public class MusicController : Singleton<MusicController>
{

    public AudioMixer mainMixer; // 指向你的MainMixer的引用

    public void SetMasterVolume(float volume)
    {
        SetVolume("Master", volume);
        SaveSystem.Instance.settingData.masterVolume = (int)volume;
    }

    //public void SetBGMVolume(float volume)
    //{
    //    mainMixer.SetFloat("BGMVolume", volume);
    //    SaveSystem.Instance.settingData.bgmVolume = (int)volume;
    //}

    //public void SetSFXVolume(float volume)
    //{
    //    mainMixer.SetFloat("SFXVolume", volume);
    //    SaveSystem.Instance.settingData.effectVolume = (int)volume;
    //}


    private void SetVolume(string name, float volume)
    {
        volume = Mathf.Clamp(volume,-80,20);
        mainMixer.SetFloat(name, volume);
    }
}