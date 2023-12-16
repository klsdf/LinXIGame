using UnityEngine;

//二进制头文件
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



//XML头文件
using System.Xml;

//JSON头文件
using LitJson;



public class SaveSystem : Singleton<SaveSystem>
{
    //存储文件的位置
    private string saveFilePath;

    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        saveFilePath = Application.dataPath + "/Save";
        SaveSetting();
    }


    public SaveSettingData settingData = new SaveSettingData();//存储游戏设置的数据


    /// <summary>
    /// 保存游戏设置
    /// </summary>
    public void SaveSetting()
    {
        settingData.masterVolume = 120;

        SaveByJson(settingData, "/setting.txt");
    }


    public void SaveGameData()
    {
        
    }


    ///// <summary>
    ///// 从游戏中获得存储信息，并创建存储对象
    ///// </summary>
    ///// <returns>存储对象</returns>
    //private SaveData GetGameData()
    //{
    //    SaveData saveData = new SaveData();

    //    return saveData;
    //}


    ///// <summary>
    ///// 将某个存储对象的数据加载到游戏中
    ///// </summary>
    //private void SetGameData(SaveData saveData)
    //{

    //}



    public void SaveByJson<T>(T save,string fileName)
    {
        string saveJsonStr = JsonMapper.ToJson(save);
        StreamWriter sw = new StreamWriter(saveFilePath+fileName);
        sw.Write(saveJsonStr);
        sw.Close();
        print("保存成功");
    }

    //public void LoadByJson()
    //{

    //    if (File.Exists(saveFilePath))
    //    {
    //        StreamReader sr = new StreamReader(saveFilePath);
    //        string jsonStr = sr.ReadToEnd();
    //        sr.Close();
    //        SaveData save = JsonMapper.ToObject<SaveData>(jsonStr);
    //        SetGameData(save);
    //    }
    //    else
    //    {
    //        print("存档文件不存在");
    //    }
    //}

}

