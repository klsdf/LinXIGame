using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 


[Serializable]
public class Objinfo
{
    [SerializeField]
    public GameObject obj;
    [SerializeField]
    public int num;
}
public class MapController : Singleton<MapController>
{
    public GenType genType;

    private TileBase[] terrainTiles;

    public TileBase[] terrainTiles1;
    public TileBase[] terrainTiles2;
    public TileBase[] terrainTiles3;


    private TileBase[] decoratorTiles;

    public TileBase[] decoratorTiles1;
    public TileBase[] decoratorTiles2; 
    public TileBase[] decoratorTiles3;

    //地图的预制体
    private Objinfo[] prefabs;
    private Objinfo[] prefabs1;
    private Objinfo[] prefabs2;
    private Objinfo[] prefabs3;


    public int width = 100;
    public int height = 100;

    private Tilemap[] tilemap;





    private void Start()
    {
        tilemap = GetComponentsInChildren<Tilemap>();


        prefabs1 = new Objinfo[] {
            new Objinfo(){obj = Resources.Load<GameObject>("entity/传送门"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/兵卡商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/合成商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/敌人战士"), num = 20},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/树木"), num = 30},
        };

        prefabs2 = new Objinfo[] {
            new Objinfo(){obj = Resources.Load<GameObject>("entity/传送门"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/兵卡商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/合成商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/怪物培育器"), num = 2},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/敌人弓箭手"), num = 5},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/敌人战士"), num = 20},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/树木"), num = 30},
        };

        prefabs3 = new Objinfo[] {
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/BOSS"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("entity/传送门"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/兵卡商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/合成商店"), num = 1},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/怪物培育器"), num = 2},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/敌人弓箭手"), num = 3},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/敌人战士"), num = 10},
            new Objinfo(){obj = Resources.Load<GameObject>("Entity/树木"), num = 30},
        };




        Generate();
    }


    private void Update()
    {
    }


    /// <summary>
    /// 生成地牢
    /// </summary>
    public void Generate()
    {
        switch (GameManager.Instance.DungeonLayers)
        {
            case 1 :
                terrainTiles = terrainTiles1;
                decoratorTiles = decoratorTiles1;
                prefabs = prefabs1;
                break;
            case 2:
                terrainTiles = terrainTiles2;
                decoratorTiles = decoratorTiles2;
                prefabs = prefabs2;
                break;
            case 3:
                terrainTiles = terrainTiles3;
                decoratorTiles = decoratorTiles3;
                prefabs = prefabs3;
                break;
            default:
                terrainTiles = terrainTiles1;
                decoratorTiles = decoratorTiles1;
                prefabs = prefabs1;
                break;
        }

        GenerateBaseTerrain(tilemap[0]);
        GenerateDecoratorTerrain(tilemap[1]);
        GenerateEntity();
    }


    /// <summary>
    /// 生成地形
    /// </summary>
    /// <param name="tilemap"></param>
    private void GenerateBaseTerrain(Tilemap tilemap) 
    {
        tilemap.ClearAllTiles();
        for (int x = -width / 2; x < width / 2; x++)
        {
            for (int y = -height / 2; y < height / 2; y++)
            {
                int randomTileIndex = UnityEngine.Random.Range(0, terrainTiles.Length);
                tilemap.SetTile(new Vector3Int(x, y, 0), terrainTiles[randomTileIndex]);
            }
        }
    }


    /// <summary>
    /// 生成装饰性的地形，比如花花草草之类的
    /// </summary>
    /// <param name="tilemap"></param>
    private void GenerateDecoratorTerrain(Tilemap tilemap)
    {
        tilemap.ClearAllTiles();
        for (int x = -width / 2; x < width / 2; x++)
        {
            for (int y = -height / 2; y < height / 2; y++)
            {

                if (Util.TryTrigger(0.05f) == true)
                {
                    int randomTileIndex = UnityEngine.Random.Range(0, decoratorTiles.Length);
                    tilemap.SetTile(new Vector3Int(x, y, 0), decoratorTiles[randomTileIndex]);
                }

            }
        }
    }


    /// <summary>
    /// 创建地图的entity
    /// </summary>
    private void GenerateEntity()
    {




        Destroy(GameObject.Find("地图的临时entity"));

        GameObject entity = new GameObject("地图的临时entity"); 

        foreach (Objinfo info in prefabs)
        {
            for (int i = 0; i < info.num; i++)
            {
                Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-width/2, width/2), UnityEngine.Random.Range(-height/2, height/2));
                GameObject temp =  Instantiate(info.obj, spawnPosition, Quaternion.identity);
                temp.transform.parent = entity.transform;
            }
        }
    }

}
