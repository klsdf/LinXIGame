using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 2.0f; // 敌人的移动速度
    public float manhattanDistance = 1.0f; // 曼哈顿距离
    public Vector3 targetPosition; // 敌人的目标位置

    public int mojing = 100;


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
        
        GameManager.Instance.OnPlayerMove += EnemyAction;
    }

    private void EnemyAction(float playerCostTime)
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

    //释放协程
    private void OnDestroy()
    {
        GameManager.Instance.GetMojing(mojing);
        GameManager.Instance.OnPlayerMove -= EnemyAction;

    
    }




    //敌人没有行动
    private void EnemyPass()
    {
        
    }

    private void EnemyAttack(GameObject target)
    {
        //Debug.Log("攻击了玩家");
        targetPosition = transform.position;
        target.GetComponent<BattleBase>().ProcessAttack(battleBase);
    }

    private void EnemyMove()
    {


        //TODO
        playerTargetPosition =GetComponentInChildren<EnvCheck>().enemy.transform.position;
        //playerTargetPosition = GameManager.Instance.player.GetComponent<CharacterController>().targetPosition;
        Vector3 directionToPlayer = (playerTargetPosition - targetPosition).normalized;
        targetPosition = targetPosition + directionToPlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (playerTargetPosition - targetPosition).normalized);
    }
}