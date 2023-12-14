using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class Shop : MonoBehaviour
{
    public int cost = 100;
    public GameObject prefab;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Interactive()
    {
        //print("交互");
        if (GameManager.Instance.CheckMojingNum() >= 100)
        {
            GameManager.Instance.GetMojing(-100);
            Instantiate(prefab, transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
        }
        else 
        {
            print("金钱不足");
        }
    }
         
}
