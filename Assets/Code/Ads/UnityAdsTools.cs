using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string _androidGameId = "4224747";
    private const string _iosGameId = "4224746";
    private const string _rewardPlacemtntId = "rewardedVideo";
    private const string _bannerPlacementId = "banner";

    #region IUnityAdsListener
    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (ShowResult.Finished == showResult)
            Debug.Log("Ads is finished. ");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }
    #endregion

    #region IAdsShower
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacementId);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardPlacemtntId);
    }

    #endregion
    #region MonoBehaviour
    public void Start()
    {
        Advertisement.Initialize(_androidGameId, true);
    }
    #endregion
}
