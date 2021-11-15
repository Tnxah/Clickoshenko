using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public float clickCost = 300f;
    public float clickWeight = 2f;
    public float clickWeightRule = 1.5f;
    public float clickCostRule = 2.1f;
    public int clickCounterToWatch = clickToWatchRule;
    public static int clickToWatchRule = 5;
    private float tempClickCost = 0f;

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

    public void IncreasePerClickValue()
    {
        if (GameManager.instance.GetScore() >= clickCost ||
            (clickCounterToWatch == 0 && AdsManager.instance.isRewardedReady()))
        {

            if (clickCounterToWatch == 0 && GameManager.instance.GetScore() < clickCost)
            {
                AdsManager.instance.ShowRewarded(Increase);
                clickCounterToWatch = clickToWatchRule;
            }
            else
            {
                Increase();
                GameManager.instance.SubtractFromScore(clickCost);
            }
                        
            clickWeight *= clickWeightRule;
            clickCost *= clickCostRule;

            clickCounterToWatch--;
        }
        GameManager.instance.infoVisualizer.onTextChanges?.Invoke();
    }

    public void DoubleMultiplier()
    {
        
        if (GameManager.instance.GetScore() >= x2Cost ||
            (doubleCounterToWatch == 0 && AdsManager.instance.isRewardedReady()))
        {

            if (doubleCounterToWatch == 0 && GameManager.instance.GetScore() < x2Cost)
            {
                AdsManager.instance.ShowRewarded(Multiply);
                doubleCounterToWatch = doubleToWatchRule;
            }
            else
            {
                GameManager.instance.SubtractFromScore(x2Cost);
                Multiply();
            }
           
            x2Cost *= x2CostRule;
            doubleCounterToWatch--;
        }
        GameManager.instance.infoVisualizer.onTextChanges?.Invoke();
    }

    private void Multiply()
    {
        GameManager.instance.AddToPCV(GameManager.instance.GetPerClickValue());
    }
    private void Increase()
    {
        GameManager.instance.AddToPCV(clickWeight);
    }
}
