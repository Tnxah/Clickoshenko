using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChangeButton : MonoBehaviour
{
    public SystemLanguage language;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => LocalizationManager.instance.ChangeLanguageTo(language));
    }
}
