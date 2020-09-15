using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;



public class Menu : MonoBehaviour
{
    private const string middlePages = "ca-app-pub-1530005681115600/2652307865";
    private const string bannerKey = "ca-app-pub-1530005681115600/6388372896";
    public InterstitialAd ad;
    BannerView banner;
    AdRequest request;
    public void Awake()
    {
        banner = new BannerView(bannerKey, AdSize.Banner, AdPosition.Bottom);
        request = new AdRequest.Builder().Build();
        ad = new InterstitialAd(middlePages);
        request = new AdRequest.Builder().Build();
    }
    
    public void StartGame()
    {

        
        banner.LoadAd(request);
        ad.LoadAd(request);
        ad.OnAdLoaded += OnAdLoaded;
       



        Application.LoadLevel("Game");
    }
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        ad.Show();
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
