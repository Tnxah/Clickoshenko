using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPerClick : ShopItem
{
    public override void Action()
    {
        GameManager.instance.AddToPCV(value);
        PriceIncrease();
        ValueIncrease();
        base.Action();
    }
}
