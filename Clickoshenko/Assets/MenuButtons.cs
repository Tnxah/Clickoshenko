using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject menuButtonsPanel;

    public void ShopButton()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        menuButtonsPanel.SetActive(!menuButtonsPanel.activeSelf);
    }
}
