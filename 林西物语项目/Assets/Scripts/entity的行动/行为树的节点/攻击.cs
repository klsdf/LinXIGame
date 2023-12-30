using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 攻击 : Action
{
    public SharedTransform target;

    private BattleBase battleBase;


    public override void OnStart()
    {
        battleBase = GetComponent<BattleBase>();
    }

    public override TaskStatus OnUpdate()
    {
        NPCType profession = battleBase.profession;
        if (profession == NPCType.Wizard)
        {
            //跟踪子弹
            GameObject bullet = Resources.Load<GameObject>("子弹");
            GameObject bulletObj = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().Init(transform, target.Value, battleBase.rangeAtk, BulletType.跟踪);
        }
        else if (profession == NPCType.Archer)
        {
            //直线子弹
            GameObject bullet = Resources.Load<GameObject>("子弹");
            GameObject bulletObj = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().Init(transform, target.Value, battleBase.rangeAtk, BulletType.直线);
        }
        else if (profession == NPCType.Boss)
        {
            Debug.Log("攻击");
            //八方向直线子弹

            GameObject bullet = Resources.Load<GameObject>("子弹");

            GameObject bulletObj = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().Init(transform,target.Value, battleBase.rangeAtk, BulletType.直线);

            GameObject bulletObj1 = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj1.GetComponent<BulletController>().Init(transform, Vector3.up, battleBase.rangeAtk);

            GameObject bulletObj2 = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj2.GetComponent<BulletController>().Init(transform, Vector3.down, battleBase.rangeAtk);

            GameObject bulletObj3 = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj3.GetComponent<BulletController>().Init(transform, Vector3.left, battleBase.rangeAtk);

            GameObject bulletObj4 = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj4.GetComponent<BulletController>().Init(transform, Vector3.right, battleBase.rangeAtk);
        }

        else
        {

            target.Value.GetComponent<BattleBase>().ProcessAttack(battleBase);

        }

        return TaskStatus.Success;
    }
}
