using System;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

namespace UralHedgehog.Localization
{
    public enum Language
    {
        ENGLISH = 0,
        RUSSIAN = 1,
        GERMAN = 2,
        FRENCH = 3,
        SPANISH = 4,
        ITALIAN = 5,
        CHINESE_SIMPLIFIED = 6,
    }

    public class LocalizationManager
    {
        private static Dictionary<string, List<string>> _localization;
        private static LocalizationConfig Config { get; set; }
        private static Language Language { get; set; }
        
        public static Font Font => GetFont();
        public static TMP_FontAsset FontTMP => GetFontTMP();

        public static event Action Localize;

        public LocalizationManager(LocalizationConfig config, Language language = Language.ENGLISH)
        {
            Config = config;
            Language = language;
            
            LoadLocalization();
        }

        private static void LoadLocalization()
        {
            _localization = new Dictionary<string, List<string>>();

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(Config.LocalizationFile.text);

            foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
            {
                var keyStr = key.Attributes["Name"].Value;
                var values = new List<string>();
                
                foreach (XmlNode translate in key["Translates"].ChildNodes)
                {
                    values.Add(translate.InnerText);
                }

                _localization[keyStr] = values;
            }

            Debug.Log("Localization loading: <color=green>DONE</color>");
        }

        private static Font GetFont()
        {
            switch (Language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    return Config.Chinese;
                case Language.RUSSIAN:
                    return Config.Basic;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    return Config.Extra;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static TMP_FontAsset GetFontTMP()
        {
            switch (Language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    return Config.ChineseTMP;
                case Language.RUSSIAN:
                    return Config.BasicTMP;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    return Config.ExtraTMP;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetTranslate(string key)
        {
            return _localization.TryGetValue(key, out var value) ? 
                value[Language.GetHashCode()] : key;
        }

        public static void OnLocalize(Language language)
        {
            Language = language;
            Localize?.Invoke();
        }
    }
}