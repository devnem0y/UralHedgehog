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
            LocalizationUtils.Localize -= Localize;
        }

        private void Start()
        {
            LocalizationUtils.Localize += Localize;
            Localize();
        }

        private void Localize()
        {
            _label.font = LocalizationUtils.Font;
            _label.text = LocalizationUtils.GetTranslate(_key);
        }
    }
}