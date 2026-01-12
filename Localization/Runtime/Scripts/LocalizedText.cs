using UnityEngine;
using UnityEngine.UI;

namespace UralHedgehog.Localization
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private string _key;
        
        private Text _label;

        private void Awake()
        {
            _label = GetComponent<Text>();
        }

        private void OnDestroy()
        {
            LocalizationManager.Localize -= Localize;
        }

        private void Start()
        {
            LocalizationManager.Localize += Localize;
            Localize();
        }

        private void Localize()
        {
            _label.font = LocalizationManager.Font;
            _label.text = LocalizationManager.GetTranslate(_key);
        }
    }
}