using UnityEngine;

public enum NPCType
{
    Warrior,//战士
    Wizard,//法师
    Archer,//弓箭手
    Priest,//牧师
    Thief,//盗贼
    Merchant,//商人
}


public class NPCController : EntityActionBase
{
    public int NPCMoveSize=15;

    public NPCType profession;//职业

    public bool isPlayerControl = false;
    private bool isClick = false;//是否正在点击


    private Vector3 playerTargetPosition; // 主角的Transform

    public Vector3 CommandTargetPosition; // 控制的目标位置

    private LineRenderer lineRenderer;
    protected override void Start()
    {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 1f; // 线的起始宽度
        lineRenderer.endWidth = 1f; // 线的结束宽度
        lineRenderer.startColor = Color.white; // 线的起始颜色
        lineRenderer.endColor = Color.red; // 线的结束颜色
    }

    private void OnMouseDown()
    {
        //GameManager.Instance.ChangeMode(gameObject);
        isPlayerControl = true;
        isClick = true;


    }

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


    private void Attack(GameObject target)
    {
        //Debug.Log("攻击了玩家");

        if (profession == NPCType.Archer)
        {
            GameObject bullet = Resources.Load<GameObject>("子弹");
            //创建一个bullet对象
            GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().Init(target,100);
        }
        else
        {
            
            target.GetComponent<BattleBase>().ProcessAttack(battleBase);
        }

        targetPosition = transform.position;

    }


    //移动
    private void Move()
    {


        if (isPlayerControl == true)
        {
            //集群力，默认以玩家为中心点
            Vector3 direction = (CommandTargetPosition - targetPosition).normalized;
            targetPosition = targetPosition + direction;

            if (Vector2.Distance(CommandTargetPosition, transform.position) < 1.0f)
            {
                isPlayerControl = false;
            }


            return;
        }

     

        Vector3 playerTempPosition = playerTargetPosition + new Vector3(Random.Range(-NPCMoveSize, NPCMoveSize), Random.Range(-NPCMoveSize, NPCMoveSize), 0);
        //集群力，默认以玩家为中心点
        Vector3 directionToPlayer = (playerTempPosition - targetPosition).normalized;
        targetPosition = targetPosition + directionToPlayer;
    }

    protected override void Update()
    {

        if (isClick == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    CommandTargetPosition = hit.point;
                }

                isClick = false;
                isPlayerControl = true;
            }
        }
        if (isPlayerControl == true)
        {
            lineRenderer.positionCount = 2; // 设置线的顶点数量
            lineRenderer.SetPosition(0, transform.position); // 设置线的起点
            lineRenderer.SetPosition(1, CommandTargetPosition); // 设置线的终点
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
        base.Update();

    }

    //private void Move()
    //{
    //    //集群力，默认以玩家为中心点
    //    Vector3 directionToPlayer = (playerTargetPosition - targetPosition).normalized;

    //    ////离群力
    //    float neighborDistance = 1f;
    //    Vector3 separation = Vector3.zero;
    //    int groupNum = 0;
    //    Vector3 directionToSeparation = Vector3.zero;
    //    // 用2d圆形的射线检测，检测周围2单位tag为NPC的所有物体
    //    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, neighborDistance);
    //    foreach (Collider2D hitCollider in hitColliders)
    //    {
    //        if (hitCollider != gameObject && (hitCollider.tag == "NPC" || hitCollider.tag == "Player"))
    //        {
    //            separation += (transform.position - hitCollider.transform.position);
    //            groupNum++;
    //        }
    //    }

    //    //if (groupNum > 1)
    //    //{
    //        directionToSeparation = (separation.normalized - transform.position).normalized;
    //    //}

    //    Vector3 finalDirection = (10*directionToSeparation + directionToPlayer).normalized;




    //    //if (Vector3.Distance(playerTargetPosition, transform.position) < 5f)
    //    //{
    //    //    return;
    //    //}
    //    //directionToPlayer = (playerTargetPosition - targetPosition).normalized;

    //    targetPosition = targetPosition + finalDirection;




    //}



    //Flocking算法

    private void Flocking()
    {
         float speed = 2.0f;
         float neighborDistance = 3.0f; // Boids will consider others within this radius as neighbors
         float rotationSpeed = 4.0f;
        // Implementing flocking behavior
        // Find the center of all boids, find the average velocity of all boids, move boids towards the center and in the direction of average velocity
        Vector3 center = Vector3.zero;
        Vector3 velocity = Vector3.zero;
        GameObject[] boids = GameObject.FindGameObjectsWithTag("Boid");
        foreach (GameObject boid in boids)
        {
            if (boid != gameObject)
            {
                float distance = Vector3.Distance(boid.transform.position, transform.position);
                if (distance <= neighborDistance)
                {
                    center += boid.transform.position;
                    velocity += boid.GetComponent<NPCController>().speed * boid.transform.forward;
                }
            }
        }
        if (boids.Length > 1)
        {
            center = center / (boids.Length - 1);
            velocity = velocity / (boids.Length - 1);

            Vector3 direction = (center + velocity) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }

        // Move boid
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    //private void  分离()
    //{
    //    float speed = 2.0f;
    //    float neighborDistance = 3.0f; // Boids will consider others within this radius as neighbors
    //    float rotationSpeed = 4.0f;
    //    // Implementing flocking behavior
    //    // Find the center of all boids, find the average velocity of all boids, move boids towards the center and in the direction of average velocity
    //    Vector3 center = Vector3.zero;
    //    Vector3 velocity = Vector3.zero;
    //    GameObject[] boids = GameObject.FindGameObjectsWithTag("Boid");
    //    Vector3 separation = Vector3.zero;

    //    for (int i = 0; i < boids.Length; i++)
    //    {
    //        if (boids[i] != this)
    //        {
    //            float distance = Vector3.Distance(boids[i].transform.position, this.transform.position);
    //            if (distance < neighborDistance)
    //            {
    //                // Compute a vector that points away from the neighbor.
    //                separation += (this.transform.position - boids[i].transform.position) / distance;
    //            }
    //        }
    //    }

    //    if (boids.Length > 1)
    //    {
    //        center = center / (boids.Length - 1);
    //        velocity = velocity / (boids.Length - 1);

    //        Vector3 direction = (center + velocity + separation) - transform.position;
    //        if (direction != Vector3.zero)
    //            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + targetPosition);
    }

}