using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class GameManager : Singleton<GameManager>
{

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


    /// <summary>
    /// 进入操作某个游戏对象的模式
    /// </summary>
    /// <param name="gameObject"></param>
    /// 
    public bool isControlMode = false;
    public GameObject controlObj;

    public void ChangeMode(GameObject gameObject)
    {
        print("ok控制模式");
        isControlMode = true;
        controlObj = gameObject;
    }

    public void EndMode()
    {
        //isControlMode = false;
    }


    private void Start()
    {


    }

    private void Update()
    {
        if (isControlMode)
        {
           

            

        }
    }

}
