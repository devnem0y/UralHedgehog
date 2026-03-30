using UnityEngine;

namespace UralHedgehog.Core
{
    public class StateMachine
    {
        private IState _currentState;

        public void ChangeState<T>() where T : IState, new()
        {
            _currentState?.Exit();
            _currentState = new T();
            _currentState.Enter();
            Debug.Log($"<color=yellow>State changed to {typeof(T).Name}</color>");
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}