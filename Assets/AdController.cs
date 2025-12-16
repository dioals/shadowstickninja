using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : MonoBehaviour
{
    public static AdController instance;

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
        }
    }
    void Start()
    {
       // Advertisements.Instance.Initialize();
       
    }


    public void ShowAds()
    {
       // Advertisements.Instance.ShowInterstitial();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
