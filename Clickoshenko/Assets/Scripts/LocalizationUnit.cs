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

    public bool shouldBeReplaced = false;
    public bool dynamicInfo = false;

    TextMeshProUGUI textMeshPro;

    void Start()
    {
        textList = new Dictionary<SystemLanguage, string>();
        Initializing();

        textMeshPro = GetComponent<TextMeshProUGUI>();
        LocalizationManager.instance.onLanguageChange += SetText;
        if (dynamicInfo)
        {
            GameManager.instance.infoVisualizer.onTextChanges += SetText;
        }
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
        if (textList[LocalizationManager.instance.currentLanguage] == null ||
            textList[LocalizationManager.instance.currentLanguage] == "")
        {
            textMeshPro.text = textList[SystemLanguage.English];
        }
        else
        {
            textMeshPro.text = textList[LocalizationManager.instance.currentLanguage];
        }

        if (shouldBeReplaced)
        {
            textMeshPro.text = GameManager.instance.infoVisualizer.shopButtonVisualizer(textMeshPro.text);
        }
    }
}
