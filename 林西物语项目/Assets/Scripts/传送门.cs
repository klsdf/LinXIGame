using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 传送门 : Shop
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void 进入下一层()
    {
        canvas.gameObject.SetActive(false);
        GameManager.Instance.EnterNextLayer();


    }

}
