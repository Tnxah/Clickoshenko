using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItemData
{
    public float price;
    public float value;
    public float priceMultiplier;
    public float valueMultiplier;

    public int counterToAd;
    public int numberToAd;
    public bool videoAgainstMoney;

    public ShopItemData(ShopItem item)
    {
        this.price = item.price;
        this.value = item.value;
        this.priceMultiplier = item.priceMultiplier;
        this.valueMultiplier = item.valueMultiplier;
        this.counterToAd = item.counterToAd;
        this.numberToAd = item.numberToAd;
        this.videoAgainstMoney = item.videoAgainstMoney;
    }
}
