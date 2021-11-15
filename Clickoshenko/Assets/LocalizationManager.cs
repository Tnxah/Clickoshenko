using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    SystemLanguage currentLanguage;

    private void Start()
    {
        currentLanguage = SystemLanguage.English;
    }
}
