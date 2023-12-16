using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 

public enum PanelType
{
    ItemPanel,
    OptionPanel,
    StartPanel
}



public class UIController : Singleton<UIController>
{

    private Stack<BasePanel> panels = new Stack<BasePanel>() { };
    private Dictionary<PanelType, string> panelDic = new Dictionary<PanelType, string>();

    private List<GameObject> openingPanels =new List<GameObject>();//当前打开的所有panel


    private Transform root;

    private string path = "UIPanels/";


    private void Awake()
    {
        bindUI();


        root = GameObject.Find("UICanvas").transform;

    }


    /// <summary>
    /// 用于绑定UI的预制体和UI的路径
    /// </summary>
    private void bindUI()
    {
        panelDic.Add(PanelType.OptionPanel, path + "OptionPanel");
    }


    //public void PopPanel()
    //{
    //    BasePanel temp = PeekPanel();
    //    temp.OnExit();
    //    panels.Pop();


    //}
    //public void PushPanel(BasePanel panel)
    //{
    //    BasePanel tempPanel = PeekPanel();
    //    tempPanel?.OnPause();



    //    panels.Push(panel);
    //    panel.OnEnter();
    //}


    public void PushPanel(PanelType panelType)
    {
        string path = panelDic[panelType];
        if (panelDic.TryGetValue(panelType, out path) == true)
        {
            GameObject panel = Instantiate(Resources.Load<GameObject>(path), root,false);
            openingPanels.Add(panel);
            panel.transform.SetParent(root);
            panel.GetComponent<BasePanel>().OnOpen();
        }
    }
    //  销毁openingPanels中的panel
    public void PopPanel(GameObject panel )
    {
        if (openingPanels.Contains(panel))
        {
            openingPanels.Remove(panel);
            panel.GetComponent<BasePanel>().OnClose();
            Destroy(panel);
        }

    }




    public BasePanel PeekPanel()
    {
        if (panels.Count == 0)
        {
            return null;
        }
        return panels.Peek();
    }


    public void OnOption()
    {
        print("okkk");
        PushPanel(PanelType.OptionPanel);
    }

    public void OnStart()
    {
        SceneLoad.Instance.LoadSceneAsync();
    }


    public void OnQuit()
    {
        
    }
}
