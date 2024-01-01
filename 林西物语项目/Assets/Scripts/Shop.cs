using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class Shop : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {

    }

    public void Interactive()
    {

        canvas.gameObject.SetActive(true);
    }

    public void BuyCard()
    {
        if (GameManager.Instance.CheckMojingNum() >= 100)
        {
            WarCardController.Instance.AddCard("兵卡近战");
            GameManager.Instance.GetMojing(-100);
        }
        else
        {
            print("金钱不足");
        }
    }


    public void CloseShop()
    {
        canvas.gameObject.SetActive(false);
    }


}
