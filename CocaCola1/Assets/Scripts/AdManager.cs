using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using UnityEngine.Events;

public class AdManager : MonoBehaviour {
    public static AdManager instance;

	//Admob
	InterstitialAd interstitial;
	[Header("Admob")]
	public string BannerId = "ca-app-pub-3940256099942544/6300978111"; // Your Admob Code for Banner
	public string InterstitialAd = "ca-app-pub-3940256099942544/1033173712"; // Your Admob Code for Interstitial
	public string APPId = "ca-app-pub-3940256099942544~3347511713"; // Your AppID code
    //UnityAds
	[Header("Unity Ads")]
    public string UnityGameID = "3084422";
	public string UnityVideo = "video";
	void Awake()
	{
        instance = this;
    }
	void Start()
	{
		//UnityAds
		Advertisement.Initialize(UnityGameID);
		//Admob
	    MobileAds.Initialize(initStatus => { });
		
	#if UNITY_ANDROID
			string appId = APPId;
	#elif UNITY_IPHONE
				string appId = "APPId";
	#else
				string appId = "unexpected_platform";
	#endif
		MobileAds.Initialize(appId);
		RequestBanner();
		RequestInterstitial();
	}
	private void RequestBanner()
	{
	#if UNITY_EDITOR
			string adUnitId = "unused";
	#elif UNITY_ANDROID
			string adUnitId = BannerId;
	#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
	#else
			string adUnitId = "unexpected_platform";
	#endif
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
	}

private void RequestInterstitial()
{
    #if UNITY_ANDROID
        string adUnitId = InterstitialAd;
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        string adUnitId = "unexpected_platform";
    #endif
    this.interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		this.interstitial.LoadAd(request);
	}
	public void ShowAdmobAd()
	{
		if (interstitial.IsLoaded())
		{
				interstitial.Show();
		}
		else
		{
			Debug.Log("Interstitial is not ready yet");
		}
	}
	
    //UnityAds
   public void ShowUnityAd()
    {
		if (Advertisement.IsReady(UnityVideo))
		{
			Advertisement.Show(UnityVideo);
		}
		else
		{
			interstitial.Show();
			Debug.Log("Interstitial Admob Show");
		}

	}
}