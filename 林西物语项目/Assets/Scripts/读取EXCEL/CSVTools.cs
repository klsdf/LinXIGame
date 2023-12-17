using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// 说明：用于读取CSV文件，把excel的csv文件放到StreamingAssets里面即可
/// </summary>
public class CSVTools : MonoBehaviour
{

    public List<string[]> content = null;
    public string[] test1;
    private void Start()
    {
        content = LoadFile("/player.csv");
        foreach (string[] item in content)
        {
            test1 = item;
            print(item.Length);
            //for (int i = 0; i < item.Length; i++)
            //{
            //    Debug.Log(item[i]);
            //}
            //
        }
    }
    public static List<string[]> LoadFile(string path)
    {
        path = Application.streamingAssetsPath + path;
        List<string[]> content = null;
        if (!File.Exists(path))
        {
            Debug.LogError("路径不存在");
            return content;
        }

        try
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                content = new List<string[]>();
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] temp = line.Split(";");
                    temp = temp[0].Split(",");
                    content.Add(temp);
                }
                streamReader.Close();
                streamReader.Dispose();
            }




        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }

        return content;
    }
}
