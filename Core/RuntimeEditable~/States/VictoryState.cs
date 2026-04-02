namespace UralHedgehog.Core
{
    public class VictoryState : IState
    {
        public void Enter()
        {
            ServiceLocator.Get<StateMachine>().ChangeState<GameplayState>();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            
        }
    }
}