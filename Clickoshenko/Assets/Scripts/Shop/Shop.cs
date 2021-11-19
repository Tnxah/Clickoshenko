using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public float x2Cost = 2000f;
    public float x2CostRule = 6f;
    public static int doubleToWatchRule = 10;
    public int doubleCounterToWatch = doubleToWatchRule;
    private float tempX2Cost = 0f;

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
        
        //GameManager.instance.infoVisualizer.onTextChanges?.Invoke();
    }

    public void OnDoubleButton(ShopItem item)
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
        //if (GameManager.instance.GetScore() >= x2Cost ||
        //    (doubleCounterToWatch == 0 && AdsManager.instance.isRewardedReady()))
        //{

        //    if (doubleCounterToWatch == 0 && GameManager.instance.GetScore() < x2Cost)
        //    {
        //        AdsManager.instance.ShowRewarded(DoublePerClick);
        //        doubleCounterToWatch = doubleToWatchRule;
        //    }
        //    else
        //    {
        //        GameManager.instance.SubtractFromScore(x2Cost);
        //        DoublePerClick();
        //    }


        //    doubleCounterToWatch--;
        //}
        //GameManager.instance.infoVisualizer.onTextChanges?.Invoke();
    }

    private void DoublePerClick()
    {
        GameManager.instance.AddToPCV(GameManager.instance.GetPerClickValue());

        x2Cost *= x2CostRule;
    }
}
