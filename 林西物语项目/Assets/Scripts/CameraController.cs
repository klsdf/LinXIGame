using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class CameraController : MonoBehaviour
{

    private float ZoomSpeed = 1f; // 控制缩放的速度
    private CinemachineVirtualCamera VirtualCamera; // Cinemachine摄像机
    private void Start()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollWheel != 0)
        {
            // ZoomSpeed为正数时，鼠标滚轮向上滚动，摄像机视野变小，ZoomSpeed为负数时，鼠标滚轮向下滚动，摄像机视野变大
            VirtualCamera.m_Lens.OrthographicSize -= mouseScrollWheel * ZoomSpeed;
        }
    }
}
