using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
/// <summary>
/// 作者：闫辰祥
/// 
/// 用鼠标滚轮可以来控制地图的缩放
/// </summary>
public class 地图缩放 : MonoBehaviour
{
    static 地图缩放 instance;
    public static 地图缩放 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<地图缩放>();

            }
            return instance;
        }
    }



    public float zoomSpeed = 1.0f;
    public float minScale = 0.5f;
    public float maxScale = 2.0f;


    public float 一二级图标的缩放界限 = 1.0f;
    public float 二三级图标的缩放界限 = 1.5f;
    public event Action<地区级别> 缩放图标;



    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        if (scrollData != 0.0f)
        {
            Vector3 scale = rectTransform.localScale;
            scale += new Vector3(1f, 1f, 1f) * scrollData * zoomSpeed;
            scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
            scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
            rectTransform.localScale = scale;


            //判断缩放的级别进行缩放
            if (scale.x < 一二级图标的缩放界限)
            {
                缩放图标?.Invoke(地区级别.一级);
            }
            else if (scale.x < 二三级图标的缩放界限)
            {
                缩放图标?.Invoke(地区级别.二级);
            }
            else {
                缩放图标?.Invoke(地区级别.三级);
            }
        }
    }





   
}
