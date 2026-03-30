using UnityEngine;

namespace UralHedgehog.Localization
{
    public class LocalizationExample : MonoBehaviour
    {
        [SerializeField] private LocalizationConfig _config;
        [SerializeField] private Language _language;
        
        private void Awake()
        {
            // Обязательно нужно инициализировать до вызова Start()
            LocalizationUtils.SetManager(_config, _language);
        }
    }
}