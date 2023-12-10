using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Vector3 targetPosition;

    [Range(1, 20)]
    public float speed=5f;
    private BattleBase battleBase;

    public Vector3 direction;

    private bool canAttack;



    private void Awake()
    {
        targetPosition = transform.position;
        battleBase = GetComponent<BattleBase>();
    }

    void Start()
    {
        

        //GameObject emptyObject = new GameObject("坐标点");

        //// 设置空游戏对象的位置为原游戏对象的位置
        //emptyObject.transform.position = transform.position;
        //emptyObject.transform.parent = transform;

        //targetPosition = emptyObject.transform.position;
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
                //GameManager.Instance.PlayerMove();
                direction = new Vector3(x, y, 0);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction,4f);


            
                for (int i=0;i<hits.Length;i++)
                {
                    //如果前进的方向有敌人
                    if (hits[i].collider.gameObject != gameObject && hits[i].collider.gameObject.CompareTag("Enemy"))
                    {
                        //玩家攻击
                        if (canAttack == true)
                        {

                            print(hits[i].collider.gameObject.name);
                            hits[i].collider.gameObject.GetComponent<BattleBase>().ProcessAttack(battleBase);
                            targetPosition = transform.position;
                            GameManager.Instance.PlayerMove();
                            canAttack = false;
                            return;
                        }
                        //说明玩家现在刚刚攻击完，而且还按着键
                        else {
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
    }
}