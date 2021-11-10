using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoVisualiser : MonoBehaviour
{
    public TextMeshProUGUI Score;


    private void FixedUpdate()
    {
        Score.text = GameManager.instance.GetScore();
    }
}
