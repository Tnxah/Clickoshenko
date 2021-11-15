﻿using TMPro;
using UnityEngine;

public class InfoVisualizer : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI perSecondValue;
    public TextMeshProUGUI perClickValue;


    private void FixedUpdate()
    {
        score.text = ((int)GameManager.instance.GetScore()).ToString();
        //perClickValue.text = (GameManager.instance.GetPerClickValue()).ToString();
        //perSecondValue.text = (GameManager.instance.GetPerSecondValue()).ToString();
    }

    public string shopButtonVisualizer(string text)
    {

        if (text.Contains("$clickprice$"))
        {
            text = text.Replace("$clickprice$", Shop.instance.clickCost.ToString());
        }
        if (text.Contains("$clickweight$"))
        {
            text = text.Replace("$clickweight$", Shop.instance.clickWeight.ToString());
        }
        if (text.Contains("$doubleprice$"))
        {
            text = text.Replace("$doubleprice$", Shop.instance.x2Cost.ToString());
        }
        return text;
    }
}
