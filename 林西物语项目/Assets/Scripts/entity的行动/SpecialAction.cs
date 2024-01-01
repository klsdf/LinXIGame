using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// 
/// 特殊行动是指兵种在每回合所特别进行的活动，比如产钱，产兵卡之类的
/// </summary>
public abstract class SpecialAction : MonoBehaviour
{



    abstract public void  DoAction(float costime);

}
