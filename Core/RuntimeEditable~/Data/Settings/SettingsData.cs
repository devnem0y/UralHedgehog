using UnityEngine;
using UralHedgehog.Localization;

namespace UralHedgehog.Core
{
    [System.Serializable]
    public class SettingsData : ISettingsData
    {
        [Header("Громкость")]
        [Space(3)]
        
        [SerializeField, Range(0f, 1f)] private float _volumeMaster;
        public float VolumeMaster => _volumeMaster;
        
        [SerializeField, Range(0f, 1f)] private float _volumeMusic;
        public float VolumeMusic => _volumeMusic;
        
        [SerializeField, Range(0f, 1f)] private float _volumeSound;
        public float VolumeSound => _volumeSound;
        
        [SerializeField, Range(0f, 1f)] private float _volumeVoice;
        public float VolumeVoice => _volumeVoice;

        [Space(3)]
        [Header("Язык")]
        [Space(3)]
        
        [SerializeField] private Language _language;
        public Language Language => _language;

        public SettingsData(SettingsData data)
        {
            _volumeMaster = data.VolumeMaster;
            _volumeMusic = data.VolumeMusic;
            _volumeSound = data.VolumeSound;
            _volumeVoice = data.VolumeVoice;
            _language = data.Language;
        }
        
        public SettingsData(float master, float music, float sound, float voice, Language language)
        {
            _volumeMaster = master;
            _volumeMusic = music;
            _volumeSound = sound;
            _volumeVoice = voice;
            _language = language;
        }
    }
}