using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _score;
    private float _clickValue = 1;
    private float _perSecondValue = 0;

    public static GameManager instance;

    public OnClick onClick;


    private void Awake()
    {
        if (onClick.clickAction == null)
        {
            onClick.clickAction = IncreaseScore;
        }        
    }

    private void Start()
    {
       

        if (instance == null)
        {
            instance = this;
        }
    }

    private void IncreaseScore()
    {
        _score += _clickValue;
    }

    public string GetScore()
    {
        return ((int)_score).ToString();
    }

    public float GetClickValue()
    {
        return _clickValue;
    }

}
