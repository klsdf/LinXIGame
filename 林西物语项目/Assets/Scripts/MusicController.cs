using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 作者：闫辰祥
/// </summary>

public class MusicController : MonoBehaviour
{
    public AudioMixer mainMixer; // 指向你的MainMixer的引用

    [Range(-80,10)]
    public float volume = 0.0f;

    private void Update()
    {
        mainMixer.SetFloat("Master", volume);
    }

    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("Master", volume);
    }

    public void SetBGMVolume(float volume)
    {
        mainMixer.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", volume);
    }
}