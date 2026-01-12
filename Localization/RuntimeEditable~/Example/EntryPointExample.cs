using UnityEngine;

namespace UralHedgehog.Localization
{
    public class EntryPointExample : MonoBehaviour
    {
        [SerializeField] private LocalizationConfig _config;
        [SerializeField] private Language _language;
        
        private void Awake()
        {
            // Обязательно нужно инициализировать до вызова Start()
            new LocalizationManager(_config, _language);
        }
    }
}