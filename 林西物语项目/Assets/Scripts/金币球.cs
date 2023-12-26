using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class 金币球 : 可捡拾entity
{
    public int 金币值;
    protected override void BePickedUP(Collider2D collision)
    {
        GameManager.Instance.GetMojing(金币值);
    }
}
