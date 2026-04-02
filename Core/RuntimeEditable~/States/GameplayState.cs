namespace UralHedgehog.Core
{
    public class GameplayState : IState
    {
        private readonly StateMachine _nestedMachine = new();

        public void Enter()
        {
            var baseState = _nestedMachine.GetState<PlayerHubState>();
            baseState.SetMachine(_nestedMachine);
            _nestedMachine.ChangeState<PlayerHubState>();
        }

        public void Exit() { }

        public void Update() => _nestedMachine.Update();
        public void FixedUpdate() => _nestedMachine.FixedUpdate();
        public void LateUpdate() => _nestedMachine.LateUpdate();
    }
}