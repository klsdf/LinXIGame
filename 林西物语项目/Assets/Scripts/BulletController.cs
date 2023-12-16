using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BulletController : MonoBehaviour
{

    public GameObject targetObj;
    private float nowCostTime;//当前已经消耗的时间
    public float costTime;//子弹移动一次所需要的时间
    private Vector3 targetPosition;//即将过去的地方


    private float speed = 30f;
    public int damage = 5;//子弹的伤害


    void Start()
    {
        GameManager.Instance.OnPlayerMove += Action;
        targetPosition = transform.position;
    }


    public void Init(GameObject attackTarget, int damage)
    {
        targetObj = attackTarget;
        this.damage = damage;
    }



    private void Action(float playerCostTime)
    {

        nowCostTime += playerCostTime;
        while (nowCostTime >= costTime)
        {

            Move();

            nowCostTime -= costTime;
        }

    }

    private void Move()
    {
        if (targetObj == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 directionToTarget = (targetObj.transform.GetComponent<EnemyController>().targetPosition - targetPosition).normalized;
        targetPosition = targetPosition + directionToTarget;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnDestroy()
    {

        GameManager.Instance.OnPlayerMove -= Action;
    }
}
