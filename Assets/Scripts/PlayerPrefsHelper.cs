using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PlayerPrefsHelper
{
    static List<string> keys = new List<string>();
    public static int GetInt(string key, int defaultValue = 0)
    {
        if (keys.Contains(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            Debug.LogError("Key not found in PlayerPrefsHelper: " + key);
            return defaultValue;
        }
    }

    public static float GetFloat(string key, float defaultValue = 0f)
    {
        if (keys.Contains(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        else
        {
            Debug.LogError("Key not found in PlayerPrefsHelper: " + key);
            return defaultValue;
        }
    }

    public static string GetString(string key, string defaultValue = "")
    {
        if (keys.Contains(key))
        {
            return PlayerPrefs.GetString(key);
        }
        else
        {
            Debug.LogError("Key not found in PlayerPrefsHelper: " + key);
            return defaultValue;
        }
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        if (keys.Contains(key))
        {
            return PlayerPrefs.GetInt(key) == 1;
        }
        else
        {
            Debug.LogError("Key not found in PlayerPrefsHelper: " + key);
            return defaultValue;
        }
    }
    public static void AddInt(string key, int addValue, int defaultvalue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, addValue + defaultvalue);
            keys.Add(key);
        }
        else
        {
            PlayerPrefs.SetInt(key, addValue + PlayerPrefs.GetInt(key));
        }
    }
    public static void AddString(string key, string addValue, string defaultvalue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetString(key, addValue + defaultvalue);
            keys.Add(key);
        }
        else
        {
            PlayerPrefs.SetString(key, addValue + PlayerPrefs.GetString(key));
        }
    }
    public static void AddFloat(string key, float addValue, float defaultvalue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetFloat(key, addValue + defaultvalue);
            keys.Add(key);
        }
        else
        {
            PlayerPrefs.SetFloat(key, addValue + PlayerPrefs.GetFloat(key));
        }
    }
    public static void SetBool(string key, bool value)
    {
        if (!value)
        {
            PlayerPrefs.SetInt(key, 0);
        }
        else
        {
            PlayerPrefs.SetInt(key, 1);
        }
    }
 
}
