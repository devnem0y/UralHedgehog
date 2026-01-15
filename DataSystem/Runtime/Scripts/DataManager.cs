using UnityEngine;

namespace UralHedgehog.Data
{
    public static class DataManager
    {
        public static void Write<T>(ISaverHandler saverHandler)
        {
            saverHandler.Save();
            
            var data = (T) saverHandler.Data;
            var json = JsonUtility.ToJson(data);
            
            PlayerPrefs.SetString(nameof(T), json);
            PlayerPrefs.Save();
        }

        public static T Get<T>() where T : class
        {
            const string key = nameof(T);

            if (!PlayerPrefs.HasKey(key)) return default;
            
            var path = PlayerPrefs.GetString(key);
            var data = JsonUtility.FromJson<T>(path);
            return data;
        }
    }
}