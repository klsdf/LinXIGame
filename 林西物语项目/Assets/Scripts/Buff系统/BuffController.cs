using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 


//buff的类型
public enum BuffType
{ 
    SPEED_UP,
    SPEED_DOWN,


}

public class BuffController : MonoBehaviour
{

    public bool isRunningBuff = false;

    public float nowCostTime = 0;

    public BuffBase buff = new BuffSpeedUp("加速", 3f);

    private void Start()
    {
        //skill = 
        GameManager.Instance.OnPlayerMove += (playerCostTime) =>
        {

           
            nowCostTime += playerCostTime;
            if (nowCostTime <= buff.activeTime)
            {
                
                buff.Active(gameObject);
            }
            else {
                nowCostTime -= buff.activeTime;
                buff.Stop(gameObject);
            }
        };
    }


    public void SetBuff()
    { 
    }


}
