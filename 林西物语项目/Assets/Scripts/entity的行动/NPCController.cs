using UnityEngine;

public class NPCController : EntityActionBase
{


    protected override void Action(float playerCostTime)
    {
        playerTargetPosition = GameManager.Instance.player.GetComponent<CharacterController>().targetPosition;


        nowCostTime += playerCostTime;

        while (nowCostTime >= battleBase.costTime)
        {

            //NPC攻击
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    Attack(hitCollider.gameObject);
                    nowCostTime -= battleBase.costTime;
                    return;
                }
            }

            //NPC移动
            Move();

            nowCostTime -= battleBase.costTime;
        }
    }

    private Vector3 playerTargetPosition; // 主角的Transform

    private void Attack(GameObject target)
    {
        //Debug.Log("攻击了玩家");
        targetPosition = transform.position;
        target.GetComponent<BattleBase>().ProcessAttack(battleBase);
    }

    private void Move()
    {

        if (Vector3.Distance(playerTargetPosition, transform.position) < 5f)
        {
            return;
        }
        Vector3 directionToPlayer = (playerTargetPosition - targetPosition).normalized;
        targetPosition = targetPosition + directionToPlayer;
    }



 
}