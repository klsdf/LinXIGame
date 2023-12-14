using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>

public class EntityGenerate : MonoBehaviour
{
    [SerializeField]
    public Objinfo[] prefabs; 
    public Vector2 spawnValues; //生成对象的范围


    [Serializable]
    public class Objinfo
    {
        [SerializeField]
        public GameObject obj;
        [SerializeField]
        public int num;
    }

    void Start()
    {
        SpawnObjects();
    }


    //生成对象
    public void SpawnObjects()
    {
        foreach (Objinfo info in prefabs)
        {
            for (int i = 0; i < info.num; i++)
            {
                Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), UnityEngine.Random.Range(-spawnValues.y, spawnValues.y));
                Instantiate(info.obj, spawnPosition, Quaternion.identity);
            }
        }
    }
}
