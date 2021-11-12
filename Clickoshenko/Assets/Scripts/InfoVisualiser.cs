using TMPro;
using UnityEngine;

public class InfoVisualiser : MonoBehaviour
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
}
