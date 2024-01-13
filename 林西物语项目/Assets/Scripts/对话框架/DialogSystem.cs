using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 


///自定义的，角色的姓名类
public enum Character
{
    李二狗,
    秦飞羽,
    林千叶,
    月千秋
}


/// <summary>
/// 自定义的，立绘的名称类
/// </summary>
public enum Tachie
{
    李二狗_严肃,
    李二狗_沉默,
    李二狗_生气,
    李二狗_疑惑
}



public class StoryScript
{
    public string text;//文本
    public string nameText = "";//姓名
    public string tatsueName = "";//立绘名字
    public Action function;



    //public StoryScript()
    public StoryScript(string text)
    {
        this.text = text;
    }

    public StoryScript(string text, string nameText):this(text)
    {
        this.nameText = nameText;
    }
    public StoryScript(string text, string nameText, Action function):this(text,nameText)
    {
        this.function = function;
    }

    public StoryScript(string text, Character character) : this(text)
    {
        this.nameText = character.ToString();
    }
    public StoryScript(string text, Character character,Tachie tachie) : this(text)
    {
        this.nameText = character.ToString();
        this.tatsueName = tachie.ToString();
    }
    public StoryScript(string text, Character character, Action function) : this(text,character)
    {
        this.function = function;
    }
    public StoryScript(string text, Character character, Tachie tachie, Action function) : this(text, character)
    {
        this.function = function;
        this.tatsueName = tachie.ToString();
    }

    public StoryScript(string text, Action function):this(text)
    {
        this.function = function;
    }
}

[RequireComponent(typeof(DialogEffect))]
public class DialogSystem : Singleton<DialogSystem>
{
  

    //UI部分
    [Header("对话文本区域")]
    private TMP_Text textDialog;//对话文本
    private TMP_Text textName;//姓名文本
    private Image imageTatsue;//立绘图像
    [Header("对话区域")]
    private GameObject dialogArea;//对话区域


    //逻辑部分
    private List<StoryScript> storys;
    private int storyPointer;

    private bool canPlay = true;

    private string defaultText = "结束";


    //剧情
    public 第一章剧情 剧情;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayNextStory();
        }
    }

    private void Start()
    {
        

        GameObject obj =  Resources.Load<GameObject>("对话系统UI");
        obj = Instantiate(obj);



        textDialog = GameObject.Find("剧情框").GetComponent<TMP_Text>();
        textName = GameObject.Find("姓名框").GetComponent<TMP_Text>();
        imageTatsue = GameObject.Find("立绘").GetComponent<Image>();
        dialogArea = GameObject.Find("对话系统UI");


        剧情.Init();
    }

    public void SetAndPlayStorys(List<StoryScript> newStorys)
    {
        storys = newStorys;
        storyPointer = 0;
        PlayNextStory();
    }

    public void PlayNextStory()
    {

        if (canPlay == false)
        {
            return;
        }
        if (storyPointer >= storys.Count)
        {

            dialogArea.SetActive(false);
            textDialog.text = defaultText;

            return;
        }
        if (dialogArea != null)
        {
            dialogArea.SetActive(true);
        }


        //播放文本
        string tempText = storys[storyPointer].text;
        if (textDialog != null)
        {
            textDialog.text = tempText;
        }

        string name = storys[storyPointer].nameText;
        if (name != "")
        {
            textName.transform.parent.gameObject.SetActive(true);
            textName.text = name;
        }
        else
        {
            textName.transform.parent.gameObject.SetActive(false);
        }



        string tatsueName = storys[storyPointer].tatsueName;
        if (name != "")
        {
            imageTatsue.gameObject.SetActive(true);
            imageTatsue .sprite =  Resources.Load<Sprite>($"立绘/{tatsueName}");
        }
        else
        {
            imageTatsue.gameObject.SetActive(false);
        }


        //执行函数
        if (storys[storyPointer].function != null)
        {
            storys[storyPointer].function();
        }
        storyPointer++;

    }






}

