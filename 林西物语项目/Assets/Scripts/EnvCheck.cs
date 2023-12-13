using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class EnvCheck : MonoBehaviour
{
    public GameObject firstEnemy;

    public GameObject lastEnemy;

    public GameObject clostestEnemy;


    public List<GameObject> enemys;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionBattleBase = collision.gameObject.GetComponent<BattleBase>();
        var parentBattleBase = transform.parent.GetComponent<BattleBase>();
        if (collisionBattleBase != null && parentBattleBase != null)
        {

            if (collisionBattleBase.party == parentBattleBase.party)
            {
                print("发现自己人");
            }
            else
            {
                firstEnemy = collision.gameObject;
                enemys.Add(collision.gameObject);


                print("发现敌人");
            }
        }
        else
        { 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //查看离开的对象是否在enemys中
        if (enemys.Contains(collision.gameObject))
        {
            enemys.Remove(collision.gameObject);
            if (enemys.Count > 0)
            {
                firstEnemy = enemys[0];
            }
            else
            {
                firstEnemy = null;
            }
        }
    }
}
