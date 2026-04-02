using UnityEngine;

namespace UralHedgehog.Core
{
    public class PlayerHubState : IState, IPausable
    {
        private StateMachine _ownMachine;
        
        public void SetMachine(StateMachine machine) => _ownMachine = machine;

        public void Enter()
        {
            SubscribeToPauseEvents();
            Debug.Log("PlayerHubState: Entered - player setup");
        }

        public void Exit() => UnsubscribeFromPauseEvents();

        public void Update()
        {
            if (PauseManager.IsGamePaused) return;
            
            //TODO: Игровая логика (только когда не на паузе)
            
            if (Input.GetKeyDown(KeyCode.L)) RequestLevelStart();
        }

        public void OnPause() 
        {
            Time.timeScale = 0f; // Останавливаем время в игре
            Debug.Log("PlayerHubState: Paused - showing pause UI");
        }
        public void OnResume()
        {
            Time.timeScale = 1f; // Возобновляем время
            Debug.Log("PlayerHubState: Resumed - hiding pause UI");
        }

        public void SubscribeToPauseEvents() => PauseManager.onPauseChanged += HandlePauseEvent;
        public void UnsubscribeFromPauseEvents() => PauseManager.onPauseChanged -= HandlePauseEvent;

        private void HandlePauseEvent(bool paused)
        {
            if (paused) OnPause(); else OnResume();
        }
        
        public void RequestLevelStart()
        {
            _ownMachine?.ChangeState<LevelState>();
        }

        public void FixedUpdate() { }
        public void LateUpdate() { }
    }
}