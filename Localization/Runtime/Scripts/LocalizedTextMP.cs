using TMPro;
using UnityEngine;

namespace UralHedgehog.Localization
{
    public class LocalizedTextMP : MonoBehaviour
    {
        [SerializeField] private string _key;
        
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        
        public string Param { get; set; }
        public string Prefix { get; set; }
        
        private TMP_Text _label;
        
        private bool _isInit;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }
        
        private void Start()
        {
            LocalizationManager.Localize += Localize;
            Localize();
        }
        
        private void OnDestroy()
        {
            LocalizationManager.Localize -= Localize;
        }

        private void Localize()
        {
            _label.font = LocalizationManager.FontTMP;
            
            var str = LocalizationManager.GetTranslate(_key);
            if (string.IsNullOrEmpty(Prefix))
            {
                _label.text = string.IsNullOrEmpty(Param) ? str : $"{str}\n{Param}";
            }
            else
            {
                _label.text = string.IsNullOrEmpty(Param) ? $"{Prefix}{str}" : $"{Prefix}{str}\n{Param}";
            }
        }
    }
}