using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
/// <summary>
/// 作者：闫辰祥
/// </summary>



public enum GameType
{
    剧情,
    游戏
}


public class GameManager : Singleton<GameManager>
{
    GameType gameType = GameType.游戏;
    private int moJIngNum =0;

    private int populationNum = 0;
    public int PopulationNum
    {
        get { 
            return populationNum; 
        }
        set { 
            populationNum = Mathf.Clamp(value,0, maxPopulationNum);

            string str = $"人口：{populationNum.ToString()}/{maxPopulationNum}";
            pulationText.text = str;
        }
    }


    public bool IsPopulationFull()
    {
        if (populationNum >= maxPopulationNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    private int maxPopulationNum = 3;



    public TMP_Text text;
    public TMP_Text pulationText;

    private void Awake()
    {
       
    }

    private void ChangeMOjing(int num)
    {
       
        int newNum = Mathf.Clamp(moJIngNum + num, 0, 999999); 

        DOTween.To(() => moJIngNum, x => moJIngNum = x, newNum, 1f) // 1f是动画的持续时间，可以根据需要更改
            .OnUpdate(() => text.text = moJIngNum.ToString())
            .OnComplete(() => moJIngNum = newNum);
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



    //玩家进行了行动，包括攻击， 移动，放置卡牌等
    public void PlayerAction()
    {

        //剧情模式下，玩家无法操作
        if (gameType == GameType.剧情)
        {
            return;
        }

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


    //地牢当前的层数
    private int dungeonLayers = 1;
    public int DungeonLayers
    {
        get { return dungeonLayers; }
    }

    private int maxDungeonLayers = 3;


    /// <summary>
    /// 进入地牢的下一层
    /// </summary>
    /// <returns>地牢当前的层数</returns>
    public int EnterNextLayer()
    {
        dungeonLayers++;

        if (dungeonLayers > maxDungeonLayers)
        {
            print("通关");
            GameWin();
            return dungeonLayers;
        }

        MapController.Instance.Generate();

        return dungeonLayers;
    }


    public GameObject 胜利面板;

    public void GameWin()
    {
        胜利面板.SetActive(true);
    }


    public void GameOver()
    {
        
    }


    //返回开始菜单
    public void GotoStartMenu()
    {
        SceneManager.LoadScene("开始界面");
    }




    public void EnterStoryMode()
    {
        gameType = GameType.剧情;
    }

}
