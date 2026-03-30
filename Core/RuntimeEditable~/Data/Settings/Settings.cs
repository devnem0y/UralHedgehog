using UnityEngine;
using UnityEngine.Audio;
using UralHedgehog.Localization;

namespace UralHedgehog.Core
{
    public class Settings : ISettings, ISubscriptionHandler
    {
        private const string MASTER = "Master";
        private const string MUSIC = "Music";
        private const string SOUND = "Sound";
        private const string VOICE = "Voice";
        
        private readonly IProfile _profile;
        private readonly AudioMixer _audioMixer;
        
        private SettingsData _data;
        
        public float VolumeMaster { get; private set; }
        public float VolumeMusic { get; private set; }
        public float VolumeSound { get; private set; }
        public float VolumeVoice { get; private set; }
        public Language Language { get; private set; }

        public Settings(AudioMixer audioMixer)
        {
            _profile = ServiceLocator.Get<IProfile>();
            _profile.onProfileLoaded += OnProfileLoaded;
            
            _audioMixer = audioMixer;
        }
        
        public void Unsubscribe()
        {
            _profile.onProfileLoaded -= OnProfileLoaded;
        }
        
        public void Save()
        {
            _data = new SettingsData(VolumeMaster, VolumeMusic, VolumeSound, VolumeVoice, Language);
            _profile.SaveSettings(_data);
        }
        
        private void OnProfileLoaded()
        {
            _data = _profile.SettingsData;
            
            VolumeMaster = _data.VolumeMaster;
            VolumeMusic = _data.VolumeMusic;
            VolumeSound = _data.VolumeSound;
            VolumeVoice = _data.VolumeVoice;
            Language = _data.Language;
            
            ChangeVolumeMaster(VolumeMaster);
            ChangeVolumeMusic(VolumeMusic);
            ChangeVolumeSound(VolumeSound);
            ChangeVolumeVoice(VolumeVoice);
            OnChangeLanguage(Language);
        }

        private void SetFloat(string nameGroup, float value)
        {
            _audioMixer.SetFloat(nameGroup, Mathf.Lerp(-80, 0, value));
        }
    
        public void ChangeVolumeMaster(float value)
        {
            VolumeMaster = value;
            SetFloat(MASTER, VolumeMaster);
        }

        public void ChangeVolumeMusic(float value)
        {
            VolumeMusic = value;
            SetFloat(MUSIC, VolumeMusic);
        }

        public void ChangeVolumeSound(float value)
        {
            VolumeSound = value;
            SetFloat(SOUND, VolumeSound);
        }

        public void ChangeVolumeVoice(float value)
        {
            VolumeVoice = value;
            SetFloat(VOICE, VolumeVoice);
        }

        public void OnChangeLanguage(Language language)
        {
            Language = language;
            LocalizationUtils.ChangeLanguage(Language);
        }
    }
}