using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(perSecond());
    }

    IEnumerator perSecond()
    {
        while (true)
        {
GameManager.instance.AddToScore(GameManager.instance.GetPerSecondValue());
        yield return new WaitForSeconds(1);
        }
        
    }
}
