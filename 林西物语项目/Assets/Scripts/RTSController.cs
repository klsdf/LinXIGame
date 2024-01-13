using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class RTSController : MonoBehaviour
{
    
    private Vector3 startPosition;

    List< GameObject> units = new List<GameObject>();
    [SerializeField]
    private Transform selectionArea;

    private void Awake()
    {
        selectionArea.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }


    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Util.GetMouseWorldPosition2D();
            foreach(GameObject unit in units)
            {

                unit.GetComponent<RTSUnit>().NotControl();
            }

            units.Clear();
            selectionArea.gameObject.SetActive(true);

        }

        if (Input.GetMouseButton(0))
        { 
            Vector3 mousePos = Util.GetMouseWorldPosition2D();

            Vector3 lowerLeft  = new Vector3(
                Mathf.Min(mousePos.x, startPosition.x), 
                Mathf.Min(mousePos.y, startPosition.y)
                
            );
            Vector3 upperRight = new Vector3(
                Mathf.Max(mousePos.x, startPosition.x),
                Mathf.Max(mousePos.y, startPosition.y)
           );

            selectionArea.position = lowerLeft;
            selectionArea.localScale = upperRight - lowerLeft;
        }


        if (Input.GetMouseButtonUp(0))
        {
            Collider2D[] collidersArray = Physics2D.OverlapAreaAll(startPosition, Util.GetMouseWorldPosition2D());
            foreach (Collider2D collider in collidersArray)
            {
                if (collider.tag == "NPC")
                {
                    collider.GetComponent<RTSUnit>().Controled();
                    units.Add(collider.gameObject);
                }
            }
            selectionArea.gameObject.SetActive(false);
     
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject obj in units)
            {
                obj.GetComponent<RTSUnit>().SetPosition(Util.GetMouseWorldPosition2D());
            }
        }

    }
}
