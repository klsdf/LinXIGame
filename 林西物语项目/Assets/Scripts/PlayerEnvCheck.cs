using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class PlayerEnvCheck : MonoBehaviour
{
    public GameObject searchIcon;


    private Collider2D collisionObj;


    private bool canInteractive = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当进入的物体的tag为Enemy时，将其加入到敌人列表中
        if (collision.CompareTag("Shop"))
        {
            searchIcon.SetActive(true);
           
            canInteractive = true;
            collisionObj = collision;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop"))
        {
            searchIcon.SetActive(false);
        }
        collisionObj = null;
    }




    void Start()
    {
        
    }


    void Update()
    {
        if (canInteractive) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(collisionObj!=null)
                    collisionObj.GetComponent<Shop>().Interactive();
            }
        }
    }
}
