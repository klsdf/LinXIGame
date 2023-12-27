using UnityEngine;

public class EnemyController : EntityActionBase
{

    protected override void Action(float playerCostTime)
    {
        // 更新敌人的目标位置
        //targetPosition = player.position;

        nowCostTime += playerCostTime;

        while (nowCostTime >= battleBase.costTime)
        {

            //敌人攻击
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);

            foreach (var hitCollider in hitColliders)
            {
                BattleBase battleBase = hitCollider.GetComponent<BattleBase>();
                if (battleBase != null)
                {
                    if (hitCollider.GetComponent<BattleBase>().party == BattleParty.Player)
                    {
                        EnemyAttack(hitCollider.gameObject);
                        nowCostTime -= battleBase.costTime;
                        return;
                    }
                }
            }

            //敌人移动
            EnemyMove();


            nowCostTime -= battleBase.costTime;
        }
    }

    public int mojing = 100;


    private Vector3 actionTargetPosition; // 攻击或者追逐的目标


    //public Vector3 moveDir;

    protected override void OnDead()
    {
        base.OnDead();
      

    }




    //敌人没有行动
    private void EnemyPass()
    {
        
    }

    private void EnemyAttack(GameObject target)
    {
        targetPosition = transform.position;
        target.GetComponent<BattleBase>().ProcessAttack(battleBase);
    }

    private void EnemyMove()
    {

        GameObject enemy = GetComponentInChildren<EnvCheck>().firstEnemy;
        if (enemy != null)
        {
            actionTargetPosition = GetComponentInChildren<EnvCheck>().firstEnemy.transform.position;
            //playerTargetPosition = GameManager.Instance.player.GetComponent<CharacterController>().targetPosition;
            Vector3 directionToPlayer = (actionTargetPosition - targetPosition).normalized;
            targetPosition = targetPosition + directionToPlayer;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (actionTargetPosition - targetPosition).normalized);
    }

}