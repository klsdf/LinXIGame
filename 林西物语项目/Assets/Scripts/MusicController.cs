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

    [Range(-80,10)]
    public float volume = 0.0f;




    private void Start()
    {

    }






    public void SetMasterVolume(float volume)
    {
        SetVolume("Master", volume);
    }

    public void SetBGMVolume(float volume)
    {
        mainMixer.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", volume);
    }


    private void SetVolume(string name, float volume)
    {
        volume = Mathf.Clamp(volume,-80,20);
        mainMixer.SetFloat(name, volume);
    }
}