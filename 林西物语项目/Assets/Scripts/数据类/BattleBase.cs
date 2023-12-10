using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 作者：闫辰祥
/// </summary>
public class BattleBase : MonoBehaviour
{
   


    public float maxHp;
    public float attack;
    public float defense;


    public float hp;

    public float costTime;//每进行一次行动的耗时

    public AudioSource audioSource;



  
    public Slider slider;

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
