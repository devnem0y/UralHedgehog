using System;
using TMPro;
using UnityEngine;

namespace UralHedgehog.Localization
{
    public interface ILocalizationManager
    {
        public Font Font { get; }
        public TMP_FontAsset FontTMP { get; }
        public event Action Localize;
        
        public string GetTranslate(string key);
        public void OnLocalize(Language language);
    }
}