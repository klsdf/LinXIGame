using UnityEngine;

public class NPCController1 : MonoBehaviour
{

    public float speed = 5.0f;
    public float manhattanDistance = 1.0f; 
    public Vector3 targetPosition; 


    private Vector3 playerTargetPosition; // 主角的Transform

    //战斗有关的数据
    private BattleBase battleBase;
    public float nowCostTime;//当前已经消耗的时间

    //public Vector3 moveDir;

    private void Awake()
    {
        battleBase = GetComponent<BattleBase>();
        nowCostTime =   0;
        targetPosition = transform.position;
    }

    void Update()
    {
    
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
    }


    private void Start()
    {
        
        GameManager.Instance.OnPlayerMove += (playerCostTime) =>
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



        };
    }



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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (playerTargetPosition - targetPosition).normalized);
    }
}