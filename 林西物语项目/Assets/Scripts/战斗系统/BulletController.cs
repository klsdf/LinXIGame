using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

public enum BulletType
{
    跟踪,
    直线
}


public class BulletController : MonoBehaviour
{

    private Transform target;
    private float nowCostTime;//当前已经消耗的时间
    private float costTime = 1f;//子弹移动一次所需要的时间
    private Vector3 targetPosition;//即将过去的地方

    Vector3 dir;

    private float lifeTime = 20;
    BattleBase battleBase1;

    private float speed = 30f;
    private float damage = 5;//子弹的伤害


    private Transform attacker;

    BulletType bulletType;

    void Start()
    {
        GameManager.Instance.OnPlayerMove += Action;
        targetPosition = transform.position;
        battleBase1 = attacker.GetComponent<BattleBase>();
    }


    public void Init(Transform attacker,Transform attackTarget, float damage, BulletType bulletType)
    {
        this.attacker = attacker;
        target = attackTarget;
        this.damage = damage;
        this.bulletType = bulletType;
        dir = (attackTarget.position - transform.position).normalized;
    }

    public void Init(Transform attacker, Vector3 direction, float damage )
    {
        this.attacker = attacker;
        this.damage = damage;
        dir = direction.normalized;
        bulletType = BulletType.直线;
    }



    private void Action(float playerCostTime)
    {
        lifeTime -= playerCostTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            return;
        }


        nowCostTime += playerCostTime;
        while (nowCostTime >= costTime)
        {

            Move();

            nowCostTime -= costTime;
        }

    }

    private void Move()
    {

        if (bulletType == BulletType.跟踪)
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 directionToTarget = (target.GetComponent<EnemyController>().targetPosition - targetPosition).normalized;
            targetPosition = targetPosition + directionToTarget;

        }
        else if(bulletType == BulletType.直线)
        {
           
            targetPosition = targetPosition + dir;
        }


 
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if(GameManager.Instance!=null)
        GameManager.Instance.OnPlayerMove -= Action;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
    

       
        BattleBase battleBase2 = other.GetComponent<BattleBase>();

        if(battleBase2!=null)

        if (Util.isEnemy(battleBase1, battleBase2))
        {
            battleBase2.GetDamage(damage);
            Destroy(gameObject);

        }
    }

}
