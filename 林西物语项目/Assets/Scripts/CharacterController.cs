using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public Vector3 targetPosition;

    [Range(1, 20)]
    public float speed=100f;
    private BattleBase battleBase;

    public Vector3 direction;

    private bool canAttack;
    private Rigidbody2D rigidbody2D;




    public Vector2 boxCenter = new Vector2(0, 0);
    public Vector2 boxSize = new Vector2(5, 5);



    private void Awake()
    {
        targetPosition = transform.position;
        battleBase = GetComponent<BattleBase>();
        rigidbody2D = GetComponent<Rigidbody2D>();
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

                for (int i=0;i<hits.Length;i++)
                {
                    //如果前进的方向有敌人
                    if (hits[i].collider.gameObject != gameObject  )
                    {

                        if (hits[i].collider.gameObject.CompareTag("Enemy"))
                        {
                            //玩家攻击
                            if (canAttack == true)
                            {
                                hits[i].collider.gameObject.GetComponent<BattleBase>().ProcessAttack(battleBase);
                                targetPosition = transform.position;
                                GameManager.Instance.PlayerMove();
                                canAttack = false;
                                return;
                            }
                            //说明玩家现在刚刚攻击完，而且还按着键
                            else
                            {
                                return;
                            }
                        } else if (hits[i].collider.gameObject.CompareTag("Tree"))
                        {
                            print(hits[i].collider.gameObject.name);
                            return;
                        }
                        
                        

                    }
                }

                //如果前面没有敌人的话，就移动
                targetPosition += new Vector3(x, y, 0);
                GameManager.Instance.PlayerMove();

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.PlayerMove();
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