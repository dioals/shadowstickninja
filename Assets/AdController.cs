using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Playgama;

public class AdController : MonoBehaviour
{
    public static AdController instance;
    private string interstitial_id = "end_game_int01";
    private bool playgamaReady = false;

    [SerializeField] private int gamesBetweenInterstitials = 3;

    private const string GamesEndedKey = "AdController.GamesEnded";
    private int gamesEndedSinceLastAd;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gamesEndedSinceLastAd = SaveSystem.GetInt(GamesEndedKey, 0);
        }
    }
    void Start()
    {
       // Advertisements.Instance.Initialize();
       #if UNITY_WEBGL && !UNITY_EDITOR
        // Wait for the Playgama bridge to be ready
        // await Bridge.Initialize(); // or Bridge.IsInitialized event if that’s your API
        Bridge.advertisement.SetMinimumDelayBetweenInterstitial(30);
        if(Bridge.advertisement.isInterstitialSupported)
            playgamaReady = true;        
#endif
    }


    public void ShowAds()
    {
        ShowPlaygamaInterstitial();

    }

    public void OnGameEnded()
    {
        gamesEndedSinceLastAd++;
        if (gamesEndedSinceLastAd >= gamesBetweenInterstitials)
        {
            ShowPlaygamaInterstitial();
            gamesEndedSinceLastAd = 0;
        }

        SaveSystem.SetInt(GamesEndedKey, gamesEndedSinceLastAd);
    }

    private void ShowPlaygamaInterstitial()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // Use the Playgama Bridge helper defined in playgama-bridge-unity.js.
        if (!playgamaReady) return;

        Bridge.advertisement.ShowInterstitial(interstitial_id);
#else
        Debug.Log("Playgama interstitials are only available in WebGL builds.");
#endif
    }
}
