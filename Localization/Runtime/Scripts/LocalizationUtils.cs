using System;
using TMPro;
using UnityEngine;

namespace UralHedgehog.Localization
{
    public static class LocalizationUtils
    {
        private const string Exception = "LocalizationManager не инициализирован. Вызовите SetManager() перед использованием.";
        
        private static ILocalizationManager _manager;
        
        public static Font Font => _manager?.Font;
        public static TMP_FontAsset FontTMP => _manager?.FontTMP;
        
        public static bool HasManager => _manager != null;
        
        public static ILocalizationManager Manager
        {
            get
            {
                if (_manager != null) return _manager;
                throw new InvalidOperationException(Exception);
            }
        }

        public static void SetManager(LocalizationConfig config, Language language)
        {
            _manager = new LocalizationManager(config, language);
        }
        
        public static void SetManager(ILocalizationManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }
        
        public static string GetTranslate(string key)
        {
            if (_manager != null) return _manager.GetTranslate(key);
            
            Debug.LogWarning(Exception);
            
            return key;
        }
        
        public static event Action Localize
        {
            add => _manager.Localize += value;
            remove => _manager.Localize -= value;
        }
        
        public static void ChangeLanguage(Language language)
        {
            _manager?.OnLocalize(language);
        }
    }
}