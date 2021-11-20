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
        if (GameObject.FindGameObjectsWithTag("Localization").Length > 1)
        {
            GameObject.Destroy(gameObject);
        }

        GameObject.DontDestroyOnLoad(this);
    }

    private void Start()
    {
        

        availableLanguages.Add(SystemLanguage.English);
        availableLanguages.Add(SystemLanguage.Russian);
        availableLanguages.Add(SystemLanguage.Polish);

        //currentLanguage = SystemLanguage.English;
    }
    
    public delegate void RefreshLanguage();
    public RefreshLanguage onLanguageChange;

    public void ChangeLanguageTo(SystemLanguage language)
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

    public string GetRewarded()
    {
        return ConstantDictionary.rewarded[currentLanguage];
    }
}

public class ConstantDictionary
{
    public static Dictionary<SystemLanguage, string> rewarded = new Dictionary<SystemLanguage, string>
    {   {SystemLanguage.English, "Watch video" },
        {SystemLanguage.Russian, "Посмотреть видео" },
        {SystemLanguage.Polish, "Oglądać filmik" }
    };
}
