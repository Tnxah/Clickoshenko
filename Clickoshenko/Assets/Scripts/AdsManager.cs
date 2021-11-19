using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    string gameID = "4452331";
    string interstitialId = "Interstitial_Android";
    string rewardedID = "Rewarded_Android";
    string bannerID = "Banner_Android";
#else
    string gameId = "4452330";
    string interstitialId = "Interstitial_iOS";
    string rewardedId = "Rewarded_iOS";
    string bannerId = "Banner_iOS";
#endif 

    public TextMeshProUGUI debug;

    Action onRewardedAdSuccess;
    public static AdsManager instance;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        ShowBanner();
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
        
        if (Advertisement.IsReady(bannerID))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
        else
        {
            StartCoroutine(BannerChecker());
        }
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
}
