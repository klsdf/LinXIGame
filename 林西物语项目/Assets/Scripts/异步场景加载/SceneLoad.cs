using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class SceneLoad : Singleton<SceneLoad>
{
    public Slider slider;

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
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // 阻止场景在加载完后立即激活

        // 等待直到场景完全加载
        while (!asyncLoad.isDone)
        {
            // ��以在此处添加加载进度条的UI更新
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");


            slider.value = asyncLoad.progress;
            // ��场景加载完成，等待用户点击屏幕
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