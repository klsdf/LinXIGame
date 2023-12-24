using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 第一章剧情 : MonoBehaviour
{

    void Start()
    {

        DialogEffect.Instance.FadeOut();
        DialogSystem.Instance.SetAndPlayStorys(new List<StoryScript>() {
        new StoryScript("不要再尝试了，失败了，，4号试验场，，，已经，，机会，，，剩，，，拜托了，不，，，再。快醒醒。"),
        new StoryScript("最后，，，机会。。合并。。。毁灭"),
        new StoryScript("喂！快醒醒！",()=>{ DialogEffect.Instance.FadeIn(); }),
        new StoryScript("看来是真睡死了。这可咋整啊。",Character.秦飞羽),
        new StoryScript("嘿，我有主意了。",Character.秦飞羽),
        new StoryScript("看招！猴子偷……",Character.秦飞羽),
        new StoryScript("猴子偷桃！",Character.李二狗),
        new StoryScript("test"),
        });
        




//少年：啊啊啊。你这家伙，醒着就别装睡啊。居然还敢来骗！来偷袭！我一个25岁的老同志。

//少年：这好吗？

//主角：别bb了，什么事情吵我？午休不是还有一个时辰吗？

//少年：你刚才没有感觉出来吗？地震了。在山林里睡觉很危险的。说不准就会有野兽过来。现在老板让全体集合呢。赶快过去吧。

//主角：ok，走吧。

//少年：这次对你的救命之恩你可要好好挂念在心上啊。这可不是下一次馆子就能了事的事情啊。

//主角：那再赏你一个猴子偷桃作为报答吧。

//少年：少侠饶命！小的知错！知错！

//主角：走吧，别废话了。保不准待会有什么东西跑出来。

//主角：（话说回来，我刚才好像在做一个什么梦？）

//主角：（。。。。想不起来）

//主角：（算了，继续前进吧）




    }


    void Update()
    {
        
    }
}
