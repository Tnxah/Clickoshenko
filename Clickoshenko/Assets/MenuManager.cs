using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject newVersionPanel;
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(CheckForUpdated());
        
    }

    private void Update()
    {
        //if (newVersionPanel.activeSelf == false && RemoteConfig.instance.IsNewVersion())
        //{
        //    newVersionPanel.SetActive(true);
        //}
    }
    IEnumerator CheckForUpdated()
    {
        
        yield return new WaitUntil(() => RemoteConfig.instance.IsNewVersion() == true);
        
        if (RemoteConfig.instance.IsNewVersion())
        {
            newVersionPanel.SetActive(true);
        }
    }
    public void OnDownloadButton()
    {
        Application.OpenURL(RemoteConfig.instance.GetDownloadLink());
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowHidePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void MuteUnmute()
    {
        AudioController.instance.MuteUnmute();
    }
}
