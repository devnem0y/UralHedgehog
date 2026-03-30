using System;

namespace UralHedgehog.Core
{
    public interface IProfile
    {
        public PlayerData PlayerData { get; }
        public SettingsData SettingsData { get; }
        
        public event Action onProfileLoaded;
        
        public void Load();
        public void SavePlayer(PlayerData playerData);
        public void SaveSettings(SettingsData settingsData);
    }
}