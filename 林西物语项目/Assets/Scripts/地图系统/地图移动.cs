using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 地图移动 : MonoBehaviour
{

    private void Start()
    {
        draggableImage = GetComponent<Image>();
    }

   

    public Image draggableImage;
    private bool isDragging;
    private Vector2 lastMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2)) // 2 是鼠标中键
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 diff = currentMousePosition - lastMousePosition;
            lastMousePosition = currentMousePosition;

            Vector2 pos = draggableImage.transform.localPosition;
            pos += diff;
            draggableImage.transform.localPosition = pos;
        }
    }
}
