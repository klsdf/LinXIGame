using UnityEngine;
using BehaviorDesigner.Runtime;

public class NPCController : AttackableEntityBase
{
    public int NPCMoveSize=15;


    public bool isPlayerControl = false;
    private bool isClick = false;//是否正在点击


    private Vector3 playerTargetPosition; // 主角的Transform

    private Vector3 CommandTargetPosition; // 控制的目标位置


    private LineRenderer lineRenderer;

    private BehaviorTree behaviorTree;


    private SpecialAction specialAction;

    protected override void Start()
    {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 1f; // 线的起始宽度
        lineRenderer.endWidth = 1f; // 线的结束宽度
        lineRenderer.startColor = Color.white; // 线的起始颜色
        lineRenderer.endColor = Color.red; // 线的结束颜色

        envCheck = GetComponentInChildren<EnvCheck>();
        behaviorTree = GetComponent<BehaviorTree>();
        specialAction = GetComponent<SpecialAction>();
    }

    private void OnMouseDown()
    {
        //GameManager.Instance.ChangeMode(gameObject);
        //isPlayerControl = true;
        //isClick = true;
    }

    protected override void Action(float playerCostTime)
    {
        playerTargetPosition = GameManager.Instance.player.GetComponent<PlayerController>().targetPosition;
        nowCostTime += playerCostTime;

        while (nowCostTime >= battleBase.costTime)
        {
            behaviorTree.SendEvent("CanAction");
            nowCostTime -= battleBase.costTime;
            specialAction?.DoAction(battleBase.costTime);
        }
        
    }

    protected override void Update()
    {

        //if (isClick == true)
        //{
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Vector3 mousePosition = Input.mousePosition;
        //        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //        CommandTargetPosition = new Vector3(mousePosition.x, mousePosition.y,0);
        //        behaviorTree.SetVariableValue("点击的位置", CommandTargetPosition);


        //        isClick = false;
        //        isPlayerControl = true;
        //    }
        //}
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

    /// <summary>
    /// 玩家强制命令NPC移动到某个位置
    /// </summary>
    /// <param name="position">位置</param>
    public void SetCommandPosition(Vector3 position)
    {
        CommandTargetPosition = position;
        isPlayerControl = true;
        behaviorTree.SetVariableValue("点击的位置", CommandTargetPosition);
        
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + targetPosition);
    }

}