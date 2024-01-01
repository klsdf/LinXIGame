using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class ShopComposite : Shop
{
    //开始合成
    public void Composite()
    {
        WarCardController.Instance.DeleteAndCreateCard(NPCType.Warrior,NPCType.Warrior,NPCType.Warrior,NPCType.Archer);
    }
}
