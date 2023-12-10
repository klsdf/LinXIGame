using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BuffBase : MonoBehaviour
{
   
        public string skillName;
        public float activeTime;//持续时间

        public virtual void Active(GameObject obj)
        {
        }
        public virtual void Stop(GameObject obj)
        {
        }



    public BuffBase(string skillName, float activeTime)
        {
            this.skillName = skillName;
        
            this.activeTime = activeTime;
        }
    

}
