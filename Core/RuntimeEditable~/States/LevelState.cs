using UnityEngine;

namespace UralHedgehog.Core
{
    public class LevelState : IState, IPausable
    {
        public void Enter()
        {
            SubscribeToPauseEvents();
            Debug.Log("LevelState: Level started");
        }

        public void Exit() => UnsubscribeFromPauseEvents();

        public void Update()
        {
            if (PauseManager.IsGamePaused) return;
            
            //TODO: Игровая логика (только когда не на паузе)
                
            if (Input.GetKeyDown(KeyCode.V)) ServiceLocator.Get<StateMachine>().ChangeState<VictoryState>();
        }

        public void OnPause()
        {
            Time.timeScale = 0f; // Останавливаем время в игре
            Debug.Log("LevelState: Paused - showing pause UI");
        }

        public void OnResume()
        {
            Time.timeScale = 1f; // Возобновляем время
            Debug.Log("LevelState: Resumed - hiding pause UI");
        }

        public void SubscribeToPauseEvents() => PauseManager.onPauseChanged += HandlePauseEvent;
        public void UnsubscribeFromPauseEvents() => PauseManager.onPauseChanged -= HandlePauseEvent;

        private void HandlePauseEvent(bool paused)
        {
            if (paused) OnPause();
            else OnResume();
        }

        public void FixedUpdate() { }
        public void LateUpdate() { }
    }
}