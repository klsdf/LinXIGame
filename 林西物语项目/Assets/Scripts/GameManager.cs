using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
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



    private int moJIngNum = 10000;


    public TMP_Text text;
    private void Awake()
    {
        //text = GetComponent<TMP_Text>();
    }

    private void ChangeMOjing(int num)
    {
        moJIngNum += num;
        moJIngNum = Mathf.Clamp(moJIngNum,0,999999);
        text.text = moJIngNum.ToString();
    }

    public int CheckMojingNum()
    {
        return moJIngNum;
    }
    public void CostMojing(int num)
    {
        ChangeMOjing(-num);
    }

    public void GetMojing(int num)
    {
        ChangeMOjing(num);
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
    private void Start()
    {
  
    }

}
