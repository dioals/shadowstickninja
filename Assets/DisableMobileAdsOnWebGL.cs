using UnityEngine;

/// <summary>
/// WebGL builds on Playgama should not run native/mobile ad SDKs.
/// This strips any ad-related behaviours before scenes load to prevent
/// Google Mobile Ads / ImmersiveAdsManager from initializing.
/// </summary>
public static class DisableMobileAdsOnWebGL
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RemoveMobileAdsBehaviours()
    {
        var behaviours = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
        foreach (var behaviour in behaviours)
        {
            var typeName = behaviour.GetType().FullName;
            if (string.IsNullOrEmpty(typeName))
            {
                continue;
            }

            if (typeName.Contains("ImmersiveAds") || typeName.Contains("GoogleMobileAds") || typeName.Contains("AdMob"))
            {
                behaviour.enabled = false;
                Object.Destroy(behaviour.gameObject);
            }
        }
    }
#endif
}
