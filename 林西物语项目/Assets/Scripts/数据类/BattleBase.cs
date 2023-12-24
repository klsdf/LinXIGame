using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 


//队伍
public enum BattleParty
{ 
    Player,//玩家阵营
    Neutral,//完全中立
    CapturedPlayer,//被抓的玩家阵营
    Enemy//敌方阵营
}

public class BattleBase : MonoBehaviour
{
   
    public BattleParty party;


    public float maxHp;
    public float attack;
    public float defense;


    [SerializeField]
    private float hp;

    public float costTime;//每进行一次行动的耗时

    private AudioSource audioSource;



  
    private Slider slider;

    //被敌人攻击
    public void ProcessAttack(BattleBase enemyData) 
    {
        hp -= enemyData.attack - defense;

        audioSource.Play();
        slider.maxValue = maxHp;
        slider.value = hp;


        if (hp <= 0)
        {
            Dead();
        }
    }

    //回血
    public void Recover(int recoverHP)
    { 
        hp = Mathf.Clamp(hp+ recoverHP, 0, maxHp);
    }


    public void GetDamage(int damage)
    {

        hp -= damage;

        if (hp <= 0)
        {
            Dead();
        }

    }

    public void Dead() 
    {

        Destroy(gameObject);
    }

  



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        hp = maxHp;
        Slider[] Test = GetComponentsInChildren<Slider>();
        foreach (Slider test in Test)
        {
            slider = test;
        }

       

    }


    void Update()
    {
     
    }
}
