using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class WarCardController : Singleton<WarCardController>
{

    public List<兵卡> warCards;


    private void Start()
    {
        warCards = GetComponentsInChildren<兵卡>().ToList();
    }



    /// <summary>
    /// 会从Resources的兵卡中读取一个卡
    /// </summary>
    /// <param name="warCardName"></param>
    public void AddCard(string warCardName)
    {
        GameObject obj = GameObject.Find("兵卡区域");
        GameObject card = Resources.Load<GameObject>($"兵卡/{warCardName}");

        card = Instantiate(card, transform.position, Quaternion.identity);
        card.transform.parent = obj.transform;
        warCards.Add(card.GetComponent<兵卡>());
    }



    public void RemoveCard(NPCType card)
    {
   
    }


    /// <summary>
    /// 查看卡组中是否拥有以下的卡牌，如果缺少任何一张都会返回false
    /// </summary>
    public bool CheckHasCards(NPCType card1, NPCType card2, NPCType card3)
    {
        List<兵卡> tempwarCards = new List<兵卡>(warCards);
        bool result1 = false;
        bool result2 = false;
        bool result3 = false;

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card1)
            {
                result1 = true;
                tempwarCards.Remove(card);
            }
        } 

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card2)
            {
                result2 = true;
                tempwarCards.Remove(card);
            }
        }

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card2)
            {
                result3 = true;
                tempwarCards.Remove(card);
            }
        }

        return result1&& result2 &&result3;
    }


    public bool DeleteAndCreateCard(NPCType card1, NPCType card2, NPCType card3, NPCType cardResult)
    {
        if (CheckHasCards(card1, card2, card3) == false)
        {
            return false;
        }

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card1)
            {
                Destroy(card.gameObject);
                warCards.Remove(card);
                break;
            }
        }

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card2)
            {
                Destroy(card.gameObject);
                warCards.Remove(card);
                break;
            }
        }

        foreach (兵卡 card in warCards)
        {
            if (card.cardType == card3)
            {
                Destroy(card.gameObject);
                warCards.Remove(card);
                break;
            }
        }


        AddCard(cardResult.ToString());


        return true;

    }

}
