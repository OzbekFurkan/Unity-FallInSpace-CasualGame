using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class reklam : MonoBehaviour
{
    private InterstitialAd interstitial;
    static reklam reklamkontrol;
    void Start()
    {

        this.request();
    }
    private void request()
    {
        if (reklamkontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            reklamkontrol = this;
#if UNITY_ANDROID
            string appId = "ca-app-pub-4684639985963900~5924391009";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544/4411468910";
#else
        string appId = "unexpected_platform";
#endif


            MobileAds.Initialize(appId);
            /////////////////////////////////////////////////////////////////////////////////////////////////
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4684639985963900/8797966350";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif


            this.interstitial = new InterstitialAd(adUnitId);
            this.interstitial.OnAdClosed += interstitialclosed;
            ////////////////////////////////////////////////////////////////////////////////////////////////

            AdRequest request = new AdRequest.Builder().Build();

            this.interstitial.LoadAd(request);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        else
        {
            Destroy(gameObject);
        }



    }
    private void interstitialclosed(object sender, EventArgs e)
    {
        request();
    }
    public void reklamigoster()
    {

        this.interstitial.Show();

        reklamkontrol = null;

    }
}
