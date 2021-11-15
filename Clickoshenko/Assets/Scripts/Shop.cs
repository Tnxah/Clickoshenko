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

    public float x2Cost = 2000f;
    public float x2CostRule = 6f;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

       
    }

    public void IncreasePerClickValue()
    {
        if (GameManager.instance.GetScore() >= clickCost)
        {
            GameManager.instance.SubtractFromScore(clickCost);
            GameManager.instance.AddToPCV(clickWeight);

            clickWeight *= clickWeightRule;
            clickCost *= clickCostRule;
        }
    }

    public void DoubleMultiiplier()
    {

        if (GameManager.instance.GetScore() >= x2Cost)
        {
            GameManager.instance.SubtractFromScore(x2Cost);
            GameManager.instance.AddToPCV(GameManager.instance.GetPerClickValue());

            x2Cost *= x2CostRule;
        }
    }

}
