using System;
using System.Collections.Generic;
using UnityEngine;

namespace UralHedgehog.Core
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _stateCache = new();
        
        public IState CurrentState { get; private set; }

        public T GetState<T>() where T : IState, new()
        {
            var type = typeof(T);

            if (_stateCache.TryGetValue(type, out var state)) return (T)state;
            state = new T();
            _stateCache[type] = state;

            return (T)state;
        }

        public void ChangeState<T>() where T : IState, new()
        {
            CurrentState?.Exit();
            CurrentState = GetState<T>();
            CurrentState.Enter();
            
            Debug.Log($"<color=yellow>State changed to {typeof(T).Name}</color>");
        }

        public void Update() => CurrentState?.Update();
        public void FixedUpdate() => CurrentState?.FixedUpdate();
        public void LateUpdate() => CurrentState?.LateUpdate();
    }
}