﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float _score = 0;
    private float _perClickValue = 1;
    public float _perSecondValue = 0;

    public static GameManager instance;
    public InfoVisualizer infoVisualizer;
    public OnClick onClick;
    private void Awake()
    {
        print(Application.version);
        if (onClick.clickAction == null)
        {
            onClick.clickAction = IncreaseScore;
        }
        if (instance == null)
        {
            instance = this;
        }
        infoVisualizer = GetComponent<InfoVisualizer>();

        LoadScore();
    }

    public void LoadScore()
    {
       ScoreData data = SaveSystem.LoadScore();
        if (data == null)
        {
            return;
        }
        _score = data.score;
        _perClickValue = data.perClickValue;
        _perSecondValue = data.perSecondValue;

        AddToScore(CalculateAFKScore(data.exitTime));
    }

    private float CalculateAFKScore(DateTime exitTime)
    {
        DateTime dtNow = DateTime.Now;

        TimeSpan result = dtNow.Subtract(exitTime);

        int seconds = Convert.ToInt32(result.TotalSeconds);
        
        return seconds * _perSecondValue;
    }

    public void SaveScore()
    {
        SaveSystem.SaveScore();
    }

    private void IncreaseScore()
    {
        _score += _perClickValue;
        SaveScore();
    }
    
    public void AddToScore(float value)
    {
        _score += value;
        SaveScore();
    }

    public void SubtractFromScore(float value)
    {
        _score -= value;
        SaveScore();
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
        SaveScore();
    }

    public void SubtractFromPCV(float value)
    {
        _perClickValue -= value;
        SaveScore();
    }

    public void AddToPSV(float value) {
        _perSecondValue += value;
        SaveScore();
    }

}
