using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public SystemLanguage currentLanguage;
    public List<SystemLanguage> availableLanguages;

    public static LocalizationManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        

        availableLanguages.Add(SystemLanguage.English);
        availableLanguages.Add(SystemLanguage.Russian);
        availableLanguages.Add(SystemLanguage.Polish);

        currentLanguage = SystemLanguage.English;
    }
    
    public delegate void RefreshLanguage();
    public RefreshLanguage onLanguageChange;

    public void changeLanguageTo(SystemLanguage language)
    {
        //SystemLanguage language = SystemLanguage.Russian; //only for test
        if (availableLanguages.Contains(language))
        {
            currentLanguage = language;
            onLanguageChange?.Invoke();
        }
        else
        {
            print("This language (" + language + ") is not supported yet");
        }
    }
}
