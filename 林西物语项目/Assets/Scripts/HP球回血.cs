using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class HP球回血 : 可捡拾entity
{
    public int 回血值;
    protected override void BePickedUP(Collider2D collision)
    {
        collision.GetComponent<BattleBase>().Recover(回血值);
    }
}
