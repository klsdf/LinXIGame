using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 作者：闫辰祥
/// </summary>
/// 


public abstract class BattleBase : MonoBehaviour
{
   
    public BattleParty party;


    [Header("最大生命")]
    public float maxHp;

    [Header("攻击")]
    public float atk;

    [Header("防御")]
    public float def;

    [Header("远程攻击")]
    public float rangeAtk;

    [Header("远程防御")]
    public float rangeDef;

    [Header("暴击率")]
    public float crit;

    [Header("暴击伤害")]
    public float critDamage;

    [Header("格挡率")]
    public float block;

  

    public float costTime = 1;//每进行一次行动的耗时


    [SerializeField]
    private float hp;

    private AudioSource audioSource;
  
    private Slider slider;

    //被敌人攻击
    public void ProcessAttack(BattleBase enemyData) 
    {
        BattleBase defender = this;
        BattleBase attakcer = enemyData;

        float damage = 0;
        //如果格挡成功了，那么就不会受到伤害
        if (isBlock())
        {
            return;
        }

        if (attakcer.isCrit())
        {
            damage = BiggerThan0(attakcer.atk - defender.def)* attakcer.critDamage;

        }
        else
        {
            damage = BiggerThan0(attakcer.atk - defender.def);
        }

        hp -= damage;

        audioSource.Play();
        slider.maxValue = maxHp;
        slider.value = hp;

        if (hp <= 0)
        {
            Dead();
        }
    }

    public bool isBlock()
    {
        return Util.TryTrigger(block);
    }

    public bool isCrit()
    {
        return Util.TryTrigger(crit);
    }

    public float BiggerThan0(float num)
    {
        if (num < 0)
        {
            return 0;
        }
            
        else
            return num;
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

    public virtual  void Dead() 
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
