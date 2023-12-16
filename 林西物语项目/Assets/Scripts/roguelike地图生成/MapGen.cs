using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class MapGen : MonoBehaviour
{

    public SpriteRenderer map;

    public GameObject enemy;

    public GameObject weapon;


    public Vector3 bottomLeft;
    public Vector3 topRight;
    public Vector3 topLeft;
    public Vector3 bottomRight;


    public Vector3 worldBottomLeft;
    public Vector3 worldTopRight;
    public Vector3 worldTopLeft;
    public Vector3 worldBottomRight;

    private void Start()
    {
       
    }

    void Update()
    {
        Bounds bounds = map.sprite.bounds;


        Vector3 localScale = map.transform.localScale;

        bottomLeft = Vector3.Scale(bounds.min, localScale);
        topRight = Vector3.Scale(bounds.max, localScale);
        topLeft = Vector3.Scale(new Vector3(bottomLeft.x, topRight.y, 0), localScale);
        bottomRight = Vector3.Scale(new Vector3(topRight.x, bottomLeft.y, 0), localScale);

        ////局部坐标
        //bottomLeft = bounds.min;
        // topRight = bounds.max;
        // topLeft = new Vector3(bottomLeft.x, topRight.y, 0);
        // bottomRight = new Vector3(topRight.x, bottomLeft.y, 0);


        //世界坐标
         worldBottomLeft = map.transform.position + bottomLeft;
         worldTopRight = map.transform.position + topRight;
         worldTopLeft = map.transform.position + topLeft;
         worldBottomRight = map.transform.position + bottomRight;

        //当按下F键的时候调用 RandomGen();
        if (Input.GetKeyDown(KeyCode.F))
        {
            RandomGen();
        }

    }
    //查看给定的sprite的size
    public void GetSpriteSize()
    {
        Debug.Log(map.bounds.size);
    }

    //在tree的四个坐标范围内随机生成enemy和weapon
    public void RandomGen()
    {
        float x = Random.Range(worldBottomLeft.x, worldBottomRight.x);
        float y = Random.Range(worldBottomLeft.y, worldTopLeft.y);

        Vector3 pos = new Vector3(x, y, 0);

        Instantiate(enemy, pos, Quaternion.identity);
        Instantiate(weapon, pos, Quaternion.identity);
    }

   
}

