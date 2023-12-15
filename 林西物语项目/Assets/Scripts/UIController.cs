using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class UIController : Singleton<UIController>
{


    void Start()
    {

    }


    void Update()
    {

    }


    public void OnOption()
    {
        print("okkk");
    }

    public void OnStart()
    {
        SceneLoad.Instance.LoadSceneAsync();
    }


    public void OnQuit()
    {
        
    }
}
