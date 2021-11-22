using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationUnit : MonoBehaviour
{
    public Dictionary<SystemLanguage, string> textList;

    public string russian;
    public string english;
    public string polish;

    TextMeshProUGUI textMeshPro;

    void Start()
    {
        textList = new Dictionary<SystemLanguage, string>();
        Initializing();

        textMeshPro = GetComponent<TextMeshProUGUI>();
        LocalizationManager.instance.onLanguageChange += SetText;
        SetText();
    }

    void Initializing()
    {
        textList.Add(SystemLanguage.English, english);
        textList.Add(SystemLanguage.Russian, russian);
        textList.Add(SystemLanguage.Polish, polish);
    }

    public void SetText()
    {
        if (!textList.ContainsKey(LocalizationManager.instance.currentLanguage) || 
            textList[LocalizationManager.instance.currentLanguage] == "")
        {
            textMeshPro.text = textList[SystemLanguage.English];
        }
        else
        {
            textMeshPro.text = textList[LocalizationManager.instance.currentLanguage];
        }
    }
}
