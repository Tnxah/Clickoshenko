using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string middlePages = 
        "ca-app-pub-1530005681115600/2652307865";//android
    //"ca-app-pub-1530005681115600/4112313900";//ios

    private const string bannerKey = 
    "ca-app-pub-1530005681115600/6388372896";//android
    //"ca-app-pub-1530005681115600/5228270244";//ios
    //"ca-app-pub-3940256099942544/6300978111";//test banner key 
    public InterstitialAd ad;
    BannerView banner;
    AdRequest request;

    public GameObject settingsPanel;


    public Text chooseLang;
    public Text playText;
    public Text settingsText;
    public Text exitText;

    string[] chooseLangArr = {"Выберите язык", "Choose language"};
    string[] playArr = { "Играть", "Play" };
    string[] settingsArr = { "Настройки", "Settings" };
    string[] exitArr = { "Выход", "Exit" };

    public Settings settings = new Settings();
    int language = 0;

    public void Awake()
    {
        loadLanguage();
        chooseLang.text = chooseLangArr[language];
        playText.text = playArr[language];
        settingsText.text = settingsArr[language];
        exitText.text = exitArr[language];


        banner = new BannerView(bannerKey, AdSize.Banner, AdPosition.Bottom);
        request = new AdRequest.Builder().Build();
        ad = new InterstitialAd(middlePages);
        request = new AdRequest.Builder().Build();
    }
    
    void loadLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            settings = JsonUtility.FromJson<Settings>(PlayerPrefs.GetString("Language"));
            language = settings.language; 
            
        }
    }

    public void StartGame()
    {

        
       // banner.LoadAd(request);
      //  ad.LoadAd(request);
       // ad.OnAdLoaded += OnAdLoaded;



        Application.LoadLevel("Game");
    }
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
    
    public void showHideSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void setLanguage(int index)
    {
        settings.language = index;
        chooseLang.text = chooseLangArr[settings.language];
        playText.text = playArr[settings.language];
        settingsText.text = settingsArr[settings.language];
        exitText.text = exitArr[settings.language];
        PlayerPrefs.SetString("Language", JsonUtility.ToJson(settings));   
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    
    }

[Serializable]
public class Settings
{
    public int language;
}
