using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class DialogEffect : Singleton<DialogEffect>
{
    public Light2D light2D;
    public void FadeIn()
    {
        light2D.intensity = 1;
    }


    public void FadeOut()
    {
        light2D.intensity = 0;
    }
}
