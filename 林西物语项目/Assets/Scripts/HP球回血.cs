using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class HP球回血 : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("NPC"))
        {
            collision.GetComponent<BattleBase>().Recover(100);
            Destroy(gameObject);
        }
    }
}
