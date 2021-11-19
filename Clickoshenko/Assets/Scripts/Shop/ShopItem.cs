using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public float price;
    public float value;
    public float priceMultiplier;
    public float valueMultiplier;

    public float tempPrice;

    public int counterToAd;
    public int numberToAd;
    public bool videoAgainstMoney;

    private void Start()
    {
        eachBuy();
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
    }


}
