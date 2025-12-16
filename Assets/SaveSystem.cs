using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#if UNITY_WEBGL
using Playgama;
#endif

/// <summary>
/// Wraps persistent data access. In WebGL builds we mirror PlayerPrefs into Playgama Bridge storage
/// using Bridge.storage.Get/Set, keeping PlayerPrefs as a local cache and fallback.
/// </summary>
public static class SaveSystem
{
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
        TrySetRemote(key, value.ToString());
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        int localValue = PlayerPrefs.GetInt(key, defaultValue);
        TryFetchRemote(key, incoming =>
        {
            if (int.TryParse(incoming, out var remoteValue) && remoteValue != localValue)
            {
                PlayerPrefs.SetInt(key, remoteValue);
                PlayerPrefs.Save();
                localValue = remoteValue;
            }
        });
        return localValue;
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
        TrySetRemote(key, value ?? string.Empty);
    }

    public static string GetString(string key, string defaultValue = "")
    {
        string localValue = PlayerPrefs.GetString(key, defaultValue);
        TryFetchRemote(key, incoming =>
        {
            if (!string.IsNullOrEmpty(incoming) && incoming != localValue)
            {
                PlayerPrefs.SetString(key, incoming);
                PlayerPrefs.Save();
                localValue = incoming;
            }
        });
        return localValue;
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        // Playgama storage requires explicit keys; we only clear the local cache here.
    }

    private static void TrySetRemote(string key, string value)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        try
        {
            Bridge.storage.Set(key, value);
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Playgama storage set failed for '{key}': {e.Message}");
        }
#endif
    }

    private static void TryFetchRemote(string key, Action<string> onFetched)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        try
        {
            Bridge.storage.Get(key, (success, data) =>
            {
                if (success && data != null)
                {
                    onFetched?.Invoke(data);
                }
            });
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Playgama storage get failed for '{key}': {e.Message}");
        }
#endif
    }
}
