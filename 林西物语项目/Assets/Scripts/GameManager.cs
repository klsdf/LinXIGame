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

    [SerializeField]
    private int moJIngNum;


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
    }


    public bool isChoseMode = false;
    public void EnterChoseMode()
    {
        isChoseMode = true;
    }

    private void Update()
    {
        if (isChoseMode)
        {
            //当用户点击屏幕时，将玩家移动到点击的位置
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                player.GetComponent<PlayerController>().targetPosition = mousePosition;
                player.transform.position = mousePosition;
                isChoseMode = false;
            }
        }
    }



}
