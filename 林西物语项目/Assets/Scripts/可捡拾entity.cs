using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public abstract  class 可捡拾entity : MonoBehaviour
{
    private float timer = 0;
    protected float cooldown = 20;

    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnPlayerMove += CheckDestory;
    }


    void Update()
    {

    }
    private void CheckDestory(float time)
    {
        timer += time;
        if (timer >= 0.5 * cooldown)
        {
            animator.SetBool("快要消失", true);
        }

        if (timer >= cooldown)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("NPC"))
        {
            BePickedUP(collision);
            Destroy(gameObject);
        }
    }


    //被捡拾起来
    protected abstract void BePickedUP(Collider2D collision);


    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerMove -= CheckDestory;
    }
}
