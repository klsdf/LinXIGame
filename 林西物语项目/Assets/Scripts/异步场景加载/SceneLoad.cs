using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class SceneLoad : Singleton<SceneLoad>
{
    public Slider slider;
    public TMP_Text tips;

    public string sceneName; // 需要加载的场景名
    AsyncOperation asyncLoad;

    private void Start()
    {
        //LoadSceneAsync();
    }
    public void LoadSceneAsync()
    {
       GameObject tempObj= Resources.Load<GameObject>("异步场景加载Canvas");
        tempObj = Instantiate(tempObj);
        slider = tempObj.GetComponentInChildren<Slider>();
        tips = tempObj.GetComponentInChildren<TMP_Text>();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // 阻止场景在加载完后立即激活

        tips.text = "123123";
        // 等待直到场景完全加载
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");
            slider.value = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f)
            {
                if (Input.GetMouseButtonDown(0))
                    asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        Debug.Log("Scene loaded.");
    }
}