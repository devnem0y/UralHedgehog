using System;
using System.Collections.Generic;
using System.Linq;
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

    public class LocalizationManager : ILocalizationManager
    {
        private Dictionary<string, List<string>> _localization;
        private readonly LocalizationConfig _config;
        private Language _language;
        
        public Font Font => GetFont();
        public TMP_FontAsset FontTMP => GetFontTMP();
        
        public event Action Localize;

        public LocalizationManager(LocalizationConfig config, Language language = Language.ENGLISH)
        {
            _config = config;
            _language = language;
            LoadLocalization();
        }

        private void LoadLocalization()
        {
            _localization = new Dictionary<string, List<string>>();

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_config.LocalizationFile.text);

            var xmlNodeList = xmlDocument["Keys"]?.ChildNodes;
            if (xmlNodeList == null) return;
            
            foreach (XmlNode key in xmlNodeList)
            {
                if (key.Attributes == null) continue;

                var keyStr = key.Attributes["Name"].Value;
                var values = (from XmlNode translate in
                        key["Translates"]?.ChildNodes
                    select translate.InnerText).ToList();

                _localization[keyStr] = values;
            }
                
            Debug.Log("Localization loading: <color=green>DONE</color>");
        }

        private Font GetFont()
        {
            switch (_language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    return _config.Chinese;
                case Language.RUSSIAN:
                    return _config.Basic;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    return _config.Extra;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private TMP_FontAsset GetFontTMP()
        {
            switch (_language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    return _config.ChineseTMP;
                case Language.RUSSIAN:
                    return _config.BasicTMP;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    return _config.ExtraTMP;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetTranslate(string key)
        {
            return _localization.TryGetValue(key, out var value) ?
                value[_language.GetHashCode()] : key;
        }

        public void OnLocalize(Language language)
        {
            _language = language;
            Localize?.Invoke();
        }
    }
}