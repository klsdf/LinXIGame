using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetPosition;

    [Range(1, 20)]
    public float speed=100f;
    private BattleBase battleBase;

    public Vector3 direction;

    private bool canAttack;
    private Rigidbody2D charaRigidbody2D;




    public Vector2 boxCenter = new Vector2(0, 0);
    public Vector2 boxSize = new Vector2(5, 5);



    private void Awake()
    {
        targetPosition = transform.position;
        battleBase = GetComponent<BattleBase>();
        charaRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        

        //GameObject emptyObject = new GameObject("坐标点");

        //// 设置空游戏对象的位置为原游戏对象的位置
        //emptyObject.transform.position = transform.position;
        //emptyObject.transform.parent = transform;

        //targetPosition = emptyObject.transform.position;
    }
    private void FixedUpdate()
    {
        //rigidbody2D.MovePosition(targetPosition);
    }

    void Update()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x==0&&y==0) 
        {
            canAttack = true;
        }
        
   

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            
            //说明玩家进行了交互
            if (x != 0 || y != 0)
            {
                direction = new Vector3(x, y, 0);
                //RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction,2f);


                float angle = 0;
                float distance = 0;
                boxCenter = transform.position + direction;
                boxSize = new Vector2(2,1);
                RaycastHit2D[] hits = Physics2D.BoxCastAll(boxCenter, boxSize, angle, direction, distance);

                GameObject hitsObj;
                for (int i=0;i<hits.Length;i++)
                {
                    hitsObj = hits[i].collider.gameObject;
                    //如果前进的方向有敌人
                    if (hitsObj != gameObject  )
                    {
                        BattleBase otherBattleBase = hitsObj.GetComponent<BattleBase>();
                        if (otherBattleBase != null)
                        {

                            if (otherBattleBase.party == BattleParty.Enemy || otherBattleBase.party == BattleParty.Neutral)
                            {
                                //玩家攻击
                                if (canAttack == true)
                                {
                                    hits[i].collider.gameObject.GetComponent<BattleBase>().ProcessAttack(battleBase);
                                    targetPosition = transform.position;
                                    GameManager.Instance.PlayerAction();
                                    canAttack = false;
                                    return;
                                }
                                //说明玩家现在刚刚攻击完，而且还按着键
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                }

                //如果前面没有敌人的话，就移动
                targetPosition += new Vector3(x, y, 0);
                GameManager.Instance.PlayerAction();

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.PlayerAction();
        }
      
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
      

        // 发射射线
        Gizmos.DrawLine(transform.position, transform.position + 2*direction);
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}