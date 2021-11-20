using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoVisualizer : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI perSecondValue;
    public TextMeshProUGUI perClickValue;

    public delegate void DynamicObjects();
    public DynamicObjects onTextChanges;

    private void FixedUpdate()
    {
        score.text = ((int)GameManager.instance.GetScore()).ToString();
        //perClickValue.text = (GameManager.instance.GetPerClickValue()).ToString();
        //perSecondValue.text = (GameManager.instance.GetPerSecondValue()).ToString();
    }

    
}
