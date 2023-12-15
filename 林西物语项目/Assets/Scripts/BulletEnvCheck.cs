using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BulletEnvCheck : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<BattleBase>().GetDamage(transform.parent.GetComponent<BulletController>().damage);
            Destroy(transform.parent.gameObject);

        }
    }

}
