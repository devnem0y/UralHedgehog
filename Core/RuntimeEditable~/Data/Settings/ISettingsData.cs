using UralHedgehog.Localization;

namespace UralHedgehog.Core
{
    public interface ISettingsData
    {
        public float VolumeMaster { get; }
        public float VolumeMusic { get; }
        public float VolumeSound { get; }
        public float VolumeVoice { get; }
        public Language Language { get;}
    }
}