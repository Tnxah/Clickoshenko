using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public float price;
    public float value;
    public float priceMultiplier;
    public float valueMultiplier;

    public int counterToAd;
    public int numberToAd;
    public bool videoAgainstMoney;

    private void Start()
    {
        LoadShopItem();
        UIShopManager.instance.PrepareText(this);
    }

    public virtual void PriceIncrease()
    {
        price *= priceMultiplier;
    }

    public virtual void ValueIncrease()
    {
        value *= valueMultiplier;
    }

    public virtual void Action()
    {
        eachBuy();
    }

    public void eachBuy()
    {
        counterToAd--;
        if (counterToAd == 0)
        {
            videoAgainstMoney = true;
        }
        else if(counterToAd < 0)
        {
            videoAgainstMoney = false;
            counterToAd = numberToAd;
        }
        UIShopManager.instance.PrepareText(this);
        SaveShopItem();
    }


    public void LoadShopItem()
    {
        ShopItemData data = SaveSystem.LoadShopItem(this.name);
        if (data == null)
        {
            return;
        }
        price = data.price;
        value = data.value;
        priceMultiplier = data.priceMultiplier;
        counterToAd = data.counterToAd;
        numberToAd = data.numberToAd;
        videoAgainstMoney = data.videoAgainstMoney;
    }

    public void SaveShopItem()
    {
        SaveSystem.SaveShopItem(this);
    }
}
