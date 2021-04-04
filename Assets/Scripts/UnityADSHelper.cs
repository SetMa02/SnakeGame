using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Advertisements;
using Helpers;
using System;

public class UnityADSHelper : MonoBehaviour
{
    public string gameId;
    [Header("Games ID")] [SerializeField] private string googlePlayAppId;

    [Header("Banner Position")] [SerializeField] private BannerPosition bannerPosition;

    private void Awake()
    {
        gameId = this.googlePlayAppId;
        Advertisement.Initialize(gameId);
    }

    public void ShowRewardetVideoAds(Action<ShowResult> callback)
    {
        if (UnityADSRewardetVideoHelper.isReady())
        {
            UnityADSRewardetVideoHelper.Show(callback);
        }
    }

    public void ShowBannerAD()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    public bool RewardetVideoIsReady() => Advertisement.IsReady();
    public bool BannerIsReady() => Advertisement.IsReady();

    private IEnumerator ShowBannerWhenReady()
    {
        while(!UnityADSBannerHelper.isReady())
        {
            yield return new WaitForSeconds(0.25f);
        }
        UnityADSBannerHelper.Show(this.bannerPosition);
    }

    public void DemoRewardetVideoAd()
    {
        ShowRewardetVideoAds(result =>
            {
                switch(result)
                {
                    case ShowResult.Failed:
                        Debug.Log("ShowResult => Failed");
                        break;
                    case ShowResult.Finished:
                        Debug.Log("ShowResult => Finished");
                        break;
                    case ShowResult.Skipped:
                        Debug.Log("ShowResult => Skipped");
                        break;
                }
            });
    }

}
