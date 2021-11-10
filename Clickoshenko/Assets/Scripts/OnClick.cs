using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public delegate void Click();
    public Click clickAction;

    public void OnClickButton()
    {
        clickAction?.Invoke();
    }
}
