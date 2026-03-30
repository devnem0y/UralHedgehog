using System;
using UnityEngine;

namespace UralHedgehog.Data
{
    public static class DataManager
    {
        public static void Write<T>(T data) where T : class
        {
            if (data == null)
                throw new ArgumentNullException(typeof(T).Name, "Cannot save null data");

            try
            {
                var json = JsonUtility.ToJson(data);
                var key = typeof(T).Name;
                PlayerPrefs.SetString(key, json);
                PlayerPrefs.Save();
                Debug.Log($"Saved data: {typeof(T).Name} with key '{key}'");
            }
            catch (Exception ex)
            {
                Debug.Log($"<color=red>Failed to save {typeof(T).Name}: {ex.Message}</color>");
                throw;
            }
        }

        public static T Get<T>() where T : class
        {
            var key = typeof(T).Name;

            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogWarning($"No data found for type {typeof(T).Name} with key '{key}'");
                return default;
            }

            try
            {
                var json = PlayerPrefs.GetString(key);
                var data = JsonUtility.FromJson<T>(json);

                if (data == null)
                {
                    Debug.Log($"<color=red>Failed to deserialize data for type {typeof(T).Name}. JSON: {json}</color>");
                    return default;
                }

                Debug.Log($"Loaded data: {typeof(T).Name}");
                return data;
            }
            catch (Exception ex)
            {
                Debug.Log($"<color=red>Exception while loading {typeof(T).Name}: {ex.Message}</color>");
                return default;
            }
        }
    }
}