using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class GameManager : MonoBehaviour
{

    //单例模式
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

            }
            return instance;
        }
    }



    //观察者模式
    public event Action<float> OnPlayerMove;

    public GameObject player;


    public void PlayerMove()
    {
        float playerCostTime = player.GetComponent<BattleBase>().costTime;
        OnPlayerMove?.Invoke(playerCostTime);

        //print("ok");

    }

}
