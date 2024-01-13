using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class RTSUnit : MonoBehaviour
{



    public GameObject 选中的标记;

    private NPCController npcController;

    void Start()
    {
        npcController = GetComponent<NPCController>();  
    }



    /// <summary>
    /// 被玩家选中
    /// </summary>
    public void Controled()
    {
        选中的标记.SetActive(true);
    }

    /// <summary>
    /// 不被玩家选中
    /// </summary>
    public void NotControl()
    {
        选中的标记.SetActive(false);
    }


    public void SetPosition(Vector3 position)
    {

        npcController.SetCommandPosition(position);
        
    }

 

   

    void Update()
    {
        
    }
}
