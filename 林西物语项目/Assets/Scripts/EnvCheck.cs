using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class EnvCheck : MonoBehaviour
{
    public GameObject enemy;

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
                enemy = collision.gameObject;
                print("发现敌人");
            }
        }
        else
        { 
        }
    }
}
