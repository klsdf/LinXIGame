using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class ObjTest : MonoBehaviour
{
    float rotationSpeeds = 10.0f;

    Vector3 direction = new Vector3(1, 1, 1);
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(rotationSpeeds* direction * Time.deltaTime);
    }
}
