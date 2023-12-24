using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public abstract  class EntityActionBase : MonoBehaviour
{
    public float speed = 5.0f;
    public float manhattanDistance = 1.0f;
    public Vector3 targetPosition;//自己目前即将去的位置


    //战斗有关的数据
    protected BattleBase battleBase;
    public float nowCostTime;//当前已经消耗的时间

    private void Awake()
    {
        battleBase = GetComponent<BattleBase>();
        nowCostTime = 0;
        targetPosition = transform.position;
    }

    protected virtual void Start()
    {
        GameManager.Instance.OnPlayerMove += Action;
    }


    protected virtual void OnDead()
    {
        GameManager.Instance.OnPlayerMove -= Action;
    }
     //释放协程
    private void OnDestroy()
    {
        OnDead();
       
     
    }
    protected abstract void Action(float playerCostTime);
    protected virtual void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + (playerTargetPosition - targetPosition).normalized);
    //}
}
