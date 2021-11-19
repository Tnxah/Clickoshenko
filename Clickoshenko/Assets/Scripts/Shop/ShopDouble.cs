using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDouble : ShopItem
{
    public override void Action()
    {
        GameManager.instance.AddToPCV(GameManager.instance.GetPerClickValue());
        PriceIncrease();
        base.Action();
    }
}
