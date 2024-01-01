using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

public enum 兵卡状态
{
    商店,
    兵卡栏
}

public class 兵卡 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //public 兵卡状态 状态;
    private GameObject itemToSpawn;
    private Vector3 originalPosition;
    public NPCType cardType;

    private void Start()
    {
        switch (cardType)
        {
            case NPCType.Warrior:
                itemToSpawn = Resources.Load<GameObject>("Entity/队友战士");
                break;
            case NPCType.Archer:
                 itemToSpawn = Resources.Load<GameObject>("Entity/队友远程弓箭手");
                break;
        }

       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.IsPopulationFull())
        {
            print("人口已满！");
            transform.position = originalPosition;
            return;
        }

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = new Vector3(position.x, position.y, 0);

        GameObject spawnedItem = Instantiate(itemToSpawn, position, Quaternion.identity);
        Destroy(gameObject);
        //进行一回合操作
        GameManager.Instance.PlayerAction();
    }
}
