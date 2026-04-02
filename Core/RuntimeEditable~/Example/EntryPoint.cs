using UnityEngine;
using UnityEngine.Audio;
using UralHedgehog.Audio;
using UralHedgehog.Localization;
using UralHedgehog.UI;

namespace UralHedgehog.Core
{
    /// <summary>
    /// Точки входа в игру.
    /// </summary>
    public class EntryPoint : MonoBehaviour
    {
        [Header("Аудио")][Space(5)]
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        [Space(10)]
        [Header("Локализация")][Space(5)]
        [SerializeField] private LocalizationConfig _config;
        [SerializeField] private Language _language;
        [Space(10)]
        [Header("Интерфейс UI")][Space(5)]
        [SerializeField] private UIRoot _uiRoot;
        [Space(10)]
        [Header("Данные для старта и сохранения")][Space(5)]
        [SerializeField] private PlayerDataConfig _playerDataConfig;
        [SerializeField] private SettingsDataConfig _settingsDataConfig;
        
        private Profile _profile;
        private Player _player;
        private Settings _settings;
        private StateMachine _stateMachine;

        private void Awake()
        {
            Initialized();
        }

        private void Initialized()
        {
            _stateMachine = new StateMachine();
            _profile = new Profile(_playerDataConfig, _settingsDataConfig);
            
            AudioUtils.SetManager(_audioMixer, _audioResources);
            LocalizationUtils.SetManager(_config, _language);
            
            ServiceLocator.Register(_uiRoot);
            ServiceLocator.Register(_stateMachine);
            ServiceLocator.Register<IProfile>(_profile);
            
            _player = new Player();
            _settings = new Settings(_audioMixer);
            
            ServiceLocator.Register<IPlayer>(_player);
            ServiceLocator.Register<ISettings>(_settings);
            
            _stateMachine.ChangeState<LaunchState>();
            
            Debug.Log("EntryPoint: <color=green>Initialized</color>");
        }

        private void Update()
        {
            _stateMachine.Update();
            
            Pause();

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log($"CurrentState: <color=yellow>{_stateMachine.CurrentState.GetType().Name}</color>");
            }
        }

        private void Pause()
        {
            //TODO: Обработка глобальной паузы
            if (!Input.GetKeyDown(KeyCode.P)) return;
            
            if (_stateMachine.CurrentState is GameplayState) PauseManager.SetGamePaused(!PauseManager.IsGamePaused);
        }

        private void OnDestroy()
        {
            //TODO: Сохранение здесь временно
            _player.Save();
            _settings.Save();
            
            _player.Unsubscribe();
            _settings.Unsubscribe();
        }
    }
}
