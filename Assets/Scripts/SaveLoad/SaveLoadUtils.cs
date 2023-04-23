using UnityEngine;

public static class SaveLoadUtils
{
    public static void SaveObject<T>(string key, T value)
    {
        PlayerPrefs.SetString(key, JsonUtility.ToJson(value));
    }

    public static T LoadObject<T>(string key)
    {
        if (!PlayerPrefs.HasKey(key)) return default(T);
        return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
    }
}