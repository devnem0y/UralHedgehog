using UralHedgehog.Localization;

namespace UralHedgehog.Core
{
    public interface ISettings : ISettingsData
    {
        public void ChangeVolumeMaster(float value);
        public void ChangeVolumeMusic(float value);
        public void ChangeVolumeSound(float value);
        public void ChangeVolumeVoice(float value);
        public void OnChangeLanguage(Language language);
        public void Save();
    }
}