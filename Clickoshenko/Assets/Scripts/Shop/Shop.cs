using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void BuyPerClickBoost(ShopItem item)
    {
       

        if (item.videoAgainstMoney && GameManager.instance.GetScore() < item.price)
        {
            AdsManager.instance.ShowRewarded(item.Action);
        }
        else
        {
            GameManager.instance.SubtractFromScore(item.price);
            item.Action();
        }
    }
}
