using TMPro;
using UnityEngine;

namespace UralHedgehog.Localization
{
    [CreateAssetMenu(fileName = "LocalizationConfig", menuName = "Ural Hedgehog/Localization", order = 1)]
    public class LocalizationConfig : ScriptableObject
    {
        [SerializeField] private TextAsset _localizationFile;
        public TextAsset LocalizationFile => _localizationFile;
        [Space(5)]
        [Header("Fonts")] 
        [SerializeField] private Font _basic;
        public Font Basic => _basic;
        [SerializeField] private Font _extra;
        public Font Extra => _extra;
        [SerializeField] private Font _chinese;
        public Font Chinese => _chinese;
        [Space(5)]
        [Header("FontsAsset")] 
        [SerializeField] private TMP_FontAsset _basicTMP;
        public TMP_FontAsset BasicTMP => _basicTMP;
        [SerializeField] private TMP_FontAsset _extraTMP;
        public TMP_FontAsset ExtraTMP => _extraTMP;
        [SerializeField] private TMP_FontAsset _chineseTMP;
        public TMP_FontAsset ChineseTMP => _chineseTMP;
    }
}
