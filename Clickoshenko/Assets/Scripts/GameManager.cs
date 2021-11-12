﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _score;
    private float _perClickValue = 1;
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
        _score += _perClickValue;
    }
    
    public void AddToScore(float value)
    {
        _score += value;
    }

    public void SubtractFromScore(float value)
    {
        _score -= value;
    }


    public float GetScore()
    {
        return _score;
    }

    public float GetPerClickValue()
    {
        return _perClickValue;
    }
    public float GetPerSecondValue()
    {
        return _perSecondValue;
    }

    public void AddToPCV(float value)
    {
        _perClickValue += value;
    }

    public void SubtractFromPCV(float value)
    {
        _perClickValue -= value;
    }

}
