using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPerSecond : ShopItem
{
    public override void Action()
    {
        GameManager.instance.AddToPSV(value);
        PriceIncrease();
        ValueIncrease();
        base.Action();
    }
}
