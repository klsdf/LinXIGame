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

    public void AddCard(string warCardName)
    {
        GameObject obj = GameObject.Find("兵卡区域");
        GameObject card = Resources.Load<GameObject>("兵卡/兵卡近战");

        card = Instantiate(card, transform.position, Quaternion.identity);
        card.transform.parent = obj.transform;
        warCards.Add(card.GetComponent<兵卡>());
    }



    public void RemoveCard(NPCType card)
    {
   
    }

    public void DeleteAndCreateCard(NPCType card1, NPCType card2, NPCType card3, NPCType cardResult)
    {
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


        AddCard("兵卡远程");

    }

}
