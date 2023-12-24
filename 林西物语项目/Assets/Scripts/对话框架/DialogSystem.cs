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

public enum Character
{
    李二狗,
    秦飞羽,
    林千叶,
    月千秋
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
    public StoryScript(string text, Character character, Action function) : this(text,character)
    {
        this.function = function;
    }


    public StoryScript(string text, Action function):this(text)
    {
        this.function = function;
    }
}


public class DialogSystem : Singleton<DialogSystem>
{
  

    //UI部分
    [Header("对话文本区域")]
    public TMP_Text textDialog;//对话文本
    public TMP_Text textName;//姓名文本
    public Image imageTatsue;//立绘图像
    [Header("对话区域")]
    public GameObject dialogArea;//对话区域


    //逻辑部分
    private List<StoryScript> storys;
    private int storyPointer;

    private bool canPlay = true;

    public string defaultText = "结束";





    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayNextStory();
        }
    }

    private void Start()
    {
        //textDialog = GameObject.Find("剧情框").GetComponent<TMP_Text>();
        //textName = GameObject.Find("姓名框").GetComponent<TMP_Text>();
        //imageTatsue = GameObject.Find("人物立绘").GetComponent<Image>();
        //dialogArea = GameObject.Find("对话框");


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
        if (textDialog != null)
        {
            textName.text = name;
        }


        //执行函数
        if (storys[storyPointer].function != null)
        {
            storys[storyPointer].function();
        }
        storyPointer++;

    }






}

