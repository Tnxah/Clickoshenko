using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsListener
{
#if UNITY_ANDROID
    string gameID = "4452907";
    string interstitialId = "Interstitial_Android";
    string rewardedID = "Rewarded_Android";
    string bannerID = "Banner_Android";
#else
    string gameId = "4452906";
    string interstitialId = "Interstitial_iOS";
    string rewardedId = "Rewarded_iOS";
    string bannerId = "Banner_iOS";
#endif 

    public TextMeshProUGUI debug;

    Action onRewardedAdSuccess;
    public static AdsManager instance;

    private void Awake()
    {
#if UNITY_EDITOR
        return;
        #endif
        Advertisement.Initialize(gameID, false, false, this);


    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        
        Advertisement.AddListener(this);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        
    }

   
    public void ShowInterstitial()
    {
        if (Advertisement.IsReady(interstitialId))
        {
            
            Advertisement.Show(interstitialId);
        }
    }

    public void ShowRewarded(Action onSuccess)
    {
        if (Advertisement.IsReady(rewardedID))
        {
            onRewardedAdSuccess = onSuccess;
            Advertisement.Show(rewardedID);
        }
        else
        {
            print("Rewarded ad is not awailable");
        }
    }

    public void ShowBanner()
    {

        BannerOptions options = new BannerOptions
        {
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(bannerID, options);        
    }

    private void OnBannerShown()
    {
        debug.text += "Banner shown";
        print("Banner shown");
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator BannerChecker()
    {
        yield return new WaitUntil(() => Advertisement.IsReady(bannerID));
        ShowBanner();
    }

    public void LoadBanner()
    {
        debug.text += "Banner start loading";
        print("Banner start loading");
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(bannerID, options);
    }

    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        debug.text += "Banner loaded";
        ShowBanner();

    }

    
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        debug.text += $"Banner Error: {message}";
        

    }

    public void OnUnityAdsReady(string placementId)
    {
        print("ADS ARE READY");
        
    }

    public void OnUnityAdsDidError(string message)
    {
        print("ERROR " + message);
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        print("VIDEO STARTED");
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedID && showResult == ShowResult.Finished)
        {
            print("REWARD");
            //***********
            // GIVE REWARD TO THE PLAYER
            onRewardedAdSuccess.Invoke();
            //***********
        }
    }

    public bool isRewardedReady()
    {
        return Advertisement.IsReady(rewardedID);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        debug.text += "Unity Ads initialization complete.";
        LoadBanner();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        debug.text += $"Unity Ads Initialization Failed: {error.ToString()} - {message}";
    }
}
