using UnityEngine;

namespace UralHedgehog.Core
{
    [CreateAssetMenu(fileName = "SettingsDataConfig", menuName = "Ural Hedgehog/Data/SettingsDataConfig", order = 0)]
    public class SettingsDataConfig : ScriptableObject
    {
        [SerializeField] private SettingsData _settingsData;
        public SettingsData SettingsData => _settingsData;
    }
}