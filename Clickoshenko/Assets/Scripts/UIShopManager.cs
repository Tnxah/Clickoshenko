using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopManager : MonoBehaviour
{
    public GameObject perClickButton;
    public GameObject doubleButton;

    public static UIShopManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        CheckAvailability(perClickButton, perClickButton.GetComponent<ShopItem>());
        CheckAvailability(doubleButton, doubleButton.GetComponent<ShopItem>());
    }

    private void CheckAvailability(GameObject button, ShopItem shopItem)
    {
        if (shopItem.price <= GameManager.instance.GetScore() ||
            (shopItem.videoAgainstMoney && AdsManager.instance.isRewardedReady()))
        {
            button.GetComponent<Button>().interactable = true;
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void PrepareText(ShopItem item)
    {
        TextMeshProUGUI textMeshPro = item.GetComponentInChildren<TextMeshProUGUI>();
        item.GetComponentInChildren<LocalizationUnit>().SetText();

        if (item.videoAgainstMoney)
        {
            textMeshPro.text = textMeshPro.text.Replace("$price$", LocalizationManager.instance.GetRewarded());
        }
        else
        {
            textMeshPro.text = textMeshPro.text.Replace("$price$", item.price.ToString());
        }
        textMeshPro.text = textMeshPro.text.Replace("$value$", item.value.ToString());
    }
}
