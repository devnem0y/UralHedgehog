using System;
using UnityEngine;
using UralHedgehog.Data;

namespace UralHedgehog.Core
{
    public class Profile : IProfile
{
    public PlayerData PlayerData { get; private set; }
    public SettingsData SettingsData { get; private set; }

    private readonly PlayerDataConfig _playerDataConfig;
    private readonly SettingsDataConfig _settingsDataConfig;
    
    public event Action onProfileLoaded;

    public Profile(PlayerDataConfig playerDataConfig, SettingsDataConfig settingsDataConfig)
    {
        _playerDataConfig = playerDataConfig ? 
            playerDataConfig : throw new ArgumentNullException(nameof(playerDataConfig));
        _settingsDataConfig = settingsDataConfig ? 
            settingsDataConfig : throw new ArgumentNullException(nameof(settingsDataConfig));
    }
    
    public void Load()
    {
        try
        {
            var playerData = DataManager.Get<PlayerData>();
            PlayerData = playerData ?? _playerDataConfig.PlayerData;
            
            var settingsData = DataManager.Get<SettingsData>();
            SettingsData = settingsData ?? _settingsDataConfig.SettingsData;
            
            Debug.Log("Profile: <color=green>loaded successfully</color>");
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"Failed to load profile: {ex.Message}");
            // Инициализируем данными по умолчанию при ошибке
            PlayerData = _playerDataConfig.PlayerData;
            SettingsData = _settingsDataConfig.SettingsData;
        }
        
        onProfileLoaded?.Invoke();
    }

    public void SavePlayer(PlayerData playerData)
    {
        if (playerData == null)
        {
            Debug.LogWarning("PlayerData is null, cannot save");
            return;
        }
        
        try
        {
            DataManager.Write(playerData);
            Debug.Log("Player data saved successfully");
        }
        catch (Exception ex)
        {
            Debug.Log($"<color=red>Failed to save player data: {ex.Message}</color>");
        }
    }

    public void SaveSettings(SettingsData settingsData)
    {
        if (settingsData == null)
        {
            Debug.LogWarning("SettingsData is null, cannot save");
            return;
        }
        
        try
        {
            DataManager.Write(settingsData);
            Debug.Log("Settings data saved successfully");
        }
        catch (Exception ex)
        {
            Debug.Log($"<color=red>Failed to save settings data: {ex.Message}</color>");
        }
    }
}
}