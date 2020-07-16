using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3667992";
#elif UNITY_ANDROID
    private string gameId = "3667993";
#endif

    string placement = "rewardedVideo";
    bool testMode = true;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowRewardedAdd()
    {
        Advertisement.Show(placement);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ads Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Add did start");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                GameManager.Instance.Player.DiamondAmuont += 100;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown. " + showResult);
                break;
        }
    }
}
