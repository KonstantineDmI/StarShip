using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour, IUnityAdsListener
{
    [SerializeField]
    private readonly string _gameId = "4036683";

    [SerializeField]
    private readonly string _myPlacementId = "Rewarded_Android";

    private bool _testMode = true;

    public GameObject gameoverPanel;
  
    void Start()
    {
      
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(_myPlacementId))
        {
            Advertisement.Show(_myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            AppStart start = new AppStart();
            //Time.timeScale = 1;
            //SpawnPlayer.currentShip.gameObject.GetComponent<Player>().Heal(100);
            //gameoverPanel.SetActive(false);
            DBUpdate.sessionCoinQuantity *= 2;
            start.DataAdding();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("finished");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == _myPlacementId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
