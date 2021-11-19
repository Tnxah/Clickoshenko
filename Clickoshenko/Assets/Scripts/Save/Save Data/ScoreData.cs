using System;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public float score;
    public float perClickValue;
    public float perSecondValue;

    public ScoreData()
    {
        score = GameManager.instance.GetScore();
        perClickValue = GameManager.instance.GetPerClickValue();
        perSecondValue = GameManager.instance.GetPerSecondValue();
    }
}
